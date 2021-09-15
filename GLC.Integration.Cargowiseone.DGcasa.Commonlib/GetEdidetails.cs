using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GLC.Integration.Cargowiseone.DGcasa.Commonlib
{
    public class GetEdidetails
    {
        public void insertgs08(string orderno, string gs08)
        {
            try
            {
                //PROD Connectionstring

                //string connectionString = @"Data Source=PROD01\CARGOPROD;Initial Catalog=Cargowiseone;Integrated Security=true";

                //Test Connectionstring

                string connectionString = @"Data Source=WEBDEV01;Initial Catalog=Cargowiseone;Integrated Security=true";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("sp_dgcasags09", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@orderNo", orderno);
                command.Parameters.AddWithValue("@gs08", gs08);                
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }

        public string getgs03(string orderno)
        {
            try
            {
                //PROD Connectionstring

                //string connectionString = @"Data Source=PROD01\CARGOPROD;Initial Catalog=Cargowiseone;Integrated Security=true";

                //Test Connectionstring

                string connectionString = @"Data Source=WEBDEV01;Initial Catalog=Cargowiseone;Integrated Security=true";

                SqlConnection connection = new SqlConnection(connectionString);
                SqlCommand command = new SqlCommand("sp_getgso8", connection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@orderNo", orderno);

                connection.Open();
                var codectn = command.ExecuteScalar();
                connection.Close();                

                return codectn.ToString();
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
    }
}
