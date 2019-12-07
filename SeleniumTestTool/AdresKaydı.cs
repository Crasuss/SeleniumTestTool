using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
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
    public partial class AdresKaydı : Form
    {
        public AdresKaydı()
        {
            InitializeComponent();
        }

        private void AdresKaydı_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string email = kgiris.mail;

            string şifre = kgiris.sifre;



            IWebDriver driver = new FirefoxDriver();
            string link = @"https://www.1v1y.com/";
            driver.Navigate().GoToUrl(link);


            driver.FindElement(By.XPath(".//*[@id='projectHeader']/nav[1]/nav[1]/a[1]")).Click();
            driver.FindElement(By.Id("loginmail")).SendKeys(email);
            driver.FindElement(By.Id("loginpassword")).SendKeys(şifre);

            System.Threading.Thread.Sleep(10000);

            driver.FindElement(By.XPath(".//*[@id='loginlightbox']/div[1]/form/button")).Click();

            System.Threading.Thread.Sleep(1000);

            driver.FindElement(By.XPath(".//*[@id='ProfileNavigation']/div[1]")).Click();
            driver.FindElement(By.XPath(".//*[@id='ProfileNavigationDetail']/a[3]")).Click();
            driver.FindElement(By.XPath(".//*[@id='CustomerAddresses']/div[2]/address/a[1]")).Click();
            
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[3]/input")).Clear();
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[3]/input")).SendKeys(textBox1.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[5]/textarea")).Clear();
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[5]/textarea")).SendKeys(textBox2.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[9]/input")).Click();
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[9]/input")).SendKeys(textBox3.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[11]/input")).Clear();
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[11]/input")).SendKeys(textBox4.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[2]/input")).Clear();
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[2]/input")).SendKeys(textBox5.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[4]/input")).Clear();
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[4]/input")).SendKeys(textBox6.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[7]/select")).SendKeys(comboBox1.Text);
            driver.FindElement(By.XPath(".//*[@id='addressform']/div[8]/select")).SendKeys(comboBox2.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[10]/input")).Clear();
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[10]/input")).SendKeys(textBox7.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[15]/button")).Click();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            IWebDriver driver = new FirefoxDriver();
            string link = @"https://www.1v1y.com/";
            driver.Navigate().GoToUrl(link);
            string email = kgiris.mail;

            string password = kgiris.sifre;




            driver.FindElement(By.XPath(".//*[@id='projectHeader']/nav[1]/nav[1]/a[1]")).Click();
            System.Threading.Thread.Sleep(10000);
            driver.FindElement(By.Id("loginmail")).SendKeys(email);
            driver.FindElement(By.Id("loginpassword")).SendKeys(password);
            System.Threading.Thread.Sleep(10000);
            driver.FindElement(By.XPath(".//*[@id='loginlightbox']/div[1]/form/button")).Click();

            System.Threading.Thread.Sleep(1000);

            driver.FindElement(By.XPath(".//*[@id='ProfileNavigation']/div[1]")).Click();
            driver.FindElement(By.XPath(".//*//*[@id='ProfileNavigationDetail']/a[3]")).Click();
            driver.FindElement(By.XPath(".//*[@id='CustomerAddresses']/div[1]/a")).Click();
            System.Threading.Thread.Sleep(10000);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[3]/input")).SendKeys(textBox1.Text);

            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[5]/textarea")).SendKeys(textBox2.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[9]/input")).SendKeys(textBox3.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[11]/input")).SendKeys(textBox4.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[2]/input")).SendKeys(textBox5.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[4]/input")).SendKeys(textBox6.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[7]/select")).SendKeys(comboBox1.Text);
            driver.FindElement(By.XPath(".//*[@id='addressform']/div[8]/select")).SendKeys(comboBox2.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[10]/input")).SendKeys(textBox7.Text);
            driver.FindElement(By.XPath(".//*//*[@id='addressform']/div[15]/button")).Click();
        }
    }
}
