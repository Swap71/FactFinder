using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactFinder
{
    class POMFF
    {
        IWebDriver driver;
        // EditMAFSL1 p = new EditMAFSL1();
        // int t = P.i;
        // int i =1 
        // int i = 3;
        // for(int j= 10;j<=20;j++)
        //        {
        //  if (name.Contains("TOM"))
        //       {
        //[FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_txtName']")]
        //  [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_txtName']")]//Testing 
        //  [FindsBy(How = How.ClassName, Using = "RadInputMgr RadInputMgr_trynkett RadInput_Enabled_trynkett")]
        //   [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtName')]")] // Imp
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_memberslogin_Login1_UserName']")] 
     

        public IWebElement Givenname2 { get; set; }



        //[FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_txtNumber']")]
        //      [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_txtNumber']")]
        //   [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtNumber')]")] // Imp
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_memberslogin_Login1_Password']")]
        
        //  [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl44_txtNumber']")]


        //  private IWebElement Password { get; set; }
        private IWebElement PSWD2 { get; set; }

        //[FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_ManageACNNumber']")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_ManageABNNumber']")]



        private IWebElement ACN2 { get; set; }

        // }
        //[FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_ManageABNNumber']")]
        //  [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_ManageABNNumber']")]
        //   [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'ManageABNNumber')]")] // Imp
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_ClientName']")]
        


        //  private IWebElement Password { get; set; }
        private IWebElement ABN2 { get; set; }

        // [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_txtPhone']")]
        //  [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_txtPhone']")]
        [FindsBy(How = How.XPath, Using = "//input[contains(@id, 'txtPhone')]")] // Imp
                                                                                 //    wait.Until(ExpectedConditions.ElementIsVisible(By.XPath("//input[contains(@id, 'txtPhone')]")));


        //  private IWebElement Password { get; set; }
        private IWebElement OPhone2 { get; set; }


        // [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_txtFax']")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_txtFax']")]

        //  private IWebElement Password { get; set; }
        private IWebElement OFax2 { get; set; }

        //[FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_txtAddress1']")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_txtAddress1']")]

        private IWebElement Address2 { get; set; }
        //  private IWebElement Password { get; set; }

        //[FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_txtAddress2']")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_txtAddress2']")]

        private IWebElement Address3 { get; set; }



        // [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_txtSuburb']")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_txtSuburb']")]

        private IWebElement Suburb2 { get; set; }


        //  [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_txtPostcode']")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_txtPostcode']")]

        private IWebElement Postcode2 { get; set; }


        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_memberslogin_Login1_LoginButton']")]
        private IWebElement SigiInButton2 { get; set; }

        [FindsBy(How = How.Id, Using = "txtClientEmail")]

        private IWebElement Hemail2 { get; set; }

        //   [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_txtPostalAddress1']")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_txtPostalAddress1']")]
        private IWebElement Paddr2 { get; set; }

        // [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_txtPostalSuburb']")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_txtPostalSuburb']")]
        private IWebElement Psubr2 { get; set; }

        // [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl02_ctl03_txtPostalPostcode']")]
        [FindsBy(How = How.XPath, Using = ".//*[@id='ctl00_ctl00_cph1_cph1_rgManageAFSL_ctl00_ctl26_txtPostcode']")]
        private IWebElement Pcode2 { get; set; }


        [FindsBy(How = How.XPath, Using = "//button[@title='Update']")] // Imp

        public IWebElement Update1 { get; set; }


        public void EnterGivenName2(string givenName)

        {

            Givenname2.Clear();

            Givenname2.SendKeys(givenName);


        }




        public void EnterPSWD2(string afsl2)

        {
            PSWD2.Clear();

            PSWD2.SendKeys(afsl2);

        }

        public void EnterClient(string acn2)


        {


            ACN2.Clear();

            ACN2.SendKeys(acn2);


        }
        public void EnterABN2(string abn2)

        {


            ABN2.Clear();

            ABN2.SendKeys(abn2);

        }
        public void EnterOPhone1(string ophone2)

        {


            OPhone2.Clear();

            OPhone2.SendKeys(ophone2);

        }
        public void EnterOFax2(string ofax2)

        {


            OFax2.Clear();

            OFax2.SendKeys(ofax2);

        }
        public void EnterAddr2(string address2)

        {


            Address2.Clear();

            Address2.SendKeys(address2);

        }
        public void EnterAddr3(string address3)

        {


            Address3.Clear();

            Address3.SendKeys(address3);

        }
        public void EnterSubr1(string suburb2)

        {

            Suburb2.Clear();

            Suburb2.SendKeys(suburb2);


        }
        public void EnterPostcode1(string pc2)


        {
            Postcode2.Clear();

            Postcode2.SendKeys(pc2);


            // Pcm.Clear();


            //  var selectTest = new SelectElement(Pcm);

            // selectTest.SelectByValue(pcm);
        }
        public void EnterPaddr2(string padd2)

        {

            Paddr2.Clear();

            Paddr2.SendKeys(padd2);


        }
        public void EnterPsubr2(string psub2)

        {

            Psubr2.Clear();

            Psubr2.SendKeys(psub2);


        }
        public void EnterPcode1(string pcode2)

        {

            Pcode2.Clear();

            Pcode2.SendKeys(pcode2);


        }


        public void EnterUpdate()

        {

            //   Update1.Clear();

            Update1.Click();


        }

    }
}
