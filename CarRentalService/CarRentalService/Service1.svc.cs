using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace CarRentalService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class Service1 : IService1
    {
        public string InsertCarDetails(CarDetails carDetails)
        {
            string Message;
            try
            {    
                string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(ConString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into CarRentalTable(Marka, Model, Rok_produkcji, Moc_silnika, Rodzaj_paliwa) values(@CarBrand, @CarModel, @ProductionYear ,@EnginePower, @FuelType)", con);
                cmd.Parameters.AddWithValue("@CarBrand", carDetails.CarBrand);
                cmd.Parameters.AddWithValue("@CarModel", carDetails.CarModel);
                cmd.Parameters.AddWithValue("@ProductionYear", carDetails.ProductionYear);
                cmd.Parameters.AddWithValue("@EnginePower", carDetails.EnginePower);
                cmd.Parameters.AddWithValue("@FuelType", carDetails.FuelType);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Message = "Dane zostały wprowadzone";
                }
                else
                {
                    Message = "Dane nie zostały wprowadzone";
                }
                con.Close();
                return Message;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Message = "Wprowadź dane poprawnie";
                return Message;
            }

        }

        public string DeleteCarDetails(CarDetails carDetails)
        {
            string Message;
            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete CarRentalTable where Id=@Id", con);
            cmd.Parameters.AddWithValue("@Id", carDetails.Id);
            int result = cmd.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "Dane usunięte poprawnie";
            }
            else
            {
                Message = "Dane nie zostały usunięte";
            }
            con.Close();
            return Message;
        }

        public string UpdateCarDetails(CarDetails carDetails)
        {
            string Message;
            try
            {
                string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(ConString);
                con.Open();
                SqlCommand cmd = new SqlCommand("update CarRentalTable set Marka=@CarBrand, Model=@CarModel, Rok_produkcji=@ProductionYear, Moc_silnika=@EnginePower, Rodzaj_paliwa=@FuelType where Id=@Id", con);
                cmd.Parameters.AddWithValue("@Id", carDetails.Id);
                cmd.Parameters.AddWithValue("@CarBrand", carDetails.CarBrand);
                cmd.Parameters.AddWithValue("@CarModel", carDetails.CarModel);
                cmd.Parameters.AddWithValue("@ProductionYear", carDetails.ProductionYear);
                cmd.Parameters.AddWithValue("@EnginePower", carDetails.EnginePower);
                cmd.Parameters.AddWithValue("@FuelType", carDetails.FuelType);
                int result = cmd.ExecuteNonQuery();
                if (result == 1)
                {
                    Message = "Dane zaktualizowane poprawnie";
                }
                else
                {
                    Message = "Dane nie zostały zaktualizowane poprawnie";
                }
                con.Close();
                return Message;
            }
            catch (System.Data.SqlClient.SqlException)
            {
                Message = "Wprowadź dane poprawnie";
                return Message;
            }

        }

        public DataSet SelectCarDetails()
        {
            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CarRentalTable", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }

        public string RentCar(People p)
        {
            string Message;
            try
            {
                string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
                SqlConnection con = new SqlConnection(ConString);
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into People(Imie, Nazwisko, Rok_urodzenia, CarId) values(@Name, @Surname, @Date, @CarId)", con);
                SqlCommand cmd2 = new SqlCommand("select count(*) from People where CarId = @CarId", con);
                cmd2.Parameters.AddWithValue("@CarId", p.CarId);
                int result2 = (int)cmd2.ExecuteScalar();
                if (result2 > 0)
                {
                    Message = "Ten pojazd został już wypożyczony!";
                    con.Close();
                    return Message;
                }
                else
                {
                    cmd.Parameters.AddWithValue("@Name", p.Name);
                    cmd.Parameters.AddWithValue("@Surname", p.Surename);
                    cmd.Parameters.AddWithValue("@Date", p.Date);
                    cmd.Parameters.AddWithValue("@CarId", p.CarId);
                    int result = cmd.ExecuteNonQuery();
                    if (result == 1)
                    {
                        Message = "Dane zostały wprowadzone";
                    }
                    else
                    {
                        Message = "Dane nie zostały wprowadzone";
                    }
                    con.Close();
                    return Message;
                }
                

            }
            
            catch (System.Data.SqlTypes.SqlTypeException)
            {
                Message = "Wprowadź poprawną datę";
                return Message;
            }
            
        }

        public string DeletePeopleDetails(People p)
        {
            string Message;
            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            SqlCommand cmd = new SqlCommand("delete People where Id=@Id", con);
            SqlCommand cmd2 = new SqlCommand("select max(Id) from People", con);
            SqlCommand cmd3 = new SqlCommand("DBCC CHECKIDENT ('People', RESEED, 0);", con);
            cmd.Parameters.AddWithValue("@Id", p.Id);
            int result = cmd.ExecuteNonQuery();
            int max = cmd2.ExecuteNonQuery();
            if (result == 1)
            {
                Message = "Dane usunięte poprawnie";
                if (max == 0)
                {
                    cmd3.ExecuteNonQuery();
                }
            }
            else
            {
                Message = "Dane nie usunięte poprawnie";
            }

            con.Close();
            return Message;
        }

        public DataSet SelectPeopleDetails()
        {
            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from People", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            cmd.ExecuteNonQuery();
            con.Close();
            return ds;
        }
    }
}
