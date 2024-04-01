using AtmosUserManager.Client.Shared.Dialog;
using JenHairousApp.Shared.Entities;
using Microsoft.AspNetCore.Components;
using MudBlazor;

namespace JenHairousApp.Client.Pages.Categories
{
    public partial class Categories
    {
        public CategoryModel            categoryModel           { get; set; }
        public List<CategoryModel>      categoryList            { get; set; }


        private string                  searchString            = "";

        protected override async Task OnInitializedAsync()
        {
            categoryModel       = new CategoryModel();
            await GetCategories();
        }

        public async Task GetCategories()
        {
            categoryList        = (await _categoryService.GetAllCategoriesAsync()).Data;
        }

        private bool Search(CategoryModel category)
        {
            return string.IsNullOrWhiteSpace(searchString) || category.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase);
        }

        private async Task InvokeModal(int Id = 0)
        {
            var parameters      = new DialogParameters();

            if (Id != 0)
            {
                categoryModel = categoryList.FirstOrDefault(x => x.Id == Id);
                parameters.Add  ( "Id",             categoryModel.Id    );
                parameters.Add  ( "Name",           categoryModel.Name  );
            }

            var options         = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog          = _dialogService.Show<AddEditCategoryModal>("Modal", parameters, options);
            var result          = await dialog.Result;

            if( !result.Cancelled)
            {
                await Reset();
            }
        }

        private async Task Delete(int id)
        {
            string deleteContent        = $"Delete category {categoryList.FirstOrDefault(x => x.Id == id).Name}";
            var parameters              = new DialogParameters();
            parameters.Add              ( "ContentText", string.Format(deleteContent, id));
            var options                 = new DialogOptions() { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog                  = _dialogService.Show<DeleteConfirmation>("Delete", parameters, options);
            var result                  = await dialog.Result;

            if (!result.Cancelled)
            {
                var response = await _categoryService.DeleteCategoryAsync( id );
                await Reset();

                if (response.Succeeded)
                {
                    _snackBar.Add(response.Messages[0], Severity.Success);
                }
                else
                    foreach (var message in response.Messages)
                        _snackBar.Add(message , Severity.Error);
            }
        }

        private async Task Reset()
        {
            categoryModel = new();
            await GetCategories();
            await InvokeAsync(StateHasChanged);
        }
    }
}
