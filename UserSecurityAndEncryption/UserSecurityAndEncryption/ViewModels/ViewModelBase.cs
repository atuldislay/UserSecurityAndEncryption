using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserSecurityAndEncryption.ViewModels
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        #region Property Changed Event Handler

        public void SetPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null) PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Property Changed Event Handler
    }
}
