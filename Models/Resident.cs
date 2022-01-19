using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace VillageWebApplication___Exam.NET.Models
{
    public class Resident
    {
 
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string FatherName { get; set; }
        public string Gender { get; set; }
        public bool IsBornInVillage { get; set; }
        public DateTime DateBirth { get; set; }

    }
}