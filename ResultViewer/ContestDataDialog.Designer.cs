namespace ResultViewer
{
    partial class ContestDataDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ContestDataDialog));
            this.CancelButton = new System.Windows.Forms.Button();
            this.OkButton = new System.Windows.Forms.Button();
            this.JuryGroupBox = new System.Windows.Forms.GroupBox();
            this.JuryListbox = new System.Windows.Forms.ListBox();
            this.JuryRemoveButton = new System.Windows.Forms.Button();
            this.JuryCountLabel = new System.Windows.Forms.Label();
            this.JuryAddButton = new System.Windows.Forms.Button();
            this.JuryFIOLabel = new System.Windows.Forms.Label();
            this.JuryFIOTextbox = new System.Windows.Forms.TextBox();
            this.ContGroupBox = new System.Windows.Forms.GroupBox();
            this.ContestListbox = new System.Windows.Forms.ListBox();
            this.ContRemoveButton = new System.Windows.Forms.Button();
            this.ContCountLabel = new System.Windows.Forms.Label();
            this.ContAddButton = new System.Windows.Forms.Button();
            this.ContFIOTextbox = new System.Windows.Forms.TextBox();
            this.ContFIOLabel = new System.Windows.Forms.Label();
            this.JuryGroupBox.SuspendLayout();
            this.ContGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            resources.ApplyResources(this.CancelButton, "CancelButton");
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // OkButton
            // 
            resources.ApplyResources(this.OkButton, "OkButton");
            this.OkButton.Name = "OkButton";
            this.OkButton.UseVisualStyleBackColor = true;
            this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // JuryGroupBox
            // 
            this.JuryGroupBox.Controls.Add(this.JuryListbox);
            this.JuryGroupBox.Controls.Add(this.JuryRemoveButton);
            this.JuryGroupBox.Controls.Add(this.JuryCountLabel);
            this.JuryGroupBox.Controls.Add(this.JuryAddButton);
            this.JuryGroupBox.Controls.Add(this.JuryFIOLabel);
            this.JuryGroupBox.Controls.Add(this.JuryFIOTextbox);
            resources.ApplyResources(this.JuryGroupBox, "JuryGroupBox");
            this.JuryGroupBox.Name = "JuryGroupBox";
            this.JuryGroupBox.TabStop = false;
            // 
            // JuryListbox
            // 
            this.JuryListbox.FormattingEnabled = true;
            resources.ApplyResources(this.JuryListbox, "JuryListbox");
            this.JuryListbox.Name = "JuryListbox";
            // 
            // JuryRemoveButton
            // 
            resources.ApplyResources(this.JuryRemoveButton, "JuryRemoveButton");
            this.JuryRemoveButton.Name = "JuryRemoveButton";
            this.JuryRemoveButton.UseVisualStyleBackColor = true;
            this.JuryRemoveButton.Click += new System.EventHandler(this.JuryRemoveButton_Click);
            // 
            // JuryCountLabel
            // 
            resources.ApplyResources(this.JuryCountLabel, "JuryCountLabel");
            this.JuryCountLabel.Name = "JuryCountLabel";
            // 
            // JuryAddButton
            // 
            resources.ApplyResources(this.JuryAddButton, "JuryAddButton");
            this.JuryAddButton.Name = "JuryAddButton";
            this.JuryAddButton.UseVisualStyleBackColor = true;
            this.JuryAddButton.Click += new System.EventHandler(this.JuryAddButton_Click);
            // 
            // JuryFIOLabel
            // 
            resources.ApplyResources(this.JuryFIOLabel, "JuryFIOLabel");
            this.JuryFIOLabel.Name = "JuryFIOLabel";
            // 
            // JuryFIOTextbox
            // 
            resources.ApplyResources(this.JuryFIOTextbox, "JuryFIOTextbox");
            this.JuryFIOTextbox.Name = "JuryFIOTextbox";
            this.JuryFIOTextbox.TextChanged += new System.EventHandler(this.JuryFIOTextbox_TextChanged);
            this.JuryFIOTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.JuryFIOTextbox_KeyPress);
            // 
            // ContGroupBox
            // 
            this.ContGroupBox.Controls.Add(this.ContestListbox);
            this.ContGroupBox.Controls.Add(this.ContRemoveButton);
            this.ContGroupBox.Controls.Add(this.ContCountLabel);
            this.ContGroupBox.Controls.Add(this.ContAddButton);
            this.ContGroupBox.Controls.Add(this.ContFIOTextbox);
            this.ContGroupBox.Controls.Add(this.ContFIOLabel);
            resources.ApplyResources(this.ContGroupBox, "ContGroupBox");
            this.ContGroupBox.Name = "ContGroupBox";
            this.ContGroupBox.TabStop = false;
            // 
            // ContestListbox
            // 
            this.ContestListbox.FormattingEnabled = true;
            resources.ApplyResources(this.ContestListbox, "ContestListbox");
            this.ContestListbox.Name = "ContestListbox";
            // 
            // ContRemoveButton
            // 
            resources.ApplyResources(this.ContRemoveButton, "ContRemoveButton");
            this.ContRemoveButton.Name = "ContRemoveButton";
            this.ContRemoveButton.UseVisualStyleBackColor = true;
            this.ContRemoveButton.Click += new System.EventHandler(this.ContRemoveButton_Click);
            // 
            // ContCountLabel
            // 
            resources.ApplyResources(this.ContCountLabel, "ContCountLabel");
            this.ContCountLabel.Name = "ContCountLabel";
            // 
            // ContAddButton
            // 
            resources.ApplyResources(this.ContAddButton, "ContAddButton");
            this.ContAddButton.Name = "ContAddButton";
            this.ContAddButton.UseVisualStyleBackColor = true;
            this.ContAddButton.Click += new System.EventHandler(this.ContAddButton_Click);
            // 
            // ContFIOTextbox
            // 
            resources.ApplyResources(this.ContFIOTextbox, "ContFIOTextbox");
            this.ContFIOTextbox.Name = "ContFIOTextbox";
            this.ContFIOTextbox.TextChanged += new System.EventHandler(this.ContFIOTextbox_TextChanged);
            this.ContFIOTextbox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ContFIOTextbox_KeyPress);
            // 
            // ContFIOLabel
            // 
            resources.ApplyResources(this.ContFIOLabel, "ContFIOLabel");
            this.ContFIOLabel.Name = "ContFIOLabel";
            // 
            // ContestDataDialog
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ContGroupBox);
            this.Controls.Add(this.JuryGroupBox);
            this.Controls.Add(this.OkButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.MaximizeBox = false;
            this.Name = "ContestDataDialog";
            this.JuryGroupBox.ResumeLayout(false);
            this.JuryGroupBox.PerformLayout();
            this.ContGroupBox.ResumeLayout(false);
            this.ContGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OkButton;
        private System.Windows.Forms.GroupBox JuryGroupBox;
        private System.Windows.Forms.Button JuryAddButton;
        private System.Windows.Forms.Label JuryFIOLabel;
        private System.Windows.Forms.TextBox JuryFIOTextbox;
        private System.Windows.Forms.GroupBox ContGroupBox;
        private System.Windows.Forms.Label ContFIOLabel;
        private System.Windows.Forms.Button ContAddButton;
        private System.Windows.Forms.TextBox ContFIOTextbox;
        private System.Windows.Forms.Label JuryCountLabel;
        private System.Windows.Forms.Label ContCountLabel;
        private System.Windows.Forms.Button JuryRemoveButton;
        private System.Windows.Forms.Button ContRemoveButton;
        private System.Windows.Forms.ListBox JuryListbox;
        private System.Windows.Forms.ListBox ContestListbox;
    }
}