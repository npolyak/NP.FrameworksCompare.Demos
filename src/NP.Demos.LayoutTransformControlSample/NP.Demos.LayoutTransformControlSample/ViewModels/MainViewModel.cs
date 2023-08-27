using System.Collections.ObjectModel;
using System.ComponentModel;

namespace NP.Demos.LayoutTransformControlSample.ViewModels;

public class MainViewModel : ObservableCollection<string>, INotifyPropertyChanged
{
    public MainViewModel()
    {
        for (int i = 0; i < 1000; i++) 
        {
            Add($"This is sentence {i}.");
        }
    }



    #region ScaleFactor Property
    private double _scaleFactor = 1d;
    public double ScaleFactor
    {
        get
        {
            return this._scaleFactor;
        }
        set
        {
            if (this._scaleFactor == value)
            {
                return;
            }

            this._scaleFactor = value;
            this.OnPropertyChanged(new PropertyChangedEventArgs(nameof(ScaleFactor)));
        }
    }
    #endregion ScaleFactor Property

}
