using System;
using System.Windows.Forms;
using System.Drawing;
namespace currencyConvertor
{
    class Program : Form
    {
        TextBox txtInput;
        ComboBox cboFrom, cboTo;
        Label lblArrow, lblOutput;
        Button btnConvert;
        double dInput, dOutput;
        //values of every currency against 1 USD($)
        static double usd = 1.00;
        static double eur = 0.88;
        static double gbp = 0.76;
        static double etb = 48.02;
        public Program()
        {
            // variable inisialization, giving them proper sizes and location
            txtInput = new TextBox();
            txtInput.Location = new Point(10, 10);
            txtInput.Size = new Size(90, 30);
            cboFrom = new ComboBox();
            cboFrom.Location = new Point(120, 10);
            cboFrom.Size = new Size(70, 30);
            cboFrom.Items.Add("ETB");
            cboFrom.Items.Add("USD($)");
            cboFrom.Items.Add("GBP(£)");
            cboFrom.Items.Add("EUR(€)");
            lblArrow = new Label();
            lblArrow.Location = new Point(200, 10);
            lblArrow.Size = new Size(20, 30);
            lblArrow.Text = "-->";
            cboTo = new ComboBox();
            cboTo.Location = new Point(230, 10);
            cboTo.Size = new Size(70, 30);
            cboTo.Items.Add("ETB");
            cboTo.Items.Add("USD($)");
            cboTo.Items.Add("GBP(£)");
            cboTo.Items.Add("EUR(€)");
            btnConvert = new Button();
            btnConvert.Text = "Convert";
            btnConvert.Location = new Point(45, 50);
            btnConvert.Size = new Size(230, 30);
            lblOutput = new Label();
            lblOutput.Location = new Point(60, 100);
            lblOutput.Size = new Size(220, 25);
            lblOutput.Text = "your answer will be displayed here";
            // adding event handler
            btnConvert.Click += new EventHandler(convert);
            //adding conrols to the interface
            Controls.Add(txtInput);
            Controls.Add(cboFrom);
            Controls.Add(lblArrow);
            Controls.Add(cboTo);
            Controls.Add(btnConvert);
            Controls.Add(lblOutput);
            // giving the interface size and title
            this.Size = new Size(330, 170);
            this.Text = "My currency converter";
        }
        public void convert(Object obj, EventArgs e)
        {
            dInput = double.Parse(txtInput.Text);
            int indexFrom = cboFrom.SelectedIndex;
            int indexTo = cboTo.SelectedIndex;
            dOutput = currencyConverter(dInput, indexFrom, indexTo);
            lblOutput.Text = dInput + " " + cboFrom.SelectedItem + " = " + dOutput + " "
            + cboTo.SelectedItem;
        }
        public double currencyConverter(double dInputValue, int indexFrom, int indexTo)
        //returns the coverted currency
        {
            double fromValue = indexMatch(indexFrom);
            double toValue = indexMatch(indexTo);
            return usd / fromValue * dInputValue * toValue;
        }
        public double indexMatch(int index) //used to return the value of the selected currency againt the USD($)
        {
            if (index == 0)
                return etb;
            else if (index == 1)
                return usd;
            else if (index == 2)
                return gbp;
            else
                return eur;
        }
        static void Main(string[] args)
        {
            Application.Run(new Program());
        }
    }
}