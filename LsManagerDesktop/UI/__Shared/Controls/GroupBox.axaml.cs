using Avalonia;
using Avalonia.Controls;

namespace LsManagerDesktop.UI.__Shared.Controls;

public partial class GroupBox : ContentControl
{
    public static readonly StyledProperty<string> TitleProperty = AvaloniaProperty.Register<GroupBox, string>(
        nameof(Title), defaultValue: "GroupBox");

    public string Title
    {
        get => GetValue(TitleProperty);
        set => SetValue(TitleProperty, value);
    }
}