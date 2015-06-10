using FinalProjectCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCore.Services
{
    public interface IFavorService
    {
        Favor AddFavor(Favor favor);

        void UpdateFavor(Favor favor);

        void DeleteFavor(Favor favor);

        IList<Favor> GetAllFavor();

        Favor GetFavorByName(string Product_Name);

        Favor GetFavorById(int Form_ID);
    }
}
