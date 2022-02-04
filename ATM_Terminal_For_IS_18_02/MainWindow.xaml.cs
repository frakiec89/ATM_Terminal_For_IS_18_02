using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace ATM_Terminal_For_IS_18_02
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btGo_Click(object sender, RoutedEventArgs e)
        {
            var content = File.ReadAllText("Content.json");
            var us = JsonConvert.DeserializeObject<List<dynamic>>(content);

            bool f = false;

            foreach (var item in us)
            {

                var n = item.NumberCard;
                var p = item.Pin;

                if (n== tbNumber.Text &&  p == tbPin.Text)
                {
                    MessageBox.Show($"привет {item.UserName}");
                    f = true;
                    WindowsATM windowsATM = new WindowsATM(item);
                    windowsATM.Show();
                    this.Close();
                    return; 
                }
            }
            if(f == false)
            {
                MessageBox.Show($"Пользователь не  найден");
            }
        }
    }
}
