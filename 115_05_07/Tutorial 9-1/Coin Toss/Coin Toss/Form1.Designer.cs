namespace Coin_Toss
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
            this.outputListBox = new System.Windows.Forms.ListBox();
            this.tossButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // 註解：以下為輸出清單元件的初始化設定
            // 設定為較大的字型（18pt），並調整元件大小以配合字型，方便閱讀
            // 
            // outputListBox
            // 
            this.outputListBox.FormattingEnabled = true;
            this.outputListBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.outputListBox.Location = new System.Drawing.Point(20, 16);
            this.outputListBox.Name = "outputListBox";
            this.outputListBox.Size = new System.Drawing.Size(320, 190);
            this.outputListBox.TabIndex = 0;
            // 
            // 註解：擲硬幣按鈕，文字改為繁體中文並加大按鈕尺寸
            // 
            // tossButton
            // 
            this.tossButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tossButton.Location = new System.Drawing.Point(20, 220);
            this.tossButton.Name = "tossButton";
            this.tossButton.Size = new System.Drawing.Size(150, 60);
            this.tossButton.TabIndex = 1;
            this.tossButton.Text = "擲五次"; // 按鈕文字：擲五次（繁體中文）
            this.tossButton.UseVisualStyleBackColor = true;
            this.tossButton.Click += new System.EventHandler(this.tossButton_Click);
            // 
            // 註解：離開按鈕，文字改為繁體中文並加大按鈕尺寸
            // 
            // exitButton
            // 
            this.exitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exitButton.Location = new System.Drawing.Point(190, 220);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(150, 60);
            this.exitButton.TabIndex = 2;
            this.exitButton.Text = "離開"; // 按鈕文字：離開（繁體中文）
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // 註解：表單整體設定，修改標題為繁體中文並設定預設字型為 18pt
            // 也調整 ClientSize 以容納較大的元件與字型
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(360, 300);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.tossButton);
            this.Controls.Add(this.outputListBox);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Form1";
            this.Text = "擲硬幣"; // 表單標題：擲硬幣（繁體中文）
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox outputListBox;
        private System.Windows.Forms.Button tossButton;
        private System.Windows.Forms.Button exitButton;
    }
}

