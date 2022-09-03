using CommunityToolkit.Mvvm.ComponentModel;
using CustomComponent.Models;
using System;

namespace CustomComponent.Components;

public partial class MyLabelCompnoent : ContentView
{
    public MyLabelCompnoent()
	{
		InitializeComponent();
        MyLabelCompnoentVM myLabelCompnoentVM = new MyLabelCompnoentVM();
        MessagingCenter.Subscribe<Page, LabelM>(this, "MyMessage", (sender,arg) =>
        {
            Label1.Text = arg.MText;
            Label1.TextColor = arg.MColor;
            Border1.Stroke = arg.MColor;
        });
    }
}

/*
public partial class MyLabelCompnoentVM : ObservableObject
{
    [ObservableProperty]
    private string mText;

    [ObservableProperty]
    private Color mColor = Colors.Red;

}
*/


/*
public partial class MyLabelCompnoent : ContentView
{
    public MyLabelCompnoent()
    {
        InitializeComponent();
    }

    public static readonly BindableProperty MTextProperty = BindableProperty.CreateAttached(
        nameof(MTextArg), typeof(string), typeof(string), "", BindingMode.TwoWay,
            propertyChanged: (myLabelCompnoent, oldValue, newValue) =>
            {
                ((MyLabelCompnoentVM)myLabelCompnoent.BindingContext).MText = newValue.ToString();
            });
    public string MTextArg
    {
        get { return (string)GetValue(MTextProperty); }
        set { SetValue(MTextProperty, value); }
    }

    public static readonly BindableProperty MColorProperty =
       BindableProperty.CreateAttached(nameof(MColorArg), typeof(string), typeof(string), "", BindingMode.TwoWay,
          propertyChanged: (myLabelCompnoent, oldValue, newValue) =>
          {
              ((MyLabelCompnoentVM)myLabelCompnoent.BindingContext).MColor = Color.FromArgb(newValue.ToString());
          });

    public string MColorArg
    {
        get { return GetValue(MColorProperty).ToString(); }
        set { SetValue(MColorProperty, value); }
    }
}

*/