using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Interactivity;
using Avalonia.Media;
using ReactiveUI;

namespace LsManagerDesktop.UI.__Shared.Controls;

public class NavigationButton : TemplatedControl
{
    public static readonly StyledProperty<Geometry> ButtonIconProperty =
        AvaloniaProperty.Register<NavigationButton, Geometry>(
            nameof(ButtonIcon));

    private static readonly RoutedEvent<RoutedEventArgs> ClickEvent =
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

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        if (e.NameScope.Find("NavBtn") is Button btn)
            btn.Click += (_, _) => RaiseEvent(new RoutedEventArgs(ClickEvent, this));
    }
}