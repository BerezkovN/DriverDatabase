
using System;
using System.ComponentModel;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;

namespace DriverDatabase
{
    public class CarForm : Form
    {
        private TextBox NameTextBox;
        private Button OKButton;
        private Button CloseButton;
        private Label NameLabel;
        private Label DriverLabel;
        private ComboBox comboBox1;
        private Label label2;
        private Label driversLabel;
        private List<Driver> AddedDrivers = new List<Driver>();
        private bool isEdit = false;
        private Car car;
        public Car Car
        {
            set
            {
                this.car = value;
                this.NameTextBox.Text = this.car.Name;
                this.AddedDrivers = new List<Driver>(car.Drivers);
                this.car.Drivers.Clear();
                this.isEdit = true;
                SetAuthorsLabel();
            }

            get
            {
                return this.car;
            }
        }

        public CarForm()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        private void InitializeComponent()
        {
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.DriverLabel = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.driversLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Location = new System.Drawing.Point(77, 25);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(60, 20);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(156, 22);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(121, 22);
            this.NameTextBox.TabIndex = 1;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(16, 151);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(85, 37);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(241, 151);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(85, 37);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Cancel";
            // 
            // AuthorLable
            // 
            this.DriverLabel.Location = new System.Drawing.Point(52, 110);
            this.DriverLabel.Name = "AuthorLable";
            this.DriverLabel.Size = new System.Drawing.Size(85, 20);
            this.DriverLabel.TabIndex = 6;
            this.DriverLabel.Text = "Add author";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(156, 107);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 24);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 17);
            this.label2.TabIndex = 8;
            this.label2.Text = "Authors:";
            // 
            // authorsLabel
            // 
            this.driversLabel.AutoSize = true;
            this.driversLabel.Location = new System.Drawing.Point(156, 68);
            this.driversLabel.Name = "authorsLabel";
            this.driversLabel.Size = new System.Drawing.Size(0, 17);
            this.driversLabel.TabIndex = 9;
            // 
            // BookForm
            // 
            this.ClientSize = new System.Drawing.Size(349, 200);
            this.Controls.Add(this.driversLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.DriverLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "BookForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializeComboBox()
        {
            foreach (var driver in DriverList.Instance.Drivers)
            {
                comboBox1.Items.Add(driver);
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            if (this.car == null)
            {
                this.car = new Car();
            }

            if (this.NameTextBox.Text == "" )
            {
                return;
            }
            
            this.car.Name = this.NameTextBox.Text;
            this.car.Drivers.AddRange(AddedDrivers);

            if (!isEdit)
            {
                foreach (var author in AddedDrivers)
                {
                    author.Cars.Add(this.car);
                }
            }
            else
            {
                CarList.Instance.SaveToFile(CarList.DefaultFileName);
                CarList.Instance.LoadFromFile(CarList.DefaultFileName);
                DriverList.Instance.LoadFromFile(DriverList.DefaultFileName);
            }

            CarList.Instance.FireListChanged();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Driver selected = (Driver)comboBox1.SelectedItem;

            if (AddedDrivers.IndexOf(selected) == -1)
                AddedDrivers.Add(selected);
            else
                AddedDrivers.Remove(selected);

            SetAuthorsLabel();
        }

        private void SetAuthorsLabel()
        {
            string result = "";

            foreach (var driver in AddedDrivers)
            {
                result += driver.Name + ", ";
            }

            if (result.Length - 2 > 0)
                driversLabel.Text = result.Substring(0, result.Length - 2);
            else
                driversLabel.Text = "";
        }
    }
}