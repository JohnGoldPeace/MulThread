namespace MulThread
{
    partial class MainForm
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
            this.TaskListView = new System.Windows.Forms.ListView();
            this.IndexCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProgressCol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1 = new System.Windows.Forms.Panel();
            this.AddBtn = new System.Windows.Forms.Button();
            this.ColID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TaskListView
            // 
            this.TaskListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IndexCol,
            this.StatusCol,
            this.ProgressCol,
            this.ColID});
            this.TaskListView.Dock = System.Windows.Forms.DockStyle.Top;
            this.TaskListView.Location = new System.Drawing.Point(0, 0);
            this.TaskListView.Name = "TaskListView";
            this.TaskListView.Size = new System.Drawing.Size(654, 379);
            this.TaskListView.TabIndex = 0;
            this.TaskListView.UseCompatibleStateImageBehavior = false;
            // 
            // IndexCol
            // 
            this.IndexCol.Text = "Index";
            // 
            // StatusCol
            // 
            this.StatusCol.Text = "Status";
            this.StatusCol.Width = 100;
            // 
            // ProgressCol
            // 
            this.ProgressCol.Text = "Progress";
            this.ProgressCol.Width = 100;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.AddBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 379);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(654, 36);
            this.panel1.TabIndex = 1;
            // 
            // AddBtn
            // 
            this.AddBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.AddBtn.Location = new System.Drawing.Point(557, 6);
            this.AddBtn.Name = "AddBtn";
            this.AddBtn.Size = new System.Drawing.Size(85, 23);
            this.AddBtn.TabIndex = 0;
            this.AddBtn.Text = "AddTask";
            this.AddBtn.UseVisualStyleBackColor = true;
            this.AddBtn.Click += new System.EventHandler(this.AddBtn_Click);
            // 
            // ColID
            // 
            this.ColID.Text = "ID";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 415);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.TaskListView);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView TaskListView;
        private System.Windows.Forms.ColumnHeader IndexCol;
        private System.Windows.Forms.ColumnHeader StatusCol;
        private System.Windows.Forms.ColumnHeader ProgressCol;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button AddBtn;
        private System.Windows.Forms.ColumnHeader ColID;
    }
}