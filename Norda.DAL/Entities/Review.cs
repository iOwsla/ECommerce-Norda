using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Norda.DAL.Entities
{
    [Table("Review")]
    public class Review
    {
        [Key]
        public int ID { get; set; }

        [StringLength(400), Column(TypeName = "varchar(400)"), Display(Name = "Yorum Yap")]
        public string Comment { get; set; }
        [Required(ErrorMessage = "Puan alanı boş bırakılamaz.")]

        public int ProductID { get; set; }
        public Product Product { get; set; }

        public int Rating { get; set; }

        public int UserID { get; set; }
        public User User { get; set; }

    }
}
