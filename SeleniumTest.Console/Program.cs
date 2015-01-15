using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using TestCore.Services;

namespace SeleniumTest.Console
{
    class Program
    {
        static void Main(string[] args)
        {
           // RunAsync().Wait();
           // RunUserActionAsync().Wait();
           GetUserActionsSync();

        }

        private  static void GetUserActionsSync()
        {
            using (var driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:2267/");

                IWebElement from = driver.FindElementById("txtFromLocation");
                IWebElement to = driver.FindElementById("txtToLocation");
                IWebElement date = driver.FindElementById("txtDate");

                from.SendKeys(Keys.Control + "a");
                from.SendKeys(Keys.Delete);
                from.SendKeys("Antalya(Antalya)");
                //driver.FindElement(By.CssSelector("flight-search ui-autocomplete-input")).Click();
                from.SendKeys(Keys.Down);
                from.SendKeys(Keys.Tab);
                Thread.Sleep(5000);

                to.SendKeys(Keys.Control + "a");
                to.SendKeys(Keys.Delete);
                to.SendKeys("Istanbul(Sabiha Gokcen)");
                to.SendKeys(Keys.Down);
                to.SendKeys(Keys.Tab);
                Thread.Sleep(5000);

              
                to.SendKeys(Keys.Tab);
                to.SendKeys(Keys.Tab);
                to.SendKeys(Keys.Tab);
                to.SendKeys(Keys.Tab);
                to.SendKeys(Keys.Tab);
                to.SendKeys(Keys.Tab);
                
                //driver.FindElement(By.CssSelector("ui-corner-all")).Click();
                //driver.FindElementById("ui-id-3").Click();
                /*  date.SendKeys(Keys.Control + "a");
                    date.SendKeys(Keys.Delete);
                 */
                // date.Clear();
                // date.SendKeys("");

                // IWebElement dateElement = driver.FindElement(By.CssSelector("ui-datepicker-trigger"));
                // dateElement.Click();
                // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0, 3));
                // date.Clear();
                // date.SendKeys(Keys.Enter);
                // date.SendKeys("08.01.2015");

                IWebElement searchButton = driver.FindElement(By.CssSelector(string.Format("[data-bind*='{0}']", "click: search")));
                searchButton.SendKeys(Keys.Enter);
                Thread.Sleep(10000);
                driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0,10));
                driver.Close();
                //var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;
                // File.WriteAllText("result.txt", result);

                // Take a screenshot and save it into screen.png
                //driver.GetScreenshot().SaveAsFile(@"c:\screen.jpeg", ImageFormat.Jpeg);
            }
        }

        private async static Task  RunUserActionAsync()
        {
            IEnumerable<int> searchCollection = new[] {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
            Parallel.ForEach(searchCollection, async x => await GetUserActions());
        }

        private async static  Task GetUserActions()
        {
            
            using (var driver = new FirefoxDriver())
            {
                driver.Navigate().GoToUrl("http://localhost:2267/");

                IWebElement from = driver.FindElementById("txtFromLocation");
                IWebElement to = driver.FindElementById("txtToLocation");
                IWebElement date = driver.FindElementById("txtDate");
                from.SendKeys(Keys.Control + "a");
                from.SendKeys(Keys.Delete);

                /*  date.SendKeys(Keys.Control + "a");
                  date.SendKeys(Keys.Delete);
                 */
                from.SendKeys("Antalya");
                driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0, 2));
                from.SendKeys(Keys.ArrowDown);
                from.SendKeys(Keys.Enter);
                from.SendKeys(Keys.Tab);

                to.SendKeys(Keys.Control + "a");
                to.SendKeys(Keys.Delete);
                //driver.FindElement(By.CssSelector("ui-corner-all")).Click();
                //driver.FindElementById("ui-id-3").Click();
                to.SendKeys("İstanbul");
                driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0, 2));
                to.SendKeys(Keys.ArrowDown);
                to.SendKeys(Keys.Enter);
                to.SendKeys(Keys.Tab);

                //  date.Clear();
                // date.SendKeys("");

                //IWebElement dateElement = driver.FindElement(By.CssSelector("ui-datepicker-trigger"));
                // dateElement.Click();
                // driver.Manage().Timeouts().ImplicitlyWait(new TimeSpan(0, 0, 0, 3));
                //  date.Clear();
                //  date.SendKeys(Keys.Enter);
                // date.SendKeys("08.01.2015");

                IWebElement searchButton = driver.FindElement(By.CssSelector(string.Format("[data-bind*='{0}']", "click: search")));
                searchButton.SendKeys(Keys.Enter);

                //var result = driver.FindElementByXPath("//div[@id='case_login']/h3").Text;
                // File.WriteAllText("result.txt", result);

                // Take a screenshot and save it into screen.png
                //driver.GetScreenshot().SaveAsFile(@"c:\screen.jpeg", ImageFormat.Jpeg);
            }
        }

        static FlightApiTestService service = new FlightApiTestService();
        private async static Task RunAsync()
        {
           // IEnumerable<int> searchCollection = new[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };


           string key = await GetKey();
           IEnumerable<string> urlCollection = await service.GetTestUrls(20, key);
           Parallel.ForEach(urlCollection, async x => await GetToFireFox(x.ToString()));
        }

        private async static Task GetToFireFox(string searchKey)
        {
            FirefoxDriver firefoxDriver = new FirefoxDriver();
            firefoxDriver.Navigate().GoToUrl(searchKey);
           // firefoxDriver.FindElement(By.Id("gbqfq")).SendKeys(searchKey);
            //firefoxDriver.FindElement(By.Id("gbqfq")).SendKeys(Keys.Enter);
        }

        private static async Task<string> GetKey()
        {
            string authenticationKey = await service.GetAuthenticationKeyAsync();

            return authenticationKey;
        }
    }
}
