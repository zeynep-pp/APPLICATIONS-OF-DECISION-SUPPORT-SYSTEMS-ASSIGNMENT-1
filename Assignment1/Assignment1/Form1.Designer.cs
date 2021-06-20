namespace Assignment1
{
    partial class Form1
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
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblResult = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnResult = new System.Windows.Forms.Button();
            this.lblResult2 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Location = new System.Drawing.Point(353, 67);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(519, 22);
            this.txtFilePath.TabIndex = 1;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnSearch.Location = new System.Drawing.Point(107, 30);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(206, 59);
            this.btnSearch.TabIndex = 2;
            this.btnSearch.Text = "SEARCH DATASET";
            this.btnSearch.UseVisualStyleBackColor = false;
            this.btnSearch.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // lblResult
            // 
            this.lblResult.AutoSize = true;
            this.lblResult.ForeColor = System.Drawing.Color.Red;
            this.lblResult.Location = new System.Drawing.Point(27, 123);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(0, 17);
            this.lblResult.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 606);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(357, 29);
            this.label1.TabIndex = 1;
            this.label1.Text = "DECISION SUPPORT ASSIGNMENT\r\n";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // btnResult
            // 
            this.btnResult.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnResult.Location = new System.Drawing.Point(488, 477);
            this.btnResult.Name = "btnResult";
            this.btnResult.Size = new System.Drawing.Size(169, 41);
            this.btnResult.TabIndex = 5;
            this.btnResult.Text = "RESULTS";
            this.btnResult.UseVisualStyleBackColor = false;
            this.btnResult.Click += new System.EventHandler(this.btnDiscover_Click);
            // 
            // lblResult2
            // 
            this.lblResult2.AutoSize = true;
            this.lblResult2.ForeColor = System.Drawing.Color.Red;
            this.lblResult2.Location = new System.Drawing.Point(550, 238);
            this.lblResult2.Name = "lblResult2";
            this.lblResult2.Size = new System.Drawing.Size(0, 17);
            this.lblResult2.TabIndex = 6;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(910, 606);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(242, 29);
            this.label2.TabIndex = 7;
            this.label2.Text = "2014510056 Zeynep Köse";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1176, 658);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblResult2);
            this.Controls.Add(this.btnResult);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblResult);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.txtFilePath);
            this.Name = "Form1";
            this.Text = "DECISION SUPPORT ASSIGNMENT";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnResult;
        private System.Windows.Forms.Label lblResult2;
        private System.Windows.Forms.Label label2;
    }
}

