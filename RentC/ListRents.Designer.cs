namespace RentC
{
    partial class ListRents
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
            this.RentsGridView = new System.Windows.Forms.DataGridView();
            this.BackButton = new System.Windows.Forms.Button();
            this.ActiveButton = new System.Windows.Forms.Button();
            this.AllButton = new System.Windows.Forms.Button();
            this.DeletedRentsButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.RentsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // RentsGridView
            // 
            this.RentsGridView.AllowUserToAddRows = false;
            this.RentsGridView.AllowUserToDeleteRows = false;
            this.RentsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RentsGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.RentsGridView.Location = new System.Drawing.Point(12, 13);
            this.RentsGridView.Name = "RentsGridView";
            this.RentsGridView.RowTemplate.Height = 24;
            this.RentsGridView.Size = new System.Drawing.Size(1058, 474);
            this.RentsGridView.TabIndex = 0;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(713, 493);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(173, 48);
            this.BackButton.TabIndex = 1;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ActiveButton
            // 
            this.ActiveButton.Location = new System.Drawing.Point(355, 493);
            this.ActiveButton.Name = "ActiveButton";
            this.ActiveButton.Size = new System.Drawing.Size(173, 48);
            this.ActiveButton.TabIndex = 2;
            this.ActiveButton.Text = "Show Active Rents";
            this.ActiveButton.UseVisualStyleBackColor = true;
            this.ActiveButton.Click += new System.EventHandler(this.ActiveButton_Click);
            // 
            // AllButton
            // 
            this.AllButton.Location = new System.Drawing.Point(176, 493);
            this.AllButton.Name = "AllButton";
            this.AllButton.Size = new System.Drawing.Size(173, 48);
            this.AllButton.TabIndex = 3;
            this.AllButton.Text = "Show All Rents";
            this.AllButton.UseVisualStyleBackColor = true;
            this.AllButton.Click += new System.EventHandler(this.AllButton_Click);
            // 
            // DeletedRentsButton
            // 
            this.DeletedRentsButton.Location = new System.Drawing.Point(534, 493);
            this.DeletedRentsButton.Name = "DeletedRentsButton";
            this.DeletedRentsButton.Size = new System.Drawing.Size(173, 48);
            this.DeletedRentsButton.TabIndex = 4;
            this.DeletedRentsButton.Text = "Show Deleted Rents";
            this.DeletedRentsButton.UseVisualStyleBackColor = true;
            this.DeletedRentsButton.Click += new System.EventHandler(this.DeletedRentsButton_Click);
            // 
            // ListRents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 553);
            this.Controls.Add(this.DeletedRentsButton);
            this.Controls.Add(this.AllButton);
            this.Controls.Add(this.ActiveButton);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.RentsGridView);
            this.Name = "ListRents";
            this.Text = "ListRents";
            this.Load += new System.EventHandler(this.ListRents_Load);
            ((System.ComponentModel.ISupportInitialize)(this.RentsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button BackButton;
        private System.Windows.Forms.DataGridView RentsGridView;
        private System.Windows.Forms.Button ActiveButton;
        private System.Windows.Forms.Button AllButton;
        private System.Windows.Forms.Button DeletedRentsButton;
    }
}