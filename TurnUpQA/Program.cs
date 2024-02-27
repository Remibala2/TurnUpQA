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


//For webpage to wait for 5 secs doing nothing
Thread.Sleep(1000);
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

//###########################################Day2################

//Create a new Time Record

IWebElement AdminDropdown = driver.FindElement(By.XPath("//body/div[3]/div[1]/div[1]/ul[1]/li[5]/a[1]"));
AdminDropdown.Click();

//navigate to Time and Material page
IWebElement TimeAndMaterialOption = driver.FindElement(By.XPath("//a[contains(text(),'Time & Materials')]"));
TimeAndMaterialOption.Click();
driver.Manage().Window.FullScreen();

//click on Create New button
IWebElement CreateTM = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
CreateTM.Click();

//TypeCode
IWebElement TypeCode = driver.FindElement(By.XPath("//body/div[@id='container']/form[@id='TimeMaterialEditForm']/div[1]/div[1]/div[1]/span[1]/span[1]"));
TypeCode.Click();


//Code
IWebElement CodeTM = driver.FindElement(By.XPath("//input[@id='Code']"));
CodeTM.SendKeys("A943");

IWebElement DescriptionTM = driver.FindElement(By.XPath("//input[@id='Description']"));
DescriptionTM.SendKeys("Description");

IWebElement PricePerUnitTM = driver.FindElement(By.XPath("//body/div[@id='container']/form[@id='TimeMaterialEditForm']/div[1]/div[4]/div[1]/span[1]/span[1]/input[1]"));
PricePerUnitTM.SendKeys("1234");

IWebElement SaveButtonTM = driver.FindElement(By.XPath("//input[@id='SaveButton']"));
SaveButtonTM.Click();
