﻿using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurnUpQA.Utilities;

namespace TurnUpQA.Pages
{
    public class TimeMaterialPage
    {
        public void CreateTimeMaterialRecord(IWebDriver driver)
        {
            //Create a new Time record

            //Click on Create new button
            IWebElement createNewButton = driver.FindElement(By.XPath("//*[@id=\"container\"]/p/a"));
            createNewButton.Click();

            //Select Time from dropdown
            IWebElement typeCodeMainDropdown = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[1]/div/span[1]/span"));
            typeCodeMainDropdown.Click();
            IWebElement typeCodeDropdown = driver.FindElement(By.XPath("//*[@id=\"TypeCode_listbox\"]/li[2]"));
            typeCodeDropdown.Click();

            //Enter Code
            IWebElement codeTextbox = driver.FindElement(By.Id("Code"));
            codeTextbox.SendKeys("DTU65");

            //Enter Description
            IWebElement descriptionTextbox = driver.FindElement(By.Id("Description"));
            descriptionTextbox.SendKeys("Description");

            //Enter the price
            WaitUtils.WaitToBeClickable(driver, "XPath", "//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]", 1);

            IWebElement priceTextbox = driver.FindElement(By.XPath("//*[@id=\"TimeMaterialEditForm\"]/div/div[4]/div/span[1]/span/input[1]"));
            priceTextbox.SendKeys("5");

            //Click on the Save Button
            WaitUtils.WaitToBeVisible(driver, "Id", "SaveButton", 2);

            IWebElement saveButton = driver.FindElement(By.Id("SaveButton"));
            saveButton.Click();

            Thread.Sleep(2000);

            //Check if a new time record has been created successfully

            IWebElement goToLastpageButton = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[4]/a[4]/span"));
            goToLastpageButton.Click();

            IWebElement newRecordCode = driver.FindElement(By.XPath("//*[@id='tmsGrid']/div[3]/table/tbody/tr[last()]/td[1]"));
            //if (newRecordCode.Text == "February2024")
            //{
            //    Assert.Pass("New Material/Time Record has been created successfully");
            //}
            //else
            //{
            //    Assert.Fail("New Material/Time Record has not been created :( :( :(");
            //}

            Assert.That((newRecordCode.Text == "DTU65"), "New Material/Time Record has not been created");
        }

        public void EditTimeMaterialRecord(IWebDriver driver)
        {
            //Code for Edit Time Record
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            //Click on Edit Button
            IWebElement editButton = driver.FindElement(By.XPath("//tbody/tr[last()]/td[5]/a[1]"));
            editButton.Click();
            Thread.Sleep(3000);

            //Edit Code in Code Textbox
            IWebElement editCodeTextbox = driver.FindElement(By.Id("Code"));
            editCodeTextbox.Clear();
            editCodeTextbox.SendKeys("DTU65");

            //Edit Description in Description Textbox
            IWebElement editDescriptionTextBox = driver.FindElement(By.Id("Description"));
            editDescriptionTextBox.Clear();
            editDescriptionTextBox.SendKeys("IC2023Edited");

            //Edit Price in Price Textbox
            WaitUtils.WaitToBeVisible(driver, "XPath", "//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]", 3);
            IWebElement editPriceOverlappingTag = driver.FindElement(By.XPath("//*[@id='TimeMaterialEditForm']/div/div[4]/div/span[1]/span/input[1]"));
            IWebElement editPriceTextBox = driver.FindElement(By.Id("Price"));
            editPriceOverlappingTag.Click();
            editPriceTextBox.Clear();
            editPriceOverlappingTag.Click();
            editPriceTextBox.SendKeys("500");

            //Click on save button
            IWebElement editSaveButton = driver.FindElement(By.Id("SaveButton"));
            editSaveButton.Click();
            Thread.Sleep(4000);

            // Clock on goToLastPage Button
            IWebElement editGoToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));
            editGoToLastPageButton.Click();

            IWebElement editedCode = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            IWebElement EditedDescription = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[3]"));

            //if (editedCode.Text == "IC2023Edited" && EditedDescription.Text == "IC2023Edited")
            //{
            //    Console.WriteLine("Time Record has been updated successfully");
            //}
            //else
            //{
            //    Console.WriteLine("Time Record has not been updated");
            //}
            Assert.That((editedCode.Text == "DTU65"), "Time Record has not been updated");
        }

        public void DeleteTimeMaterialRecord(IWebDriver driver)
        {
            //Code for Delete Time Record
            IWebElement goToLastPageButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[4]/a[4]/span"));

            Thread.Sleep(3000);
            goToLastPageButton.Click();
            Thread.Sleep(3000);

            //Click on delete button
            IWebElement deleteButton = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[5]/a[2]"));
            deleteButton.Click();

            IAlert simpleAlert = driver.SwitchTo().Alert();
            simpleAlert.Accept();

            IWebElement lastCodeInTable = driver.FindElement(By.XPath("//*[@id=\"tmsGrid\"]/div[3]/table/tbody/tr[last()]/td[1]"));
            Assert.That((lastCodeInTable.Text.Equals("DTU65")), "Time Record has not been deleted");
        }
        }
    }
