//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EFOldAppDemo
{
    using System;
    using System.Collections.Generic;
    
    public partial class Dept
    {
        public int DeptId { get; set; }
        public string DeptName { get; set; }
        public Nullable<int> RegionId { get; set; }
    
        public virtual Region Region { get; set; }
    }
}
