namespace NbuClient
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.CurrencyComboBox = new System.Windows.Forms.ComboBox();
            this.RegionComboBox = new System.Windows.Forms.ComboBox();
            this.CityComboBox = new System.Windows.Forms.ComboBox();
            this.SortByComboBox = new System.Windows.Forms.ComboBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.FindButton = new System.Windows.Forms.Button();
            this.CurrencyLabel = new System.Windows.Forms.Label();
            this.CityLabel = new System.Windows.Forms.Label();
            this.SortByLabel = new System.Windows.Forms.Label();
            this.RegionLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.BanksListView = new System.Windows.Forms.ListView();
            this.CurrencyListView = new System.Windows.Forms.ListView();
            this.LastDateLabel = new System.Windows.Forms.Label();
            this.OrgTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CurrencyComboBox
            // 
            this.CurrencyComboBox.FormattingEnabled = true;
            this.CurrencyComboBox.Location = new System.Drawing.Point(48, 130);
            this.CurrencyComboBox.Name = "CurrencyComboBox";
            this.CurrencyComboBox.Size = new System.Drawing.Size(280, 24);
            this.CurrencyComboBox.TabIndex = 0;
            // 
            // RegionComboBox
            // 
            this.RegionComboBox.FormattingEnabled = true;
            this.RegionComboBox.Location = new System.Drawing.Point(346, 130);
            this.RegionComboBox.Name = "RegionComboBox";
            this.RegionComboBox.Size = new System.Drawing.Size(238, 24);
            this.RegionComboBox.TabIndex = 1;
            // 
            // CityComboBox
            // 
            this.CityComboBox.FormattingEnabled = true;
            this.CityComboBox.Location = new System.Drawing.Point(611, 130);
            this.CityComboBox.Name = "CityComboBox";
            this.CityComboBox.Size = new System.Drawing.Size(120, 24);
            this.CityComboBox.TabIndex = 2;
            // 
            // SortByComboBox
            // 
            this.SortByComboBox.FormattingEnabled = true;
            this.SortByComboBox.Items.AddRange(new object[] {
            "Min Purchase",
            "Max Sale"});
            this.SortByComboBox.Location = new System.Drawing.Point(759, 130);
            this.SortByComboBox.Name = "SortByComboBox";
            this.SortByComboBox.Size = new System.Drawing.Size(120, 24);
            this.SortByComboBox.TabIndex = 3;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Location = new System.Drawing.Point(1085, 27);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(137, 30);
            this.UpdateButton.TabIndex = 6;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(1085, 124);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(137, 30);
            this.FindButton.TabIndex = 7;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // CurrencyLabel
            // 
            this.CurrencyLabel.AutoSize = true;
            this.CurrencyLabel.Location = new System.Drawing.Point(45, 95);
            this.CurrencyLabel.Name = "CurrencyLabel";
            this.CurrencyLabel.Size = new System.Drawing.Size(65, 17);
            this.CurrencyLabel.TabIndex = 8;
            this.CurrencyLabel.Text = "Currency";
            // 
            // CityLabel
            // 
            this.CityLabel.AutoSize = true;
            this.CityLabel.Location = new System.Drawing.Point(608, 95);
            this.CityLabel.Name = "CityLabel";
            this.CityLabel.Size = new System.Drawing.Size(31, 17);
            this.CityLabel.TabIndex = 9;
            this.CityLabel.Text = "City";
            // 
            // SortByLabel
            // 
            this.SortByLabel.AutoSize = true;
            this.SortByLabel.Location = new System.Drawing.Point(756, 95);
            this.SortByLabel.Name = "SortByLabel";
            this.SortByLabel.Size = new System.Drawing.Size(50, 17);
            this.SortByLabel.TabIndex = 10;
            this.SortByLabel.Text = "SortBy";
            // 
            // RegionLabel
            // 
            this.RegionLabel.AutoSize = true;
            this.RegionLabel.Location = new System.Drawing.Point(343, 95);
            this.RegionLabel.Name = "RegionLabel";
            this.RegionLabel.Size = new System.Drawing.Size(53, 17);
            this.RegionLabel.TabIndex = 11;
            this.RegionLabel.Text = "Region";
            // 
            // DateLabel
            // 
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(45, 27);
            this.DateLabel.Name = "DateLabel";
            this.DateLabel.Size = new System.Drawing.Size(38, 17);
            this.DateLabel.TabIndex = 12;
            this.DateLabel.Text = "Date";
            // 
            // BanksListView
            // 
            this.BanksListView.HideSelection = false;
            this.BanksListView.Location = new System.Drawing.Point(48, 189);
            this.BanksListView.Name = "BanksListView";
            this.BanksListView.Size = new System.Drawing.Size(758, 415);
            this.BanksListView.TabIndex = 13;
            this.BanksListView.UseCompatibleStateImageBehavior = false;
            // 
            // CurrencyListView
            // 
            this.CurrencyListView.HideSelection = false;
            this.CurrencyListView.Location = new System.Drawing.Point(843, 189);
            this.CurrencyListView.Name = "CurrencyListView";
            this.CurrencyListView.Size = new System.Drawing.Size(379, 415);
            this.CurrencyListView.TabIndex = 14;
            this.CurrencyListView.UseCompatibleStateImageBehavior = false;
            // 
            // LastDateLabel
            // 
            this.LastDateLabel.AutoSize = true;
            this.LastDateLabel.Location = new System.Drawing.Point(137, 27);
            this.LastDateLabel.Name = "LastDateLabel";
            this.LastDateLabel.Size = new System.Drawing.Size(127, 17);
            this.LastDateLabel.TabIndex = 15;
            this.LastDateLabel.Text = "Place to show date";
            // 
            // OrgTypeComboBox
            // 
            this.OrgTypeComboBox.FormattingEnabled = true;
            this.OrgTypeComboBox.Location = new System.Drawing.Point(930, 130);
            this.OrgTypeComboBox.Name = "OrgTypeComboBox";
            this.OrgTypeComboBox.Size = new System.Drawing.Size(121, 24);
            this.OrgTypeComboBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(927, 95);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Org Type";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1245, 628);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OrgTypeComboBox);
            this.Controls.Add(this.LastDateLabel);
            this.Controls.Add(this.CurrencyListView);
            this.Controls.Add(this.BanksListView);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.RegionLabel);
            this.Controls.Add(this.SortByLabel);
            this.Controls.Add(this.CityLabel);
            this.Controls.Add(this.CurrencyLabel);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.SortByComboBox);
            this.Controls.Add(this.CityComboBox);
            this.Controls.Add(this.RegionComboBox);
            this.Controls.Add(this.CurrencyComboBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CurrencyComboBox;
        private System.Windows.Forms.ComboBox RegionComboBox;
        private System.Windows.Forms.ComboBox CityComboBox;
        private System.Windows.Forms.ComboBox SortByComboBox;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Label CurrencyLabel;
        private System.Windows.Forms.Label CityLabel;
        private System.Windows.Forms.Label SortByLabel;
        private System.Windows.Forms.Label RegionLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.ListView BanksListView;
        private System.Windows.Forms.ListView CurrencyListView;
        private System.Windows.Forms.Label LastDateLabel;
        private System.Windows.Forms.ComboBox OrgTypeComboBox;
        private System.Windows.Forms.Label label1;
    }
}

