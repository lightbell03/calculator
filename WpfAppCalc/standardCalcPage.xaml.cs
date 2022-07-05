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

namespace WpfAppCalc
{
    /// <summary>
    /// standardCalcPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class standardCalcPage : Page
    {
        string operation = "";
        string specialOpText = "";
        decimal result = 0;
        bool doneOperation = false;
        bool numberBtnClickCheck = false;
        bool dotBtnClickCheck = false;
        public standardCalcPage()
        {
            InitializeComponent();
            inputText.TextAlignment = TextAlignment.Right;
            resultText.TextAlignment = TextAlignment.Right;
            inputText.Text = "0";
        }

        private void number_Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                if (inputText.Text == "0" || doneOperation == true)
                {
                    inputText.Text = "";
                    doneOperation = false;
                }
                switch (btn.Name)
                {
                    case "zero":
                        inputText.Text += "0";
                        break;
                    case "one":
                        inputText.Text += "1";
                        break;
                    case "two":
                        inputText.Text += "2";
                        break;
                    case "three":
                        inputText.Text += "3";
                        break;
                    case "four":
                        inputText.Text += "4";
                        break;
                    case "five":
                        inputText.Text += "5";
                        break;
                    case "six":
                        inputText.Text += "6";
                        break;
                    case "seven":
                        inputText.Text += "7";
                        break;
                    case "eight":
                        inputText.Text += "8";
                        break;
                    case "nine":
                        inputText.Text += "9";
                        break;

                }
            }

