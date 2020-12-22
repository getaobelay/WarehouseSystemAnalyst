using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.Blazor.Client.ClientService;
using WarehouseSystemAnalyst.Mediator.Dtos.ProductDtos;

namespace WarehouseSystemAnalyst.Blazor.Client.Pages
{
    [Authorize]
    public partial class ProductPage : ComponentBase
    {
        private string selectId { get; set; } = null;
        private bool IsAdded { get; set; } = false;
        private List<ProductDto> products { get; set; }
        private ProductPackageDto productPackage { get; set; }
        private ProductMesureDto productMesure { get; set; }
        private List<ProductItemDto> productItems { get; set; }
        private ProductDto editPorduct { get; set; }
        [Inject] ClientRepository<ProductDto> _clientRepository { get; set; }

        private string SelectdProductId { get; set; }

        protected override async Task OnInitializedAsync()
        {
            _clientRepository.ControllerName = "api/products";
            products = new List<ProductDto>();
            productPackage = new ProductPackageDto();
            productMesure = new ProductMesureDto();
            productItems = new List<ProductItemDto>();
            editPorduct = new ProductDto();
            await LoadProducts();
        }

        private async Task LoadProducts()
        {


            var result = await _clientRepository.GetAllAsync();

            if (result.Success)
            {
                products = result.Object;

            }

        }


        public void Clear()
        {
            productPackage = new ProductPackageDto();
            productMesure = new ProductMesureDto();
            editPorduct = new ProductDto();
        }

        public async Task PostAsync()
        {
            if(editPorduct != null)
            {

                var response = await _clientRepository.PostAsync(editPorduct);

                if (response.Success)
                {
                    Clear();
                    IsAdded = true;
                    await LoadProducts();
                }

            }

        }

        public async Task DeleteAsync(string id)
        {

            var response = await _clientRepository.DeleteAsync(id);

            if (response.Success)
            {
                await LoadProducts();
            }

        }

        public async Task PutAsync(string id, ProductDto updatedProduct)
        {
            var response = await _clientRepository.PutAsync(id, updatedProduct);

            if (response.Success)
            {
                IsAdded = true;
                Clear();
                await LoadProducts();
            }


        }
    }
}
