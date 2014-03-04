namespace CIPTrackingTools
{
    partial class frmThomasBrothers
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtThomasBrothersPage = new System.Windows.Forms.TextBox();
            this.btnFind = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.txtThomasBrothersRow = new System.Windows.Forms.TextBox();
            this.txtThomasBrothersColumn = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(172, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Thomas Brothers Page (e.g. 1289):";
            // 
            // txtThomasBrothersPage
            // 
            this.txtThomasBrothersPage.Location = new System.Drawing.Point(188, 20);
            this.txtThomasBrothersPage.Name = "txtThomasBrothersPage";
            this.txtThomasBrothersPage.Size = new System.Drawing.Size(49, 20);
            this.txtThomasBrothersPage.TabIndex = 0;
            this.txtThomasBrothersPage.TextChanged += new System.EventHandler(this.txtThomasBrothersPage_TextChanged);
            this.txtThomasBrothersPage.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThomasBrothersPage_KeyPress);
            // 
            // btnFind
            // 
            this.btnFind.Enabled = false;
            this.btnFind.Location = new System.Drawing.Point(255, 55);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(75, 23);
            this.btnFind.TabIndex = 3;
            this.btnFind.Text = "Find";
            this.btnFind.UseVisualStyleBackColor = true;
            this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(375, 55);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 4;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // txtThomasBrothersRow
            // 
            this.txtThomasBrothersRow.Location = new System.Drawing.Point(311, 20);
            this.txtThomasBrothersRow.Name = "txtThomasBrothersRow";
            this.txtThomasBrothersRow.Size = new System.Drawing.Size(49, 20);
            this.txtThomasBrothersRow.TabIndex = 1;
            this.txtThomasBrothersRow.TextChanged += new System.EventHandler(this.txtThomasBrothersRow_TextChanged);
            this.txtThomasBrothersRow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThomasBrothersRow_KeyPress);
            // 
            // txtThomasBrothersColumn
            // 
            this.txtThomasBrothersColumn.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtThomasBrothersColumn.Location = new System.Drawing.Point(444, 20);
            this.txtThomasBrothersColumn.Name = "txtThomasBrothersColumn";
            this.txtThomasBrothersColumn.Size = new System.Drawing.Size(49, 20);
            this.txtThomasBrothersColumn.TabIndex = 2;
            this.txtThomasBrothersColumn.TextChanged += new System.EventHandler(this.txtThomasBrothersColumn_TextChanged);
            this.txtThomasBrothersColumn.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtThomasBrothersColumn_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(252, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 16;
            this.label2.Text = "Row (1-7):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(372, 23);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Column (A-J):";
            // 
            // frmThomasBrothers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(509, 93);
            this.Controls.Add(this.txtThomasBrothersRow);
            this.Controls.Add(this.txtThomasBrothersPage);
            this.Controls.Add(this.txtThomasBrothersColumn);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnFind);
            this.Controls.Add(this.btnClose);
            this.Name = "frmThomasBrothers";
            this.Text = "CipT - Find Thomas Brothers Page";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtThomasBrothersPage;
        private System.Windows.Forms.Button btnFind;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TextBox txtThomasBrothersRow;
        private System.Windows.Forms.TextBox txtThomasBrothersColumn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}