using FinalProjectCore.Models;
using FinalProjectCore.Services;
using FinalProjectCore.Services.Impl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Http;

namespace FinalProjectWebApp.Controllers
{
    public class FavorController : ApiController
    {

        public IFavorService FavorService { get; set; }

        [HttpPost]
        public Favor AddFavor(Favor favor)
        {
            CheckFavorIsNotNullThrowException(favor);

            try
            {
                return FavorService.AddFavor(favor);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpPut]
        public Favor UpdateFavor(Favor favor)
        {
            CheckFavorIsNullThrowException(favor);

            try
            {
                FavorService.UpdateFavor(favor);
                return FavorService.GetFavorByName(favor.Product_Name);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpDelete]
        public void DeleteFavor(Favor favor)
        {
            try
            {
                FavorService.DeleteFavor(favor);
            }
            catch (Exception)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }
        }

        [HttpGet]
        public IList<Favor> GetAllFavor()
        {
            return FavorService.GetAllFavor();
        }

        [HttpGet]
        public Favor GetFavorById(Int32 Form_ID)
        {
            var favor = FavorService.GetFavorById(Form_ID);

            if (favor == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return favor;
        }

        [HttpGet]
        [ActionName("Product_Name")]
        public Favor GetFavorByName(string input)
        {
            var favor = FavorService.GetFavorByName(input);

            if (favor == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }

            return favor;
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果不存在則拋出錯誤.
        /// </summary>
        /// <param name="favor">
        ///     課程資料.
        /// </param>
        private void CheckFavorIsNullThrowException(Favor favor)
        {
            Favor dbFavor = FavorService.GetFavorById(favor.Form_ID);

            if (dbFavor == null)
            {
                throw new HttpResponseException(HttpStatusCode.NotFound);
            }
        }

        /// <summary>
        ///     檢查課程資料是否存在，如果存在則拋出錯誤.
        /// </summary>
        /// <param name="favor">
        ///     課程資料.
        /// </param>
        private void CheckFavorIsNotNullThrowException(Favor favor)
        {
            Favor dbFavor = FavorService.GetFavorById(favor.Form_ID);

            if (dbFavor != null)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
        }

    }
}