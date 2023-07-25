namespace FinancialTradingPlatform
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnFastLocalOperation = new System.Windows.Forms.Button();
            this.btnCPUBoundOperation = new System.Windows.Forms.Button();
            this.lvwOutput = new System.Windows.Forms.ListView();
            this.SuspendLayout();
            // 
            // btnFastLocalOperation
            // 
            this.btnFastLocalOperation.Location = new System.Drawing.Point(38, 33);
            this.btnFastLocalOperation.Name = "btnFastLocalOperation";
            this.btnFastLocalOperation.Size = new System.Drawing.Size(280, 50);
            this.btnFastLocalOperation.TabIndex = 0;
            this.btnFastLocalOperation.Text = "Fast Local Operation";
            this.btnFastLocalOperation.UseVisualStyleBackColor = true;
            this.btnFastLocalOperation.Click += new System.EventHandler(this.btnFastLocalOperation_Click);
            // 
            // btnCPUBoundOperation
            // 
            this.btnCPUBoundOperation.Location = new System.Drawing.Point(38, 99);
            this.btnCPUBoundOperation.Name = "btnCPUBoundOperation";
            this.btnCPUBoundOperation.Size = new System.Drawing.Size(280, 47);
            this.btnCPUBoundOperation.TabIndex = 1;
            this.btnCPUBoundOperation.Text = "CPU Bound Operation";
            this.btnCPUBoundOperation.UseVisualStyleBackColor = true;
            this.btnCPUBoundOperation.Click += new System.EventHandler(this.btnCPUBoundOperation_Click);
            // 
            // lvwOutput
            // 
            this.lvwOutput.Location = new System.Drawing.Point(378, 33);
            this.lvwOutput.Name = "lvwOutput";
            this.lvwOutput.Size = new System.Drawing.Size(393, 337);
            this.lvwOutput.TabIndex = 2;
            this.lvwOutput.UseCompatibleStateImageBehavior = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.lvwOutput);
            this.Controls.Add(this.btnCPUBoundOperation);
            this.Controls.Add(this.btnFastLocalOperation);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private Button btnFastLocalOperation;
        private Button btnCPUBoundOperation;
        private ListView lvwOutput;

        private void AddListItem(string item)
        {
            ListViewItem listViewItem = new ListViewItem(item);
            listViewItem.Text = item;
            lvwOutput.Items.Add(listViewItem);
        }
    }
}