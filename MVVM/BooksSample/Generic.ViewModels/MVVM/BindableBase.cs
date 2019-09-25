using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace GenericViewModels.MVVM
{
    public abstract class BindableBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;

        public virtual void RaisePropertyChanged([CallerMemberName] string propertyName = default!)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

#nullable disable // to enable use T with both reference and value types
        public bool SetProperty<T>(ref T item, T value, [CallerMemberName] string propertyName = default!)
#nullable restore
        {
            if (EqualityComparer<T>.Default.Equals(item, value))
                return false;

            item = value;
            RaisePropertyChanged(propertyName);
            return true;
        }
    }
}
