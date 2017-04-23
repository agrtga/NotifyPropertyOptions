using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace NotifyPropertyOptions
{
    public sealed class OptionInSetter : IOption, INotifyPropertyChanged
    {
        int var1;
        string var2;

        public int Var1
        {
            get => var1;
            set
            {
                if (var1 != value) {
                    var1 = value;
                    OnPropertyChanged();
                }
            }
        }

        public string Var2
        {
            get => var2;
            set
            {
                if (var2 != value) {
                    var2 = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        void OnPropertyChanged([CallerMemberName]string propName = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(propName));
        }
    }
}
