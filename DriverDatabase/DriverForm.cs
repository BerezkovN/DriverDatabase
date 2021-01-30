
using System;
using System.Linq;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace DriverDatabase
{
	public class DriverForm : Form
	{
		private TextBox NameTextBox;
		private TextBox FavColorTextBox;
		private Button OKButton;
		private Button CloseButton;
        private Label NameLabel;
        private Label ColorLabel;
        public Driver driver;
		public Driver Driver
		{
			set
			{
				this.driver = value;
				this.NameTextBox.Text = this.driver.Name;
				this.FavColorTextBox.Text = this.driver.FavColor;
            }

			get
			{
				return this.driver;
			}
		}

		public DriverForm()
		{
			InitializeComponent();
		}

		private void InitializeComponent()
		{
            this.NameLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.ColorLabel = new System.Windows.Forms.Label();
            this.FavColorTextBox = new System.Windows.Forms.TextBox();
            this.OKButton = new System.Windows.Forms.Button();
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NameLabel
            // 
            this.NameLabel.Location = new System.Drawing.Point(62, 18);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(60, 20);
            this.NameLabel.TabIndex = 0;
            this.NameLabel.Text = "Name:";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(148, 18);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(119, 22);
            this.NameTextBox.TabIndex = 1;
            // 
            // ColorLabel
            // 
            this.ColorLabel.Location = new System.Drawing.Point(34, 58);
            this.ColorLabel.Name = "ColorLabel";
            this.ColorLabel.Size = new System.Drawing.Size(108, 20);
            this.ColorLabel.TabIndex = 2;
            this.ColorLabel.Text = "Favourite color:";
            // 
            // FavColorTextBox
            // 
            this.FavColorTextBox.Location = new System.Drawing.Point(148, 58);
            this.FavColorTextBox.Name = "FavColorTextBox";
            this.FavColorTextBox.Size = new System.Drawing.Size(119, 22);
            this.FavColorTextBox.TabIndex = 3;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(43, 118);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(85, 37);
            this.OKButton.TabIndex = 4;
            this.OKButton.Text = "OK";
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(193, 118);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(85, 37);
            this.CloseButton.TabIndex = 5;
            this.CloseButton.Text = "Cancel";
            // 
            // DriverForm
            // 
            this.ClientSize = new System.Drawing.Size(326, 167);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.ColorLabel);
            this.Controls.Add(this.FavColorTextBox);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.CloseButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "DriverForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Add driver";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		private void OKButton_Click(object sender, EventArgs e)
		{
			if ((Object)this.driver == null)
			{
				this.driver = new Driver();
			}

            //Don't forget to fix
            if (DriverList.Instance.Drivers.Any(el => el.Name == this.NameTextBox.Text))
            {
                MessageBox.Show("Driver with this name already exists!!");
                return;
            }
            else if (this.NameTextBox.Text == "")
            {
                MessageBox.Show("Driver has to have a name");
                return;
            }

            this.driver.Name = this.NameTextBox.Text;
            this.driver.FavColor = this.FavColorTextBox.Text;

            DriverList.Instance.FireListChanged();

			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}