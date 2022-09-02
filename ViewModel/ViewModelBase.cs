using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace exam.ViewModel
{
    abstract class ViewModelBase : INotifyPropertyChanged, IDisposable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void Dispose()
        {
            this.OnDispose();
        }

        protected virtual void OnDispose() { }

        public virtual void OnPropertyChanged(string propertName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertName));
        }
    }
}
