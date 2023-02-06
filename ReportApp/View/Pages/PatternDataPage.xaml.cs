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
using ReportApp.Model;
using Word = Microsoft.Office.Interop.Word;
using System.IO;
using System.Globalization;

namespace ReportApp.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для PatternDataPage.xaml
    /// </summary>
    public partial class PatternDataPage : Page
    {
        public PatternDataPage()
        {
            InitializeComponent();
        }

        private void EnterWord_Click(object sender, RoutedEventArgs e)
        {
            Word.Application application = new Word.Application();
            //Вариант 1
            Word.Document activeDoc = application.Documents.Open($"{Directory.GetCurrentDirectory()}\\..\\..\\Assets\\Docum\\dogovor.doc");
            activeDoc.Activate();
            activeDoc.Bookmarks["FIO"].Range.Text = FioTextBlock.Text;
            activeDoc.Bookmarks["DateStart"].Range.Text = StartDatePicker.SelectedDate.Value.Day.ToString();
            activeDoc.Bookmarks["MonthStart"].Range.Text = StartDatePicker.SelectedDate.Value.Date.ToString("MMMM", new CultureInfo("ru-RU"));
            activeDoc.Bookmarks["YearsStart"].Range.Text = StartDatePicker.SelectedDate.Value.Year.ToString();
            application.Visible = true;
        }
    }
}
