//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace puantaj2017.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class PersonelGrup
    {
        public int id { get; set; }
        public int grupid { get; set; }
        public int personelid { get; set; }
    
        public virtual Grup Grup { get; set; }
        public virtual Personel Personel { get; set; }
    }
}
