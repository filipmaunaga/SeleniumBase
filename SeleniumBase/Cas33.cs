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
    class Cas33 : SeleniumBaseClass
    {


        [Test]
        public void Test()
        {
            this.Navigate("http://shop.qa.rs/");
            DoWait(2);

           

            IWebElement pro = this.FindElement(By.XPath("(//select[@name='quantity'])[3]"));
            var selection = new SelectElement(pro);
            selection.SelectByValue("10");
            DoWait(2);
            this.FindElement(By.XPath("(//input[@type='submit' and @value='ORDER NOW'])[3]"))?.Click();
            DoWait(2);
            IWebElement quantity = this.FindElement(By.XPath("//tbody//tr[1]/td[2]"));
            IWebElement ppi = this.FindElement(By.XPath("//tbody//tr[1]/td[3]"));

            IWebElement total = this.FindElement(By.XPath("//tbody//tr[1]/td[4]"));
            DoWait(2);
            string q1 = quantity.Text;
            int q2 = Convert.ToInt32(q1);
            string p1 = ppi.Text;
            int p2 = Convert.ToInt32(p1);
            string t1 = ppi.Text;
            int t2 = Convert.ToInt32(t1);

            if (q2 * p2 == t2)
            {
                Assert.Pass("Prosao");

            }
            else
                Assert.Fail("Nije");



        }
        [SetUp]
        public void SetUpTests()
        {
            this.Driver = new ChromeDriver();
        }
        [TearDown]
        public void TearDownTests()
        {
            this.Close();
        }
    }
}