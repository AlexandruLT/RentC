﻿namespace RentC
{
    partial class ListCars
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
            this.CarsGridView = new System.Windows.Forms.DataGridView();
            this.BackButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.CarsGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // CarsGridView
            // 
            this.CarsGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CarsGridView.Location = new System.Drawing.Point(12, 12);
            this.CarsGridView.Name = "CarsGridView";
            this.CarsGridView.RowTemplate.Height = 24;
            this.CarsGridView.Size = new System.Drawing.Size(1065, 473);
            this.CarsGridView.TabIndex = 0;
            // 
            // BackButton
            // 
            this.BackButton.Location = new System.Drawing.Point(462, 497);
            this.BackButton.Name = "BackButton";
            this.BackButton.Size = new System.Drawing.Size(173, 48);
            this.BackButton.TabIndex = 2;
            this.BackButton.Text = "Back";
            this.BackButton.UseVisualStyleBackColor = true;
            this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // ListCars
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1089, 557);
            this.Controls.Add(this.BackButton);
            this.Controls.Add(this.CarsGridView);
            this.Name = "ListCars";
            this.Text = "ListCars";
            this.Load += new System.EventHandler(this.ListCars_Load);
            ((System.ComponentModel.ISupportInitialize)(this.CarsGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView CarsGridView;
        private System.Windows.Forms.Button BackButton;
    }
}