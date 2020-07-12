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
            this.CityComboBox = new System.Windows.Forms.ComboBox();
            this.SortByComboBox = new System.Windows.Forms.ComboBox();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.FindButton = new System.Windows.Forms.Button();
            this.CurrencyLabel = new System.Windows.Forms.Label();
            this.SortByLabel = new System.Windows.Forms.Label();
            this.DateLabel = new System.Windows.Forms.Label();
            this.BanksListView = new System.Windows.Forms.ListView();
            this.CurrencyListView = new System.Windows.Forms.ListView();
            this.LastDateLabel = new System.Windows.Forms.Label();
            this.OrgTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // CurrencyComboBox
            // 
            this.CurrencyComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrencyComboBox.FormattingEnabled = true;
            this.CurrencyComboBox.Location = new System.Drawing.Point(48, 132);
            this.CurrencyComboBox.Name = "CurrencyComboBox";
            this.CurrencyComboBox.Size = new System.Drawing.Size(337, 24);
            this.CurrencyComboBox.TabIndex = 0;
            this.CurrencyComboBox.SelectedIndexChanged += new System.EventHandler(this.CurrencyComboBox_SelectedIndexChanged);
            // 
            // CityComboBox
            // 
            this.CityComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.CityComboBox.FormattingEnabled = true;
            this.CityComboBox.Location = new System.Drawing.Point(421, 132);
            this.CityComboBox.Name = "CityComboBox";
            this.CityComboBox.Size = new System.Drawing.Size(120, 24);
            this.CityComboBox.TabIndex = 2;
            // 
            // SortByComboBox
            // 
            this.SortByComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SortByComboBox.FormattingEnabled = true;
            this.SortByComboBox.Items.AddRange(new object[] {
            "All",
            "Min Purchase",
            "Max Sale"});
            this.SortByComboBox.Location = new System.Drawing.Point(610, 132);
            this.SortByComboBox.Name = "SortByComboBox";
            this.SortByComboBox.Size = new System.Drawing.Size(120, 24);
            this.SortByComboBox.TabIndex = 3;
            // 
            // UpdateButton
            // 
            this.UpdateButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.UpdateButton.Location = new System.Drawing.Point(969, 29);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(137, 30);
            this.UpdateButton.TabIndex = 6;
            this.UpdateButton.Text = "Update";
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
            // 
            // FindButton
            // 
            this.FindButton.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.FindButton.Location = new System.Drawing.Point(969, 126);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(137, 30);
            this.FindButton.TabIndex = 7;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // CurrencyLabel
            // 
            this.CurrencyLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.CurrencyLabel.AutoSize = true;
            this.CurrencyLabel.Location = new System.Drawing.Point(45, 97);
            this.CurrencyLabel.Name = "CurrencyLabel";
            this.CurrencyLabel.Size = new System.Drawing.Size(65, 17);
            this.CurrencyLabel.TabIndex = 8;
            this.CurrencyLabel.Text = "Currency";
            // 
            // SortByLabel
            // 
            this.SortByLabel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.SortByLabel.AutoSize = true;
            this.SortByLabel.Location = new System.Drawing.Point(607, 97);
            this.SortByLabel.Name = "SortByLabel";
            this.SortByLabel.Size = new System.Drawing.Size(50, 17);
            this.SortByLabel.TabIndex = 10;
            this.SortByLabel.Text = "SortBy";
            // 
            // DateLabel
            // 
            this.DateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.DateLabel.AutoSize = true;
            this.DateLabel.Location = new System.Drawing.Point(45, 29);
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
            this.BanksListView.Size = new System.Drawing.Size(642, 411);
            this.BanksListView.TabIndex = 13;
            this.BanksListView.UseCompatibleStateImageBehavior = false;
            this.BanksListView.View = System.Windows.Forms.View.Details;
            this.BanksListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.BanksListView_ItemSelectionChanged);
            // 
            // CurrencyListView
            // 
            this.CurrencyListView.HideSelection = false;
            this.CurrencyListView.Location = new System.Drawing.Point(727, 189);
            this.CurrencyListView.Name = "CurrencyListView";
            this.CurrencyListView.Size = new System.Drawing.Size(379, 415);
            this.CurrencyListView.TabIndex = 14;
            this.CurrencyListView.UseCompatibleStateImageBehavior = false;
            // 
            // LastDateLabel
            // 
            this.LastDateLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.LastDateLabel.AutoSize = true;
            this.LastDateLabel.Location = new System.Drawing.Point(137, 29);
            this.LastDateLabel.Name = "LastDateLabel";
            this.LastDateLabel.Size = new System.Drawing.Size(127, 17);
            this.LastDateLabel.TabIndex = 15;
            this.LastDateLabel.Text = "Place to show date";
            // 
            // OrgTypeComboBox
            // 
            this.OrgTypeComboBox.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.OrgTypeComboBox.FormattingEnabled = true;
            this.OrgTypeComboBox.Location = new System.Drawing.Point(798, 132);
            this.OrgTypeComboBox.Name = "OrgTypeComboBox";
            this.OrgTypeComboBox.Size = new System.Drawing.Size(121, 24);
            this.OrgTypeComboBox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(795, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 17;
            this.label1.Text = "Org Type";
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(418, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "City";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1153, 633);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.OrgTypeComboBox);
            this.Controls.Add(this.LastDateLabel);
            this.Controls.Add(this.CurrencyListView);
            this.Controls.Add(this.BanksListView);
            this.Controls.Add(this.DateLabel);
            this.Controls.Add(this.SortByLabel);
            this.Controls.Add(this.CurrencyLabel);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.UpdateButton);
            this.Controls.Add(this.SortByComboBox);
            this.Controls.Add(this.CityComboBox);
            this.Controls.Add(this.CurrencyComboBox);
            this.MaximumSize = new System.Drawing.Size(1171, 680);
            this.MinimumSize = new System.Drawing.Size(1171, 680);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox CurrencyComboBox;
        private System.Windows.Forms.ComboBox CityComboBox;
        private System.Windows.Forms.ComboBox SortByComboBox;

        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Label CurrencyLabel;
        private System.Windows.Forms.Label SortByLabel;
        private System.Windows.Forms.Label DateLabel;
        private System.Windows.Forms.ListView BanksListView;
        private System.Windows.Forms.ListView CurrencyListView;
        private System.Windows.Forms.Label LastDateLabel;
        private System.Windows.Forms.ComboBox OrgTypeComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

