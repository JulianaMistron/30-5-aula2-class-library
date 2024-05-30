using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic;
using Models;
using System.Linq.Expressions;
using System.Runtime.ExceptionServices;
using System.Text;

namespace Repositories
{
    public class CarRepository
    {
        string strConn = "Data Source=127.0.0.1;Initial Catalog=30-5-aula2-class-library;User id=sa;Password=SqlServer2019!; TrustServerCertificate=true;";
        SqlConnection conn;
        private object car;

        public CarRepository()
        {
            conn = new SqlConnection(strConn);
            conn.Open();
        }
        public bool Insert(Car car)
        {
            bool result = false;

            try
            {

                SqlCommand cmd = new SqlCommand(Car.INSERT, conn);
                cmd.Parameters.Add(new SqlParameter("@Name", car.Name));
                cmd.Parameters.Add(new SqlParameter("@Color", car.Color));
                cmd.Parameters.Add(new SqlParameter("@Year", car.Year));
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                return result;
            }
            finally
            {
                conn.Close();
            }
            return result;

        }
        public bool Update(Car car)
        {
            bool result = false;
            try
            {
                string sql = "UPDATE CAR set Name =@Name, Color = @Color, Year = @Year WHERE id = @id";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.Add(new SqlParameter("@Name", car.Name));
                cmd.Parameters.Add(new SqlParameter("@Color", car.Color));
                cmd.Parameters.Add(new SqlParameter("@Year", car.Year));
                cmd.Parameters.Add(new SqlParameter("@Id", car.Id));
                cmd.ExecuteNonQuery();
                result = true;
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }
        public bool Delete(int id)
        {
            bool result = false;

            try
            {
                SqlCommand cmd = new SqlCommand(Car.DELETE, conn);
                cmd.Parameters.Add(new SqlParameter("@Id", id));
                return (cmd.ExecuteNonQuery() > 0);
            }
            catch (Exception)
            {
                result = false;
            }
            finally
            {
                conn.Close();
            }
            return result;
        }

        public List<Car> GetAll()
        {
            List<Car> cars = new List<Car>();

            StringBuilder sb = new StringBuilder();//stringbuilder: concatenação das strings
            sb.Append("SELECT id, name, color, year FROM CAR");

            try
            {

                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Car car = new Car();
                    car.Id = reader.GetInt32(0);
                    car.Name = reader.GetString(1);
                    car.Color = reader.GetString(2);
                    car.Year = reader.GetInt32(3);
                    cars.Add(car);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return cars;
        }
        public Car Get(int id)
        {

            StringBuilder sb = new StringBuilder();//stringbuilder: concatenação das strings
            sb.Append("SELECT Id, Name, Color, Year FROM CAR WHERE iD = @Id");
            Car car = new();
            try
            {
                SqlCommand cmd = new SqlCommand(sb.ToString(), conn);
                cmd.Parameters.Add(new SqlParameter("@Id", id));

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    car.Id = reader.GetInt32(0);
                    car.Name = reader.GetString(1);
                    car.Color = reader.GetString(2);
                    car.Year = reader.GetInt32(3);
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
            }
            return car;
        }
    }
}