            numberBtnClickCheck = true;
        }

        private void printCalc(string op, bool equalOp)
        {
            if (equalOp)
                resultText.Text += inputText.Text + "=";
            else
                resultText.Text = Convert.ToString(result) + op;
            inputText.Text = Convert.ToString(result);
        }
        
        private void calc(string op, bool equalOp)
        {
            if (!numberBtnClickCheck)
            {
                resultText.Text = Convert.ToString(result) + op;
                operation = op;
                return;
            }

            decimal inputVal = Convert.ToDecimal(inputText.Text);

            if (resultText.Text == "")
            {
                operation = op;
                result = inputVal;
                resultText.Text = inputText.Text + op;

                doneOperation = true;
                numberBtnClickCheck = false;
                dotBtnClickCheck = false;
                return;
            }

            switch (operation)
            {
                case "+":
                    result += inputVal;
                    printCalc(op, equalOp);
                    break;
                case "-":
                    result -= Convert.ToInt32(inputText.Text);
                    printCalc(op, equalOp);
                    break;
                case "*":
                    result *= inputVal;
                    printCalc(op, equalOp);
                    break;
                case "/":
                    if (inputText.Text != null)
                    {
                        if (Convert.ToInt32(inputText.Text) == 0)
                        {
                            result = 0;
                            inputText.Text = "0으로 나눌 수 없습니다.";
                            return;
                        }
                    }
                    result /= Convert.ToInt32(inputText.Text);
                    printCalc(op, equalOp);
                    break;
                case "root":
                    resultText.Text += op;
                    inputText.Text = Convert.ToString(result);
                    break;
                case "power":
                    resultText.Text += op;
                    inputText.Text = Convert.ToString(result);
                    break;
                case "inverse":
                    resultText.Text += op;
                    inputText.Text = Convert.ToString(result);
                    break;
                case "percent":
                    resultText.Text += op;
                    inputText.Text = Convert.ToString(result);
                    break;
            }

            operation = op;
            numberBtnClickCheck = false;
            dotBtnClickCheck = false;
            doneOperation = true;
        }
        private void operation_Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn != null)
            {
                switch (btn.Name)
                {
                    case "plus":
                        calc("+", false);
                        break;
                    case "minus":
                        calc("-", false);
                        break;
                    case "divide":
                        calc("/", false);
                        break;
                    case "multi":
                        calc("*", false);
                        break;
                    case "equal":
                        calc("=", true);
                        break;
                }
            }
        }

        private void printAndCalcExtendCalc(string op, string mark)
        {
            double inputVal = Convert.ToDouble(inputText.Text);
            decimal resVal = 0;
            if (op == "root")
            {
                if (inputVal == 0)
                    resVal = 0;
                else
                    resVal = (decimal)Math.Sqrt(inputVal);
            }
            else if (op == "power")
                resVal = (decimal)(inputVal * inputVal);
            else if (op == "inverse")
                resVal = 1 / Convert.ToDecimal(inputText.Text);
            else if (op == "percent")
            {
                resVal = result * (Convert.ToDecimal(inputText.Text) / 100);
                resultText.Text = Convert.ToString(result) + operation + Convert.ToString(resVal);
                inputText.Text = Convert.ToString(resVal);
                return;
            }
            switch (operation)
            {
                case "+":
                    result += resVal;
                    specialOpText = mark + inputText.Text + ")";
                    resultText.Text += specialOpText;
                    break;
                case "-":
                    result -= resVal;
                    specialOpText = mark + inputText.Text + ")";
                    resultText.Text += "+" + specialOpText;
                    break;
                case "*":
                    result *= resVal;
                    specialOpText = mark + inputText.Text + ")";
                    resultText.Text += "+" + specialOpText;
                    break;
                case "/":
                    result /= resVal;
                    specialOpText = mark + inputText.Text + ")";
                    resultText.Text += "+" + specialOpText;
                    break;
                case "power":
                    result = resVal;
                    specialOpText = mark + specialOpText + ")";
                    resultText.Text = specialOpText;
                    break;
                case "root":
                    result = resVal;
                    specialOpText = mark + specialOpText + ")";
                    resultText.Text = specialOpText;
                    break;
                case "inverse":
                    result = resVal;
                    specialOpText = mark + specialOpText + ")";
                    resultText.Text = specialOpText;
                    break;
                default:
                    result = resVal;
                    specialOpText = mark + inputText.Text + ")";
                    resultText.Text = specialOpText;
                    break;
            }

            inputText.Text = Convert.ToString(resVal);
        }
        private void power_Btn_Click(object sender, RoutedEventArgs e)
        {
            printAndCalcExtendCalc("power", "sqr(");
            operation = "power";
        }

        private void percent_Btn_Click(object sender, RoutedEventArgs e)
        {
            printAndCalcExtendCalc("percent", "");
        }

        private void inverse_Btn_Click(object sender, RoutedEventArgs e){
            printAndCalcExtendCalc("inverse", "1/(");
            operation = "inverse";
        }

        private void root_Btn_Click(object sender, RoutedEventArgs e)
        {

            printAndCalcExtendCalc("root", "√(");
            operation = "root";
        }

        private void sign_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (inputText.Text[0].Equals('-'))
                inputText.Text = inputText.Text.Remove(0, 1);
            else if (inputText.Text != "0")
                inputText.Text = "-" + inputText.Text;
        }
        private void dot_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (!dotBtnClickCheck) {
                dotBtnClickCheck = true;
                inputText.Text += ".";
            }
        }

        private void clear_Btn_Click(object sender, RoutedEventArgs e)
        {
            result = 0;
            resultText.Text = "";
            inputText.Text = "0";
            specialOpText = "";
            operation = "";
            doneOperation = false;
            numberBtnClickCheck = false;
        }

        private void del_Btn_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text.Remove(inputText.Text.Length - 1, 1);
            if (inputText.Text == "")
                inputText.Text = "0";
        }

        private void programmer_Menu_Btn_Click(object sender, RoutedEventArgs e)
        {
            programmerCalcPage pCalcPage = new programmerCalcPage();

            NavigationService.Navigate(pCalcPage);
        }

        private void standard_Menu_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/standardCalcPage.xaml", UriKind.Relative));
        }
    }
}
