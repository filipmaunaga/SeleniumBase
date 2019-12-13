using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;


namespace SeleniumBase
{
    class Tests : SeleniumBaseClass
    {
        [Test]
        public void RunTest()
        {
            //this.Navigate("http://google.com/");
            //IWebElement el= this.FindElement(By.Name("q"));
            //this.SendKeys("something",true,el);
            //this.DoWait(4);
            this.Navigate("http://qa.todorowww.net/register"); 
            IWebElement el2 = this.FindElement(By.Name("zemlja"));
            var selection = new SelectElement(el2);
            this.DoWait(2);
            selection.SelectByText("Slovenija");
            this.DoWait(2);
            selection.SelectByValue("ba");
            this.DoWait(2);
        }
        [SetUp]
        public void SetUpTests()
        {
            this.Driver = new ChromeDriver();
            this.Wait = 2;
        }
        [TearDown]
        public void TearDownTests()
        {
            this.Close();
        }
    }
}
