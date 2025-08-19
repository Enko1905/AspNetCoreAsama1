using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DataTransferObject
{
    public abstract record ProductDtoManipulation
    {
        [MaxLength(100, ErrorMessage = "Product Name max 100 characters")]
        public string Name { get; set; }
        [MaxLength(500, ErrorMessage = "Description Name max 100 characters")]
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
