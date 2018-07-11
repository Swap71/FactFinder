using NUnit.Framework;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FactFinder
{
    [TestFixture]
    public class CreatingStepLogs
    {
        public ExtentReports extent;
        public ExtentTest test;

[OneTimeSetUp]
public void StartReport()
        {
            string pth = System.Reflection.Assembly.GetCallingAssembly().CodeBase;
            string actualPath = pth.Substring(0, pth.LastIndexOf("bin"));
            string projectPath = new Uri(actualPath).LocalPath; // project path of your solution
                                                                // string projectPath = new Uri(actualPath)."C:/Users/Stellar/source/repos/FactFinder/FactFinder/"; // project path of your solution

            string reportPath = projectPath + "Reports\\testreport.html";

            // true if you want to append data to the report.  Replace existing report with new report.  False to create new report each time
            extent = new ExtentReports(reportPath);
        }

        [Test]
        public void StepLogsGeneartion()
        {
            test = extent.StartTest("StepLogsGeneartion");
            test.Log(LogStatus.Info, "START TEST1");
            test.Log(LogStatus.Info, "START TEST2");
            test.Log(LogStatus.Info, "START TEST3");
        }

        [OneTimeTearDown]
        public void TearDown()
        {
            extent.EndTest(test);
            test.Log(LogStatus.Info, "EndTest1");
            extent.Flush();
            test.Log(LogStatus.Info, "EndTest2");
            extent.Close();
            test.Log(LogStatus.Info, "EndTest3");
        }
    }
}
