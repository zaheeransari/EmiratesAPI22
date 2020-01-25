using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace nCoreCMSBL
{
    public class Util
    {
        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        private static T GetItem<T>(DataRow dr)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach (DataColumn column in dr.Table.Columns)
            {
                foreach (PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName && !string.IsNullOrEmpty(Convert.ToString(dr[column.ColumnName])))
                        pro.SetValue(obj, dr[column.ColumnName], null);
                    else
                        continue;
                }
            }
            return obj;
        }

		public static List<T> ContructList<T>(IDataReader dr)
		{
			List<T> objList = new List<T>();
			while (dr.Read())
			{
				//T objT = default(T);
				T objT = Activator.CreateInstance<T>();
				PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
				for (int col = 0; col <= dr.FieldCount - 1; col++)
				{
					foreach (PropertyDescriptor prop in properties)
					{
						if (prop.Name.ToUpper() == dr.GetName(col).ToUpper() && !string.IsNullOrEmpty(Convert.ToString(dr.GetValue(col))))
						{
							prop.SetValue(objT, Convert.ChangeType(dr.GetValue(col), prop.PropertyType));
						}
					}
				}
				objList.Add(objT);

			}
			return objList;
		}

		#region base64Encode
		/// <summary>
		/// Encode Password
		/// </summary>
		/// <returns>returns string </returns>
		public static string base64Encode(string data)
        {
            try
            {
                byte[] encData_byte = new byte[data.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(data);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception e)
            {
                throw new Exception("Error in base64Encode" + e.Message);
            }
        }
        #endregion

    }
}
