//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RPTest.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Auditory_Software
    {
        public int Id { get; set; }
        public int Id_Auditory { get; set; }
        public int Id_Software { get; set; }
    
        public virtual Auditory Auditory { get; set; }
        public virtual Software Software { get; set; }
    }
}
