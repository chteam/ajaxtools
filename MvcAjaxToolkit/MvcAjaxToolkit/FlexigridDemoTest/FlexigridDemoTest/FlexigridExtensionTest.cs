using FlexigridMvcDemo;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using System.Data;
using System.Collections.Generic;
using System.Linq.Expressions;
using MvcAjaxToolkit;
using FlexigridMvcDemo.Models;
using System.Linq;
namespace FlexigridDemoTest
{
    
    
    /// <summary>
    ///This is a test class for FlexigridExtensionTest and is intended
    ///to contain all FlexigridExtensionTest Unit Tests
    ///</summary>
    [TestClass()]
    public class FlexigridExtensionTest
    {


        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Additional test attributes
        // 
        //You can use the following additional attributes as you write your tests:
        //
        //Use ClassInitialize to run code before running the first test in the class
        //[ClassInitialize()]
        //public static void MyClassInitialize(TestContext testContext)
        //{
        //}
        //
        //Use ClassCleanup to run code after all tests in a class have run
        //[ClassCleanup()]
        //public static void MyClassCleanup()
        //{
        //}
        //
        //Use TestInitialize to run code before running each test
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{
        //}
        //
        //Use TestCleanup to run code after each test has run
        //[TestCleanup()]
        //public void MyTestCleanup()
        //{
        //}
        //
        #endregion


        /// <summary>
        ///A test for ToFlexigridObject
        ///</summary>
        // TODO: Ensure that the UrlToTest attribute specifies a URL to an ASP.NET page (for example,
        // http://.../Default.aspx). This is necessary for the unit test to be executed on the web server,
        // whether you are testing a page, web service, or a WCF service.
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("E:\\UserCode\\FlexigridDemo\\FlexigridMvcDemo", "/")]
        [UrlToTest("http://localhost:1736/")]
        public void ToFlexigridObjectTest()
        {
            PagedList<UserInfo> json;
            using (var t1 = new FlexigridMvcDemo.Models.TEST1Entities())
                json = t1.UserInfo.OrderBy(c => c.Id).Pager(1, 10);
            
            var data = json.ToFlexigridObject(c => c.Id,
                x =>
                {
                    x.Add(c => c.Id)
                    .Add(c => c.Email)
                    .Add(c => c.Name)
                    .Add(c => c.Age)
                    .Add(c => 1);
                });
            Assert.AreEqual(1, data.page);
            Assert.AreEqual(10, data.rows.Count);
            Assert.AreEqual(5, data.rows[0].cell.Count);
        }
        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("E:\\UserCode\\FlexigridDemo\\FlexigridMvcDemo", "/")]
        [UrlToTest("http://localhost:1736/")]
        public void ToFlexigridObjectTest2()
        {
            PagedList<UserInfo> json;
            using (var t1 = new FlexigridMvcDemo.Models.TEST1Entities())
                json = t1.UserInfo.OrderBy(c => c.Id).Pager(1, 10);

            var data = json.ToFlexigridObject();
            Assert.AreEqual(1, data.page);
            Assert.AreEqual(10, data.rows.Count);
            //Assert.AreEqual("Id",data.rows[0].id);
         //   Assert.Inconclusive(string.Join(",",data.rows[0].cell));
            Assert.AreEqual(6, data.rows[0].cell.Count);
        }
        /// <summary>
        ///A test for ToFlexigridObject
        ///</summary>
        public void ToFlexigridObjectTest1Helper<T>()
            where T : class
        {
            PagedList<T> list = null; // TODO: Initialize to an appropriate value
            Expression<Func<T, object>> key = null; // TODO: Initialize to an appropriate value
            Action<FlexigridModelProperties<T>> properties = null; // TODO: Initialize to an appropriate value
            FlexgridData<T> expected = null; // TODO: Initialize to an appropriate value
            FlexgridData<T> actual;
            actual = FlexigridExtension.ToFlexigridObject<T>(list, key, properties);
            Assert.AreEqual(expected, actual);
            Assert.Inconclusive("Verify the correctness of this test method.");
        }

        [TestMethod()]
        [HostType("ASP.NET")]
        [AspNetDevelopmentServerHost("E:\\UserCode\\FlexigridDemo\\FlexigridMvcDemo", "/")]
        [UrlToTest("http://localhost:1736/")]
        public void ToFlexigridObjectTest1()
        {
            ToFlexigridObjectTest1Helper<GenericParameterHelper>();
        }
    }
}
