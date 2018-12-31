using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF6_Example.Models
{
    [Table("tbl_customers")]
    public class CustomerModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int customerid { get; set; }
        [Required(ErrorMessage ="*")]
        [StringLength(100)]
        public string customername { get; set; }

        [Required(ErrorMessage ="*")]
        [StringLength(100)]
        public string customerpassword { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        public string customercity { get; set; }

        [Required(ErrorMessage = "*")]
        [StringLength(100)]
        [Column("CustomerEmailAddress")]
        public string customeremailid { get; set; }

        [NotMapped]
        public string customerdetails { get; set; }
        public List<OrderModel> Orders { get; set; }
      
    }
}