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
    [Serializable]
    public partial class Topic_Competencies
    {
        public int Id { get; set; }
        public int Id_Topic { get; set; }
        public int Id_Competencies { get; set; }
    
        public virtual Competencies Competencies { get; set; }
        public virtual Topic Topic { get; set; }
        public Topic_Competencies()
        {

        }
    }
}