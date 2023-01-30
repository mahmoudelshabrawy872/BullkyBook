﻿using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallkyBook.Modles
{
    public class Product
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        [DisplayName("Product Title")]
        public string Title{ get; set; }
        [Required]
        [MaxLength(150)]
        [DisplayName("Product Description")]
        public string Description{ get; set; }
        [Required]
        public string ISBN { get; set; } 
        [Required]
        public string Auther { get; set; } 
        [Required]
        [Range(1,10000)]
        public double ListPrice { get; set; }
        [Required]
        [Range(1,10000)]
        public double Price { get; set; }
        [Required]
        [Range(1,10000)]
        public double Price50 { get; set; }
        [Required]
        [Range(1,10000)]
        public double Price100 { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }  
        [Required]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        [ValidateNever]
        public Category Category { get; set; }
        [Required]
        public int CoverTypeId { get; set; }
        [ForeignKey("CoverTypeId")]
        [ValidateNever]
        public CoverType CoverType{ get; set; }

    }
}
