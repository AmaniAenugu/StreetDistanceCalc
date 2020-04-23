using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication7.Models;

namespace WebApplication7
{
    public static class Data
    {
        private static List<Street> DataList = new List<Street>();


        public static void SaveData(Street street)
        {
            DataList.Add(street);

        }

        public static List<Street> GetStreets()
        {
            return DataList;

        }
    }
}
