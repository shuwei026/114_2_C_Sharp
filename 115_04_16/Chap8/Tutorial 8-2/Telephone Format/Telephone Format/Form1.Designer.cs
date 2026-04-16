namespace Telephone_Format
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
            this.numberTextBox = new System.Windows.Forms.TextBox();
            this.instructionLabel = new System.Windows.Forms.Label();
            this.formatButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 設定整個表單的字型為繁體中文常用字型，字型大小 18
            // 這樣可以讓所有元件有一致且較大的字型顯示
            // 若需要單獨調整某個元件，可在該元件的屬性中覆寫 Font
            // -----------------------------------------------------------------
            this.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            // -----------------------------------------------------------------
            
            // numberTextBox
            // 
            // 電話號碼輸入欄位：放在表單上方中間偏左，寬度增加以容納較長的數字字串
            this.numberTextBox.Location = new System.Drawing.Point(80, 80);
            this.numberTextBox.Name = "numberTextBox";
            // 調整大小以配合字型 18，增加高度與寬度
            this.numberTextBox.Size = new System.Drawing.Size(220, 39);
            // 使用與表單相同的字型設定，確保字型大小一致
            this.numberTextBox.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.numberTextBox.TabIndex = 0;
            // 
            // instructionLabel
            // 
            // 指示標籤：放在表單最上方，置中顯示輸入說明，字數略多所以高度給比較大
            this.instructionLabel.Location = new System.Drawing.Point(10, 10);
            this.instructionLabel.Name = "instructionLabel";
            this.instructionLabel.Size = new System.Drawing.Size(360, 60);
            this.instructionLabel.TabIndex = 1;
            // 將提示文字改為繁體中文，說明輸入內容與功能
            this.instructionLabel.Text = "輸入 10 位數字，我會將其格式化為電話號碼。";
            this.instructionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.instructionLabel.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            // 
            // formatButton
            // 
            // 格式化按鈕：放在輸入欄位下方靠左，按下後會觸發格式化邏輯
            this.formatButton.Location = new System.Drawing.Point(70, 140);
            this.formatButton.Name = "formatButton";
            this.formatButton.Size = new System.Drawing.Size(110, 45);
            this.formatButton.TabIndex = 2;
            // 按鈕文字改為繁體中文
            this.formatButton.Text = "格式化";
            this.formatButton.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.formatButton.UseVisualStyleBackColor = true;
            this.formatButton.Click += new System.EventHandler(this.formatButton_Click);
            // 
            // exitButton
            // 
            // 離開按鈕：放在輸入欄位下方靠右，按下後關閉表單
            this.exitButton.Location = new System.Drawing.Point(200, 140);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(110, 45);
            this.exitButton.TabIndex = 3;
            // 按鈕文字改為繁體中文
            this.exitButton.Text = "離開";
            this.exitButton.Font = new System.Drawing.Font("Microsoft JhengHei", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // Form1
            // 
            // 調整表單大小以容納較大的字型與元件
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 220);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.formatButton);
            this.Controls.Add(this.instructionLabel);
            this.Controls.Add(this.numberTextBox);
            this.Name = "Form1";
            // 表單標題改為繁體中文
            this.Text = "電話格式化";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numberTextBox;
        private System.Windows.Forms.Label instructionLabel;
        private System.Windows.Forms.Button formatButton;
        private System.Windows.Forms.Button exitButton;
    }
}

