﻿using Store.Domain.Entites.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Store.Domain.Entites.HomePages
{
    public  class Slider:BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
