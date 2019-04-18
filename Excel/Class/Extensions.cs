using System.Data;

namespace Excel.Class
{
    public static class Extensions
    {
        public static void AddRange(this DataColumnCollection dt, string[] columns)
        {
            foreach (var item in columns)
            {
                dt.Add(item);
            }
        }
    }
}
