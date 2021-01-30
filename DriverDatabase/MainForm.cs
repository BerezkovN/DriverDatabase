
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;

namespace DriverDatabase
{
	public class MainForm : Form
	{
		public ListBox ListBox;
		public Button AddButton;
		public Button EditButton;
        private MainMenu mainMenu;
        private IContainer components;
        private Label Folder;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private Button button1;
        public Button DeleteButton;
        private ToolStripMenuItem clearToolStripMenuItem;
        private ToolStripMenuItem saveToolStripMenuItem;

        private Object selectedItem;
        private List<ToolStripItem> itemList;
        private ToolStripMenuItem viewToolStripMenuItem;
        private List<Object> objectList;

		public MainForm()
		{
			InitializeComponent();
			DriverList.Instance.ListChanged += new EventHandler(this.OnListChanged);
            CarList.Instance.ListChanged += new EventHandler(this.OnListChanged);
			Application.ApplicationExit += new EventHandler(this.OnApplicationExit);
		}

		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            this.ListBox = new System.Windows.Forms.ListBox();
            this.AddButton = new System.Windows.Forms.Button();
            this.EditButton = new System.Windows.Forms.Button();
            this.DeleteButton = new System.Windows.Forms.Button();
            this.mainMenu = new System.Windows.Forms.MainMenu(this.components);
            this.Folder = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.button1 = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox
            // 
            this.ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ListBox.ItemHeight = 20;
            this.ListBox.Location = new System.Drawing.Point(37, 53);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(262, 144);
            this.ListBox.TabIndex = 0;
            this.ListBox.SelectedIndexChanged += new System.EventHandler(this.OnListBoxSelectedIndexChanged);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(315, 53);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(142, 50);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add driver";
            this.AddButton.Click += new System.EventHandler(this.OnAddDriverButtonClick);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(315, 136);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(142, 50);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Edit";
            this.EditButton.Click += new System.EventHandler(this.OnEditButtonClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(477, 136);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(142, 50);
            this.DeleteButton.TabIndex = 3;
            this.DeleteButton.Text = "Delete";
            this.DeleteButton.Click += new System.EventHandler(this.OnDeleteButtonClick);
            // 
            // Folder
            // 
            this.Folder.AutoSize = true;
            this.Folder.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.Folder.Location = new System.Drawing.Point(38, 29);
            this.Folder.Name = "Folder";
            this.Folder.Size = new System.Drawing.Size(59, 18);
            this.Folder.TabIndex = 4;
            this.Folder.Text = "Drivers:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.viewToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(639, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem,
            this.saveToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(46, 24);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(126, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(55, 24);
            this.viewToolStripMenuItem.Text = "View";
            this.viewToolStripMenuItem.Click += new System.EventHandler(this.viewToolStripMenuItem_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 50);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add car";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnAddCarButtonClick);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(639, 211);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Folder);
            this.Controls.Add(this.ListBox);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.EditButton);
            this.Controls.Add(this.DeleteButton);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.Menu = this.mainMenu;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Closed += new System.EventHandler(this.OnFormClosed);
            this.Load += new System.EventHandler(this.OnFormLoad);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		// obsluhy udalosti
		private void OnListChanged(object sender, EventArgs e)
		{
			this.EditButton.Enabled = false;

			this.ListBox.Items.Clear();
            if (selectedItem is String || selectedItem is null)
            {
                Folder.Text = "Drivers:";

                for (int i = 0; i < DriverList.Instance.Count; i++)
                {
                    this.ListBox.Items.Add(DriverList.Instance[i]);
                }
            }
            else if (selectedItem is Driver)
            {
                Driver selectedDriver = (Driver)selectedItem;

                Folder.Text = selectedDriver.Name + ":";

                for (int i = 0; i < selectedDriver.Cars.Count; i++)
                {
                    this.ListBox.Items.Add(selectedDriver.Cars[i]);
                }
            }
		}

		private void OnAddDriverButtonClick(object sender, EventArgs e)
		{
			DriverForm driverForm = new DriverForm();
			if (driverForm.ShowDialog() == DialogResult.OK)
			{
				DriverList.Instance.Add(driverForm.Driver);
			}
		}

        private void OnAddCarButtonClick(object sender, EventArgs e)
        {
            CarForm bookForm = new CarForm();
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                CarList.Instance.Add(bookForm.Car);
            }
        }

