﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NowyProjekt.Model;

namespace NowyProjekt
{

    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        LibraryContext libraryContext;

        public Login(LibraryContext libraryContext)
        {
            this.libraryContext = libraryContext;
            InitializeComponent();
        }

        private void backToRegisterButton(object s, RoutedEventArgs e)
        {
            Register register = new Register(libraryContext);
            this.Close();
            register.Show();
        }

        private void LogOut(object s, RoutedEventArgs e)
        {
            this.Close();
        }

        private void logIn(object s, RoutedEventArgs e)
        {
            var member = libraryContext.Members.FirstOrDefault(b => b.Email == emailTextBox.Text);

            if (member != null)
            {
                if (member.Password == passwordTextBox.Text)
                {
                    MessageBox.Show("Login successfully!");

                    memberData.Visibility = Visibility.Visible;

                    logOutButton.IsEnabled = true;
                    logInButton.IsEnabled = false;

                    var currentMember = libraryContext.Members.Where(a => a.Email == emailTextBox.Text).ToList();
                    
                    firstNameBox.DataContext = currentMember;
                    lastNameBox.DataContext = currentMember;
                    emailBox.DataContext = currentMember;
                    phoneBox.DataContext = currentMember;
                    passwordBox.DataContext = currentMember;

                    //libraryContext.Orders.Add() ;

                    //Wypisanie z bazy do comboboxa
                    var memberBooks = libraryContext.Books.Where(a => a.Title == emailTextBox.Text).ToList();
                    //var w = libraryContext.Books.Union(libraryContext.Orders).;
                    //var v = "select Books.Title FROM Books INNER JOIN (Members INNER JOIN Orders ON Members.Id = Orders.MemberId) ON Books.Id = Orders.BookId".ToList();
                    //select Books.Title FROM Books INNER JOIN (Members INNER JOIN Orders ON Members.Id = Orders.MemberId) ON Books.Id = Orders.BookId WHERE Members.Id=2

                    //borrowCombobox.ItemsSource = v;



                    //Wpisanie do bazy z comboboxa
                    //var borrowBook= 

                }
                else MessageBox.Show("Wrong password");
            }
            else MessageBox.Show("User doesnt exist");

        }

        private void Update(object s, RoutedEventArgs e)
        {
            var member = libraryContext.Members.FirstOrDefault(b => b.Email == emailTextBox.Text);
            libraryContext.Update(member);
            libraryContext.SaveChanges();
            MessageBox.Show("Changes have been saved successfully!");
        }

        private void Delete(object s, RoutedEventArgs e)
        {
            var member = libraryContext.Members.FirstOrDefault(b => b.Email == emailTextBox.Text);
            libraryContext.Remove(member);
            libraryContext.SaveChanges();
            MessageBox.Show("Account deleted successfully");

            MainWindow main = new MainWindow(libraryContext);
            this.Close();
            main.Show();
        }


    }
}
