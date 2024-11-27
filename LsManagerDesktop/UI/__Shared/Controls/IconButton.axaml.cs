using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace LsManagerDesktop.UI.__Shared.Controls;

public class IconButton : Button
{
    public static readonly StyledProperty<Geometry> ButtonIconProperty =
        AvaloniaProperty.Register<NavigationButton, Geometry>(
            nameof(ButtonIcon));
    
    public Geometry ButtonIcon
    {
        get => GetValue(ButtonIconProperty);
        set => SetValue(ButtonIconProperty, value);
    }
}