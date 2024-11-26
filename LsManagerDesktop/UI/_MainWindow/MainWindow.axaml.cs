using System;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace LsManagerDesktop.UI._MainWindow;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void NavigationButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Console.WriteLine("Clicked...");
    }
}