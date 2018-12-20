using System;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace ExclusiveCakesSeleniumTest
{
    class Program
    {
        public static IWebDriver wd;

        static void Main(string[] args)
        {

            Console.WriteLine("Input connection string: ");
            string conn = Console.ReadLine();

            wd = new ChromeDriver();
            wd.Navigate().GoToUrl(conn);

            try
            {
                wd.FindElement(By.Id("takeit")).Click();

                wd.Navigate().GoToUrl(conn + "/PieCatalogs/Catalog");

                wd.FindElement(By.Id("pie_1")).Click();
                wd.FindElement(By.Id("back")).Click();
                wd.FindElement(By.Id("pie_2")).Click();
                wd.FindElement(By.Id("back")).Click();
                wd.FindElement(By.Id("pie_3")).Click();
                wd.FindElement(By.Id("back")).Click();
                wd.FindElement(By.Id("pie_4")).Click();
                wd.FindElement(By.Id("back")).Click();

                wd.Navigate().GoToUrl(conn + "/Orders/Create");

                IWebElement cakeWight, custName, custPhone, comments;
                cakeWight = wd.FindElement(By.Id("cake_wight"));
                cakeWight.SendKeys("600");
                custName = wd.FindElement(By.Id("cust_name"));
                custName.SendKeys("John Doe");
                custPhone = wd.FindElement(By.Id("cast_phone"));
                custPhone.SendKeys("0000102030");
                //wd.FindElement(By.ClassName("custom-file-input")).Click(); Thread.Sleep(10000);
                comments = wd.FindElement(By.Id("comment"));
                comments.SendKeys("Here should be a comment, but it ");

                wd.FindElement(By.Id("submit")).Click();

                Console.WriteLine("\nDebugging is completed seccesfully!");

                Thread.Sleep(10000);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }
    }
}
