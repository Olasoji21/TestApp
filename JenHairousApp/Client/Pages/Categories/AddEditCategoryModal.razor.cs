using JenHairousApp.Shared.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System.ComponentModel.DataAnnotations;

namespace JenHairousApp.Client.Pages.Categories
{
    public partial class AddEditCategoryModal
    {
        private bool                                    transfer;
        private bool                                    success;
        private string[]                                errors          = { };
        private MudForm                                 form;

        [CascadingParameter]
        private MudDialogInstance   MudDialog           { get; set; }

        [Parameter]
        public int                  Id                  { get; set; }

        [Parameter]
        [Required]
        public string               Name                { get; set; }

        public void Cancel()
        {
            MudDialog.Cancel();
        }

        public async Task SaveAsync()
        {
            form.Validate();

            if( form.IsValid)
            {
                var result = await _categoryService.GetByUniqueName( Name );
                
                if( result.Succeeded && result.Data  )
                {
                    _snackBar.Add($"Category with name {Name} is already added", Severity.Error);
                    return;
                }

                var response = await _categoryService.SaveCategoryAsync(new CategoryModel(Id = Id, Name = Name));
                if ( response.Succeeded )
                {
                    if (response.Succeeded)
                    {
                        _snackBar.Add(response.Messages[0], Severity.Success);
                        MudDialog.Close();
                    }
                    else
                        foreach (var message in response.Messages)
                            _snackBar.Add(message, Severity.Error);
                }
            }
        }
    }
}
