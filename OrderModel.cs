using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_EF6_Example.Models
{
    [Table("tbl_orders")]
    public class OrderModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int orderid { get; set; }

        [Required(ErrorMessage ="*")]
        public int customerid { get; set; }

        [Required(ErrorMessage ="*")]
        public string itemname { get; set; }

        [Required(ErrorMessage ="*")]
        public int itemprice { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime orderdate { get; set; }

        [ForeignKey("customerid")]
        public CustomerModel customer { get; set; }

        [Required(ErrorMessage ="*")]
        public string ordercity { get; set; }
    }
}