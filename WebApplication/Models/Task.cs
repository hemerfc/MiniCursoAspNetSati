using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication.Models
{
    public class Task
    {
        public int Id { get; set; }
        public bool Done { get; set; }
        public String Name { get; set; }
    }
}