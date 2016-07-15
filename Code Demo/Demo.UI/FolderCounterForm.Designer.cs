namespace Demo.UI
{
    partial class FolderCounterForm
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
            this.Start = new System.Windows.Forms.Button();
            this.RootPath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.FolderCounts = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Messages = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(11, 57);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(98, 23);
            this.Start.TabIndex = 1;
            this.Start.Text = "List and Count";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.ListAndCount_Click);
            // 
            // RootPath
            // 
            this.RootPath.Location = new System.Drawing.Point(12, 31);
            this.RootPath.Name = "RootPath";
            this.RootPath.Size = new System.Drawing.Size(522, 20);
            this.RootPath.TabIndex = 2;
            this.RootPath.Text = "C:\\";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(190, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Top level folders and subfolder counts:";
            // 
            // FolderCounts
            // 
            this.FolderCounts.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.FolderCounts.Location = new System.Drawing.Point(11, 108);
            this.FolderCounts.Name = "FolderCounts";
            this.FolderCounts.Size = new System.Drawing.Size(523, 372);
            this.FolderCounts.TabIndex = 7;
            this.FolderCounts.UseCompatibleStateImageBehavior = false;
            this.FolderCounts.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Folder";
            this.columnHeader1.Width = 250;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Subfolder Count";
            this.columnHeader2.Width = 100;
            // 
            // Messages
            // 
            this.Messages.Location = new System.Drawing.Point(11, 508);
            this.Messages.Multiline = true;
            this.Messages.Name = "Messages";
            this.Messages.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.Messages.Size = new System.Drawing.Size(523, 88);
            this.Messages.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 492);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Messages:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(143, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Enter a valid path to a folder:";
            // 
            // FolderCounterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(547, 601);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Messages);
            this.Controls.Add(this.FolderCounts);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.RootPath);
            this.Controls.Add(this.Start);
            this.Name = "FolderCounterForm";
            this.Text = "Folder Counter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button Start;
        private System.Windows.Forms.TextBox RootPath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListView FolderCounts;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.TextBox Messages;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}

