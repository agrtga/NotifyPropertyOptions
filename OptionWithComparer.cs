using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotifyPropertyOptions
{
    public sealed class OptionWithComparer : IOption, INotifyPropertyChanged
    {
        int var1;
        string var2;

        public int Var1
        {
            get => var1;
            set => SetField(ref var1, value);
        }

        public string Var2
        {
            get => var2;
            set => SetField(ref var2, value);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged(string propName)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        void SetField<T>(ref T field, T value, [CallerMemberName]string propName = null)
        {
            if (!EqualityComparer<T>.Default.Equals(field, value)) {
                field = value;
                OnPropertyChanged(propName);
            }
        }
    }
}
