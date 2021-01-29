using System;
using System.Windows.Forms;
using DriverDatabase;

public class Program
{
	[STAThread]
	public static void Main()
	{
		Application.EnableVisualStyles();
		Application.Run(new MainForm());
	}
}
