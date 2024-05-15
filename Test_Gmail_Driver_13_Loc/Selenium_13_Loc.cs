using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Test_Gmail_Driver_13_Loc
{
    public class Selenium_13_Loc
    {
        private IWebDriver driver_13_loc;

        public Selenium_13_Loc()
        {
            this.driver_13_loc = new ChromeDriver();
            goToBaseUrl();
        }

        public void goToBaseUrl()
        {
            this.driver_13_loc.Navigate().GoToUrl("https://accounts.google.com/v3/signin/identifier?continue=https%3A%2F%2Fmail.google.com%2Fmail%2Fu%2F0%2F&emr=1&followup=https%3A%2F%2Fmail.google.com%2Fmail%2Fu%2F0%2F&ifkv=AaSxoQzEHIH8j1lq9iT0MUVP713hzhvh2G3Sx0yVTBH9oY_ZtvyL5IvpxMk0LIFnBPjpUILis8ab&osid=1&passive=1209600&service=mail&flowName=GlifWebSignIn&flowEntry=ServiceLogin&dsh=S1543997491%3A1715588264074708&ddm=0");
        }

        public string login_13_loc(string email_13_loc, string pass_13_loc)
        {
            this.driver_13_loc
                .FindElement(By
                .XPath("/html/body/div[1]/div[1]/div[2]/c-wiz/div/div[2]/div/div/div[1]/form/span/section/div/div/div[1]/div/div[1]/div/div[1]/input"))
                .SendKeys(email_13_loc);

            this.driver_13_loc
                .FindElement(By
                .XPath("/html/body/div[1]/div[1]/div[2]/c-wiz/div/div[3]/div/div[1]/div/div/button"))
                .Click();

            Thread.Sleep(5000);

            try
            {
                IWebElement e = this.driver_13_loc
                    .FindElement(By
                    .XPath("//div[contains(text(), 'Couldn’t find your Google Account')]"));
                return "Couldnt find your Google Account";
                //Couldn’t find your Google Account
            }
            catch {}

            try
            {
                IWebElement e = this.driver_13_loc
                    .FindElement(By
                    .XPath("//div[contains(text(), 'Enter a valid email or phone number')]"));
                return "Enter a valid email or phone number";
            }
            catch { }

            this.driver_13_loc
                .FindElement(By
                .XPath("/html/body/div[1]/div[1]/div[2]/c-wiz/div/div[2]/div/div/div/form/span/section[2]/div/div/div[1]/div[1]/div/div/div/div/div[1]/div/div[1]/input"))
                .SendKeys(pass_13_loc);

            this.driver_13_loc
                .FindElement(By
                .XPath("/html/body/div[1]/div[1]/div[2]/c-wiz/div/div[3]/div/div[1]/div/div/button"))
                .Click();

            Thread.Sleep(4000);
            try
            {
                return this.driver_13_loc
                    .FindElement(By
                    .XPath("/html/body/div[1]/div[1]/div[2]/c-wiz/div/div[2]/div/div/div/form/span/section[2]/div/div/div[1]/div[2]/div[2]/span")).Text;
                //Wrong password. Try again or click Forgot password to reset it.
            }
            catch {}
            Thread.Sleep(3000);
            if (!this.inHome_13_loc())
                return "Login failed";
            return "Logged in successfully";
        }

        public bool inHome_13_loc()
        {
            try
            {
                this.driver_13_loc
                    .FindElement(By.
                    XPath("/html/body/div[7]/div[3]/div/div[1]/div/div[2]/div[2]/header/div[2]/div[1]/div[4]/div/a"));
                return true;
            }
            catch
            {
                return false;
            }
        }

        public string sendEmail_13_loc(string recipients, string subject, string content)
        {
            if (this.inHome_13_loc())
            {

                try
                {
                    this.driver_13_loc
                        .FindElement(By
                        .XPath("/html/body/div[27]/div/div/div/div[1]/div[2]/div[1]/div[1]/div/div/div/div[2]/div/div[2]/div/div/div/div/table/tbody/tr/td[2]/img[3]"))
                        .Click();
                }
                catch { }
                this.driver_13_loc
                    .FindElement(By
                    .XPath("/html/body/div[7]/div[3]/div/div[2]/div[1]/div[1]/div/div"))
                    .Click();
                Thread.Sleep(1000);
                this.driver_13_loc
                    .FindElement(By
                    .XPath("/html/body/div[27]/div/div/div/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/form/div[1]/table/tbody/tr[1]/td[2]/div/div/div[1]/div/div[3]/div/div/div/div/div/input"))
                    .SendKeys(recipients);
                this.driver_13_loc
                    .FindElement(By
                    .XPath("/html/body/div[27]/div/div/div/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/form/div[3]/input"))
                    .SendKeys(subject);
                this.driver_13_loc
                    .FindElement(By
                    .XPath("/html/body/div[27]/div/div/div/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/table/tbody/tr[1]/td/div/div[1]/div[2]/div[3]/div/table/tbody/tr/td[2]/div[2]/div"))
                    .SendKeys(content);
                this.driver_13_loc
                    .FindElement(By
                    .XPath("/html/body/div[27]/div/div/div/div[1]/div[2]/div[1]/div[1]/div/div/div/div[3]/div/div/div[4]/table/tbody/tr/td[2]/table/tbody/tr[2]/td/div/div/div[4]/table/tbody/tr/td[1]/div/div[2]/div[1]"))
                    .Click();
                Thread.Sleep(2000);
                if(subject == "" && content == "")
                {
                    try
                    {
                        IAlert alert = this.driver_13_loc.SwitchTo().Alert();
                        alert.Accept();
                    } catch { }
                }
                try
                {
                    string res = this.driver_13_loc.FindElement(By.XPath("/html/body/div[38]/div[2]/div/div[1]")).Text;
                    if (res.Contains("Please specify at least one recipient."))
                    {
                        this.driver_13_loc.FindElement(By.XPath("/html/body/div[38]/div[2]/div/div[2]/div/button")).Click();
                        return res;
                    }
                } catch { }
                Thread.Sleep(1000);
                try
                {
                    if(this.driver_13_loc
                        .FindElement(By
                        .XPath("/html/body/div[38]/div[2]/div/div[1]")).Text.Contains("Please make sure that all addresses are properly formed"))
                    {
                        this.driver_13_loc
                        .FindElement(By
                        .XPath("/html/body/div[38]/div[2]/div/div[2]/div/button")).Click();
                        return "Invalid recipients";
                    }
                }
                catch {}
                Thread.Sleep(3000);
                return "Sent email successfully";
            }
            else
                return "Not logged in yet";
        }

        public bool search_13_loc(string kw)
        {
            if (this.inHome_13_loc())
            {
                IWebElement e_13_loc = this.driver_13_loc
                    .FindElement(By
                    .XPath("/html/body/div[7]/div[3]/div/div[1]/div/div[2]/div[2]/header/div[2]/div[2]/div[2]/form/div[1]/table/tbody/tr/td/table/tbody/tr/td/div/input[1]"));
                e_13_loc.Clear();
                e_13_loc.SendKeys(kw);
                e_13_loc.SendKeys(Keys.Enter);
                try
                {
                    return !this
                        .driver_13_loc
                        .FindElement(By
                        .XPath("/html/body/div[7]/div[3]/div/div[2]/div[2]/div/div/div/div[2]/div/div[1]/div/div[2]/div/div/div/div[2]/div[6]/div[2]/table/tbody/tr/td"))
                        .Text.Contains("No messages matched your search");
                }
                catch
                {
                    return true;
                }
            }
            else
                return false;
        }

        public bool deleteMail_13_loc(string kw)
        {
            if (this.search_13_loc(kw) && this.inHome_13_loc())
            {
                Thread.Sleep(1000);
                this.driver_13_loc
                    .FindElement(By
                    .XPath("/html/body/div[7]/div[3]/div/div[2]/div[2]/div/div/div/div[2]/div/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div[2]/div[1]/div/div/div[1]/div/div[1]/div"))
                    .Click();

                this.driver_13_loc
                    .FindElement(By
                    .XPath("/html/body/div[7]/div[3]/div/div[2]/div[2]/div/div/div/div[2]/div/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div[2]/div[1]/div/div/div[8]/div/div[1]"))
                    .Click();

                this.driver_13_loc
                    .FindElement(By
                    .XPath("/html/body/div[7]/div[3]/div/div[2]/div[2]/div/div/div/div[2]/div/div[1]/div/div[2]/div/div/div/div[2]/div[1]/div[2]/div[1]/div/div/div[2]/div[3]/div"))
                    .Click();

                return true;
            }
            else
            {
                return false;
            }
        }

        public void close()
        {
            this.driver_13_loc.Quit();
        }

        public bool signOut_13_loc()
        {
            if (this.inHome_13_loc())
            {
                this.driver_13_loc.Navigate().GoToUrl("https://accounts.google.com/Logout?hl=en&continue=https://mail.google.com/mail/&service=mail&timeStmp=1715622479&secTok=.AG5fkS8bm97TQbJPmOtiS6liDjoBnXjDKA&ec=GAdAFw");
                Thread.Sleep(2000);
                goToBaseUrl();
                return true;
            }
            else return false;
        }
    }
}
