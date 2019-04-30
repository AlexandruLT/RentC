namespace RentC
{
    partial class ListCustomers
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
            this.BackButton = new System.Windows.Forms.Button();
            this.CustomersGridView = new System.Windows.Forms.DataGridView();
            this.ShowActiveButton = new System.Windows.Forms.Button();
            this.ShowAllButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CustomersGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(638, 489);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(180, 48);
            this.BackButton.TabIndex = 3;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // CustomersGridView
            // 
            this.CustomersGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CustomersGridView.Location = new System.Drawing.Point(9, 9);
            this.CustomersGridView.Name = "CustomersGridView";
            this.CustomersGridView.RowTemplate.Height = 24;
            this.CustomersGridView.Size = new System.Drawing.Size(1058, 474);
            this.CustomersGridView.TabIndex = 2;
            // 
            // ShowActiveButton
            // 
            this.ShowActiveButton.Location = new System.Drawing.Point(452, 489);
            this.ShowActiveButton.Name = "ShowActiveButton";
            this.ShowActiveButton.Size = new System.Drawing.Size(180, 48);
            this.ShowActiveButton.TabIndex = 4;
            this.ShowActiveButton.Text = "Show Active Customers";
            this.ShowActiveButton.UseVisualStyleBackColor = true;
            this.ShowActiveButton.Click += new System.EventHandler(this.ShowActiveButton_Click);
            // 
            // ShowAllButton
            // 
            this.ShowAllButton.Location = new System.Drawing.Point(266, 489);
            this.ShowAllButton.Name = "ShowAllButton";
            this.ShowAllButton.Size = new System.Drawing.Size(180, 48);
            this.ShowAllButton.TabIndex = 5;
            this.ShowAllButton.Text = "Show All Customers";
            this.ShowAllButton.UseVisualStyleBackColor = true;
            this.ShowAllButton.Click += new System.EventHandler(this.ShowAllButton_Click);
            // 
            // ListCustomers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1076, 546);
            this.Controls.Add(this.ShowAllButton);
            this.Controls.Add(this.ShowActiveButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CustomersGridView);
            this.Name = "ListCustomers";
            this.Text = "ListCustomers";
            this.Load += new System.EventHandler(this.ListCustomers_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CustomersGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.DataGridView CustomersGridView;
        private System.Windows.Forms.Button ShowActiveButton;
        private System.Windows.Forms.Button ShowAllButton;
    }
}