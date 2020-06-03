﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CurrencyApp.Models
{
    public class TimeInterval
    {
        [Required]
        [DataType(DataType.Date)]
        public DateTime from { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime to { get; set; }

    }
}
