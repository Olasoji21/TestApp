using JenHairous.Shared.Entities;
using JenHairousApp.Shared.Entities;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;

namespace JenHairousApp.Client.Pages.Products
{
    public partial class Products
    {
        public List<string>                 imageUrls               = new List<string>();
        public List<CategoryModel>          categoryList            { get; set; }
        public List<ProductModel>           productList             { get; set; }

        public ProductModel                 productModel            { get; set; }   = new();
        public ProductModel                 productToDelete         { get; set; }
        
        IReadOnlyList<IBrowserFile>         selectedFiles;

        private int                         categoryId              { get; set; }
        private bool                        showDeletePopup         = false;
        private bool                        successPopup            = false;
        private string                      Message                 = string.Empty;

        protected override async Task OnInitializedAsync()
        {
            await GetCategories();
            await GetProducts();
        }

        private async Task GetCategories()
        {
            categoryList = (await _categoryService.GetAllCategoriesAsync()).Data;
        }

        private async Task GetProducts()
        {
            productList = (await _productService.GetProducts()).Data;
            foreach (var product in productList)
            {
                product.CategoryName = categoryList.FirstOrDefault(x => x.Id == product.Id).Name;
            }
        }

        private async Task SaveProduct()
        {
            await _productService.SaveProduct(productModel);
            await GetProducts();
            ClearForm();
        }

        private async Task DeleteProduct()
        {
            ToggleDeletePopup();
            var flag        = (await _productService.DeleteProduct(productToDelete.Id)).Data;
            Message         = flag ? "Product Deleted Successfully!!" : "Product Not Deleted Try Again";
            ToggleSuccessPopup();
            productToDelete = new ProductModel();
            await GetProducts();
        }

        private void EditButtonClick(ProductModel _productToEdit)
        {
            productModel    = _productToEdit;
            InvokeAsync(StateHasChanged);
        }

        private void DeleteButtonClick(ProductModel _productToDelete)
        {
            productToDelete = _productToDelete;
            ToggleDeletePopup();
        }

        private void ToggleDeletePopup()
        {
            showDeletePopup = showDeletePopup == true ? false : true;
        }

        private void ToggleSuccessPopup()
        {
            successPopup    = successPopup == true ? false : true;
        }

        private void ClearForm()
        {
            productModel    = new ProductModel();
            imageUrls       = new List<string>();
        }

        private void CategoryClicked(ChangeEventArgs categoryEvent)
        {
            if (!string.IsNullOrEmpty(Convert.ToString(categoryEvent.Value)))
            {
                categoryId              = Convert.ToInt32(categoryEvent.Value);
                productModel.CategoryId = categoryId;
                InvokeAsync(StateHasChanged);
            }

        }

        private async Task OnInputFileChange(InputFileChangeEventArgs e)
        {
            selectedFiles               = e.GetMultipleFiles();
            productModel.FileName       = string.Empty;

            foreach (var imageFile in selectedFiles)
            {
                var resizedImage        = await imageFile.RequestImageFileAsync("image/jpg", 100, 100);
                var buffer              = new byte[resizedImage.Size];
                await resizedImage.OpenReadStream().ReadAsync(buffer);
                var imgData             = $"data: image/jpg;base64, {Convert.ToBase64String(buffer)}";
                imageUrls.Add( imgData );
                productModel.FileName   = imgData;
            }

            successPopup    = true;
            Message         = $"{selectedFiles.Count} file(s) selected";
            await InvokeAsync(StateHasChanged);
        }
    }
}
