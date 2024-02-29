using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurnUpQA.Pages
{
    public class LoginPage
    {
        public string baseUrl = "http://horse.industryconnect.io";
        public void Login(IWebDriver driver, string username, string password)
        {
           
            //enter url - Launch turnup portal and navigate to website login page
            driver.Navigate().GoToUrl(baseUrl);

            //Identify Username textbox - enter value
            IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
            usernameTextbox.SendKeys(username);

            //Identify Password textbox - enter value
            IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
            passwordTextbox.SendKeys(password);


            //For webpage to wait for 5 secs doing nothing
            Thread.Sleep(1000);
            //Identify login button
            IWebElement loginbutton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
            loginbutton.Click();


        }
    }
}
