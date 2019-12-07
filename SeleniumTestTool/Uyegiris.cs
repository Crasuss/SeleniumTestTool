using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SeleniumTestTool
{

    public partial class Uyegiris : Form
    {
        public IWebDriver driver;
        

        public void takeScreenShot(string filename, IWebDriver driver)
        {
            ITakesScreenshot ss = (ITakesScreenshot)driver;
            Screenshot screenshot = ss.GetScreenshot();
            screenshot.SaveAsFile("C:\\Users\\LENOVO\\Desktop\\screenshot\\" + filename, ScreenshotImageFormat.Jpeg);
        }

        //public static List<string> GetUsername()
        //{

        //    SqlConnection con = new SqlConnection("Data Source=DESKTOP-3IURO6N;Initial Catalog=selenium;Integrated Security=True");
        //    con.Open();
        //    Console.WriteLine("db connected");
        //    SqlCommand kmt = new SqlCommand("Select kisi from uye_giris", con);

        //    SqlDataReader dr = kmt.ExecuteReader();


        //    List<string> account = new List<string>();
        //    while (dr.Read())
        //    {
        //        account.Add(Convert.ToString(dr[0]));
        //    }
        //    foreach (string i in account)
        //    {
        //        Console.WriteLine(i);
        //    }
        //    return account;

        //}
        //public static List<string> Getpassword()
        //{

        //    SqlConnection con = new SqlConnection("Data Source=DESKTOP-3IURO6N;Initial Catalog=selenium;Integrated Security=True");
        //    con.Open();
        //    Console.WriteLine("db connected");
        //    SqlCommand kmt = new SqlCommand("Select sifre from uye_giris", con);
        //    SqlDataReader dr = kmt.ExecuteReader();
        //    //Dictionary
        //    List<string> account1 = new List<string>();

        //    while (dr.Read())
        //    {


        //        account1.Add(Convert.ToString(dr[0]));

        //    }
        //    foreach (var i in account1)
        //    {
        //        Console.WriteLine(i);
        //    }

        //    return account1;

        //}

        public Uyegiris()
        {
            InitializeComponent();
        }

        private void uyeGiris_Load(object sender, EventArgs e)
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

                    driver.FindElement(By.Id("AuthenticationNavigation")).Click();
                    driver.FindElement(By.Id("loginmail")).SendKeys(txtMail.Text);
                    driver.FindElement(By.Id("loginpassword")).SendKeys(txtSifre.Text);
                    driver.FindElement(By.CssSelector("button[type='submit']")).Click();
                    driver.FindElement(By.XPath("/html/body/div[8]/div[2]/div/div[1]/div[3]/a")).Click();


                //List<Dictionary<List<string>, List<string>>> dicList = new List<Dictionary<List<string>, List<string>>>();

                //List<string> username = GetUsername();
                //List<string> password = Getpassword();

                ////dicList.Add( username, password);

                //driver.FindElement(By.Id("AuthenticationNavigation")).Click();
                ////foreach(var u in username)
                ////{

                ////}

                ////foreach(var p in username)
                ////{


                ////}



                //foreach (var item in username.Zip(password, (a, b) => new { A = a, B = b }))
                //{
                //    var a = item.A;
                //    var b = item.B;

                //    driver.FindElement(By.Id("loginmail")).SendKeys(a);
                //    driver.FindElement(By.Id("loginpassword")).SendKeys(b);
                //    driver.FindElement(By.CssSelector("button[type='submit']")).Click();
                //    driver.FindElement(By.XPath("/html/body/div[8]/div[2]/div/div[1]/div[3]/a")).Click();
                //    driver.FindElement(By.Id("loginmail")).Clear();
                //    driver.FindElement(By.Id("loginpassword")).Clear();
                //}
            }
            catch (Exception)
            {
                Console.WriteLine("hata var");
                int i = 1;
                takeScreenShot("Error Screenshot " + i, driver);
                i++;

            }
            }
        
        private void txtMail_TextChanged(object sender, EventArgs e)
        {
             

        }

        private void txtSifre_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
