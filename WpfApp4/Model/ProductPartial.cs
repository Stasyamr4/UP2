using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp4
{
    public partial class Product
    {

        public string CategoryName
        {
            get
            {
                return Category.Name;
            }
        }
        public string DiscountNum
        {
            get
            {
                return "Скидка: " + Discount + "%";
            }
        }
        public string SupplierName
        {
            get
            {
                return Supplier.Name;
            }
        }
        public string ProducerName
        {
            get
            {
                return Producer.Name;
            }
        }
    }
}
