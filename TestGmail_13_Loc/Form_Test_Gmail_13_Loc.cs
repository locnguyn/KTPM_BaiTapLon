using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace TestGmail_13_Loc
{
    public partial class Form_Test_Gmail_13_Loc : Form
    {
        public Form_Test_Gmail_13_Loc()
        {
            InitializeComponent();
        }

        //private void buttonSuccessfullyLogin_Click(object sender, EventArgs e)
        //{
        //    IWebDriver driver_13_Loc = new ChromeDriver();
        //    driver_13_Loc.Navigate().GoToUrl("https://mail.google.com/");
        //    driver_13_Loc.FindElement(By.Name("identifier")).SendKeys("ktpm.13.loc@gmail.com");
        //    driver_13_Loc.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/c-wiz/div/div[3]/div/div[1]/div/div/button")).Click();
        //    Thread.Sleep(4000);
        //    driver_13_Loc.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/c-wiz/div/div[2]/div/div/div/form/span/section[2]/div/div/div[1]/div[1]/div/div/div/div/div[1]/div/div[1]/input")).SendKeys("1234567890A@a");
        //    driver_13_Loc.FindElement(By.XPath("/html/body/div[1]/div[1]/div[2]/c-wiz/div/div[3]/div/div[1]/div/div/button")).Click();
        //    Thread.Sleep(4000);
        //    driver_13_Loc.FindElement(By.XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[1]/div/div")).Click();
        //    Thread.Sleep(5000);
        //    driver_13_Loc.FindElement(By.XPath("/html/body/div[26]/div/div/div/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/form/input[12]")).SendKeys("D:\\astah_uml_license_2023-2024.xml.zip");
        //    driver_13_Loc.Quit();
        //}

        private void buttonLogin_Click(object sender, EventArgs e)
        {

        }
    }
}
