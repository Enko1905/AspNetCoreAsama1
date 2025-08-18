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

        public ProductManager(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        public async Task<Products> CreateOneProductAsync(Products products)
        {
            _repositoryManager.Product.Create(products);
            await _repositoryManager.SaveAsync();
            return products;
        }

        public async Task DeleteOneProductAsync(int id, bool TrackChanges)
        {
            var product = await GetOneProductAsync(id, TrackChanges);
            if (product is not null)
            {
                _repositoryManager.Product.Delete(product);
            }

        }

        public async Task<IEnumerable<Products>> GetAllProductAsync(bool TrackChanges)
        {
            return await _repositoryManager.Product.GetAllProductAsync(TrackChanges);

        }

        public async Task<Products> GetOneProductAsync(int id, bool TrackChanges)
        {
            return await _repositoryManager.Product.GetOneProductByIdAsync(id, TrackChanges);
        }

        public async Task UpdateOneProductAsync(int id, Products products, bool TrackChanges)
        {
            var product = await _repositoryManager.Product.GetOneProductByIdAsync(id, TrackChanges);
            if (product is not null)
            {
                product.Price = products.Price;
                product.Description = products.Description;
                product.Name = products.Name;

                _repositoryManager.Product.Update(product);
                await _repositoryManager.SaveAsync();
            }

        }
    }
}
