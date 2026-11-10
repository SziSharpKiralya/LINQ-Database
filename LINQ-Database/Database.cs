using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace LINQ_Database
{
    internal class Database
    {
        private string connectionString = "server=localhost;database=diakok;uid=root;pwd=;";
        public List<Diak> DiakokBetoltese()
        {
            List<Diak> diakok = new List<Diak>();
            using(MySqlConnection connectiom = new MySqlConnection(connectionString))
            {
                string query = "SELECT * FROM diakok";
                using (MySqlCommand command = new MySqlCommand(query, connectiom))
                {
                    connectiom.Open();
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string nev = reader.GetString("nev");
                            int eletkor = reader.GetInt32("eletkor");
                            string osztaly = reader.GetString("osztaly");
                            double atlag = reader.GetDouble("atlag");

                            Diak diak = new Diak(nev, eletkor, osztaly, atlag);
                            diakok.Add(diak);
                        }
                    }
                }
            }
            return diakok;
        }
    }
}
