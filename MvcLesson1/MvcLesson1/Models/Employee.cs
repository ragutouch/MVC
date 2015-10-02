using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MvcLesson1.Models
{
    [Table("tblEmployee")]
    public class Employee
    {
        public int employeeId { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public int departmentID { get; set; }
    }
}