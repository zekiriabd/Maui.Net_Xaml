using Microsoft.Toolkit.Mvvm.Input;
using SqliteDemo.Models;
using SqliteDemo.Services.Interfaces;

namespace SqliteDemo.Pages;

public partial class PointRow : ViewCell
{
    public static readonly BindableProperty IdProperty = BindableProperty.Create("Id", typeof(string), typeof(PointRow), "Id");
    public string Id => GetValue(IdProperty).ToString();

    public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(PointRow), "Title");
    public string Title => GetValue(TitleProperty).ToString();

    public static readonly BindableProperty DateProperty = BindableProperty.Create("Date", typeof(string), typeof(PointRow), "Date");
    public string Date => GetValue(DateProperty).ToString();

    public static readonly BindableProperty PointProperty = BindableProperty.Create("Point", typeof(string), typeof(PointRow), "Point");
    public string Point => GetValue(PointProperty).ToString();

    private void Button_Clicked(object sender, EventArgs e)
    {
        ((PointsListVM)Parent.BindingContext).Delete(int.Parse(Id));
    }
    public PointRow()
    {
        InitializeComponent();
    }
}