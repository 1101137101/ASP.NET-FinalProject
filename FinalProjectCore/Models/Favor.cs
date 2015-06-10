using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProjectCore.Models
{
    public class Favor
    {
        public int Form_ID { get; set; }

        public string Product_Name { get; set; }

        public int Product_Num { get; set; }

        public string Customer_Name { get; set; }

        public string Customer_Phone { get; set; }

        public string Customer_Email { get; set; }

        public string Send_Method { get; set; }

        public string Form_Remark { get; set; }     

        public override string ToString()
        {
            return "favor: Form_ID = " + Form_ID + ", Product_Name = " + Product_Name + ".";
        }
    }
}
