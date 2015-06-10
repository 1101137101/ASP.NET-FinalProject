using FinalProjectCore.Models;
using Spring.Data.Generic;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCore.Dao.Mapper
{
    class FavorRowMapper : IRowMapper<Favor>
    {
        public Favor MapRow(IDataReader dataReader, int rowNum)
        {
            Favor target = new Favor();

            target.Form_ID = dataReader.GetInt32(dataReader.GetOrdinal("Form_ID"));
            target.Product_Name = dataReader.GetString(dataReader.GetOrdinal("Product_Name"));
            target.Product_Num = dataReader.GetInt32(dataReader.GetOrdinal("Product_Num"));
            target.Customer_Name = dataReader.GetString(dataReader.GetOrdinal("Customer_Name"));
            target.Customer_Phone = dataReader.GetString(dataReader.GetOrdinal("Customer_Phone"));
            target.Customer_Email = dataReader.GetString(dataReader.GetOrdinal("Customer_Email"));
            target.Send_Method = dataReader.GetString(dataReader.GetOrdinal("Send_Method"));
            target.Form_Remark = dataReader.GetString(dataReader.GetOrdinal("Form_Remark"));
       
            return target;
        }
    }
}
