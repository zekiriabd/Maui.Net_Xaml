namespace SqliteDemo.Pages;

public partial class PointRow : ViewCell
{
    public static readonly BindableProperty TitleProperty = BindableProperty.Create("Title", typeof(string), typeof(PointRow), "Title");
    public string Title => GetValue(TitleProperty).ToString();

    public static readonly BindableProperty DateProperty = BindableProperty.Create("Date", typeof(string), typeof(PointRow), "Date");
    public string Date => GetValue(DateProperty).ToString();

    public static readonly BindableProperty PointProperty = BindableProperty.Create("Point", typeof(string), typeof(PointRow), "Point");
    public string Point => GetValue(PointProperty).ToString();

    public PointRow()
    {
        InitializeComponent();
    }
}