﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeSite.Models
{
    public class Bull
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string PurchasedFrom { get; set; }
        public string Status { get; set; }
    }
}