using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace KH_210940320060.Models
{
    public class ProductModel
    {
        [Required]
        [DataType(DataType.Text)]
        public int ProductId { get; set; }

        [Required(ErrorMessage = "please enter valid ProductName")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "please enter valid Rate")]
        [DataType(DataType.Text)]
        public decimal Rate { get; set; }

        [Required(ErrorMessage = "please enter valid Description")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Required(ErrorMessage = "please enter valid CategoryName")]
        [DataType(DataType.Text)]
        public string CategoryName { get; set; }
    }
}