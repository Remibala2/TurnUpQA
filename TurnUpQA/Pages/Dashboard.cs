using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpQA.Pages
{
    public class Dashboard
    {
        public void NavigateToTMPage(IWebDriver driver)
        {
            IWebElement AdminDropdown = driver.FindElement(By.XPath("//body/div[3]/div[1]/div[1]/ul[1]/li[5]/a[1]"));
            AdminDropdown.Click();

            //navigate to Time and Material page
            IWebElement TimeAndMaterialOption = driver.FindElement(By.XPath("//a[contains(text(),'Time & Materials')]"));
            TimeAndMaterialOption.Click();
            driver.Manage().Window.FullScreen();
        }
        public void VerifyUser(IWebDriver driver)
        {
            //Check if the user is logged in correctly
            IWebElement user = driver.FindElement(By.XPath("//*[@id=\"logoutForm\"]/ul/li/a"));

            driver.Manage().Window.FullScreen();

            if (user.Text == "Hello hari!")
            {
                Console.WriteLine("User has logged in successfully");
            }
            else
            {
                Console.WriteLine("User has not logged in successfully :(");
            }
        }
    }
}
