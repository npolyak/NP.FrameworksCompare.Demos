using Avalonia.Controls;
using Avalonia.VisualTree;
using System.Linq;

namespace NP.Demo.StaticMarkupExtensionSample.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }

    public void CreateAndShowDialog()
    {
        Window dialogWindow = new Window()
        {
            Content = new TextBlock { Text = "Hello World" },
            HorizontalAlignment = Avalonia.Layout.HorizontalAlignment.Center,
            VerticalAlignment = Avalonia.Layout.VerticalAlignment.Center,
            Width = 200,
            Height = 200,
        };
        dialogWindow.ShowDialog(this.GetSelfAndVisualAncestors().OfType<Window>().FirstOrDefault());
    }
}
