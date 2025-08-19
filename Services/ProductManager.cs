using AutoMapper;
using Entities.DataTransferObject;
using Entities.Models;
using Microsoft.IdentityModel.Tokens;
using Repositories.Contracts;
using Services.Contratcs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ProductManager : IProductService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;

        public ProductManager(IRepositoryManager repositoryManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
        }

        public async Task<ProductDto> CreateOneProductAsync(ProductDtoForInsert productsDtoInsert)
        {
            var entity = _mapper.Map<Products>(productsDtoInsert);
            _repositoryManager.Product.CreateOneProduct(entity);
            await _repositoryManager.SaveAsync();
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task DeleteOneProductAsync(int id, bool TrackChanges)
        {
            var product = await _repositoryManager.Product.GetOneProductByIdAsync(id, TrackChanges);
            if (product is not null)
            {
                _repositoryManager.Product.DeleteOneProduct(product);
                await _repositoryManager.SaveAsync();
            }

        }

        public async Task<List<ProductDto>> GetAllProductAsync(bool TrackChanges)
        {
            var entity = await _repositoryManager.Product.GetAllProductAsync(TrackChanges);
            return _mapper.Map<List<ProductDto>>(entity);

        }

        public async Task<ProductDto> GetOneProductAsync(int id, bool TrackChanges)
        {
            var entity = await _repositoryManager.Product.GetOneProductByIdAsync(id, TrackChanges);
            return _mapper.Map<ProductDto>(entity);
        }

        public async Task UpdateOneProductAsync(int id, ProductDtoForUpdate productsDtoUpdate, bool TrackChanges)
        {
            var product = await _repositoryManager.Product.GetOneProductByIdAsync(id, TrackChanges);
            if (product is not null)
            {
                var entity = _mapper.Map<Products>(productsDtoUpdate);
               

                _repositoryManager.Product.UpdateOneProduct(entity);
                await _repositoryManager.SaveAsync();
            }

        }
    }
}
