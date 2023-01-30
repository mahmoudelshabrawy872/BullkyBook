﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallkyBook.Modles
{
    public class CoverType
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cover Type")]
        [MaxLength(55)]
        public string Name { get; set; } = string.Empty;
    }
}
