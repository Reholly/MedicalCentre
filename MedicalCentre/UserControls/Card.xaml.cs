using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace MedicalCentre.UserControls;

public partial class Card : UserControl
{
    public Card()
    {
        InitializeComponent();
    }

    public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(Card));
    public string Title
    {
        get { return (string)GetValue(TitleProperty); }
        set { SetValue(TitleProperty, value); }
    }

    public static readonly DependencyProperty ButtonCommandProperty = DependencyProperty.Register("ButtonProperty", typeof(ICommand), typeof(Card), new UIPropertyMetadata(null));
    public ICommand ButtonCommand
    {
        get { return (ICommand)GetValue(ButtonCommandProperty); }
        set { SetValue(ButtonCommandProperty, value); }
    }

    public static readonly DependencyProperty IconProperty = DependencyProperty.Register("Icon", typeof(MaterialDesignThemes.Wpf.PackIconKind), typeof(Card));
    public PackIconKind Icon
    {
        get { return (MaterialDesignThemes.Wpf.PackIconKind)GetValue(IconProperty); }
        set { SetValue(IconProperty, value); }
    }

    public static readonly DependencyProperty ButtonTextProperty = DependencyProperty.Register("ButtonText", typeof(string), typeof(Card));
    public string ButtonText
    {
        get { return (string)GetValue(ButtonTextProperty); }
        set { SetValue(ButtonTextProperty, value); }
    }
}