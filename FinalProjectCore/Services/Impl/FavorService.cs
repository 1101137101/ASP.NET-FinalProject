using FinalProjectCore.Dao;
using FinalProjectCore.Dao.Impl;
using FinalProjectCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCore.Services.Impl
{
    public class FavorService : IFavorService
    {
        public IFavorDao FavorDao { get; set; }

        public Favor AddFavor(Favor favor)
        {
            FavorDao.AddFavor(favor);
            return GetFavorByName(favor.Product_Name);
        }

        public void UpdateFavor(Favor favor)
        {
            FavorDao.UpdateFavor(favor);
        }

        public void DeleteFavor(Favor favor)
        {
            favor = FavorDao.GetFavorByName(favor.Product_Name);

            if (favor != null)
            {
                FavorDao.DeleteFavor(favor);
            }
        }

        public IList<Favor> GetAllFavor()
        {
            return FavorDao.GetAllFavor();
        }

        public Favor GetFavorByName(string Product_Name)
        {
            return FavorDao.GetFavorByName(Product_Name);
        }

        public Favor GetFavorById(int Form_ID)
        {
            return FavorDao.GetFavorById(Form_ID);
        }
    }
}
