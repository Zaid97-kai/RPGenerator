using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RPTest.Pages
{
    /// <summary>
    /// Логика взаимодействия для WorkProgramPage.xaml
    /// </summary>
    public partial class WorkProgramPage : Page
    {
        private List<string> _specialtyCodes = new List<string>() { "09.02.06 Сетевое и системное администрирование", "09.02.07 Информационные системы и программирование", "10.02.05 Обеспечение информационной безопасности автоматизированных систем" };
        public WorkProgramPage()
        {
            InitializeComponent();
            CbCode.ItemsSource = _specialtyCodes;
        }
    }
}
