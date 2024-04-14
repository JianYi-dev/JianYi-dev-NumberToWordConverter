using System;
using System.Web.UI;
using NumberToWordConverter.Manager;

namespace NumberToWordConverter
{
    public partial class _Default : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                string numberText = txtNumber.Text;
                decimal number;
                if (decimal.TryParse(numberText, out number))
                {
                    lblResult.Text = ConverterManager.ConvertNumberToString(number);
                }
                else
                {
                    lblResult.Text = "Invalid number";
                }
            }
        }
    }
}