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
   
    public partial class Favori : Form
    {
        public IWebDriver driver;
        public Favori()
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
            System.Threading.Thread.Sleep(5000);
            try
            {
                

                driver.FindElement(By.Id("AuthenticationNavigation")).Click();

                driver.FindElement(By.Id("loginmail")).SendKeys(textBox1.Text);
                driver.FindElement(By.Id("loginpassword")).SendKeys(textBox2.Text);
                driver.FindElement(By.CssSelector("button[type='submit']")).Click();

                driver.FindElement(By.XPath("//*[@id='homepage']/ul[1]/li[1]/div[1]/div/div/a/img[1]")).Click();
                driver.FindElement(By.XPath("//*[@id='catalogcontent']/ul/li[1]/div/div[1]/i[1]")).Click();

                driver.FindElement(By.XPath("//*[@id='HeaderFavorite']/span/i")).Click();
                driver.Navigate().Back();
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