        private void OnEditButtonClick(object sender, EventArgs e)
		{
			if (this.ListBox.SelectedItem == null) return;

            if (this.ListBox.SelectedItem is Driver)
            {
                DriverForm driverForm = new DriverForm();
                driverForm.Driver = this.ListBox.SelectedItem as Driver;
                driverForm.ShowDialog();
            }
            else if (this.ListBox.SelectedItem is Car)
            {
                CarForm carForm = new CarForm();
                carForm.Car = this.ListBox.SelectedItem as Car;
                bool[] checkedDrivers = new bool[DriverList.Instance.Drivers.Count];

                for (int index = 0; index < DriverList.Instance.Drivers.Count; index++)
                {
                    foreach (var driver in carForm.Car.Drivers)
                    {
                        if (DriverList.Instance.Drivers[index] == driver)
                            checkedDrivers[index] = true;
                    }
                }

                carForm.CheckedDrivers = checkedDrivers;

                carForm.ShowDialog();
            }
		}

		private void OnDeleteButtonClick(object sender, EventArgs e)
		{
			if (this.ListBox.SelectedItem == null) return;
            if (this.ListBox.SelectedItem is Driver)
                DriverList.Instance.Remove(this.ListBox.SelectedItem as Driver);
            else if (this.ListBox.SelectedItem is Car)
                CarList.Instance.Remove(this.ListBox.SelectedItem as Car);

		}

		private void OnListBoxSelectedIndexChanged(object sender, System.EventArgs e)
		{
			bool selected = this.ListBox.SelectedItem != null;
			this.EditButton.Enabled = selected;
		}

		private void OnFormLoad(object sender, System.EventArgs e)
		{
            try
			{
				DriverList.Instance.LoadFromFile(DriverList.DefaultFileName);

                CarList.Instance.LoadFromDrivers();
            }
			catch (System.IO.FileNotFoundException ex)
			{
                DriverList.Instance.CreateFile(DriverList.DefaultFileName);
                DriverList.Instance.SaveToFile(DriverList.DefaultFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load DriverList: " + ex.ToString());
            }
        }

		private void OnFormClosed(object sender, System.EventArgs e)
		{
		}

		private void OnApplicationExit(object sender, EventArgs e)
		{
			try
			{
				DriverList.Instance.SaveToFile(DriverList.DefaultFileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Chyba pri ukladani do suboru: " + ex.ToString());
			}
		}

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarList.Instance.Cars = new List<Car>();
            DriverList.Instance.Drivers = new List<Driver>();
            DriverList.Instance.SaveToFile(DriverList.DefaultFileName);
            DriverList.Instance.LoadFromFile(DriverList.DefaultFileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DriverList.Instance.SaveToFile(DriverList.DefaultFileName);
        }

        private void viewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            itemList = new List<ToolStripItem>();
            ToolStripItem firstItem = new ToolStripMenuItem
            {
                Size = new System.Drawing.Size(126, 26),
                Text = "All drivers"
            };
            firstItem.Click += new System.EventHandler(this.viewMenu_Click);
            itemList.Add(firstItem);

            objectList = new List<object>();
            objectList.Add("All drivers");

            int count = 1;
            foreach (var driver in DriverList.Instance.Drivers)
            {
                objectList.Add(driver);

                ToolStripItem item = new ToolStripMenuItem
                {
                    Name = count.ToString(),
                    Size = new System.Drawing.Size(126, 26),
                    Text = driver.Name
                };
                item.Click += new System.EventHandler(this.viewMenu_Click);
                itemList.Add(item);

                count++;
            }

            viewToolStripMenuItem.DropDownItems.Clear();
            viewToolStripMenuItem.DropDownItems.AddRange(itemList.ToArray());
        }

        private void viewMenu_Click(object sender, EventArgs e)
        {
            string toParse = (sender as ToolStripItem) != itemList[0] ? (sender as ToolStripItem).Name : "0";
            selectedItem = objectList[int.Parse(toParse)];

            DriverList.Instance.FireListChanged();
        }
    }
}
