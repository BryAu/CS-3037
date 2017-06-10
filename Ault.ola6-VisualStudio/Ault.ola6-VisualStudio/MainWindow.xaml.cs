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

namespace Ault.ola6_VisualStudio
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //boolean var to help reset 
        //the result in ResultTxt label
        bool ResetValues = true;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void textBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            ResultTxt.Text = "0";
        }

        private void OperationBtx_Click(object sender, RoutedEventArgs e)
        {
            //if no numbers have been clicked
            //reset result to 0
            if (ResetValues)
                ResultTxt.Text = "0";

            //sender.ToString returns the value "System.Windows.Forms.Button, Text: #"
            //so converted to char array and
            //grabbed the last character in the array
            //which is the only value needed
            else
            {
                char[] charArray = sender.ToString().ToCharArray();
                int endofArray = charArray.Length;
                char number = charArray[endofArray - 1];

                //concatinate value to ResultTxt
                ResultTxt.Text += number;
            }
        }



        private void CalcBtn_Click(object sender, RoutedEventArgs e)
        {
            //to reset ResultTxt if other buttons are clicked
            ResetValues = true;

            //store result in a string to manipulate
            string operatingString = ResultTxt.Text;

            //initialize a queue and string var to store numbers and operands in queue
            Queue<string> operatingQ = new Queue<string>();
            string queueNum1 = "";

            //loop through each character in ResultTxt.Text
            for (int i = 0; i < operatingString.Length; ++i)
            {
                //if the character is an operand
                if (operatingString[i] == '-' || operatingString[i] == '+' || operatingString[i] == '*')
                {
                    //then enqueue the string before the operand
                    operatingQ.Enqueue(queueNum1);
                    queueNum1 = "";                 //nullify the string
                    operatingQ.Enqueue(operatingString[i].ToString());  //enqueue the operand
                }
                //if not operand
                //then concatinate characters to the string for
                //queueing later
                else
                    queueNum1 += operatingString[i].ToString();
            }

            //enqueue the value after the last operand in the string
            operatingQ.Enqueue(queueNum1);

            //begin operating
            //by dequeueing from the front
            queueNum1 = operatingQ.Dequeue();

            //store final result and initialize it to the first number in the queue
            int rollingResult = Int32.Parse(queueNum1);

            int size = operatingQ.Count;
            //loop through the rest of the queue
            //size divided by 2 because we dequeue twice
            //every iteration
            for (int i = 0; i < (size / 2); ++i)
            {
                //store the operand and number folling
                //the operand
                string operand = operatingQ.Dequeue();
                queueNum1 = operatingQ.Dequeue();

                //do correct operation
                //dependent on operand
                if (operand == "+")
                    rollingResult += Int32.Parse(queueNum1);    //add number after operand to result
                else if (operand == "-")
                    rollingResult -= Int32.Parse(queueNum1);    //subtract number after operand to result
                else
                    rollingResult *= Int32.Parse(queueNum1);    //multiply number after operand to result
            }
            //all values in queue have been popped
            //so store final result in ResultTxt
            //for user to see
            ResultTxt.Text = rollingResult.ToString();

        }

        private void NumBtn_Click(object sender, RoutedEventArgs e)
        {
            //set to false
            //in order to concatinate
            //operands in ResultText
            if (ResetValues)
            {
                ResultTxt.Text = string.Empty;
                ResetValues = false;
            }

            //convert to char array
            //and get the last value in the array
            char[] charArray = sender.ToString().ToCharArray();
            int endofArray = charArray.Length;
            char number = charArray[endofArray - 1];

            //concatinate the number to ResultTxt
            ResultTxt.Text += number;
        }

        private void NumBtn_Press(object sender, KeyEventArgs e)
        {
            Key k = e.Key;
            //set to false
            //in order to concatinate
            //operands in ResultText
            if (ResetValues)
            {
                ResultTxt.Text = string.Empty;
                ResetValues = false;
            }

            if(k == Key.Enter)
                CalcBtn_Click(sender, e);

            else if (k == Key.Add)
            {
                ResultTxt.Text += '+';
            }

            else if (k == Key.Subtract)
            {
                ResultTxt.Text += '-';
            }

            else if (k == Key.Multiply)
            {
                ResultTxt.Text += '*';
            }

            else
            {

                //convert to char array
                //and get the last value in the array
                char[] charArray = k.ToString().ToCharArray();
                int endofArray = charArray.Length;
                char number = charArray[endofArray - 1];

                //concatinate the number to ResultTxt
                ResultTxt.Text += number;
            }
        }
    }
}
