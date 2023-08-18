using Avalonia.Controls;
using Avalonia.Media;
using Avalonia.Media.Imaging;
using Avalonia.Media.Immutable;

namespace NP.Demos.DrawingContextSample.Views;

public partial class MainView : UserControl
{
    readonly IPen _strokePen = 
        new ImmutablePen
        (
            Brushes.Blue, 
            10d,
            null, 
            PenLineCap.Round, 
            PenLineJoin.Round);

    public MainView()
    {
        InitializeComponent();
    }

    public override void Render(DrawingContext context)
    {
        context
            .DrawEllipse
            (
                Brushes.Red,
                _strokePen,
                new Avalonia.Point(100, 100),
                40,
                40);
    }
}
