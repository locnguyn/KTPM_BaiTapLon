using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Test_Gmail_Driver_13_Loc;

namespace Selenium_13_Loc_Tester
{
    [TestClass]
    public class UnitTest1
    {
        public TestContext TestContext { get; set; }
        private Selenium_13_Loc selenium_13_loc;

        [TestInitialize]
        public void SetUp()
        {
            selenium_13_loc = new Selenium_13_Loc();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\TestData_13_Loc\TestDataLogin_13_Loc.csv", "TestDataLogin_13_Loc#csv", DataAccessMethod.Sequential)]
        public void TestLoginMethod_13_loc()
        {
            string email_13_loc = TestContext.DataRow[1].ToString();
            string password_13_loc = TestContext.DataRow[2].ToString();
            string expectedResult_13_loc = TestContext.DataRow[3].ToString();

            string actualResult_13_loc = selenium_13_loc.login_13_loc(email_13_loc, password_13_loc);
            Assert.AreEqual(expectedResult_13_loc, actualResult_13_loc);
            selenium_13_loc.close();
        }

        [TestMethod]
        [DataSource("Microsoft.VisualStudio.TestTools.DataSource.CSV",
            @".\TestData_13_Loc\TestDataSendEmail_13_Loc.csv", "TestDataSendEmail_13_Loc#csv", DataAccessMethod.Sequential)]
        public void TestSendEmailMethod_13_loc()
        {
            string recipients_13_loc = TestContext.DataRow[1].ToString();
            string subject_13_loc = TestContext.DataRow[2].ToString();
            string content_13_loc = TestContext.DataRow[3].ToString();
            string expectedResult_13_loc = TestContext.DataRow[4].ToString();

            selenium_13_loc.login_13_loc("ktpm.13.loc", "1234567890A@a");
            string actualResult_13_loc = selenium_13_loc.sendEmail_13_loc(recipients_13_loc, subject_13_loc, content_13_loc);
            Assert.AreEqual(expectedResult_13_loc, actualResult_13_loc);
            selenium_13_loc.close();
        }
    }
}
