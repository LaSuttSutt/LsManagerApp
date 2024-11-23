using Avalonia;
using Avalonia.Controls;
using Avalonia.Data;

namespace LsManagerDesktop.UI.__Shared.Controls;

public class CheckBox : Button
{
    public static readonly StyledProperty<bool> IsCheckedProperty = AvaloniaProperty.Register<CheckBox, bool>(
        nameof(IsChecked), defaultBindingMode: BindingMode.TwoWay);

    public static readonly StyledProperty<string> TextProperty = AvaloniaProperty.Register<CheckBox, string>(
        nameof(Text), defaultValue: "CheckBox");
    
    public string Text
    {
        get => GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }
    public bool IsChecked
    {
        get => GetValue(IsCheckedProperty);
        set => SetValue(IsCheckedProperty, value);
    }

    protected override void OnClick()
    {
        base.OnClick();
        IsChecked = !IsChecked;
    }
}