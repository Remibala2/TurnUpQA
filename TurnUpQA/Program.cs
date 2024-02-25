//Selenium - Automation for TurnUp Portal
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

//Open browser - Chrome
IWebDriver driver = new ChromeDriver();


//enter url - Launch turnup portal and navigate to website login page
driver.Navigate().GoToUrl("http://horse.industryconnect.io");


//Identify Username textbox - enter value
IWebElement usernameTextbox = driver.FindElement(By.Id("UserName"));
usernameTextbox.SendKeys("hari");

//Identify Password textbox - enter value
IWebElement passwordTextbox = driver.FindElement(By.Id("Password"));
passwordTextbox.SendKeys("123123");

//Identify login button
IWebElement loginbutton = driver.FindElement(By.XPath("//*[@id=\"loginForm\"]/form/div[3]/input[1]"));
loginbutton.Click();

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


