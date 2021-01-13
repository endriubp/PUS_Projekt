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
    /// Interaction logic for Window2.xaml
    /// </summary>
    public partial class RentCarWindow : Window
    {
        public void showdata()
        {
            string ConString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=CarRentDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            SqlConnection con = new SqlConnection(ConString);
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from People", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            cmd.ExecuteNonQuery();

            DataGrid.ItemsSource = dt.DefaultView;
            con.Close();
        }
        public RentCarWindow()
        {
            InitializeComponent();
            showdata();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            MainWindow window = new MainWindow();
            window.Show();
            this.Close();
        }

        private void CarList_Click(object sender, RoutedEventArgs e)
        {
            CarListWindow window = new CarListWindow();
            window.Show();
        }

        private void EndRent_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.People p = new ServiceReference1.People();
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            try
            {
                if (string.IsNullOrEmpty(idtb.Text))
                    MessageBox.Show("Podaj ID pojazdu do usunięcia");
                else
                    p.Id = Convert.ToInt32(idtb.Text);
                service.DeletePeopleDetails(p);
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

        private void Rent_Click(object sender, RoutedEventArgs e)
        {
            ServiceReference1.People p = new ServiceReference1.People();
            ServiceReference1.Service1Client service = new ServiceReference1.Service1Client();
            try
            {
                if (string.IsNullOrEmpty(Nametb.Text) || string.IsNullOrWhiteSpace(SureNametb.Text))
                {
                    MessageBox.Show("Wpisz poprawnie dane");
                }
                else
                {
                    p.Name = Nametb.Text;
                    p.Surename = SureNametb.Text;
                }
                if(dp.SelectedDate == null)
                {
                    MessageBox.Show("Wprowadź datę");
                }
                else
                    p.Date = dp.SelectedDate.GetValueOrDefault();
                p.CarId = Convert.ToInt32(CarIDtb.Text);

                service.RentCar(p);
                showdata();
            }
            catch (System.ServiceModel.FaultException ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show(ex.Message.ToString() + " - Podaj poprawny identyfikator pojazdu");
            }
            
        }
    }
}
