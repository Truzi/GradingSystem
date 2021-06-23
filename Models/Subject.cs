﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GradingSystem.Models
{
    class Subject
    {
        public int ID { get; set; }
        public string Name { get; set; }

        //Relations
        public ICollection<Grade> Grades { get; set; }
    }
}