using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuperMarketAssignment.Constant
{
   public class SuperMarketConstants
    {
        public const string RequestUri = "https://www.google.com/search?q=";

        public const double platinumCustomersDiscount = 50;
        public const double goldCustomersDiscount = 30;
        public const double sliverCustomersDiscount = 10;
        public const double totalCustomersDiscount = 100;

        public static int[] platinumCustomers = new int[] { 1053, 2696, 7543, 3268 };
        public static int[] goldCustomers = new int[] { 2051, 7419, 8635 };
        public static int[] silverCustomers = new int[] { 3426, 2222, 5148 };
    }
}
