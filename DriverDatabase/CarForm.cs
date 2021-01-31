
using System;
using System.Linq;
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
        private List<Driver> AddedDrivers = new List<Driver>();
        private Panel panel;
        private Label label1;
        private Car car;
        private Label label2;
        private TextBox BrandTextBox;

        public Car Car
        {
            set
            {
                this.car = value;
                this.NameTextBox.Text = this.car.Name;
                this.BrandTextBox.Text = this.car.Brand;
            }

            get
            {
                return this.car;
            }
        }

        private bool[] checkedDrivers;
        public bool[] CheckedDrivers
        {
            get
            {
                if (checkedDrivers is null)
                {
                    checkedDrivers = new bool[DriverList.Instance.Drivers.Count];
                    return checkedDrivers;
                }
                return checkedDrivers;
            }
            set
            {
                checkedDrivers = value;

                for (int index = 0; index < panel.Controls.Count; index++)
                {
                    (panel.Controls[index] as CheckBox).Checked = checkedDrivers[index];
                }
            }
        }

        public CarForm()
        {
            InitializeComponent();
            InitializePanel();
        }

        private void InitializeComponent()
        {
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.panel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BrandTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Location = new System.Drawing.Point(85, 25);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(60, 20);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(146, 22);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(124, 22);
            this.NameTextBox.TabIndex = 1;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(30, 178);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(85, 37);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(243, 178);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(85, 37);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Cancel";
            // 
            // panel
            // 
            this.panel.AutoScroll = true;
            this.panel.Location = new System.Drawing.Point(146, 80);
            this.panel.Name = "panel";
            this.panel.Size = new System.Drawing.Size(181, 92);
            this.panel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(77, 83);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 7;
            this.label1.Text = "Drivers:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(84, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 20);
            this.label2.TabIndex = 8;
            this.label2.Text = "Brand:";
            // 
            // BrandTextBox
            // 
            this.BrandTextBox.Location = new System.Drawing.Point(146, 51);
            this.BrandTextBox.Name = "BrandTextBox";
            this.BrandTextBox.Size = new System.Drawing.Size(124, 22);
            this.BrandTextBox.TabIndex = 9;
            // 
            // CarForm
            // 
            this.ClientSize = new System.Drawing.Size(360, 227);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.BrandTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "CarForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add book";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void InitializePanel()
        {
            List<Driver> drivers = DriverList.Instance.Drivers;

            int location = 4;
            for (int index = 0; index < drivers.Count; index++)
            {
                CheckBox checkBox = new CheckBox();
                checkBox.AutoSize = true;
                checkBox.Location = new System.Drawing.Point(4, location);
                checkBox.Name = "checkBox" + index;
                checkBox.Size = new System.Drawing.Size(98, 21);
                checkBox.Text = drivers[index].Name;
                checkBox.UseVisualStyleBackColor = true;
                checkBox.Click += checkBox_Click;

                this.panel.Controls.Add(checkBox);

                location += checkBox.Size.Height + 4;
            }
        }

        private void OKButton_Click(object sender, EventArgs e)
        {
            bool isEdit = true;
            if (this.car == null)
            {
                this.car = new Car();
                isEdit = false;
            }

            this.car.Name = this.NameTextBox.Text;
            this.car.Brand = this.BrandTextBox.Text;

            if (this.NameTextBox.Text == "")
            {
                MessageBox.Show("Car has to have a name");
                return;
            }
            if (this.BrandTextBox.Text == "")
            {
                MessageBox.Show("Car has to have a brand");
                return;
            }

            if (CarList.Instance.Cars.Any(el => Car.Compare(el, this.car)) && !isEdit)
            {
                MessageBox.Show("Car with same properties already exists!!");
                return;
            }

            if (CheckedDrivers.Any(el => el == true) == false)
            {
                MessageBox.Show("Car has to have at least 1 driver");
                return;
            }
            ResetDriverCars();

            CarList.Instance.FireListChanged();

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void ResetDriverCars()
        {
            for (int index = 0; index < CheckedDrivers.Length; index++)
            {
                if (CheckedDrivers[index])
                {
                    if (!this.car.Drivers.Contains(DriverList.Instance.Drivers[index]))
                        this.car.Drivers.Add(DriverList.Instance.Drivers[index]);

                    if (!DriverList.Instance.Drivers[index].Cars.Contains(this.car))
                        DriverList.Instance.Drivers[index].Cars.Add(this.car);
                }
                else
                {
                    this.car.Drivers.Remove(DriverList.Instance.Drivers[index]);

                    DriverList.Instance.Drivers[index].Cars.Remove(this.car);
                }
            }
        }

        private void checkBox_Click(object sender,EventArgs e)
        {
            CheckBox checkBox = sender as CheckBox;
            int index = int.Parse(checkBox.Name.Replace("checkBox", ""));

            CheckedDrivers[index] = !CheckedDrivers[index];
        }
    }
}