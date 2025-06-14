using DevExpress.DataAccess.Native.Data;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;

namespace MedicalStoreManagementSystem.DAO
{
    internal class Connection
    {
        private static string sql = "server=TRANLONG\\TRANLONG;database=MedicalStore;integrated security=true;server=MSI\\SQLEXPRESS;database=Demo;integrated security=true;";
        private static SqlConnection conn = new SqlConnection(sql);
        public static void Excute(string que, Dictionary<string, object> dic = null)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(que, conn);
            if (dic != null)
            {
                foreach (string key in dic.Keys)
                {
                    cmd.Parameters.Add(new SqlParameter(key, dic[key]));
                }
            }
            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public static void ExcutePara(string que, List<SqlParameter> parameters = null)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(que, conn);

            if (parameters != null)
            {
                foreach (var parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
            }

            try
            {
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }
        public static System.Data.DataTable Query(string que, Dictionary<string, Object> dic = null)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand(que, conn);
            if (dic != null)
            {
                foreach (string key in dic.Keys)
                    cmd.Parameters.Add(new SqlParameter(key, dic[key]));
            }
            System.Data.DataTable dt = new System.Data.DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            conn.Close();
            return dt;
        }
        public static object GetFieldValue(string tableName, string columnName, string conditionColumn, object conditionValue)
        {
            using (SqlConnection conn = new SqlConnection(sql))
            {
                conn.Open();

                string query = $"SELECT {columnName} FROM {tableName} WHERE {conditionColumn} = @{conditionColumn}";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue($"@{conditionColumn}", conditionValue);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int columnIndex = reader.GetOrdinal(columnName);
                            return reader.GetValue(columnIndex);
                        }
                        else
                        {
                            return null; // Trả về null nếu không có dữ liệu
                        }
                    }
                }
            }
        }
        public static byte[] GetImage(string tableName, string columnName, string conditionColumn, object conditionValue)
        {
            using (SqlConnection conn = new SqlConnection(sql))
            {
                conn.Open();

                string query = $"SELECT {columnName} FROM {tableName} WHERE {conditionColumn} = @{conditionColumn}";
                using (SqlCommand command = new SqlCommand(query, conn))
                {
                    command.Parameters.AddWithValue($"@{conditionColumn}", conditionValue);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            int columnIndex = reader.GetOrdinal(columnName);
                            if (!reader.IsDBNull(columnIndex))
                            {
                                // Chuyển đổi dữ liệu hình ảnh từ kiểu IMAGE sang byte[]
                                byte[] imageData = (byte[])reader[columnIndex];
                                return imageData;
                            }
                        }
                    }
                }
            }
            return null;
        }

    }
}
