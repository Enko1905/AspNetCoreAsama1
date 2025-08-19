using Entities.DataTransferObject;
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
        Task<ProductDto> GetOneProductAsync(int id, bool TrackChanges);
        Task<List<ProductDto>> GetAllProductAsync (bool TrackChanges);
        Task<ProductDto> CreateOneProductAsync(ProductDtoForInsert productsDtoInsert);

        Task UpdateOneProductAsync(int id, ProductDtoForUpdate productsDtoUpdate, bool TrackChanges);
        Task DeleteOneProductAsync(int id ,bool TrackChanges);



    }
}
