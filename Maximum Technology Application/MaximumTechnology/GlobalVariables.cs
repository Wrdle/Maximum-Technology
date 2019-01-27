using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumTechnology
{
    public class GlobalVariables
    {
        public static decimal cartPrice;
        public static List<stCart> cart = new List<stCart>();
        public static int iItems;
    }
    public static class User
    {
        public static long ID;
        public static string Username;
        public static string Firstname;
        public static string Lastname;
        public static int AccessLevel;
        public static bool isStaff;
    }

    public struct stCart
    {
        public string ModelNo;
        public string Name;
        public decimal Price;
        public int invID;
        public decimal dGST;

        public stCart(string modelno, string name, int qty, decimal price, int invid, decimal dgst)
        {
            ModelNo = modelno;
            Name = name;
            Price = price;
            invID = invid;
            dGST = dgst;

        }
    }
}
