namespace MicroMonitor
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
            this.uxComputerList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.uxAdd = new System.Windows.Forms.Button();
            this.uxDelete = new System.Windows.Forms.Button();
            this.uxLastUpdated = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // uxComputerList
            // 
            this.uxComputerList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.uxComputerList.Location = new System.Drawing.Point(12, 42);
            this.uxComputerList.Name = "uxComputerList";
            this.uxComputerList.Size = new System.Drawing.Size(760, 507);
            this.uxComputerList.TabIndex = 0;
            this.uxComputerList.UseCompatibleStateImageBehavior = false;
            this.uxComputerList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Computer";
            this.columnHeader1.Width = 259;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Status";
            this.columnHeader2.Width = 120;
            // 
            // uxAdd
            // 
            this.uxAdd.Location = new System.Drawing.Point(12, 13);
            this.uxAdd.Name = "uxAdd";
            this.uxAdd.Size = new System.Drawing.Size(75, 23);
            this.uxAdd.TabIndex = 1;
            this.uxAdd.Text = "Add";
            this.uxAdd.UseVisualStyleBackColor = true;
            // 
            // uxDelete
            // 
            this.uxDelete.Location = new System.Drawing.Point(697, 13);
            this.uxDelete.Name = "uxDelete";
            this.uxDelete.Size = new System.Drawing.Size(75, 23);
            this.uxDelete.TabIndex = 2;
            this.uxDelete.Text = "Delete";
            this.uxDelete.UseVisualStyleBackColor = true;
            // 
            // uxLastUpdated
            // 
            this.uxLastUpdated.AutoSize = true;
            this.uxLastUpdated.Location = new System.Drawing.Point(287, 13);
            this.uxLastUpdated.Name = "uxLastUpdated";
            this.uxLastUpdated.Size = new System.Drawing.Size(0, 13);
            this.uxLastUpdated.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.uxLastUpdated);
            this.Controls.Add(this.uxDelete);
            this.Controls.Add(this.uxAdd);
            this.Controls.Add(this.uxComputerList);
            this.Name = "MainForm";
            this.Text = "Micro Monitor";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView uxComputerList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button uxAdd;
        private System.Windows.Forms.Button uxDelete;
        private System.Windows.Forms.Label uxLastUpdated;
    }
}

