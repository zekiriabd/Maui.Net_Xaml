﻿namespace Layout;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new MainLayout();
	}
}
