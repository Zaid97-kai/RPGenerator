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
    
    public partial class Discipline_HourlyLoad
    {
        public int Id { get; set; }
        public int TheoreticalTraining { get; set; }
        public int PracticalTraining { get; set; }
        public int LaboratoryTraining { get; set; }
        public int Coursework { get; set; }
        public int IndependentWork { get; set; }
        public int AssesmentWork { get; set; }
        public int Id_Discipline { get; set; }
    
        public virtual Discipline Discipline { get; set; }
    }
}
