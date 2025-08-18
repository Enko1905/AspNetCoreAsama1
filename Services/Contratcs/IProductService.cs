using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Contratcs
{
    public interface IProductService
    {
        Task<Products> GetOneProductAsync(int id, bool TrackChanges);
        Task<IEnumerable<Products>> GetAllProductAsync (bool TrackChanges);
        Task<Products> CreateOneProductAsync(Products products);

        Task UpdateOneProductAsync(int id, Products products, bool TrackChanges);
        Task DeleteOneProductAsync(int id ,bool TrackChanges);



    }
}
