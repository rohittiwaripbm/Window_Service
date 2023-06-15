using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;

namespace WindowsService1
{
    public class FetchData
    {
        public DataTable Fetch() 
        {
            #region Variables
            ConString Cstrings = new ConString();
            string connectionString = ConString.connectionString;
            List<UserTable> list = new List<UserTable>();
            #endregion

            #region FetchData
            MySqlConnection connection = new MySqlConnection();
            connection.ConnectionString = connectionString;
            connection.Open();
            string sql = "select * from usertable";
            MySqlCommand cmd = new MySqlCommand(sql, connection);
            MySqlDataReader reader = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);


            #region Commented Code
            //foreach (DataRow row in dt.Rows)
            //{
            //    UserTable table= new UserTable();
            //    table.Id= Convert.ToInt32(row["ID"]);
            //    table.Name= Convert.ToString(row["Name"]);
            //    table.Email = Convert.ToString(row["email"]);
            //    table.Mobile_no = Convert.ToInt32(row["mob_no"]);
            //    table.IsActive = Convert.ToBoolean(row["IsActive"]);
            //    list.Add(table);
            //}



            //while (reader.Read())
            //{
            //    UserTable table = new UserTable();
            //    table.Id = Convert.ToInt32(reader["Id"]);
            //    table.Name= Convert.ToString(reader["Name"]);
            //    string emails = reader["email"].ToString();
            //    emails = emails.Trim();
            //    table.Email = emails;
            //    table.Mobile_no = Convert.ToInt32(reader["mob_no"]);
            //    table.IsActive = Convert.ToBoolean(reader["IsActive"]);
            //   list.Add(table);

            //}
            #endregion



            connection.Close();
            #endregion

            return dt;
        }
    }
}
