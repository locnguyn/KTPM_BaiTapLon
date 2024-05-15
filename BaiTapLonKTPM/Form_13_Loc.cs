using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BaiTapLonKTPM_13_Loc
{
    public partial class Form_13_Loc : Form
    {
        public Form_13_Loc()
        {
            InitializeComponent();
        }

        private void buttonCheckType_Click(object sender, EventArgs e)
        {
            try
            {
                double a_13_loc, b_13_loc, c_13_loc;
                a_13_loc = double.Parse(textBoxA.Text);
                b_13_loc = double.Parse(textBoxB.Text);
                c_13_loc = double.Parse(textBoxC.Text);
                Triangle t = new Triangle(a_13_loc, b_13_loc, c_13_loc);
                textBoxType.Text = t.toString();
            }
            catch (FormatException)
            {
                textBoxType.Text = "Đầu vào không hợp lệ";
            }
            catch (ArgumentException)
            {
                textBoxType.Text = "Tam giác không hợp lệ";
            }
        }

        private void buttonClear_Click(object sender, EventArgs e)
        {
            textBoxA.Text = "";
            textBoxB.Text = "";
            textBoxC.Text = "";
            textBoxPerimeter.Text = "";
            textBoxAcreage.Text = "";
            textBoxType.Text = "";
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                double a_13_loc, b_13_loc, c_13_loc;
                a_13_loc = double.Parse(textBoxA.Text);
                b_13_loc = double.Parse(textBoxB.Text);
                c_13_loc = double.Parse(textBoxC.Text);
                Triangle t = new Triangle(a_13_loc, b_13_loc, c_13_loc);
                textBoxPerimeter.Text = t.getPerimeter().ToString("0.##");
                textBoxAcreage.Text = t.getAcreage().ToString("0.##");
            }
            catch (FormatException)
            {
                textBoxType.Text = "Đầu vào không hợp lệ";
            }
            catch (ArgumentException)
            {
                textBoxType.Text = "Tam giác không hợp lệ";
            }
        }
    }
}
