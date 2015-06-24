using FinalProjectCore.Dao.Base;
using FinalProjectCore.Dao.Mapper;
using FinalProjectCore.Models;
using Spring.Data.Common;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCore.Dao.Impl
{
    public class FavorDao : GenericDao<Favor>, IFavorDao
    {
        override protected IRowMapper<Favor> GetRowMapper()
        {
            return new FavorRowMapper();
        }

        public void AddFavor(Favor favor)
        {
            string command = @"INSERT INTO Favor (Product_Name, Product_Num,Customer_Name,Customer_Phone,Customer_Email,Send_Method,Form_Remark) VALUES (@Product_Name, @Product_Num,@Customer_Name,@Customer_Phone,@Customer_Email,@Send_Method,@Form_Remark);";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Product_Name", DbType.String).Value = favor.Product_Name;
            parameters.Add("Product_Num", DbType.Int32).Value = favor.Product_Num;
            parameters.Add("Customer_Name", DbType.String).Value = favor.Customer_Name;
            parameters.Add("Customer_Phone", DbType.String).Value = favor.Customer_Phone;
            parameters.Add("Customer_Email", DbType.String).Value = favor.Customer_Email;
            parameters.Add("Send_Method", DbType.String).Value = favor.Send_Method;
            parameters.Add("Form_Remark", DbType.String).Value = favor.Form_Remark!=null?favor.Form_Remark:"";
         

            ExecuteNonQuery(command, parameters);
        }

        public void UpdateFavor(Favor favor)
        {
            string command = @"UPDATE Favor SET Product_Name = @Product_Name, Product_Num = @Product_Num, Customer_Name = @Customer_Name, Customer_Phone = @Customer_Phone, Customer_Email = @Customer_Email, Send_Method = @Send_Method, Form_Remark = @Form_Remark WHERE Form_ID = @Form_ID;";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Form_ID", DbType.Int32).Value = favor.Form_ID;
            parameters.Add("Product_Name", DbType.String).Value = favor.Product_Name;
            parameters.Add("Product_Num", DbType.Int32).Value = favor.Product_Num;
            parameters.Add("Customer_Name", DbType.String).Value = favor.Customer_Name;
            parameters.Add("Customer_Phone", DbType.String).Value = favor.Customer_Phone;
            parameters.Add("Customer_Email", DbType.String).Value = favor.Customer_Email;
            parameters.Add("Send_Method", DbType.String).Value = favor.Send_Method;
            parameters.Add("Form_Remark", DbType.String).Value = favor.Form_Remark;

            ExecuteNonQuery(command, parameters);
        }

        public void DeleteFavor(Favor favor)
        {
            string command = @"DELETE FROM Favor WHERE Form_ID = @Form_ID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Form_ID", DbType.Int32).Value = favor.Form_ID;

            ExecuteNonQuery(command, parameters);
        }

        public IList<Favor> GetAllFavor()
        {
            string command = @"SELECT * FROM Favor ORDER BY Form_ID ASC";
            IList<Favor> favor = ExecuteQueryWithRowMapper(command);
            return favor;
        }

        public Favor GetFavorByName(string name)
        {
            string command = @"SELECT * FROM Favor WHERE Product_Name = @Product_Name";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Product_Name", DbType.String).Value = name;

            IList<Favor> favor = ExecuteQueryWithRowMapper(command, parameters);
            if (favor.Count > 0)
            {
                return favor[0];
            }

            return null;
        }

        public Favor GetFavorById(int Form_ID)
        {
            string command = @"SELECT * FROM Favor WHERE Form_ID = @Form_ID";

            IDbParameters parameters = CreateDbParameters();
            parameters.Add("Form_ID", DbType.Int32).Value = Form_ID;

            IList<Favor> favor = ExecuteQueryWithRowMapper(command, parameters);
            if (favor.Count > 0)
            {
                return favor[0];
            }

            return null;
        }
    }
}
