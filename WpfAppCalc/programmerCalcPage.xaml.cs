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
    /// programmerCalcPage.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class programmerCalcPage : Page
    {
        List<string> histDecList;
        List<string> histHexList;
        List<string> histOctList;
        List<string> histBinList;

        string mode = "";
        string operation = "";
        bool doneOperation = false;
        bool numberBtnClickCheck = false;
        string decResult = "0";
        string hexResult = "0";
        string octResult = "0";
        string binResult = "0";
        string maxBinMinus = "111111111111111111111111";

        string preResultText = "";
        int result = 0;
        public programmerCalcPage()
        {
            InitializeComponent();
            histDecList = new List<string>();
            histHexList = new List<string>();
            histOctList = new List<string>();
            histBinList = new List<string>();
            resultText.TextAlignment = TextAlignment.Right;
            inputText.TextAlignment = TextAlignment.Right;

            mode = "decMode";

            inputText.Text = "0";
        }

        private void changeHexButton(bool tOrF)
        {
            A_Btn.IsEnabled = tOrF;
            B_Btn.IsEnabled = tOrF;
            C_Btn.IsEnabled = tOrF;
            D_Btn.IsEnabled = tOrF;
            E_Btn.IsEnabled = tOrF;
            F_Btn.IsEnabled = tOrF;
        }
        private void changeNumberButton(bool tOrF)
        {
            two.IsEnabled = tOrF;
            three.IsEnabled = tOrF;
            four.IsEnabled = tOrF;
            five.IsEnabled = tOrF;
            six.IsEnabled = tOrF;
            seven.IsEnabled = tOrF;
            eight.IsEnabled = tOrF;
            nine.IsEnabled = tOrF;
        }

        private void changeResultText(List<string> hist)
        {
            resultText.Text = "";
            foreach (string text in hist)
            {
                resultText.Text += text;
            }
        }

        private void hideModeBtnCanvas()
        {
            hexBtnCanvas.Visibility = Visibility.Hidden;
            decBtnCanvas.Visibility = Visibility.Hidden;
            octBtnCanvas.Visibility = Visibility.Hidden;
            binBtnCanvas.Visibility = Visibility.Hidden;
        }
        private void mode_Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null)
                return;

            switch (btn.Name)
            {
                case "hexMode":
                    hideModeBtnCanvas();
                    hexBtnCanvas.Visibility = Visibility.Visible;
                    changeHexButton(true);
                    changeNumberButton(true);
                    mode = "hexMode";
                    changeResultText(histHexList);
                    inputText.Text = hexResultText.Text;
                    break;
                case "decMode":
                    hideModeBtnCanvas();
                    decBtnCanvas.Visibility = Visibility.Visible;
                    changeNumberButton(true);
                    changeHexButton(false);
                    mode = "decMode";
                    changeResultText(histDecList);
                    inputText.Text = decResultText.Text;
                    break;
                case "octMode":
                    hideModeBtnCanvas();
                    octBtnCanvas.Visibility = Visibility.Visible;
                    changeHexButton(false);
                    changeNumberButton(true);
                    eight.IsEnabled = false;
                    nine.IsEnabled = false;
                    mode = "octMode";
                    changeResultText(histOctList);
                    inputText.Text = octResultText.Text;
                    break;
                case "binMode":
                    hideModeBtnCanvas();
                    binBtnCanvas.Visibility = Visibility.Visible;
                    changeNumberButton(false);
                    changeHexButton(false);
                    mode = "binMode";
                    changeResultText(histBinList);
                    inputText.Text = binResultText.Text;
                    break;
            }
        }

        private int inputValToDecFunc(string input)
        {
            int inputValToDec = 0;
            switch (mode)
            {
                case "hexMode":
                    inputValToDec = hexToDec(input);
                    break;
                case "decMode":
                    inputValToDec = Convert.ToInt32(input);
                    break;
                case "octMode":
                    inputValToDec = octToDec(input);
                    break;
                case "binMode":
                    inputValToDec = binToDec(input);
                    break;
            }
            return inputValToDec;
        }

        private void printAllModeInput(string input)
        { 
            int inputValToDec = inputValToDecFunc(input);
            hexResultText.Text = Convert.ToString(decToHex(inputValToDec));
            decResultText.Text = Convert.ToString(inputValToDec);
            octResultText.Text = Convert.ToString(decToOct(inputValToDec));
            binResultText.Text = Convert.ToString(decToBin(inputValToDec));
        }

        private void number_Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null)
                return;

            if (inputText.Text == "0" || doneOperation)
            {
                inputText.Text = "";
                doneOperation = false;
            }
            switch (btn.Name)
            {
                case "zero":
                    inputText.Text += "0";
                    printAllModeInput(inputText.Text);
                    break;
                case "one":
                    inputText.Text += "1";
                    printAllModeInput(inputText.Text);
                    break;
                case "two":
                    inputText.Text += "2";
                    printAllModeInput(inputText.Text);
                    break;
                case "three":
                    inputText.Text += "3";
                    printAllModeInput(inputText.Text);
                    break;
                case "four":
                    inputText.Text += "4";
                    printAllModeInput(inputText.Text);
                    break;
                case "five":
                    inputText.Text += "5";
                    printAllModeInput(inputText.Text);
                    break;
                case "six":
                    inputText.Text += "6";
                    printAllModeInput(inputText.Text);
                    break;
                case "seven":
                    inputText.Text += "7";
                    printAllModeInput(inputText.Text);
                    break;
                case "eight":
                    inputText.Text += "8";
                    printAllModeInput(inputText.Text);
                    break;
                case "nine":
                    inputText.Text += "9";
                    printAllModeInput(inputText.Text);
                    break;
                case "A_Btn":
                    inputText.Text += "A";
                    printAllModeInput(inputText.Text);
                    break;
                case "B_Btn":
                    inputText.Text += "B";
                    printAllModeInput(inputText.Text);
                    break;
                case "C_Btn":
                    inputText.Text += "C";
                    printAllModeInput(inputText.Text);
                    break;
                case "D_Btn":
                    inputText.Text += "D";
                    printAllModeInput(inputText.Text);
                    break;
                case "E_Btn":
                    inputText.Text += "E";
                    printAllModeInput(inputText.Text);
                    break;
                case "F_Btn":
                    inputText.Text += "F";
                    printAllModeInput(inputText.Text);
                    break;
            }
            numberBtnClickCheck = true;
        }

        private int hexToDec(string hex)
        {
            int res = 0;
            int power = 1;

            for (int i = hex.Length - 1; i >= 0; i--)
            {
                int tmp = 0;
                switch (hex[i])
                {
                    case 'A':
                        tmp = 10;
                        break;
                    case 'B':
                        tmp = 11;
                        break;
                    case 'C':
                        tmp = 12;
                        break;
                    case 'D':
                        tmp = 13;
                        break;
                    case 'E':
                        tmp = 14;
                        break;
                    case 'F':
                        tmp = 15;
                        break;
                    default:
                        tmp = hex[i] - '0';
                        break;
                }
                res += tmp * power;
                power *= 16;
            }
            
            return res;
        }
        private string decToHex(int dec)
        {
            string res = "";
            if (dec < 0)
            {
                return decToHex(binToDec(decToBin(dec)));
            }
            else
            {
                while (dec > 0)
                {
                    switch (dec % 16)
                    {
                        case 10:
                            res = 'A' + res;
                            break;
                        case 11:
                            res = 'B' + res;
                            break;
                        case 12:
                            res = 'C' + res;
                            break;
                        case 13:
                            res = 'D' + res;
                            break;
                        case 14:
                            res = 'E' + res;
                            break;
                        case 15:
                            res = 'F' + res;
                            break;
                        default:
                            res = Convert.ToString(dec % 16) + res;
                            break;
                    }
                    dec /= 16;
                }
            }
            return res == "" ? "0" : res;
        }

        private int octToDec(string oct)
        {
            int res = 0;
            int power = 1;

            for (int i = oct.Length - 1; i >= 0; i--)
            {
                res += (oct[i] - '0') * power;
                power *= 2;
            }

            return res;
        }

        private string decToOct(int dec)
        {
            string res = "";
            if (dec < 0)
            {
                return decToOct(binToDec(decToBin(dec)));
            }
            else
            {
                while (dec > 0)
                {
                    res = Convert.ToString(dec % 8) + res;
                    dec /= 8;
                }
            }

            return res == "" ? "0" : res;
        }
        private int binToDec(string bin)
        {
            int res = 0;
            int power = 1;
            //MessageBox.Show(bin);
            for (int i = bin.Length - 1; i >= 0; i--)
            {

                if(i == 0)
                {
                    if (bin[i] == '-')
                    {
                        res = 0 - res;
                        break;
                    }
                }
                
                res += (bin[i] - '0') * power;
                power *= 2;
            }
            return res;
        }
        private string decToBin(int dec)
        {
            string res = "";
            if (dec < 0)
            {
                string tmp = "";
                dec = 0 - dec;
                while (dec > 0)
                {
                    if (dec % 2 == 0)
                        tmp = "1" + tmp;
                    else
                        tmp = "0" + tmp;
                    dec /= 2;
                }

                for (int i = tmp.Length - 1; i >= 0; i--)
                {
                    if (tmp[i] == '1')
                    {
                        tmp = tmp.Remove(i, 1);
                        tmp = tmp.Insert(i, "0");
                    }
                    else if (tmp[i] == '0')
                    {
                        tmp = tmp.Remove(i, 1);
                        tmp = tmp.Insert(i, "1");
                        break;
                    }
                }

                string tmp2 = maxBinMinus.Remove(maxBinMinus.Length - tmp.Length, tmp.Length);
                return tmp2 + tmp;
            }
            else
            {
                while (dec > 0)
                {
                    res = Convert.ToString(dec % 2) + res;
                    dec /= 2;
                }
                return res == "" ? "0" : res;
            }
        }

        private void calcResultAllMode(int result)
        {
            hexResult = decToHex(result);
            decResult = Convert.ToString(result);
            octResult = decToOct(result);
            binResult = decToBin(result);
        }

        private void memoryResultTextAllMode(int inputVal, string op)
        {
            histDecList.Add(Convert.ToString(inputVal) + op);
            histBinList.Add(decToBin(inputVal) + op);
            histHexList.Add(decToHex(inputVal) + op);
            histOctList.Add(decToOct(inputVal) + op);
        }

        private void printResultOperation(bool equalOp, string op)
        {
            calcResultAllMode(result);
            preResultText = resultText.Text + inputText.Text;
            if (equalOp)
            {
                switch (mode)
                {
                    case "hexMode":
                        resultText.Text += inputText.Text + op + hexResult;
                        break;
                    case "decMode":
                        resultText.Text += inputText.Text + op + decResult;
                        break;
                    case "octMode":
                        resultText.Text += inputText.Text + op + octResult;
                        break;
                    case "binMode":
                        resultText.Text += inputText.Text + op + binResult;
                        break;
                }
            }
            else
                resultText.Text += inputText.Text + op;

            switch (mode)
            {
                case "hexMode":
                    inputText.Text = hexResult;
                    break;
                case "decMode":
                    inputText.Text = decResult;
                    break;
                case "octMode":
                    inputText.Text = octResult;
                    break;
                case "binMode":
                    inputText.Text = binResult;
                    break;
            }
        }

        private string notLogicCalc(string str)
        {
            string s;

            for(int i=0; i<str.Length; i++)
            {
                if (str[i] == '1')
                {
                    str = str.Remove(i, 1);
                    str = str.Insert(i, "0");
                }
                else
                {
                    str = str.Remove(i, 1);
                    str = str.Insert(i, "1");
                }
            }

            s = maxBinMinus.Remove(maxBinMinus.Length - str.Length, str.Length);
            return s + str;
        }

        private void chooseCalc(string op, bool equalOp)
        {
            if (!numberBtnClickCheck)
            {
                if(operation == "=")
                {
                    result = Convert.ToInt32(inputText.Text);
                    resultText.Text = Convert.ToString(result) + op;

                    operation = op;
                    doneOperation = true;
                }
                else
                    resultText.Text = preResultText + op;
                return;
            }

            int inputValToDec = inputValToDecFunc(inputText.Text);

            if (resultText.Text == "")
            {
                
                resultText.Text = inputText.Text + op;
                result = inputValToDec;
                calcResultAllMode(result);
                memoryResultTextAllMode(inputValToDec, op);
                numberBtnClickCheck = false;
                doneOperation = true;
                operation = op;
                return;
            }

            switch (operation)
            {
                case "+":
                    memoryResultTextAllMode(inputValToDec, op);
                    result += inputValToDec;
                    printResultOperation(equalOp, op);
                    break;
                case "-":
                    result -= inputValToDec;
                    memoryResultTextAllMode(inputValToDec, op);
                    printResultOperation(equalOp, op);
                    break;
                case "*":
                    result *= inputValToDec;
                    memoryResultTextAllMode(inputValToDec, op);
                    printResultOperation(equalOp, op);
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
                    result /= inputValToDec;
                    memoryResultTextAllMode(inputValToDec, op);
                    printResultOperation(equalOp, op);
                    break;
                case "Rsh":
                    for(int i=0; i<inputValToDec; i++)
                    {
                        result /= 2;
                        if (result == 0)
                            break;
                    }
                    memoryResultTextAllMode(inputValToDec, op);
                    printResultOperation(equalOp, op);
                    break;
                case "Lsh":
                    for (int i = 0; i < inputValToDec; i++)
                    {
                        result *= 2;
                        if (result == 0)
                            break;
                    }
                    memoryResultTextAllMode(inputValToDec, op);
                    printResultOperation(equalOp, op);
                    break;
                case "AND":
                    {
                        string inputBin = decToBin(inputValToDec);
                        string res = "";
                        int inputBinIndex = inputBin.Length - 1;
                        int binResultIndex = binResult.Length - 1;

                        while (inputBinIndex >= 0 && binResultIndex >= 0)
                        {

                            if ((inputBin[inputBinIndex] == binResult[binResultIndex]) && (inputBin[inputBinIndex] == '1') && (binResult[binResultIndex] == '1'))
                                res = "1" + res;
                            else
                                res = "0" + res;

                            inputBinIndex--;
                            binResultIndex--;
                        }

                        if (inputBinIndex > binResultIndex)
                            res = inputBin.Substring(0, inputBinIndex) + res;
                        else if (binResultIndex > inputBinIndex)
                            res = binResult.Substring(0, binResultIndex) + res;

                        result = binToDec(res);
                    }
                    memoryResultTextAllMode(inputValToDec, op);
                    printResultOperation(equalOp, op);
                    break;
                case "OR":
                    { 
                        string inputBin = decToBin(inputValToDec);
                        string res = "";
                        int inputBinIndex = inputBin.Length - 1;
                        int binResultIndex = binResult.Length - 1;

                        while (inputBinIndex >= 0 || binResultIndex >= 0)
                        {
                            if ((inputBin[inputBinIndex] == '1') || (binResult[binResultIndex] == '1'))
                                res = "1" + res;
                            else
                                res = "0" + res;

                            inputBinIndex--;
                            binResultIndex--;
                        }

                        if (inputBinIndex > binResultIndex)
                            res = inputBin.Substring(0, inputBinIndex) + res;
                        else if (binResultIndex > inputBinIndex)
                            res = binResult.Substring(0, binResultIndex) + res;

                        result = binToDec(res);
                    }
                    memoryResultTextAllMode(inputValToDec, op);
                    printResultOperation(equalOp, op);
                    break;
                case "NAND":
                    {
                        string inputBin = decToBin(inputValToDec);
                        string res = "";
                        int inputBinIndex = inputBin.Length - 1;
                        int binResultIndex = binResult.Length - 1;

                        while (inputBinIndex >= 0 || binResultIndex >= 0)
                        {
                            if ((inputBin[inputBinIndex] == binResult[binResultIndex]) && (inputBin[inputBinIndex] == '1') && (binResult[binResultIndex] == '1'))
                               res = "1" + res;
                            else
                               res = "0" + res;

                            inputBinIndex--;
                            binResultIndex--;
                        }

                        if (inputBinIndex > binResultIndex)
                            res = inputBin.Substring(0, inputBinIndex) + res;
                        else if (binResultIndex > inputBinIndex)
                            res = binResult.Substring(0, binResultIndex) + res;

                        result = binToDec(res) + 1;
                        res = notLogicCalc(res);
                        result = binToDec(res);
                    }
                    memoryResultTextAllMode(inputValToDec, op);
                    printResultOperation(equalOp, op);
                    break;
                case "NOT":
                    {

                    }
                    break;
            }

            hexResultText.Text = hexResult;
            decResultText.Text = decResult;
            octResultText.Text = octResult;
            binResultText.Text = binResult;
            operation = op;
            numberBtnClickCheck = false;
            doneOperation = true;
        }
        private void operation_Btn_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;

            if (btn == null)
                return;

            switch (btn.Name)
            {
                case "plus":
                    chooseCalc("+", false);
                    break;
                case "minus":
                    chooseCalc("-", false);
                    break;
                case "multi":
                    chooseCalc("*", false);
                    break;
                case "divide":
                    chooseCalc("/", false);
                    break;
                case "equal":
                    chooseCalc("=", true);
                    break;
                case "rightShiftBtn":
                    chooseCalc("Rsh", false);
                    break;
                case "leftShiftBtn":
                    chooseCalc("Lsh", false);
                    break;
                case "AND_Btn":
                    logicOpGrid.Visibility = Visibility.Collapsed;
                    chooseCalc("AND", false);
                    break;
                case "OR_Btn":
                    logicOpGrid.Visibility = Visibility.Collapsed;
                    chooseCalc("OR", false);
                    break;
                case "NOT_Btn":
                    logicOpGrid.Visibility = Visibility.Collapsed;
                    if (inputText.Text[0] == '-')
                    {
                        resultText.Text += "NOT(" + inputText.Text + ")";

                    }
                    else
                    {
                        resultText.Text += "NOT(" + inputText.Text + ")";

                    }
                    chooseCalc("NOT", false);
                    break;
                case "NAND_Btn":
                    logicOpGrid.Visibility = Visibility.Collapsed;
                    chooseCalc("NAND", false);
                    break;
                case "NOR_Btn":
                    logicOpGrid.Visibility = Visibility.Collapsed;
                    chooseCalc("NOR", false);
                    break;
                case "XOR_Btn":
                    logicOpGrid.Visibility = Visibility.Collapsed;
                    chooseCalc("XOR", false);
                    break;
            }
        }

        private void sign_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (inputText.Text[0].Equals('-'))
                inputText.Text = inputText.Text.Remove(0, 1);
            else if (inputText.Text[0] != '-')
                inputText.Text = "-" + inputText.Text;
            printAllModeInput(inputText.Text);
        }

        private void clear_Btn_Click(object sender, RoutedEventArgs e)
        {
            inputText.Text = "0";
            resultText.Text = "";
            result = 0;

            histHexList.Clear();
            histDecList.Clear();
            histOctList.Clear();
            histBinList.Clear();

            hexResult = "0";
            decResult = "0";
            octResult = "0";
            binResult = "0";

            hexResultText.Text = "0";
            decResultText.Text = "0";
            octResultText.Text = "0";
            binResultText.Text = "0";
        }

        private void logicOpSel_Btn_Click(object sender, RoutedEventArgs e)
        {
            if (logicOpGrid.Visibility == Visibility.Collapsed)
                logicOpGrid.Visibility = Visibility.Visible;
            else
                logicOpGrid.Visibility = Visibility.Collapsed;
        }

        private void del_Btn_click(object sender, RoutedEventArgs e)
        {
            inputText.Text = inputText.Text.Remove(inputText.Text.Length - 1, 1);
            if (inputText.Text.Length == 0)
            {
                inputText.Text = "0";
            }
            printAllModeInput(inputText.Text);
        }
        private void programmer_Menu_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/programmerCalcPage.xaml", UriKind.Relative));
        }

        private void standard_Menu_Btn_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Uri("/standardCalcPage.xaml", UriKind.Relative));
        }
    }
}
