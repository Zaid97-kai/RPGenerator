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
    
    public partial class Skills
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Id_Discipline { get; set; }
    
        public virtual Discipline Discipline { get; set; }
    }
}
