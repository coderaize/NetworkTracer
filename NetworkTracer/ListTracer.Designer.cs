namespace NetworkTracer
{
    partial class ListTracer
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
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
			this.button1 = new System.Windows.Forms.Button();
			this.button2 = new System.Windows.Forms.Button();
			this.portStart = new System.Windows.Forms.Button();
			this.portNum = new System.Windows.Forms.TextBox();
			this.myDataGridView1 = new NetworkTracer.MyDataGridView();
			this.CIName = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.IP = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.TimeOut = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.MaxHops = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.Status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(488, 414);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 31);
			this.button1.TabIndex = 1;
			this.button1.Text = "Start Trace";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(12, 414);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(75, 31);
			this.button2.TabIndex = 2;
			this.button2.Text = "Get Hops";
			this.button2.UseVisualStyleBackColor = true;
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// portStart
			// 
			this.portStart.Location = new System.Drawing.Point(388, 414);
			this.portStart.Name = "portStart";
			this.portStart.Size = new System.Drawing.Size(94, 31);
			this.portStart.TabIndex = 3;
			this.portStart.Text = "Start with Port";
			this.portStart.UseVisualStyleBackColor = true;
			this.portStart.Click += new System.EventHandler(this.portStart_Click);
			// 
			// portNum
			// 
			this.portNum.Location = new System.Drawing.Point(246, 425);
			this.portNum.Name = "portNum";
			this.portNum.Size = new System.Drawing.Size(136, 20);
			this.portNum.TabIndex = 4;
			// 
			// myDataGridView1
			// 
			this.myDataGridView1.BackgroundColor = System.Drawing.Color.White;
			dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.myDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
			this.myDataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.myDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CIName,
            this.IP,
            this.TimeOut,
            this.MaxHops,
            this.Status});
			dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.DimGray;
			dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.myDataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
			this.myDataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
			this.myDataGridView1.IsSmallFont = true;
			this.myDataGridView1.Location = new System.Drawing.Point(12, 12);
			this.myDataGridView1.Name = "myDataGridView1";
			dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
			dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.DimGray;
			dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			this.myDataGridView1.RowsDefaultCellStyle = dataGridViewCellStyle3;
			this.myDataGridView1.Size = new System.Drawing.Size(551, 396);
			this.myDataGridView1.TabIndex = 0;
			// 
			// CIName
			// 
			this.CIName.HeaderText = "CIName";
			this.CIName.Name = "CIName";
			// 
			// IP
			// 
			this.IP.HeaderText = "IP";
			this.IP.Name = "IP";
			// 
			// TimeOut
			// 
			this.TimeOut.HeaderText = "TimeOut";
			this.TimeOut.Name = "TimeOut";
			// 
			// MaxHops
			// 
			this.MaxHops.HeaderText = "MaxHops";
			this.MaxHops.Name = "MaxHops";
			// 
			// Status
			// 
			this.Status.HeaderText = "Status";
			this.Status.Name = "Status";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(214, 428);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(26, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Port";
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(575, 477);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.portNum);
			this.Controls.Add(this.portStart);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.myDataGridView1);
			this.Name = "Form1";
			this.Text = "Network Tracer";
			((System.ComponentModel.ISupportInitialize)(this.myDataGridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private MyDataGridView myDataGridView1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn CIName;
        private System.Windows.Forms.DataGridViewTextBoxColumn IP;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeOut;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaxHops;
        private System.Windows.Forms.DataGridViewTextBoxColumn Status;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button portStart;
        private System.Windows.Forms.TextBox portNum;
		private System.Windows.Forms.Label label1;
	}
}

