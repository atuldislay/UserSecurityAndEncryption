using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using UserSecurityAndEncryption.BAL;
using UserSecurityAndEncryption.Commands;
using UserSecurityAndEncryption.DAL;

namespace UserSecurityAndEncryption.ViewModels
{
    public class DashBoardViewModel : ViewModelBase
    {
        private IEnumerable<T_User> _usersObservableCollection;
        public IEnumerable<T_User> UsersObservableCollection
        {
            get
            {
                return _usersObservableCollection;

            }
            set
            {
                if (!(Equals(value, _usersObservableCollection)))
                    _usersObservableCollection = value;
                SetPropertyChanged("UsersObservableCollection");
            }

        }

        private string _userName = String.Empty;
        public string UserName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
                SetPropertyChanged("UserName");
            }
        }

        private string _passWord = String.Empty;
        public string Password
        {
            get
            {
                return _passWord;
            }
            set
            {
                _passWord = value;
                SetPropertyChanged("Password");
            }
        }


        bool _isNotificationOpen = false;
        public bool IsNotificationOpen
        {
            get { return _isNotificationOpen; }
            set
            {
                _isNotificationOpen = value;
                SetPropertyChanged("IsNotificationOpen");
            }
        }

        private T_User _selectedUser;
        public T_User SelectedUser
        {
            get { return _selectedUser; }
            set
            {
                _selectedUser = value;
                SetPropertyChanged("SelectedUser");
                _isUpdateButtonVisible = _selectedUser != null;
                SetPropertyChanged("IsUpdateButtonVisible");
            }
        }

        private string _displayMessage;
        public string DisplayMessage
        {
            get { return _displayMessage; }
            set
            {
                _displayMessage = value;
                SetPropertyChanged("DisplayMessage");
            }
        }

        private bool _isUpdateButtonVisible;
        public bool IsUpdateButtonVisible
        {
            get { return _isUpdateButtonVisible; }
            set
            {
                _isUpdateButtonVisible = value;
                SetPropertyChanged("IsUpdateButtonVisible");
            }
        }

        public ICommand AddUserButtonClicked
        {
            get;
            set;
        }

        public ICommand DeleteButtonClicked
        {
            get;
            set;
        }

        public ICommand UpdateButtonClicked
        {
            get;
            set;
        }

        public DashBoardViewModel()
        {
            UsersObservableCollection = new ObservableCollection<T_User>(UserManager.GetAllUsers());
            AddUserButtonClicked = new DelegateCommand<object>(parameter => AddUserClickCommand(), canExecute => !(String.IsNullOrEmpty(_userName) || String.IsNullOrEmpty(_passWord)));
            DeleteButtonClicked = new DelegateCommand<object>(parameter => DeleteUserClickCommand(), canExecute => _selectedUser != null && CheckUserExistBeforeDelete());
            UpdateButtonClicked = new DelegateCommand<object>(parameter => UpdateButtonClickedCommand(), canExecute => _selectedUser != null);
        }

        private void UpdateButtonClickedCommand()
        {
            UserManager.UpdateUser(_selectedUser.UserName, _userName, _passWord);
        }

        private void DeleteUserClickCommand()
        {
            UserManager.DeleteUser(_selectedUser.UserName);
        }

        private void AddUserClickCommand()
        {
            UserManager.SaveUser(_userName, _passWord);
        }

        private bool CheckUserExistBeforeDelete()
        {
            return UserManager.CheckUserBasedOnUserName(_selectedUser.UserName);
        }

    }
}
