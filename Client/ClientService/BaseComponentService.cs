using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WarehouseSystemAnalyst.BlazorUI.Client.ClientService;
using WarehouseSystemAnalyst.Mediator.Dtos;

namespace WarehouseSystemAnalyst.BlazorUI.Client.ClientService
{

    public abstract class BaseComponentService<TDto>
        where TDto : class, IBaseDto, new()
    {
        [Inject]
        private ClientRepository<TDto> _clientRepository { get; set; }
        private string selectId { get; set; } = null;
        private bool IsAdded { get; set; } = false;
        private List<TDto> Dtos { get; set; }
        private TDto editDto { get; set; }

        private async Task GetAllAsync()
        {
            var result = await _clientRepository.GetAllAsync();

            if (result.Success)
            {
                Dtos = result.Object;

            }
        }

        public async Task PostAsync(TDto editObject)
        {
            var response = await _clientRepository.PostAsync(editObject);

            if (response.Success)
            {
                IsAdded = true;
                await GetAllAsync();
            }
        }

        public async Task DeleteAsync(string id)
        {
            var response = await _clientRepository.DeleteAsync(id);

            if (response.Success)
            {
                await GetAllAsync();
            }
        }

        public async Task PutAsync(string id, TDto updatedObject)
        {
            var response = await _clientRepository.PutAsync(id, updatedObject);

            if (response.Success)
            {
                IsAdded = true;
                await GetAllAsync();
            }
        }
    }
}
