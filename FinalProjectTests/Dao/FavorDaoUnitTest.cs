
using FinalProjectCore.Dao;
using FinalProjectCore.Dao.Impl;
using FinalProjectCore.Models;
using FinalProjectCore.Services.Impl;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Spring.Testing.Microsoft;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCoreTests.Dao
{
    [TestClass]
    public class FavorDaoUnitTest : AbstractDependencyInjectionSpringContextTests
    {

        #region Spring 單元測試必寫的內容

        override protected string[] ConfigLocations
        {
            get
            {
                return new String[] { 
                    "~/Config/FinalProjectCoreDatabase.xml",
                    "~/Config/FinalProjectCorePointcut.xml",
                    "~/Config/FinalProjectCoreTests.xml" 
                };
            }
        }

        #endregion

        public IFavorDao FavorDao { get; set; }


        [TestMethod]
        public void TestFavorDao_AddFavor()
        {
            Favor favor = new Favor();
            favor.Form_ID = 1;
            favor.Product_Name = "單元測試";
            favor.Product_Num = 2;
            favor.Customer_Name = "請做出單元測試";
            favor.Customer_Phone = "請做出單元測試";
            favor.Customer_Email = "請做出單元測試";
            favor.Send_Method = "請做出單元測試";
            favor.Form_Remark = "請做出單元測試";
           FavorDao.AddFavor(favor);

           Favor dbFavor = FavorDao.GetFavorByName(favor.Product_Name);
            Assert.IsNotNull(dbFavor);
            Assert.AreEqual(favor.Name, dbFavor.Name);

            Console.WriteLine("課程編號為 = " + favor.Form_ID);
            Console.WriteLine("課程名稱為 = " + favor.Product_Name);
            Console.WriteLine("課程描述為 = " + favor.Product_Num);
            Console.WriteLine("課程編號為 = " + favor.Customer_Name);
            Console.WriteLine("課程名稱為 = " + favor.Customer_Phone);
            Console.WriteLine("課程描述為 = " + favor.Customer_Email);
            Console.WriteLine("課程名稱為 = " + favor.Send_Method);
            Console.WriteLine("課程描述為 = " + favor.Form_Remark);

            FavorDao.DeleteFavor(dbFavor);
            dbFavor = FavorDao.GetFavorByName(favor.Product_Name);
            Assert.IsNull(dbFavor);
        }

    }
}


