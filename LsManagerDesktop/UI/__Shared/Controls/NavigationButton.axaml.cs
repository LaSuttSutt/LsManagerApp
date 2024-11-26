using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;
using ReactiveUI;

namespace LsManagerDesktop.UI.__Shared.Controls;

public class NavigationButton : TemplatedControl
{
    public static readonly StyledProperty<Geometry> ButtonIconProperty = AvaloniaProperty.Register<NavigationButton, Geometry>(
        nameof(ButtonIcon));

    public static readonly RoutedEvent<RoutedEventArgs> ClickEvent =
        RoutedEvent.Register<NavigationButton, RoutedEventArgs>(nameof(Click), RoutingStrategies.Bubble);
    
    public Geometry ButtonIcon
    {
        get => GetValue(ButtonIconProperty);
        set => SetValue(ButtonIconProperty, value);
    }
    
    public event EventHandler<RoutedEventArgs>? Click
    {
        add => AddHandler(ClickEvent, value);
        remove => RemoveHandler(ClickEvent, value);
    }
}