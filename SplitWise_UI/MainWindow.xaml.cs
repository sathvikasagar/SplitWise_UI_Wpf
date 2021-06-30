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

namespace SplitWise_UI
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
        int count = 0;           //to count no of entries
        private void addDetails(object sender, RoutedEventArgs e)
        {
            PersonName.Items.Add(textBoxName.Text);
            AmountPaid.Items.Add(textBoxAmount.Text);
            Share.Items.Add(textBoxShare.Text);
            textBoxName.Clear();
            textBoxAmount.Clear();
            textBoxShare.Clear();
            count++;
        }

        private void calculate(object sender, RoutedEventArgs e)
        {
            var output = new List<string>();
            
            float totalAmount = 0;
            float[] amountPaidByEach = new float[count];
            count = 0;
            foreach (object obj in AmountPaid.Items)
            {
                string s1 = obj.ToString();
                totalAmount += float.Parse(s1);
                amountPaidByEach[count] = float.Parse(obj.ToString());
                count++;
            }

            string[] message = new string[count];
            count = 0;
            foreach (object obj in Share.Items)
            {
                float per = float.Parse(obj.ToString());
                float calc = (amountPaidByEach[count] - (totalAmount * per) / 100);
                if(calc<0)
                {
                    message[count] = " should pay " + Math.Abs(calc).ToString();
                }
                else
                {
                    message[count] = " should recieve " + Math.Abs(calc).ToString();
                }
                count++;
            }

            count = 0;
            foreach (object obj in PersonName.Items)
            {
                string s = obj.ToString() + message[count];
                output.Add(s);
                count++;
            }
            var op = string.Join(Environment.NewLine, output);
            MessageBox.Show(op);
        }

        private void clear(object sender, RoutedEventArgs e)
        {
            PersonName.Items.Clear();
            Share.Items.Clear();
            AmountPaid.Items.Clear();
        }
        
    }
}
