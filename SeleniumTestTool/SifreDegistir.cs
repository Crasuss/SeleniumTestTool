using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumTestTool
{
    public partial class SifreDegistir : Form
    {
        IWebDriver driver;
        public SifreDegistir()
        {
            InitializeComponent();
        }

        public void takeScreenShot(string filename, IWebDriver driver)
        {
            ITakesScreenshot ss = (ITakesScreenshot)driver;
            Screenshot screenshot = ss.GetScreenshot();
            screenshot.SaveAsFile("C:\\Users\\LENOVO\\Desktop\\screenshot\\" + filename, ScreenshotImageFormat.Jpeg);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            driver = new FirefoxDriver();
            string link = @"https://www.1v1y.com/";
            driver.Navigate().GoToUrl(link);

            try
            {
                driver.FindElement(By.Id("AuthenticationNavigation")).Click();

                driver.FindElement(By.Id("loginmail")).SendKeys(textBox1.Text);
                driver.FindElement(By.Id("loginpassword")).SendKeys(textBox2.Text);
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();



                driver.FindElement(By.XPath("//*[@id='ProfileNavigation']/div[1]")).Click();

                driver.FindElement(By.XPath(".//*[@Id='ProfileNavigationDetail']/a[5]")).Click();
                driver.FindElement(By.Id("OldPassword")).SendKeys(textBox3.Text);
                driver.FindElement(By.Id("NewPassword")).SendKeys(textBox4.Text);

                driver.FindElement(By.Id("ConfirmPassword")).SendKeys(textBox5.Text);
                driver.FindElement(By.XPath("//*[@id='changepasswordform']/div[4]/button")).Click();
            }
            catch (Exception)
            {
                Console.WriteLine("hata var");
                int i = 1;
                takeScreenShot("Error Screenshot " + i, driver);
                i++;
            }

        }
    }
}
