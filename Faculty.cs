//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OurWebsite
{
    using System;
    using System.Collections.Generic;
    
    public partial class Faculty
    {
        public Faculty()
        {
            this.Department = new HashSet<Department>();
            this.User = new HashSet<User>();
        }
    
        public int FacultyID { get; set; }
        public string FacultyName { get; set; }
    
        public virtual ICollection<Department> Department { get; set; }
        public virtual ICollection<User> User { get; set; }
    }
}
