using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Divisima.DAL.Entities
{
	[Table("Coupon")]
	public class Coupon
	{
		[Key]
		public int ID { get; set; }

		[Required, StringLength(50)]
		public string Code { get; set; }

		[StringLength(250)]
		public string Description { get; set; }

		[Column(TypeName = "decimal(18,2)")]
		public decimal AmountOrPercentage { get; set; }

		public bool IsPercentage { get; set; }

		public DateTime StartDate { get; set; }

		public DateTime? EndDate { get; set; }

		public int UsageLimit { get; set; }

		public int UsedCount { get; set; }

		public bool IsActive { get; set; }
	}

}
