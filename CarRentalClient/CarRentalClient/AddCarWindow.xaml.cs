using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CarRentalClient
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class AddCarWindow : Window
    {
        public void showdata()
        {
            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from CarRentalTable", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd.ExecuteNonQuery();

            DataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }
        public AddCarWindow()
        {
            InitializeComponent();
            showdata();
            cBox.Items.Add("Benzyna");
            cBox.Items.Add("Diesel");
            cBox.Items.Add("LPG");
        }

       

        private void Backbtn_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void AddCarbtn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ServiceReference1.CarDetails c = new ServiceReference1.CarDetails();
                if(string.IsNullOrEmpty(carbrandtb.Text) || string.IsNullOrWhiteSpace(carmodeltb.Text))
                {
                    MessageBox.Show("Wpisz poprawnie dane");
                }
                else
                {
                    c.CarBrand = carbrandtb.Text;
                    c.CarModel = carmodeltb.Text;
                }
                c.ProductionYear = Convert.ToInt32(productionyeartb.Text);
                c.EnginePower = Convert.ToInt32(enginepowertb.Text);
                c.FuelType = cBox.SelectedItem.ToString();

                ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
                service.InsertCarDetails(c);
                showdata();
            }
            catch(System.ServiceModel.FaultException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            catch(System.FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString() + " - w pola rok produkcji i moc silnika wpisz wartość liczbową ");
            }

        }

        private void UpdateCarbtn_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.CarDetails c = new ServiceReference1.CarDetails();
            try
            {
                
                if (string.IsNullOrEmpty(carbrandtb.Text) || string.IsNullOrWhiteSpace(carmodeltb.Text))
                {
                    MessageBox.Show("Wpisz poprawnie dane");
                }
                else
                {
                    c.CarBrand = carbrandtb.Text;
                    c.CarModel = carmodeltb.Text;
                }
                c.ProductionYear = Convert.ToInt32(productionyeartb.Text);
                c.EnginePower = Convert.ToInt32(enginepowertb.Text);
                c.FuelType = cBox.SelectedItem.ToString();
                c.Id = Convert.ToInt32(Idtb.Text);
                
                service.UpdateCarDetails(c);
                showdata();
            }
            catch (System.ServiceModel.FaultException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString() + " - w pola rok produkcji i moc silnika wpisz wartość liczbową ");
            }
        }

        private void DeleteCarbtn_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            ServiceReference1.CarDetails c = new ServiceReference1.CarDetails();
            try
            {
                if (string.IsNullOrEmpty(Idtb.Text))
                    MessageBox.Show("Podaj ID pojazdu do usunięcia");
                else
                    c.Id = Convert.ToInt32(Idtb.Text);
                service.DeleteCarDetails(c);
                showdata();
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString() + "Wprowadź wartość liczbową w polu ID");
            }
            catch (System.ServiceModel.FaultException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }

        }
    }
}
