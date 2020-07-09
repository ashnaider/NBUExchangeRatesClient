namespace NBUExchangeRatesClient
{
    partial class Form1
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
            this.CurrInfoComboBox = new System.Windows.Forms.ComboBox();
            this.RegionComboBox = new System.Windows.Forms.ComboBox();
            this.CityComboBox = new System.Windows.Forms.ComboBox();
            this.FindButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SortByComboBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.BanksCheckBox = new System.Windows.Forms.CheckBox();
            this.ExchengersCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrInfoComboBox
            // 
            this.CurrInfoComboBox.FormattingEnabled = true;
            this.CurrInfoComboBox.Location = new System.Drawing.Point(31, 86);
            this.CurrInfoComboBox.Name = "CurrInfoComboBox";
            this.CurrInfoComboBox.Size = new System.Drawing.Size(121, 24);
            this.CurrInfoComboBox.TabIndex = 0;
            // 
            // RegionComboBox
            // 
            this.RegionComboBox.FormattingEnabled = true;
            this.RegionComboBox.Location = new System.Drawing.Point(187, 86);
            this.RegionComboBox.Name = "RegionComboBox";
            this.RegionComboBox.Size = new System.Drawing.Size(121, 24);
            this.RegionComboBox.TabIndex = 1;
            // 
            // CityComboBox
            // 
            this.CityComboBox.FormattingEnabled = true;
            this.CityComboBox.Location = new System.Drawing.Point(352, 86);
            this.CityComboBox.Name = "CityComboBox";
            this.CityComboBox.Size = new System.Drawing.Size(121, 24);
            this.CityComboBox.TabIndex = 2;
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(921, 91);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(132, 24);
            this.FindButton.TabIndex = 3;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(31, 146);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1022, 372);
            this.dataGridView1.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 54);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Currency";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(184, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 17);
            this.label2.TabIndex = 6;
            this.label2.Text = "Region";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(349, 54);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "City";
            // 
            // SortByComboBox
            // 
            this.SortByComboBox.FormattingEnabled = true;
            this.SortByComboBox.Items.AddRange(new object[] {
            "Min purchase",
            "Max sale"});
            this.SortByComboBox.Location = new System.Drawing.Point(523, 86);
            this.SortByComboBox.Name = "SortByComboBox";
            this.SortByComboBox.Size = new System.Drawing.Size(124, 24);
            this.SortByComboBox.TabIndex = 8;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(524, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 17);
            this.label4.TabIndex = 9;
            this.label4.Text = "Sort by";
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(921, 48);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(132, 28);
            this.UpdateButton.TabIndex = 10;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            // 
            // BanksCheckBox
            // 
            this.BanksCheckBox.AutoSize = true;
            this.BanksCheckBox.Location = new System.Drawing.Point(703, 48);
            this.BanksCheckBox.Name = "BanksCheckBox";
            this.BanksCheckBox.Size = new System.Drawing.Size(69, 21);
            this.BanksCheckBox.TabIndex = 11;
            this.BanksCheckBox.Text = "Banks";
            this.BanksCheckBox.UseVisualStyleBackColor = true;
            // 
            // ExchengersCheckBox
            // 
            this.ExchengersCheckBox.AutoSize = true;
            this.ExchengersCheckBox.Location = new System.Drawing.Point(703, 86);
            this.ExchengersCheckBox.Name = "ExchengersCheckBox";
            this.ExchengersCheckBox.Size = new System.Drawing.Size(104, 21);
            this.ExchengersCheckBox.TabIndex = 12;
            this.ExchengersCheckBox.Text = "Exchangers";
            this.ExchengersCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1084, 555);
            this.Controls.Add(this.ExchengersCheckBox);
            this.Controls.Add(this.BanksCheckBox);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.SortByComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.CityComboBox);
            this.Controls.Add(this.RegionComboBox);
            this.Controls.Add(this.CurrInfoComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CurrInfoComboBox;
        private System.Windows.Forms.ComboBox RegionComboBox;
        private System.Windows.Forms.ComboBox CityComboBox;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox SortByComboBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.CheckBox BanksCheckBox;
        private System.Windows.Forms.CheckBox ExchengersCheckBox;
    }
}

