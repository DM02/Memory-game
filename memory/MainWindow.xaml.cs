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

namespace memory
{
    public partial class MainWindow : Window
    {
        public int ClickNumber = 0;
        public Button FirstClick;
        public Button SecondClick;
        public MainWindow()
        {
            var rand = new Random();
            InitializeComponent();
            Dictionary<string, int> letters = new Dictionary<string, int>() { { "SAMOCHOD", 0 }, { "DRZEWO", 0 }, { "OWOC", 0 }, { "WARZYWO", 0 }, { "SPORT", 0 }, { "ZAWOD", 0 } };
            foreach (Button btn in this.MemoGrid.Children)
            {
                int number;
                do
                {
                     number = rand.Next(letters.Count);
                } while (letters.ElementAt(number).Value == 2);
                btn.Tag = letters.ElementAt(number).Key;
               // btn.Content = letters.ElementAt(number).Key;
                letters[letters.ElementAt(number).Key]++;
            }
        }
        private void btn_Click(object sender, RoutedEventArgs e)
        {       
                Button btn = e.Source as Button;
            btn.Content = btn.Tag;
            if (ClickNumber == 2)
            {
                if (FirstClick.Tag == SecondClick.Tag)
                {
                    FirstClick.Visibility = Visibility.Hidden;
                    SecondClick.Visibility = Visibility.Hidden;
                }
                else
                {                   
                    FirstClick.Content = "";
                    SecondClick.Content = "";
                }
                FirstClick = null;
                SecondClick = null;
                ClickNumber = 0;
            }
            if (FirstClick == null)
            {
                FirstClick = btn;

            }
            else{
                SecondClick = btn;
            }           
            ClickNumber++;
        }
    }
}
