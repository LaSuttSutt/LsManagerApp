using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data;
using Avalonia.Interactivity;
using Avalonia.Media;
using ReactiveUI;

namespace LsManagerDesktop.UI.__Shared.Controls;

public class NavigationButton : TemplatedControl
{
    public static readonly StyledProperty<Geometry> ButtonIconProperty =
        AvaloniaProperty.Register<NavigationButton, Geometry>(
            nameof(ButtonIcon));
    
    public static readonly StyledProperty<ICommand?> CommandProperty =
        AvaloniaProperty.Register<Button, ICommand?>(nameof(Command), enableDataValidation: true);
    
    public static readonly StyledProperty<string> TextProperty = AvaloniaProperty.Register<NavigationButton, string>(
        nameof(Text), defaultValue: "Default Text");

    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public Geometry ButtonIcon
    {
        get => GetValue(ButtonIconProperty);
        set => SetValue(ButtonIconProperty, value);
    }
    
    public ICommand? Command
    {
        get => GetValue(CommandProperty);
        set => SetValue(CommandProperty, value);
    }

    protected override void OnApplyTemplate(TemplateAppliedEventArgs e)
    {
        base.OnApplyTemplate(e);

        if (e.NameScope.Find("NavBtn") is Button btn)
        {
            btn.Click += (_, _) => Command?.Execute(null);
        }
    }
}