using System.Collections;
using System.Data;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;

namespace MoGYSD.Services.Extensions
{
    public static class Staticsvvvv
    {
        public static List<int> UserProfile()
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            //string userId = HttpContext.User.GetUserId();
            //string userRoleId = db.Roles.First(c => c.Users.Select(i => i.UserId).Contains(userId)).Id;
            //var userprofiles = db.RoleProfiles.Where(p => p.RoleId == userRoleId).Select(p => p.TaskId).ToList();
            // return userprofiles;
            return new List<int>();
        }

        public static List<string> UserProfileByName()
        {
            //ApplicationDbContext db = new ApplicationDbContext();
            //string userId = HttpContext.Current.User.GetUserId();
            //string userRoleId = db.Roles.First(c => c.Users.Select(i => i.UserId).Contains(userId)).Id;

            //var userprofiles = db.RoleProfiles.Where(p => p.RoleId == userRoleId)
            //    .Select(p => p.SystemTask.Parent.Name + ":" + p.SystemTask.Name).ToList();
            //return userprofiles;
            return new List<string>();
        }
    }
    public static class EasyMD5vvv
    {
        private static string GetMd5Hash(byte[] data)
        {
            var sBuilder = new StringBuilder();
            for (var i = 0; i < data.Length; i++)
                sBuilder.Append(data[i].ToString("x2"));
            return sBuilder.ToString();
        }
        private static bool VerifyMd5Hash(byte[] data, string hash)
        {
            return 0 == StringComparer.OrdinalIgnoreCase.Compare(GetMd5Hash(data), hash);
        }
        public static string Hash(string data)
        {
            using (var md5 = MD5.Create())
                return GetMd5Hash(md5.ComputeHash(Encoding.UTF8.GetBytes(data)));
        }
        public static string Hash(FileStream data)
        {
            using (var md5 = MD5.Create())
                return GetMd5Hash(md5.ComputeHash(data));
        }
        public static bool Verify(string data, string hash)
        {
            using (var md5 = MD5.Create())
                return VerifyMd5Hash(md5.ComputeHash(Encoding.UTF8.GetBytes(data)), hash);
        }
        public static bool Verify(FileStream data, string hash)
        {
            using (var md5 = MD5.Create())
                return VerifyMd5Hash(md5.ComputeHash(data), hash);
        }
        public static DataTable CreateDataTable(IEnumerable source)
        {
            var table = new DataTable();
            var index = 0;
            var properties = new List<PropertyInfo>();
            foreach (var obj in source)
            {
                if (index == 0)
                {
                    foreach (var property in obj.GetType().GetProperties())
                    {
                        if (Nullable.GetUnderlyingType(property.PropertyType) != null)
                        {
                            continue;
                        }

                        properties.Add(property);
                        table.Columns.Add(new DataColumn(property.Name, property.PropertyType));
                    }
                }

                var values = new object[properties.Count];
                for (var i = 0; i < properties.Count; i++)
                {
                    values[i] = properties[i].GetValue(obj);
                }
                table.Rows.Add(values);
                index++;
            }
            return table;
        }
    }

}