using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPTest.Models
{
    /// <summary>
    /// Компетенция
    /// </summary>
    public partial class Competencies
    {
        private string _CompetenciesName;
        public string CompetenciesName
        {
            get { return Code + " " + Description; }
            set { _CompetenciesName = value; }
        }
    }
}
