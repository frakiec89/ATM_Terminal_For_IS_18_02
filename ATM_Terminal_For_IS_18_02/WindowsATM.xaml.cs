using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;

namespace ATM_Terminal_For_IS_18_02
{
    /// <summary>
    /// Логика взаимодействия для WindowsATM.xaml
    /// </summary>
    public partial class WindowsATM : Window
    {

        dynamic userOne; 

        public WindowsATM(dynamic user)
        {
            InitializeComponent();
            userOne = user;
            tbName.Text = userOne.UserName;
        }

        private void btExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btOutSumma_Click(object sender, RoutedEventArgs e)
        {
            var content = File.ReadAllText("Content.json");
            var us = JsonConvert.DeserializeObject<List<dynamic>>(content);

            foreach (var item in us)
            {
                var n = item.NumberCard;
                var p = item.Pin;
                var b = item.Balance;

                if (n == userOne.NumberCard && p == userOne.Pin)
                {
                    var s = b - Convert.ToDouble(tbOutSumma.Text);
                    if ( s >=0)
                    {
                        item.Balance -= Convert.ToDouble(tbOutSumma.Text);
                        MessageBox.Show("Заберите деньги");
                        break;
                    }
                   else
                    {
                        MessageBox.Show("НЕ хватает  денег  на счету");
                        return;
                    }
                }
            }

            content = JsonConvert.SerializeObject(us);

            File.WriteAllText("Content.json", content);
        }

        private void btInSumma_Click(object sender, RoutedEventArgs e)
        {
            var content = File.ReadAllText("Content.json");
            var us = JsonConvert.DeserializeObject<List<dynamic>>(content);

            foreach (var item in us)
            {

                var n = item.NumberCard;
                var p = item.Pin;
                var b = item.Balance;

                if (n == userOne.NumberCard && p == userOne.Pin)
                {
                    item.Balance += Convert.ToDouble(tbInSumma.Text);
                    MessageBox.Show("деньги положены на счет");
                    break;
                }
            }

            content = JsonConvert.SerializeObject(us);

            File.WriteAllText("Content.json", content);
        }

        private void btBalance_Click(object sender, RoutedEventArgs e)
        {
            var content = File.ReadAllText("Content.json");
            var us = JsonConvert.DeserializeObject<List<dynamic>>(content);

            foreach (var item in us)
            {

                var n = item.NumberCard;
                var p = item.Pin;
                var b = item.Balance;

                if (n == userOne.NumberCard && p == userOne.Pin)
                {
                    tbBalance.Text = item.Balance;
                    break;
                }
            }
        }
    }
}
