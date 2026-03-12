namespace WinFormsApp1
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.TextBox textBoxNum1;
        private System.Windows.Forms.TextBox textBoxNum2;
        private System.Windows.Forms.TextBox textBoxNum3;
        private System.Windows.Forms.TextBox textBoxNum4;
        private System.Windows.Forms.TextBox textBoxNum5;
        private System.Windows.Forms.Button buttonGenerate;
        private System.Windows.Forms.Button buttonLoadDraw;
        private System.Windows.Forms.Button buttonExit;
        private System.Windows.Forms.ListBox listBoxDraw;
        private System.Windows.Forms.Label labelDrawTitle;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Label labelCompareTitle;
        private System.Windows.Forms.Label labelMatchCount;
        private System.Windows.Forms.Label labelMatchNumbers;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            textBoxNum1 = new TextBox();
            textBoxNum2 = new TextBox();
            textBoxNum3 = new TextBox();
            textBoxNum4 = new TextBox();
            textBoxNum5 = new TextBox();
            buttonGenerate = new Button();
            buttonLoadDraw = new Button();
            buttonExit = new Button();
            listBoxDraw = new ListBox();
            labelDrawTitle = new Label();
            labelResult = new Label();
            labelCompareTitle = new Label();
            labelMatchCount = new Label();
            labelMatchNumbers = new Label();
            SuspendLayout();
            // 
            // textBoxNum1
            // 
            textBoxNum1.Font = new Font("微軟正黑體", 14F);
            textBoxNum1.Location = new Point(20, 12);
            textBoxNum1.Name = "textBoxNum1";
            textBoxNum1.ReadOnly = true;
            textBoxNum1.Size = new Size(64, 45);
            textBoxNum1.TabIndex = 0;
            textBoxNum1.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxNum2
            // 
            textBoxNum2.Font = new Font("微軟正黑體", 14F);
            textBoxNum2.Location = new Point(100, 12);
            textBoxNum2.Name = "textBoxNum2";
            textBoxNum2.ReadOnly = true;
            textBoxNum2.Size = new Size(64, 45);
            textBoxNum2.TabIndex = 1;
            textBoxNum2.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxNum3
            // 
            textBoxNum3.Font = new Font("微軟正黑體", 14F);
            textBoxNum3.Location = new Point(180, 12);
            textBoxNum3.Name = "textBoxNum3";
            textBoxNum3.ReadOnly = true;
            textBoxNum3.Size = new Size(64, 45);
            textBoxNum3.TabIndex = 2;
            textBoxNum3.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxNum4
            // 
            textBoxNum4.Font = new Font("微軟正黑體", 14F);
            textBoxNum4.Location = new Point(260, 12);
            textBoxNum4.Name = "textBoxNum4";
            textBoxNum4.ReadOnly = true;
            textBoxNum4.Size = new Size(64, 45);
            textBoxNum4.TabIndex = 3;
            textBoxNum4.TextAlign = HorizontalAlignment.Center;
            // 
            // textBoxNum5
            // 
            textBoxNum5.Font = new Font("微軟正黑體", 14F);
            textBoxNum5.Location = new Point(340, 12);
            textBoxNum5.Name = "textBoxNum5";
            textBoxNum5.ReadOnly = true;
            textBoxNum5.Size = new Size(64, 45);
            textBoxNum5.TabIndex = 4;
            textBoxNum5.TextAlign = HorizontalAlignment.Center;
            // 
            // buttonGenerate
            // 
            buttonGenerate.Location = new Point(20, 62);
            buttonGenerate.Name = "buttonGenerate";
            buttonGenerate.Size = new Size(120, 40);
            buttonGenerate.TabIndex = 5;
            buttonGenerate.Text = "產生號碼";
            buttonGenerate.UseVisualStyleBackColor = true;
            buttonGenerate.Click += ButtonGenerate_Click;
            // 
            // buttonLoadDraw
            // 
            buttonLoadDraw.Location = new Point(150, 62);
            buttonLoadDraw.Name = "buttonLoadDraw";
            buttonLoadDraw.Size = new Size(120, 40);
            buttonLoadDraw.TabIndex = 6;
            buttonLoadDraw.Text = "開獎號碼";
            buttonLoadDraw.UseVisualStyleBackColor = true;
            buttonLoadDraw.Click += ButtonLoadDraw_Click;
            // 
            // buttonExit
            // 
            buttonExit.Location = new Point(280, 62);
            buttonExit.Name = "buttonExit";
            buttonExit.Size = new Size(120, 40);
            buttonExit.TabIndex = 7;
            buttonExit.Text = "離開";
            buttonExit.UseVisualStyleBackColor = true;
            buttonExit.Click += ButtonExit_Click;
            // 
            // listBoxDraw
            // 
            listBoxDraw.FormattingEnabled = true;
            listBoxDraw.Location = new Point(20, 133);
            listBoxDraw.Name = "listBoxDraw";
            listBoxDraw.Size = new Size(360, 96);
            listBoxDraw.TabIndex = 9;
            // 
            // labelDrawTitle
            // 
            labelDrawTitle.AutoSize = true;
            labelDrawTitle.Location = new Point(20, 115);
            labelDrawTitle.Name = "labelDrawTitle";
            labelDrawTitle.Size = new Size(136, 23);
            labelDrawTitle.TabIndex = 8;
            labelDrawTitle.Text = "本期開獎號碼：";
            // 
            // labelResult
            // 
            labelResult.AutoSize = true;
            labelResult.Location = new Point(20, 250);
            labelResult.Name = "labelResult";
            labelResult.Size = new Size(0, 23);
            labelResult.TabIndex = 10;
            // 
            // labelCompareTitle
            // 
            labelCompareTitle.AutoSize = true;
            labelCompareTitle.Font = new Font("微軟正黑體", 12F, FontStyle.Bold);
            labelCompareTitle.ForeColor = Color.Red;
            labelCompareTitle.Location = new Point(420, 115);
            labelCompareTitle.Name = "labelCompareTitle";
            labelCompareTitle.Size = new Size(134, 31);
            labelCompareTitle.TabIndex = 11;
            labelCompareTitle.Text = "比對結果：";
            // 
            // labelMatchCount
            // 
            labelMatchCount.AutoSize = true;
            labelMatchCount.Font = new Font("微軟正黑體", 14F);
            labelMatchCount.ForeColor = Color.Red;
            labelMatchCount.Location = new Point(420, 150);
            labelMatchCount.Name = "labelMatchCount";
            labelMatchCount.Size = new Size(143, 35);
            labelMatchCount.TabIndex = 12;
            labelMatchCount.Text = "中0個號碼";
            // 
            // labelMatchNumbers
            // 
            labelMatchNumbers.AutoSize = true;
            labelMatchNumbers.Font = new Font("微軟正黑體", 14F, FontStyle.Bold);
            labelMatchNumbers.ForeColor = Color.Red;
            labelMatchNumbers.Location = new Point(420, 190);
            labelMatchNumbers.Name = "labelMatchNumbers";
            labelMatchNumbers.Size = new Size(144, 36);
            labelMatchNumbers.TabIndex = 13;
            labelMatchNumbers.Text = "✖ 沒中獎";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(620, 300);
            Controls.Add(labelMatchNumbers);
            Controls.Add(labelMatchCount);
            Controls.Add(labelCompareTitle);
            Controls.Add(labelResult);
            Controls.Add(listBoxDraw);
            Controls.Add(labelDrawTitle);
            Controls.Add(buttonExit);
            Controls.Add(buttonLoadDraw);
            Controls.Add(buttonGenerate);
            Controls.Add(textBoxNum5);
            Controls.Add(textBoxNum4);
            Controls.Add(textBoxNum3);
            Controls.Add(textBoxNum2);
            Controls.Add(textBoxNum1);
            Name = "Form1";
            Text = "樂透號碼產生器";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
    }
}
