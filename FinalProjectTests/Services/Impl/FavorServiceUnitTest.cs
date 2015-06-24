﻿using Core;
using FinalProjectCore.Models;
using FinalProjectCore.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Context;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KuasCoreTests.Services.Impl
{
    [TestClass]
    public class FavorServiceUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    //assembly://MyAssembly/MyNamespace/ApplicationContext.xml
                    "~/Config/KuasCoreDatabase.xml",
                    "~/Config/KuasCorePointcut.xml",
                    "~/Config/KuasCoreTests.xml" 
                };
            }
        }

        #endregion

        public IFavorService CourseService { get; set; }

        [TestMethod]
        public void TestCourseService_AddCourse()
        {

            Favor course = new Favor();
            course.Id = "UnitTests";
            course.Name = "單元測試";
            course.Description = "請做出單元測試";
            CourseService.AddCourse(course);

            Favor dbCourse = CourseService.GetCourseByName(course.Name);
            Assert.IsNotNull(dbCourse);
            Assert.AreEqual(course.Name, dbCourse.Name);

            Console.WriteLine("課程編號為 = " + dbCourse.Id);
            Console.WriteLine("課程名稱為 = " + dbCourse.Name);
            Console.WriteLine("課程描述為 = " + dbCourse.Description);

            CourseService.DeleteCourse(dbCourse);
            dbCourse = CourseService.GetCourseByName(course.Name);
            Assert.IsNull(dbCourse);
        }

    }
}