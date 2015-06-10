using FinalProjectCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCore.Dao
{
     public interface IFavorDao
    {
         void AddFavor(Favor favor);

         void UpdateFavor(Favor favor);

         void DeleteFavor(Favor favor);

         IList<Favor> GetAllFavor();

         Favor GetFavorByName(string Product_Name);

         Favor GetFavorById(int Form_ID);

    }
}
