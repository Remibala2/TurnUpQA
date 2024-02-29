//Selenium - Automation for TurnUp Portal
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TurnUpQA.Pages;

public class Program
{
    private static void Main(string[] args)
    {
        //Open browser - Chrome
        IWebDriver driver = new ChromeDriver();

        LoginPage loginPageObj = new LoginPage();
        Dashboard homepage = new Dashboard();
        TMPage TMPage = new TMPage();

        //Login User
        loginPageObj.Login(driver, "hari", "123123");


        //Verify Newly Created record
        driver.Manage().Window.FullScreen();
        Thread.Sleep(2000);
        homepage.NavigateToTMPage(driver);
        driver.Manage().Window.FullScreen();
        Thread.Sleep(2000);
        TMPage.VerifyLastRecord(driver);
        driver.Manage().Window.FullScreen();
        Thread.Sleep(2000);
        homepage.VerifyUser(driver);

        //Edit Last Record
        TMPage.EditTMRecord(driver);
        driver.Manage().Window.FullScreen();
        Thread.Sleep(2000);
        TMPage.VerifyLastRecord(driver);

        //Delete Last Record

        Thread.Sleep(2000);
        TMPage.DeleteTMRecord(driver);
        driver.Manage().Window.FullScreen();
        Thread.Sleep(2000);
        TMPage.VerifyLastRecord(driver);


    }
}