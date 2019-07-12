using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Excel
{
    public static class Extensions
    {
        //=============================================================================================================================================================
        public static void AddRange(this DataColumnCollection dt, string[] columns)
        {
            foreach (var item in columns)
            {
                dt.Add(item);
            }
        }
        //=============================================================================================================================================================
        public static string RemoverAcentuacao(this string text)
        {
            return new string(text
                .Normalize(NormalizationForm.FormD)
                .Where(ch => char.GetUnicodeCategory(ch) != UnicodeCategory.NonSpacingMark)
                .ToArray());
        }
        //=============================================================================================================================================================
        public static bool IsNullOrEmpty(this string text)
        {
            var t = string.IsNullOrEmpty(text);
            return t;
        }
        //=============================================================================================================================================================
               
        public static DataTable ToDataTable(this List<Tuple<string, string>> list)

        {
            DataTable tmp = new DataTable();
            var columns = new[] { "CNPJ", "VALOR", }; // Cria um array de string.
            tmp.Columns.AddRange(columns.Select(c => new DataColumn(c)).ToArray());

            foreach (var itemList in list)
            {
                tmp.Rows.Add(new object[2] { itemList.Item1, itemList.Item2 }); //adiociona ao DataTable
            }

            return tmp;

        }        

        //=============================================================================================================================================================
    }
}
