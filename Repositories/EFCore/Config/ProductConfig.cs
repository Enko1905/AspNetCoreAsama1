using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repositories.EFCore.Config
{
    public class ProductConfig : IEntityTypeConfiguration<Products>
    {
        public void Configure(EntityTypeBuilder<Products> builder)
        {
            builder.HasData(
                new Products {Id=1, Name="Laptop" , Description="Yeni Nesil Laptop" ,Price=5000},
                new Products {Id=2, Name="Çanta" , Description="Sırt Çantası" ,Price=3200},
                new Products {Id=3, Name="Masa" , Description="Oturma Masası" ,Price=5400},
                new Products {Id=4, Name="Silgi" , Description="Okul silgisi" ,Price=5230}
                );
        }
    }
}