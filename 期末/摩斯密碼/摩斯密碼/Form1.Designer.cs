namespace 摩斯密碼
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        // UI controls
        private System.Windows.Forms.Label labelInput;
        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Label labelMorse;
        private System.Windows.Forms.TextBox textBoxMorse;
        private System.Windows.Forms.Label labelMapping;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button buttonConvert;
        private System.Windows.Forms.Button buttonClear;

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
            this.labelInput = new System.Windows.Forms.Label();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.labelMorse = new System.Windows.Forms.Label();
            this.textBoxMorse = new System.Windows.Forms.TextBox();
            this.labelMapping = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.buttonConvert = new System.Windows.Forms.Button();
            this.buttonClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // labelInput
            // 
            this.labelInput.AutoSize = true;
            this.labelInput.Location = new System.Drawing.Point(12, 12);
            this.labelInput.Name = "labelInput";
            this.labelInput.Size = new System.Drawing.Size(116, 18);
            this.labelInput.TabIndex = 0;
            this.labelInput.Text = "請輸入字串：";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxInput.Location = new System.Drawing.Point(15, 35);
            this.textBoxInput.Multiline = true;
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxInput.Size = new System.Drawing.Size(408, 140);
            this.textBoxInput.TabIndex = 1;
            // 
            // labelMorse
            // 
            this.labelMorse.AutoSize = true;
            this.labelMorse.Location = new System.Drawing.Point(12, 180);
            this.labelMorse.Name = "labelMorse";
            this.labelMorse.Size = new System.Drawing.Size(134, 18);
            this.labelMorse.TabIndex = 2;
            this.labelMorse.Text = "完整摩斯密碼：";
            // 
            // textBoxMorse
            // 
            this.textBoxMorse.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxMorse.Location = new System.Drawing.Point(15, 200);
            this.textBoxMorse.Multiline = true;
            this.textBoxMorse.Name = "textBoxMorse";
            this.textBoxMorse.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxMorse.Size = new System.Drawing.Size(408, 100);
            this.textBoxMorse.TabIndex = 3;
            // 
            // labelMapping
            // 
            this.labelMapping.AutoSize = true;
            this.labelMapping.Location = new System.Drawing.Point(12, 305);
            this.labelMapping.Name = "labelMapping";
            this.labelMapping.Size = new System.Drawing.Size(98, 18);
            this.labelMapping.TabIndex = 4;
            this.labelMapping.Text = "逐字對照：";
            // 
            // listBox1
            // 
            this.listBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 18;
            this.listBox1.Location = new System.Drawing.Point(15, 325);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(408, 112);
            this.listBox1.TabIndex = 5;
            // 
            // buttonConvert
            // 
            this.buttonConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonConvert.Location = new System.Drawing.Point(241, 455);
            this.buttonConvert.Name = "buttonConvert";
            this.buttonConvert.Size = new System.Drawing.Size(80, 30);
            this.buttonConvert.TabIndex = 6;
            this.buttonConvert.Text = "轉換";
            this.buttonConvert.UseVisualStyleBackColor = true;
            // 
            // buttonClear
            // 
            this.buttonClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonClear.Location = new System.Drawing.Point(332, 455);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(80, 30);
            this.buttonClear.TabIndex = 7;
            this.buttonClear.Text = "清除";
            this.buttonClear.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(440, 520);
            this.Controls.Add(this.labelInput);
            this.Controls.Add(this.textBoxInput);
            this.Controls.Add(this.labelMorse);
            this.Controls.Add(this.textBoxMorse);
            this.Controls.Add(this.labelMapping);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.buttonConvert);
            this.Controls.Add(this.buttonClear);
            this.Name = "Form1";
            this.Text = "摩斯密碼轉換";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}

