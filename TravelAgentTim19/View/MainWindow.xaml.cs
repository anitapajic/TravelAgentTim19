﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using TravelAgentTim19.Model;
using TravelAgentTim19.Model.Enum;
using TravelAgentTim19.Repository;
using TravelAgentTim19.Service;

namespace TravelAgentTim19.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainRepository MainRepository;
        public UserService UserService;
        public MainWindow()
        {
            MainRepository = new MainRepository();
            UserService = new UserService(MainRepository);
            InitializeComponent();
        }
        private void Border_MouseDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void Image_MouseUp(object sender, MouseButtonEventArgs e)
        {
            MainRepository.Save();
            Application.Current.Shutdown();
        }
       
        private void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape && WindowState == WindowState.Maximized)
            {
                WindowState = WindowState.Normal;
            }
        }
        
        
        private void passwordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(PasswordBox.Password) && PasswordBox.Password.Length > 0)
                TextPassword.Visibility = Visibility.Collapsed;
            else
                TextPassword.Visibility = Visibility.Visible;
        }
        
        private void textPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            PasswordBox.Focus();
        }


        private void SignInFormButton_Click(object sender, RoutedEventArgs e)
        {
            bool login = UserService.Login(TxtEmail.Text, PasswordBox.Password);
            if (login)
            {
                bool found = false;
                User user = MainRepository.UserRepository.GetUserByEmail(TxtEmail.Text);
                if (TxtEmail.Text.Equals(user.Email) && PasswordBox.Password.Equals(user.Password))
                {
                    if (user.Role == Role.Agent)
                    {
                        AgentMainWindow agentMainWindow = new AgentMainWindow(MainRepository);
                        agentMainWindow.Show();
                        Close();
                    }
                    else if(user.Role == Role.Client)
                    {
                        UserMainWindow userMainWindow = new UserMainWindow();
                        userMainWindow.Show(); 
                        Close();
                    }
                    found = true;
                }
                if (found == false)
                {
                    MessageBox.Show("User does not exist!");
                }
            }
            else
            {
                MessageBox.Show("Invalid data!");
            }
        }
        
        private void SignUpFormButton_Click(object sender, RoutedEventArgs e)
        {
            bool registered = UserService.Register(SignUpFNameBox.Text, SignUpLNameBox.Text, SignUpEmailBox.Text,
                SignUpPasswordBox.Password, SignUpPassword2Box.Password);
            if (registered)
            {
                SignUpFNameBox.Text = null;
                SignUpLNameBox.Text = null;
                SignUpEmailBox.Text = null;
                SignUpPasswordBox.Password = null;
                SignUpPassword2Box.Password = null;
            }
            MessageBox.Show(registered ? "Successfully Signed Up" : "Unsuccessfully Signed Up");
        }

        private void emailBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(TxtEmail.Text) && TxtEmail.Text.Length > 0)
                TextEmail.Visibility = Visibility.Collapsed;
            else
                TextEmail.Visibility = Visibility.Visible;
        }
        

        private void textEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TxtEmail.Focus();
        }

        
        private void SignUpButton_Click(object sender, RoutedEventArgs e)
        {
            
            SignUpCanvas.Visibility = Visibility.Hidden;
            SignInCanvas.Visibility = Visibility.Visible;
            
            SignUpPanel.Visibility = Visibility.Hidden;
            SignInPanel.Visibility = Visibility.Visible;
            
            SignUpFormPanel.Visibility = Visibility.Visible;
            SignInFormPanel.Visibility = Visibility.Hidden;
            
            SignUpBorder.Background = Brushes.White;
            SignInBorder.Background = new LinearGradientBrush(
                new GradientStopCollection()
                {
                    new GradientStop(Color.FromRgb(58, 169, 173), 0),
                    new GradientStop(Color.FromRgb(58, 173, 161), 1)
                },
                new Point(0, 0),
                new Point(1, 1)
            );
            MyGrid.ColumnDefinitions.Clear(); // Clear existing column definitions

            MyGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.5, GridUnitType.Star) });
            MyGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
                
        }
        
        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            SignUpCanvas.Visibility = Visibility.Visible;
            SignInCanvas.Visibility = Visibility.Hidden;
            
            SignUpPanel.Visibility = Visibility.Visible;
            SignInPanel.Visibility = Visibility.Hidden;
            
            SignUpFormPanel.Visibility = Visibility.Hidden;
            SignInFormPanel.Visibility = Visibility.Visible;
            
            SignInBorder.Background = Brushes.White;
            SignUpBorder.Background = new LinearGradientBrush(
                new GradientStopCollection()
                {
                    new GradientStop(Color.FromRgb(58, 169, 173), 0),
                    new GradientStop(Color.FromRgb(58, 173, 161), 1)
                },
                new Point(0, 0),
                new Point(1, 1)
            );
            MyGrid.ColumnDefinitions.Clear(); // Clear existing column definitions

            MyGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1, GridUnitType.Star) });
            MyGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = new GridLength(1.5, GridUnitType.Star) });
        }




        private void textSignUpFName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignUpFNameBox.Focus();
        }

        private void signUpFNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SignUpFNameBox.Text) && SignUpFNameBox.Text.Length > 0)
                TextSignUpFName.Visibility = Visibility.Collapsed;
            else
                TextSignUpFName.Visibility = Visibility.Visible;         }
        
        private void textSignUpLName_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignUpLNameBox.Focus();
        }

        private void signUpLNameBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SignUpLNameBox.Text) && SignUpLNameBox.Text.Length > 0)
                TextSignUpLName.Visibility = Visibility.Collapsed;
            else
                TextSignUpLName.Visibility = Visibility.Visible;        
        }
        private void textSignUpEmail_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignUpEmailBox.Focus();
        }
        private void signUpEmailBox_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SignUpEmailBox.Text) && SignUpEmailBox.Text.Length > 0)
                TextSignUpEmail.Visibility = Visibility.Collapsed;
            else
                TextSignUpEmail.Visibility = Visibility.Visible;
        }
 
        private void textSignUpPassword_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignUpPasswordBox.Focus();
        }
        private void signUpPasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SignUpPasswordBox.Password) && SignUpPasswordBox.Password.Length > 0)
                TextSignUpPassword.Visibility = Visibility.Collapsed;
            else
                TextSignUpPassword.Visibility = Visibility.Visible;
        }
        
        private void textSignUpPassword2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            SignUpPassword2Box.Focus();
        }
        private void signUpPassword2Box_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(SignUpPassword2Box.Password) && SignUpPassword2Box.Password.Length > 0)
                TextSignUpPassword2.Visibility = Visibility.Collapsed;
            else
                TextSignUpPassword2.Visibility = Visibility.Visible;
        }
    }
}