using Microsoft.Win32;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml.Linq;
using System.Data;
using System.Data.SqlClient;
using System.Net;
using MainApp;
using System.Data;
using System.Data.SqlClient;
using MainApp.Mains;
using Backend;
using Backend.Repository;

namespace MainApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        public string connectionString = @"Data Source=.;Initial Catalog=LoginAndRegister;Integrated Security=true";

        public bool isvalid;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LableEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtemail.Focus();
        }

        private void txtemail_TextChanged(object sender, TextChangedEventArgs e)
        {
            String email = txtemail.Text.Trim().ToLower();
            if (string.IsNullOrEmpty(email))
            {
                txtemail.BorderBrush = Brushes.Red;
            }
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void LablePassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            txtPassword.Focus();

        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            String password = txtPassword.Password.Trim().ToLower().ToString();
            if (string.IsNullOrEmpty(password))
            {
                txtPassword.BorderBrush = Brushes.Red;
                txtemail.BorderBrush = Brushes.Green;

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtemail.Text) && !string.IsNullOrEmpty(txtPassword.Password))
            {
                MessageBox.Show("singed in is Succifully");
            }
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void imageclose_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void LablePasswordSignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtPasswordSignUp_PasswordChanged(object sender, RoutedEventArgs e)
        {
        }

        private void LableEmailSignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtemailSignUp_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void txtUsernameSignUp_TextChanged(object sender, TextChangedEventArgs e)
        {
        }

        private void LableUsernameSignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void LablePasswordcurrectSignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void txtPasswordcurrectSignUp_PasswordChanged(object sender, RoutedEventArgs e)
        {

        }

        private void txtcurrectPasswordSignUp_PasswordChanged(object sender, RoutedEventArgs e)
        {
        }

        private void LablecurrectPasswordSignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            SignUppage.Visibility = Visibility.Visible;
            MainSignUppage.Visibility = Visibility.Visible;
            SignInpage.Visibility = Visibility.Collapsed;
            MainSignIpPage.Visibility = Visibility.Collapsed;

        }

        private void SigninButton_Click(object sender, RoutedEventArgs e)
        {
            SignInpage.Visibility = Visibility.Visible;
            MainSignIpPage.Visibility = Visibility.Visible;
            SignUppage.Visibility = Visibility.Collapsed;
            MainSignUppage.Visibility = Visibility.Collapsed;
        }

        private void imagecloseSignUp_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }


        private void btnSignin_Click(object sender, RoutedEventArgs e)
        {
            //bool isValid = true;
            //isValid = checkEmployeisValidity();
                String username, password;  
                username = txtemail.Text;
                password = txtPassword.Password;
                SqlConnection conn = new SqlConnection(connectionString);
                try
                {
                    string query = "Select * From Registertbl where Email='"+txtemail.Text+"' AND password='" + txtPassword.Password+"'";
                    SqlDataAdapter sda = new SqlDataAdapter(query,conn);  
                    DataTable dataTable = new DataTable();
                    sda.Fill(dataTable);

                    if(dataTable.Rows.Count > 0 )
                    {
                        username = txtemail.Text;
                        password = txtPassword.Password;    
                        MainPage w1 = new MainPage(); 
                        w1.Show();
                        this.Hide();
                    }
                    else
                    {
                        MessageBox.Show("invalid login details","erorr");
                        txtemail.Clear();
                        txtPassword.Clear();
                        txtemail.Focus();
                    }
                }
                catch
                {
                    MessageBox.Show("erorr");
                }
                finally
                {
                    conn.Close();
                }
        }
        //private bool checkEmployeisValidity()
        //{
        //    bool isvalid = true;
        //    String email = txtemail.Text.Trim().ToLower();
        //    String pass = txtPassword.Password.Trim().ToLower();
        //    if (string.IsNullOrEmpty(email))
        //    {
        //        isvalid = false;
        //        mainborderemail.BorderBrush = Brushes.Red;
        //    }
        //    else if (string.IsNullOrEmpty(pass))
        //    {
        //        isvalid = false;
        //        mainborderemail.BorderBrush = Brushes.Green;
        //        mainpassborder.BorderBrush = Brushes.Red;
        //    }
        //    else
        //    {
        //        isvalid = true;
        //        mainborderemail.BorderBrush = Brushes.Green;
        //        mainpassborder.BorderBrush = Brushes.Green;
        //    }
        //    return isvalid;
        //}

        private void btnSungUp_Click(object sender, RoutedEventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                string query = $"Insert Into Registertbl (Email,username,password) VALUES(@Email,@username,@password)";
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Email", txtemailSignUp.Text);
                cmd.Parameters.AddWithValue("@username", txtUsernameSignUp.Text);
                cmd.Parameters.AddWithValue("@password", txtPasswordSignUp.Password);
                if (txtcurrectPasswordSignUp.Password == txtPasswordSignUp.Password)
                {
                    connection.Open();
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("not insert data");
            }
            finally
            {
                connection.Close();
                this.Close();
            }

        }
    }
}