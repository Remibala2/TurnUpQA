using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpQA.Pages
{
    public class TMPage
    {
        public void VerifyCreatedRecord(IWebDriver driver)
        {
            IWebElement NewRecordTM = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            NewRecordTM.Click();

            if (NewRecordTM.Text == "T943")
            {
                Console.WriteLine("Time/Material created successfully");
            }
            else
            {
                Console.WriteLine("Time/Material not created:(");
            }
        }

        public void VerifyLastRecord(IWebDriver driver)
        {
            IWebElement GoToLastPageTM = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            GoToLastPageTM.Click();
           
        }

       
        public void CreateTMRecord(IWebDriver driver)
        {
            //Create a new Time Record
            //click on Create New button
            IWebElement CreateTM = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            CreateTM.Click();

            //TypeCode
            //Main Dropdown
            IWebElement TypeCodeMainDropdown = driver.FindElement(By.XPath("//span[contains(text(),'select')]"));
            TypeCodeMainDropdown.Click();
            Thread.Sleep(2000);
            IWebElement TypeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            TypeCodeDropdown.Click();


            //Code
            IWebElement CodeTM = driver.FindElement(By.XPath("//input[@id='Code']"));
            CodeTM.SendKeys("T943");

            IWebElement DescriptionTM = driver.FindElement(By.XPath("//input[@id='Description']"));
            DescriptionTM.SendKeys("Description");

            IWebElement PricePerUnitTM = driver.FindElement(By.XPath("//body/div[@id='container']/form[@id='TimeMaterialEditForm']/div[1]/div[4]/div[1]/span[1]/span[1]/input[1]"));
            PricePerUnitTM.SendKeys("1234");

            IWebElement SaveButtonTM = driver.FindElement(By.XPath("//input[@id='SaveButton']"));
            SaveButtonTM.Click();
            driver.Manage().Window.FullScreen();
            Thread.Sleep(2000);

        }

        public void EditTMRecord(IWebDriver driver)
        {
            //Edit Time/Material

            Thread.Sleep(2000);
            IWebElement GoToLastPageTM = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
            GoToLastPageTM.Click();
            Thread.Sleep(2000);

            IWebElement EditRecordTM = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[1]"));
            EditRecordTM.Click();

            driver.Manage().Window.FullScreen();
            driver.FindElement(By.Id("Code")).Clear();
            driver.FindElement(By.Id("Code")).SendKeys("T4543Edited");
            driver.FindElement(By.Id("Description")).Clear();
            driver.FindElement(By.Id("Description")).SendKeys("Description Edited");
            Thread.Sleep(1000);
            
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).Click();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//input[@id='Price']")).Clear();
            driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).Click();
            Thread.Sleep(1000);
            driver.FindElement(By.Id("Price")).SendKeys("17");


         //   driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).SendKeys("34");


            IWebElement TMEditSaveButton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
            TMEditSaveButton.Click();

            Thread.Sleep(2000);
            driver.Manage().Window.Maximize();
            Thread.Sleep(2000);
            driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();
            Thread.Sleep(2000);

            Console.WriteLine("Last item is edited");

        }
        public void DeleteTMRecord(IWebDriver driver)
        {
            //Delete Time/Material Module
            IWebElement DeleteRecordTM = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            DeleteRecordTM.Click();
            driver.SwitchTo().Alert().Accept();
            Thread.Sleep(1000);
            Console.WriteLine("Last Record deleted");


        }
    }
}
