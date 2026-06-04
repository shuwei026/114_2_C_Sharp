namespace Tutorial_9_3_3
{
    partial class MainForm
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnAccount;
        private System.Windows.Forms.Button btnDeposit;
        private System.Windows.Forms.Button btnWithdraw;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Label lblAccountCountText;
        private System.Windows.Forms.Label lblAccountCountValue;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAccount = new System.Windows.Forms.Button();
            this.btnDeposit = new System.Windows.Forms.Button();
            this.btnWithdraw = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.lblAccountCountText = new System.Windows.Forms.Label();
            this.lblAccountCountValue = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnAccount
            // 
            this.btnAccount.Location = new System.Drawing.Point(30, 30);
            this.btnAccount.Name = "btnAccount";
            this.btnAccount.Size = new System.Drawing.Size(100, 40);
            this.btnAccount.TabIndex = 0;
            this.btnAccount.Text = "開戶";
            this.btnAccount.UseVisualStyleBackColor = true;
            this.btnAccount.Click += new System.EventHandler(this.OpenAccount_Click);
            // 
            // btnDeposit
            // 
            this.btnDeposit.Location = new System.Drawing.Point(180, 30);
            this.btnDeposit.Name = "btnDeposit";
            this.btnDeposit.Size = new System.Drawing.Size(100, 40);
            this.btnDeposit.TabIndex = 1;
            this.btnDeposit.Text = "存款";
            this.btnDeposit.UseVisualStyleBackColor = true;
            this.btnDeposit.Click += new System.EventHandler(this.btnDeposit_Click);
            // 
            // btnWithdraw
            // 
            this.btnWithdraw.Location = new System.Drawing.Point(310, 30);
            this.btnWithdraw.Name = "btnWithdraw";
            this.btnWithdraw.Size = new System.Drawing.Size(100, 40);
            this.btnWithdraw.TabIndex = 2;
            this.btnWithdraw.Text = "提存";
            this.btnWithdraw.UseVisualStyleBackColor = true;
            // 
            // btnExit
            // 
            this.btnExit.Location = new System.Drawing.Point(180, 90);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(100, 40);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "離開";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // lblAccountCountText
            // 
            this.lblAccountCountText.AutoSize = true;
            this.lblAccountCountText.Location = new System.Drawing.Point(120, 160);
            this.lblAccountCountText.Name = "lblAccountCountText";
            this.lblAccountCountText.Size = new System.Drawing.Size(134, 18);
            this.lblAccountCountText.TabIndex = 4;
            this.lblAccountCountText.Text = "已開戶用戶數：";
            // 
            // lblAccountCountValue
            // 
            this.lblAccountCountValue.AutoSize = true;
            this.lblAccountCountValue.Location = new System.Drawing.Point(220, 160);
            this.lblAccountCountValue.Name = "lblAccountCountValue";
            this.lblAccountCountValue.Size = new System.Drawing.Size(16, 18);
            this.lblAccountCountValue.TabIndex = 5;
            this.lblAccountCountValue.Text = "0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAccount);
            this.Controls.Add(this.btnDeposit);
            this.Controls.Add(this.btnWithdraw);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.lblAccountCountText);
            this.Controls.Add(this.lblAccountCountValue);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

