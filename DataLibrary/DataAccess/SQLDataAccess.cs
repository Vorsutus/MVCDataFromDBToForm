using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataLibrary.DataAccess
{
    //not storing data here so making it static
    public static class SQLDataAccess
    {
        //passing in connection string value defaulted to the MVCDemoDB (most common scenarios)
        public static string GetConnectionString(string connectionName = "MVCDemoDB")
        {
            //might have to add System.Configuration to the References
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }

        //LoadData into the model T (generic parameter), returning a List of the Model T (if no parameters needed)
        public static List<T> LoadData<T>(string sql)
        {
            //connect to SQL
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                //using sql connection get the string we passed in and add it to the enumerable T, but as a List T
                return cnn.Query<T>(sql).ToList();
            }
        }

        //returns number of rows effected
        //Saves one Model using the SQL statement
        //T denotes a generic parameter that can be anything
        public static int SaveData<T>(string sql, T data)
        {
            //connect to SQL
            using (IDbConnection cnn = new SqlConnection(GetConnectionString()))
            {
                //data is the parameters, but they should already be the same as the parameters in the sql server
                return cnn.Execute(sql, data);
            }
        }
    }

}
