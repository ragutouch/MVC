//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MvcLesson2.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public int employeeId { get; set; }
        public string name { get; set; }
        public System.DateTime dateOfBirth { get; set; }
        public string city { get; set; }
        public int departmentID { get; set; }
    
        public virtual Department Department { get; set; }
    }
}
