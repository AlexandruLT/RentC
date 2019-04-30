namespace RentC
{
    partial class RegisterNewCustomer
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.IDLabel = new System.Windows.Forms.Label();
            this.NameLabel = new System.Windows.Forms.Label();
            this.BirthLabel = new System.Windows.Forms.Label();
            this.LocationLabel = new System.Windows.Forms.Label();
            this.NameTextBox = new System.Windows.Forms.TextBox();
            this.LocationTextBox = new System.Windows.Forms.TextBox();
            this.SubmitButton = new System.Windows.Forms.Button();
            this.BackButton = new System.Windows.Forms.Button();
            this.NameErrorLabel = new System.Windows.Forms.Label();
            this.LocationErrorLabel = new System.Windows.Forms.Label();
            this.IDValueLabel = new System.Windows.Forms.Label();
            this.BirthDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.BirthErrorLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // IDLabel
            // 
            this.IDLabel.AutoSize = true;
            this.IDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.IDLabel.Location = new System.Drawing.Point(50, 51);
            this.IDLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.IDLabel.Name = "IDLabel";
            this.IDLabel.Size = new System.Drawing.Size(86, 25);
            this.IDLabel.TabIndex = 0;
            this.IDLabel.Text = "Client ID";
            // 
            // NameLabel
            // 
            this.NameLabel.AutoSize = true;
            this.NameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.NameLabel.Location = new System.Drawing.Point(50, 113);
            this.NameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.NameLabel.Name = "NameLabel";
            this.NameLabel.Size = new System.Drawing.Size(119, 25);
            this.NameLabel.TabIndex = 1;
            this.NameLabel.Text = "Client Name";
            // 
            // BirthLabel
            // 
            this.BirthLabel.AutoSize = true;
            this.BirthLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.BirthLabel.Location = new System.Drawing.Point(50, 176);
            this.BirthLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.BirthLabel.Name = "BirthLabel";
            this.BirthLabel.Size = new System.Drawing.Size(102, 25);
            this.BirthLabel.TabIndex = 2;
            this.BirthLabel.Text = "Birth Date ";
            // 
            // LocationLabel
            // 
            this.LocationLabel.AutoSize = true;
            this.LocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.LocationLabel.Location = new System.Drawing.Point(50, 241);
            this.LocationLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LocationLabel.Name = "LocationLabel";
            this.LocationLabel.Size = new System.Drawing.Size(86, 25);
            this.LocationLabel.TabIndex = 3;
            this.LocationLabel.Text = "Location";
            // 
            // NameTextBox
            // 
            this.NameTextBox.Location = new System.Drawing.Point(194, 113);
            this.NameTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.NameTextBox.Name = "NameTextBox";
            this.NameTextBox.Size = new System.Drawing.Size(256, 30);
            this.NameTextBox.TabIndex = 5;
            // 
            // LocationTextBox
            // 
            this.LocationTextBox.Location = new System.Drawing.Point(194, 241);
            this.LocationTextBox.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.LocationTextBox.Name = "LocationTextBox";
            this.LocationTextBox.Size = new System.Drawing.Size(256, 30);
            this.LocationTextBox.TabIndex = 7;
            // 
            // SubmitButton
            // 
            this.SubmitButton.Location = new System.Drawing.Point(55, 314);
            this.SubmitButton.Name = "SubmitButton";
            this.SubmitButton.Size = new System.Drawing.Size(172, 44);
            this.SubmitButton.TabIndex = 8;
            this.SubmitButton.Text = "Submit";
            this.SubmitButton.UseVisualStyleBackColor = true;
            this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(278, 314);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(172, 44);
            this.BackButton.TabIndex = 9;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // NameErrorLabel
            // 
            this.NameErrorLabel.AutoSize = true;
            this.NameErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.NameErrorLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.NameErrorLabel.Location = new System.Drawing.Point(190, 88);
            this.NameErrorLabel.Name = "NameErrorLabel";
            this.NameErrorLabel.Size = new System.Drawing.Size(0, 20);
            this.NameErrorLabel.TabIndex = 13;
            this.NameErrorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // LocationErrorLabel
            // 
            this.LocationErrorLabel.AutoSize = true;
            this.LocationErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.LocationErrorLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.LocationErrorLabel.Location = new System.Drawing.Point(190, 216);
            this.LocationErrorLabel.Name = "LocationErrorLabel";
            this.LocationErrorLabel.Size = new System.Drawing.Size(0, 20);
            this.LocationErrorLabel.TabIndex = 14;
            this.LocationErrorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // IDValueLabel
            // 
            this.IDValueLabel.AutoSize = true;
            this.IDValueLabel.Location = new System.Drawing.Point(189, 51);
            this.IDValueLabel.Name = "IDValueLabel";
            this.IDValueLabel.Size = new System.Drawing.Size(0, 25);
            this.IDValueLabel.TabIndex = 15;
            // 
            // BirthDateTimePicker
            // 
            this.BirthDateTimePicker.CustomFormat = "        yyyy-MM-dd";
            this.BirthDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.BirthDateTimePicker.Location = new System.Drawing.Point(194, 176);
            this.BirthDateTimePicker.Name = "BirthDateTimePicker";
            this.BirthDateTimePicker.Size = new System.Drawing.Size(256, 30);
            this.BirthDateTimePicker.TabIndex = 30;
            // 
            // BirthErrorLabel
            // 
            this.BirthErrorLabel.AutoSize = true;
            this.BirthErrorLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.BirthErrorLabel.ImageAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.BirthErrorLabel.Location = new System.Drawing.Point(190, 153);
            this.BirthErrorLabel.Name = "BirthErrorLabel";
            this.BirthErrorLabel.Size = new System.Drawing.Size(0, 20);
            this.BirthErrorLabel.TabIndex = 31;
            this.BirthErrorLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // RegisterNewCustomer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 403);
            this.Controls.Add(this.BirthErrorLabel);
            this.Controls.Add(this.BirthDateTimePicker);
            this.Controls.Add(this.IDValueLabel);
            this.Controls.Add(this.LocationErrorLabel);
            this.Controls.Add(this.NameErrorLabel);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.SubmitButton);
            this.Controls.Add(this.LocationTextBox);
            this.Controls.Add(this.NameTextBox);
            this.Controls.Add(this.LocationLabel);
            this.Controls.Add(this.BirthLabel);
            this.Controls.Add(this.NameLabel);
            this.Controls.Add(this.IDLabel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "RegisterNewCustomer";
            this.Text = "Register New Customer";
            this.Load += new System.EventHandler(this.RegisterNewCustomer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label IDLabel;
        private System.Windows.Forms.Label NameLabel;
        private System.Windows.Forms.Label BirthLabel;
        private System.Windows.Forms.Label LocationLabel;
        private System.Windows.Forms.TextBox NameTextBox;
        private System.Windows.Forms.TextBox LocationTextBox;
        private System.Windows.Forms.Button SubmitButton;
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.Label NameErrorLabel;
        private System.Windows.Forms.Label LocationErrorLabel;
        private System.Windows.Forms.Label IDValueLabel;
        private System.Windows.Forms.DateTimePicker BirthDateTimePicker;
        private System.Windows.Forms.Label BirthErrorLabel;
    }
}