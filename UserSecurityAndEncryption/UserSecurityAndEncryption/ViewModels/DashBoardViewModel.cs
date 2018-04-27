using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserSecurityAndEncryption.BAL;
using UserSecurityAndEncryption.DAL;

namespace UserSecurityAndEncryption.ViewModels
{
    public class DashBoardViewModel : ViewModelBase
    {
        private IEnumerable<string> _usersObservableCollection;
        public IEnumerable<string> UsersObservableCollection
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

        public DashBoardViewModel()
        {
            UsersObservableCollection = new List<String>(UserManager.GetAllUsers().Select(user=>user.UserName));
        }

    }
}
