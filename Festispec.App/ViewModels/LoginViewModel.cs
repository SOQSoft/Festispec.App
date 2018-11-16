﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Festispec.App.Repositories;
using Festispec.Domain;
using System.Windows;

namespace Festispec.App.ViewModels
{
    public class LoginViewModel
    {
        public MainViewModel MainView;

        private string _username;
        public string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        private string _password;
        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }
        public ICommand LoginCommand;
        private UserTestRepository _users;

        public LoginViewModel()
        {
            _users = new UserTestRepository();
            LoginCommand = new RelayCommand(Login);
        }

        public void Login()
        {
            if(fieldsAreEmpty())
            {
                return;
            }
            if(isPasswordUsernameCombinationCorrect())
            {
                //TODO initialise mainview

            }
            else
            {
                MessageBox.Show("Gebruikersnaam of wachtwoord is incorrect", "Alert", MessageBoxButton.OK, MessageBoxImage.None);
                //TODO show error in LoginView
            }
        }

        public bool fieldsAreEmpty()
        {
            if (_username == null)
            {
                MessageBox.Show("Gebruikersnaam is leeg, vul een gebruikersnaam in", "Alert", MessageBoxButton.OK, MessageBoxImage.None);
                return true ;
            }
            if(_password == null)
            {
                MessageBox.Show("Wachtwoord is leeg, vul een wachtwoord in", "Alert", MessageBoxButton.OK, MessageBoxImage.None);
                return true;
            }
            return false;
        }

        public bool isPasswordUsernameCombinationCorrect()
        {
            User InputUser = _users.GetAll().First(u => u.Username == _username);
            if (InputUser == null)
            {
                return false;
            }
            if(InputUser.Password == _password)
            {
                return true;
            }
            return false;
        }
    }
}
