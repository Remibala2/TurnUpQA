//Selenium - Automation for TurnUp Portal
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

internal class Program
{
    private static void Main(string[] args)
    {
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
        //Check the newly created entry
        IWebElement GoToLastPageTM = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]"));
        GoToLastPageTM.Click();

        driver.Manage().Window.FullScreen();
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
        
        Thread.Sleep(2000);
        GoToLastPageTM.Click();
        Thread.Sleep(2000);

        //Delete Time/Material Module
        IWebElement DeleteRecordTM = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
        DeleteRecordTM.Click();
        driver.SwitchTo().Alert().Accept();
        Thread.Sleep(1000);
        Console.WriteLine("Last Record deleted");

        //Edit Time/Material

        Thread.Sleep(2000);
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
    //    driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).Clear();
        Thread.Sleep(1000);
   //     driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span")).SendKeys("7");

       
        driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]")).SendKeys("34");
      

        IWebElement TMEditSaveButton = driver.FindElement(By.XPath("//*[@id=\"SaveButton\"]"));
        TMEditSaveButton.Click();
        
        Thread.Sleep(2000);
        driver.Manage().Window.Maximize();
        Thread.Sleep(2000);
        driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]")).Click();
        Thread.Sleep(2000);

        Console.WriteLine("Last item edited");
    }
}