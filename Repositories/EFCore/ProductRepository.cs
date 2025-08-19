using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositories.EFCore
{
    public class ProductRepository : RepositoryBase<Products>, IProductRepository
    {
        public ProductRepository(RepositoryContext context) : base(context)
        {

        }

        public void CreateOneProduct(Products products) => Create(products);
        public void DeleteOneProduct(Products products) => Delete(products);
        public void UpdateOneProduct(Products products) => Update(products);

        public async Task<List<Products>> GetAllProductAsync(bool trackChanges)
        {
            var products = await FindAll(trackChanges).ToListAsync();
            return products;
        }

        public async Task<Products> GetOneProductByIdAsync(int id, bool trackChanges)
        {
            var produts = await FindByCondation(p => p.Id.Equals(id), trackChanges).SingleOrDefaultAsync();
            return produts;
        }

        
    }
}
