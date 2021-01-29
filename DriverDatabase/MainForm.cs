﻿
using System;
using System.ComponentModel;
using System.IO;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;

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
            this.button1 = new System.Windows.Forms.Button();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ListBox
            // 
            this.ListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.ListBox.ItemHeight = 20;
            this.ListBox.Location = new System.Drawing.Point(37, 53);
            this.ListBox.Name = "ListBox";
            this.ListBox.Size = new System.Drawing.Size(262, 164);
            this.ListBox.TabIndex = 0;
            this.ListBox.SelectedIndexChanged += new System.EventHandler(this.OnListBoxSelectedIndexChanged);
            this.ListBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ListBox_MouseDoubleClick);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(315, 53);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(142, 40);
            this.AddButton.TabIndex = 1;
            this.AddButton.Text = "Add author";
            this.AddButton.Click += new System.EventHandler(this.OnAddButtonClick);
            // 
            // EditButton
            // 
            this.EditButton.Enabled = false;
            this.EditButton.Location = new System.Drawing.Point(396, 110);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(142, 40);
            this.EditButton.TabIndex = 2;
            this.EditButton.Text = "Edit";
            this.EditButton.Click += new System.EventHandler(this.OnEditButtonClick);
            // 
            // DeleteButton
            // 
            this.DeleteButton.Location = new System.Drawing.Point(396, 170);
            this.DeleteButton.Name = "DeleteButton";
            this.DeleteButton.Size = new System.Drawing.Size(142, 40);
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
            this.Folder.Size = new System.Drawing.Size(63, 18);
            this.Folder.TabIndex = 4;
            this.Folder.Text = "Authors:";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
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
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(477, 53);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(142, 40);
            this.button1.TabIndex = 6;
            this.button1.Text = "Add book";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.OnAddBookButtonClick);
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.clearToolStripMenuItem.Text = "Clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(639, 234);
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
                Folder.Text = "Authors:";

                for (int i = 0; i < DriverList.Instance.Count; i++)
                {
                    this.ListBox.Items.Add(DriverList.Instance[i]);
                }
            }
            else if (selectedItem is Driver)
            {
                Driver selectedAuthor = (Driver)selectedItem;

                Folder.Text = selectedAuthor.Name + ":";
                this.ListBox.Items.Add("...");
                for (int i = 0; i < selectedAuthor.Cars.Count; i++)
                {
                    this.ListBox.Items.Add(selectedAuthor.Cars[i]);
                }
            }
		}

		private void OnAddButtonClick(object sender, EventArgs e)
		{
			DriverForm authorForm = new DriverForm();
			if (authorForm.ShowDialog() == DialogResult.OK)
			{
				DriverList.Instance.Add(authorForm.Driver);
			}
		}

        private void OnAddBookButtonClick(object sender, EventArgs e)
        {
            CarForm bookForm = new CarForm();
            if (bookForm.ShowDialog() == DialogResult.OK)
            {
                CarList.Instance.Add(bookForm.Car);
            }
        }

        private void OnEditButtonClick(object sender, EventArgs e)
		{
			if (this.ListBox.SelectedItem == null || this.ListBox.SelectedItem is String) return;

            if (this.ListBox.SelectedItem is Driver)
            {
                DriverForm authorForm = new DriverForm();
                authorForm.Driver = this.ListBox.SelectedItem as Driver;
                authorForm.ShowDialog();
            }
            else if (this.ListBox.SelectedItem is Car)
            {
                CarForm bookForm = new CarForm();
                bookForm.Car = this.ListBox.SelectedItem as Car;
                bookForm.ShowDialog();
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
                CarList.Instance.LoadFromFile(CarList.DefaultFileName);
            }
            catch (System.IO.FileNotFoundException ex)
            {
                CarList.Instance.CreateFile(CarList.DefaultFileName);
                CarList.Instance.SaveToFile(CarList.DefaultFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load BookList: " + ex.ToString());
            }

            try
			{
				DriverList.Instance.LoadFromFile(DriverList.DefaultFileName);
			}
			catch (System.IO.FileNotFoundException ex)
			{
                DriverList.Instance.CreateFile(DriverList.DefaultFileName);
                DriverList.Instance.SaveToFile(DriverList.DefaultFileName);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load AuthorList: " + ex.ToString());
            }

            CarList.Instance.SetCorrectDrivers();
        }

		private void OnFormClosed(object sender, System.EventArgs e)
		{
		}

		private void OnApplicationExit(object sender, EventArgs e)
		{
			try
			{
				DriverList.Instance.SaveToFile(DriverList.DefaultFileName);
                CarList.Instance.SaveToFile(CarList.DefaultFileName);
			}
			catch (Exception ex)
			{
				MessageBox.Show("Chyba pri ukladani do suboru: " + ex.ToString());
			}
		}

        private void ListBox_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            selectedItem = ListBox.SelectedItem;
            if (selectedItem != null && !(selectedItem is Car))
                DriverList.Instance.FireListChanged();
        }

        private void clearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarList.Instance.Cars = new List<Car>();
            CarList.Instance.SaveToFile(CarList.DefaultFileName);
            CarList.Instance.LoadFromFile(CarList.DefaultFileName);

            DriverList.Instance.Drivers = new List<Driver>();
            DriverList.Instance.SaveToFile(DriverList.DefaultFileName);
            DriverList.Instance.LoadFromFile(DriverList.DefaultFileName);
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CarList.Instance.SaveToFile(CarList.DefaultFileName);
            DriverList.Instance.SaveToFile(DriverList.DefaultFileName);
        }

        // pomocne funkcie

    }
}
