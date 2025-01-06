using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace W1D1
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void number_Click(object sender, EventArgs e)
        {
            Button temp = (Button)sender;
            txtLCD.Text += temp.Text;
        }

        protected void btnEquals_Click(object sender, EventArgs e)
        {
            //assign variables for operation
            Double Num1 = Double.Parse(Session["Num1"].ToString());
            Double Num2 = Double.Parse(txtLCD.Text);
            String Operand = Session["Operand"].ToString();
            Double Result = 0;

            //determine operation
            switch (Operand)
            {
                case ("+"):
                    Result = Num1 + Num2;
                    break;

                case ("-"):
                    Result = Num1 - Num2;
                    break;

                case ("*"):
                    Result = Num1 * Num2;
                    break;

                case ("/"):
                    Result = Num1 / Num2;
                    break;

                default:
                    txtLCD.Text = "Error: Invalid Operand";
                    break;
            }
            //output result and reset memory LCDs
            txtLCD.Text = Result.ToString();
            mem1LCD.Text = "";
            mem2LCD.Text = "";
        }

        protected void btnOperand_Click(object sender, EventArgs e)
        {
            //store first number and operand
            Button temp = (Button)sender;

            Session["Num1"] = txtLCD.Text;
            Session["Operand"] = temp.Text;

            mem1LCD.Text = txtLCD.Text;
            mem2LCD.Text = temp.Text;
            txtLCD.Text = "";
        }
        protected void btnClearEverything_Click(object sender, EventArgs e)
        {
            //clear mem1, mem2, and main LCD
            mem1LCD.Text = "";
            mem2LCD.Text = "";
            txtLCD.Text = "";
        }
        protected void memStore_Click(object sender, EventArgs e)
        {
            //store number currently on main LCD to mem3 LCD
            Session["memNum"] = txtLCD.Text;
            mem3LCD.Text = txtLCD.Text;
            txtLCD.Text = "";
        }
        protected void memRestore_Click(object sender, EventArgs e)
        {
            //restore number from mem3 LCD to main LCD
            txtLCD.Text = Session["memNum"].ToString();
            mem3LCD.Text = "";
            Session["memNum"] = 0;
        }
        protected void memClear_Click(object sender, EventArgs e)
        {
            //clear mem3 LCD and memorized number
            mem3LCD.Text = "";
            Session["memNum"] = 0;
        }
    }
}