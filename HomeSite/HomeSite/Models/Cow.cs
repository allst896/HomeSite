﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace HomeSite.Models
{
    public class Cow
    {
        public int Id { get; set; }

        [Display(Name="Tag Number")]
        public int tagNumber { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public DateTime DOB { get; set; }
        public string Sex { get; set; }
        public string Owner { get; set; }
        public string Status { get; set; }
        public string Notes { get; set; }
        public int Dam { get; set; }
        public string Sire { get; set; }
    }
}