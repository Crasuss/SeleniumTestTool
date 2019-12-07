using OpenQA.Selenium.Firefox;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;

namespace SeleniumTestTool
{
    public partial class Form2 : Form
    {
        
        IWebDriver driver;
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                driver = new FirefoxDriver(); 
                string link = @"https://www.1v1y.com/";
                driver.Manage().Timeouts();


                driver.Navigate().GoToUrl(link);

                driver.FindElement(By.XPath(".//*[@Id='AuthenticationNavigation']/a[2]")).Click();
                driver.FindElement(By.Id("registermail")).SendKeys(txtMail.Text);
                driver.FindElement(By.Id("registername")).SendKeys(txtName.Text);
                driver.FindElement(By.Id("registersurname")).SendKeys(txtSurname.Text);
                driver.FindElement(By.Id("registerpassword")).SendKeys(txtPassword.Text);
                if (rbErkek.Checked)
                {
                    driver.FindElement(By.Id("registersexmale")).Click();
                }
                else if (rbBayan.Checked)
                {
                    driver.FindElement(By.Id("registersexfemale")).Click();
                }


                driver.FindElement(By.CssSelector("option[value='22']")).Click();
                driver.FindElement(By.XPath("/html/body/div[6]/div[2]/div/div[1]/section[1]/div[2]/form/div[6]/div[2]/div[2]/div/select[2]/option[13]")).Click();
                driver.FindElement(By.CssSelector("option[value='1990']")).Click();


                driver.FindElement(By.XPath("/html/body/div[6]/div[2]/div/div[1]/section[1]/div[2]/form/div[7]/label/span")).Click();
                driver.FindElement(By.XPath("/html/body/div[6]/div[2]/div/div[1]/section[1]/div[2]/form/div[8]/label/span")).Click();
                driver.FindElement(By.XPath("/html/body/div[6]/div[2]/div/div[1]/section[1]/div[2]/form/button")).Click();

            }
            catch (Exception )
            {
                
                 Console.WriteLine("hata var");
                int i = 1;
                takeScreenShot("Error Screenshot " + i, driver);
                i++;
                // test.Log(LogStatus.Info, "Screenshot - " + test.AddScreenCapture("C:\\Users\\LENOVO\\Desktop"));
            }

            // driver.FindElement(By.XPath("//*[@id='registerbirthdateday']/select")).SendKeys("12");
            //driver.FindElement(By.XPath("//*[@id='registerbirthdatemonth']/select")).SendKeys(cbAy.SelectedText);
            //driver.FindElement(By.XPath("//*[@id='registerbirthdateyear']")).SendKeys(cbYıl.Text);
        }

        void takeScreenShot(string filename, IWebDriver driver)
        {
            ITakesScreenshot ss = (ITakesScreenshot)driver;
            Screenshot screenshot = ss.GetScreenshot();
            screenshot.SaveAsFile("C:\\Users\\LENOVO\\Desktop\\screenshot\\" + filename, ScreenshotImageFormat.Jpeg);
        }

       
    }
}
