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
    
    public partial class Literary_Source_Author
    {
        public int Id { get; set; }
        public int Id_Author { get; set; }
        public int Id_Literary_Source { get; set; }
    
        public virtual Author Author { get; set; }
        public virtual Literary_Source Literary_Source { get; set; }
    }
}
