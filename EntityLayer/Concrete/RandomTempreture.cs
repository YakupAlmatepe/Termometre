﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class RandomTempreture
    {
        [Key]
        public int ID { get; set; }
        public int Tempreture { get; set; }
    }
}
