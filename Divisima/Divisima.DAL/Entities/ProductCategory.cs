using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisima.DAL.Entities
{
    public class ProductCategory
    {
        public int ID { get; set; }

        public int? ProductID { get; set; }
        public Product Product { get; set; }

        public int? CategoryID { get; set; }
        public Category Category { get; set; }
    }
}