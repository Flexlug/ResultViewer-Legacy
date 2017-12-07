namespace ResultViewer
{
    partial class main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(main));
            this.nameLabel = new System.Windows.Forms.Label();
            this.SetDataButton = new System.Windows.Forms.Button();
            this.ShowDataButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.LoadDataButton = new System.Windows.Forms.Button();
            this.SaveButton = new System.Windows.Forms.Button();
            this.replaceData = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.SettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MainViewerSettingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OthersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.PreviewDataListBox = new System.Windows.Forms.ListBox();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // nameLabel
            // 
            this.nameLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nameLabel.AutoSize = true;
            this.nameLabel.BackColor = System.Drawing.Color.Transparent;
            this.nameLabel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.nameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.nameLabel.Location = new System.Drawing.Point(161, 32);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(131, 25);
            this.nameLabel.TabIndex = 0;
            this.nameLabel.Text = "Result Viewer";
            this.nameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SetDataButton
            // 
            this.SetDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SetDataButton.Location = new System.Drawing.Point(144, 100);
            this.SetDataButton.Name = "SetDataButton";
            this.SetDataButton.Size = new System.Drawing.Size(160, 30);
            this.SetDataButton.TabIndex = 1;
            this.SetDataButton.Text = "Новые данные";
            this.SetDataButton.UseVisualStyleBackColor = true;
            this.SetDataButton.Click += new System.EventHandler(this.SetDataButton_Click);
            // 
            // ShowDataButton
            // 
            this.ShowDataButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.ShowDataButton.ForeColor = System.Drawing.Color.Black;
            this.ShowDataButton.Location = new System.Drawing.Point(144, 136);
            this.ShowDataButton.Name = "ShowDataButton";
            this.ShowDataButton.Size = new System.Drawing.Size(160, 30);
            this.ShowDataButton.TabIndex = 2;
            this.ShowDataButton.Text = "Показ результатов";
            this.ShowDataButton.UseVisualStyleBackColor = true;
            this.ShowDataButton.Click += new System.EventHandler(this.ShowDataButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(12, 57);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(422, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Программа для показа результатов разнообразных конкурсов";
            // 
            // StatusLabel
            // 
            this.StatusLabel.AutoSize = true;
            this.StatusLabel.BackColor = System.Drawing.Color.Transparent;
            this.StatusLabel.Location = new System.Drawing.Point(12, 257);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(68, 13);
            this.StatusLabel.TabIndex = 4;
            this.StatusLabel.Text = "Ожидание...";
            // 
            // LoadDataButton
            // 
            this.LoadDataButton.Location = new System.Drawing.Point(144, 172);
            this.LoadDataButton.Name = "LoadDataButton";
            this.LoadDataButton.Size = new System.Drawing.Size(75, 23);
            this.LoadDataButton.TabIndex = 6;
            this.LoadDataButton.Text = "Загрузить";
            this.LoadDataButton.UseVisualStyleBackColor = true;
            this.LoadDataButton.Click += new System.EventHandler(this.LoadDataButton_Click);
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(229, 172);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 7;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // replaceData
            // 
            this.replaceData.Location = new System.Drawing.Point(310, 100);
            this.replaceData.Name = "replaceData";
            this.replaceData.Size = new System.Drawing.Size(37, 30);
            this.replaceData.TabIndex = 8;
            this.replaceData.Text = "+";
            this.replaceData.UseVisualStyleBackColor = true;
            this.replaceData.Visible = false;
            this.replaceData.Click += new System.EventHandler(this.replaceData_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SettingsToolStripMenuItem,
            this.OthersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(452, 24);
            this.menuStrip1.TabIndex = 9;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // SettingsToolStripMenuItem
            // 
            this.SettingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.MainViewerSettingsToolStripMenuItem});
            this.SettingsToolStripMenuItem.Name = "SettingsToolStripMenuItem";
            this.SettingsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.SettingsToolStripMenuItem.Text = "Главные";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.openToolStripMenuItem.Text = "Открыть";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // MainViewerSettingsToolStripMenuItem
            // 
            this.MainViewerSettingsToolStripMenuItem.Name = "MainViewerSettingsToolStripMenuItem";
            this.MainViewerSettingsToolStripMenuItem.Size = new System.Drawing.Size(246, 22);
            this.MainViewerSettingsToolStripMenuItem.Text = "Настройки вывода результатов";
            this.MainViewerSettingsToolStripMenuItem.Click += new System.EventHandler(this.MainViewerSettingsToolStripMenuItem_Click);
            // 
            // OthersToolStripMenuItem
            // 
            this.OthersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreatorsToolStripMenuItem});
            this.OthersToolStripMenuItem.Name = "OthersToolStripMenuItem";
            this.OthersToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.OthersToolStripMenuItem.Text = "Прочее";
            // 
            // CreatorsToolStripMenuItem
            // 
            this.CreatorsToolStripMenuItem.Name = "CreatorsToolStripMenuItem";
            this.CreatorsToolStripMenuItem.Size = new System.Drawing.Size(131, 22);
            this.CreatorsToolStripMenuItem.Text = "Создатели";
            this.CreatorsToolStripMenuItem.Click += new System.EventHandler(this.CreatorsToolStripMenuItem_Click);
            // 
            // PreviewDataListBox
            // 
            this.PreviewDataListBox.FormattingEnabled = true;
            this.PreviewDataListBox.Location = new System.Drawing.Point(224, 94);
            this.PreviewDataListBox.Name = "PreviewDataListBox";
            this.PreviewDataListBox.Size = new System.Drawing.Size(216, 173);
            this.PreviewDataListBox.TabIndex = 10;
            this.PreviewDataListBox.Visible = false;
            // 
            // main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(452, 279);
            this.Controls.Add(this.PreviewDataListBox);
            this.Controls.Add(this.replaceData);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.LoadDataButton);
            this.Controls.Add(this.StatusLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ShowDataButton);
            this.Controls.Add(this.SetDataButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "main";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Result Viewer";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button SetDataButton;
        private System.Windows.Forms.Button ShowDataButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label StatusLabel;
		private System.Windows.Forms.Button LoadDataButton;
		private System.Windows.Forms.Button SaveButton;
		private System.Windows.Forms.Button replaceData;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem SettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MainViewerSettingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem OthersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem CreatorsToolStripMenuItem;
        private System.Windows.Forms.ListBox PreviewDataListBox;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
    }
}

