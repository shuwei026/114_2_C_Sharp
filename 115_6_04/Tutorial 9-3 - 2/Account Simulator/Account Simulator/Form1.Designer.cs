namespace Account_Simulator
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
            this.depositGroupBox = new System.Windows.Forms.GroupBox();
            this.depositButton = new System.Windows.Forms.Button();
            this.depositTextBox = new System.Windows.Forms.TextBox();
            this.depositAmountDescriptionLabel = new System.Windows.Forms.Label();
            this.withdrawGroupBox = new System.Windows.Forms.GroupBox();
            this.withdrawButton = new System.Windows.Forms.Button();
            this.withdrawTextBox = new System.Windows.Forms.TextBox();
            this.withdrawAmountDescriptionLabel = new System.Windows.Forms.Label();
            this.balanceDescriptionLabel = new System.Windows.Forms.Label();
            this.balanceLabel = new System.Windows.Forms.Label();
            this.exitButton = new System.Windows.Forms.Button();
            this.createAccountButton = new System.Windows.Forms.Button();
            this.accountNumberTextBox = new System.Windows.Forms.TextBox();
            this.ownerNameTextBox = new System.Windows.Forms.TextBox();
            this.openingAmountTextBox = new System.Windows.Forms.TextBox();
            this.accountNumberLabel = new System.Windows.Forms.Label();
            this.ownerNameLabel = new System.Windows.Forms.Label();
            this.openingAmountLabel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.depositGroupBox.SuspendLayout();
            this.withdrawGroupBox.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // depositGroupBox
            // 
            this.depositGroupBox.Controls.Add(this.depositButton);
            this.depositGroupBox.Controls.Add(this.depositTextBox);
            this.depositGroupBox.Controls.Add(this.depositAmountDescriptionLabel);
            this.depositGroupBox.Location = new System.Drawing.Point(42, 326);
            this.depositGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.depositGroupBox.Name = "depositGroupBox";
            this.depositGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.depositGroupBox.Size = new System.Drawing.Size(226, 109);
            this.depositGroupBox.TabIndex = 0;
            this.depositGroupBox.TabStop = false;
            this.depositGroupBox.Text = "Make a Deposit";
            // 
            // depositButton
            // 
            this.depositButton.Location = new System.Drawing.Point(57, 64);
            this.depositButton.Margin = new System.Windows.Forms.Padding(4);
            this.depositButton.Name = "depositButton";
            this.depositButton.Size = new System.Drawing.Size(112, 32);
            this.depositButton.TabIndex = 2;
            this.depositButton.Text = "Deposit";
            this.depositButton.UseVisualStyleBackColor = true;
            this.depositButton.Click += new System.EventHandler(this.depositButton_Click);
            // 
            // depositTextBox
            // 
            this.depositTextBox.Location = new System.Drawing.Point(102, 28);
            this.depositTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.depositTextBox.Name = "depositTextBox";
            this.depositTextBox.Size = new System.Drawing.Size(98, 29);
            this.depositTextBox.TabIndex = 1;
            // 
            // depositAmountDescriptionLabel
            // 
            this.depositAmountDescriptionLabel.AutoSize = true;
            this.depositAmountDescriptionLabel.Location = new System.Drawing.Point(24, 32);
            this.depositAmountDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.depositAmountDescriptionLabel.Name = "depositAmountDescriptionLabel";
            this.depositAmountDescriptionLabel.Size = new System.Drawing.Size(67, 18);
            this.depositAmountDescriptionLabel.TabIndex = 0;
            this.depositAmountDescriptionLabel.Text = "Amount:";
            // 
            // withdrawGroupBox
            // 
            this.withdrawGroupBox.Controls.Add(this.withdrawButton);
            this.withdrawGroupBox.Controls.Add(this.withdrawTextBox);
            this.withdrawGroupBox.Controls.Add(this.withdrawAmountDescriptionLabel);
            this.withdrawGroupBox.Location = new System.Drawing.Point(291, 326);
            this.withdrawGroupBox.Margin = new System.Windows.Forms.Padding(4);
            this.withdrawGroupBox.Name = "withdrawGroupBox";
            this.withdrawGroupBox.Padding = new System.Windows.Forms.Padding(4);
            this.withdrawGroupBox.Size = new System.Drawing.Size(226, 109);
            this.withdrawGroupBox.TabIndex = 1;
            this.withdrawGroupBox.TabStop = false;
            this.withdrawGroupBox.Text = "Make a Withdrawal";
            // 
            // withdrawButton
            // 
            this.withdrawButton.Location = new System.Drawing.Point(57, 64);
            this.withdrawButton.Margin = new System.Windows.Forms.Padding(4);
            this.withdrawButton.Name = "withdrawButton";
            this.withdrawButton.Size = new System.Drawing.Size(112, 32);
            this.withdrawButton.TabIndex = 2;
            this.withdrawButton.Text = "Withdraw";
            this.withdrawButton.UseVisualStyleBackColor = true;
            this.withdrawButton.Click += new System.EventHandler(this.withdrawButton_Click);
            // 
            // withdrawTextBox
            // 
            this.withdrawTextBox.Location = new System.Drawing.Point(113, 27);
            this.withdrawTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.withdrawTextBox.Name = "withdrawTextBox";
            this.withdrawTextBox.Size = new System.Drawing.Size(98, 29);
            this.withdrawTextBox.TabIndex = 1;
            // 
            // withdrawAmountDescriptionLabel
            // 
            this.withdrawAmountDescriptionLabel.AutoSize = true;
            this.withdrawAmountDescriptionLabel.Location = new System.Drawing.Point(24, 32);
            this.withdrawAmountDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.withdrawAmountDescriptionLabel.Name = "withdrawAmountDescriptionLabel";
            this.withdrawAmountDescriptionLabel.Size = new System.Drawing.Size(67, 18);
            this.withdrawAmountDescriptionLabel.TabIndex = 0;
            this.withdrawAmountDescriptionLabel.Text = "Amount:";
            // 
            // balanceDescriptionLabel
            // 
            this.balanceDescriptionLabel.AutoSize = true;
            this.balanceDescriptionLabel.Location = new System.Drawing.Point(556, 336);
            this.balanceDescriptionLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.balanceDescriptionLabel.Name = "balanceDescriptionLabel";
            this.balanceDescriptionLabel.Size = new System.Drawing.Size(69, 18);
            this.balanceDescriptionLabel.TabIndex = 2;
            this.balanceDescriptionLabel.Text = "Balance:";
            // 
            // balanceLabel
            // 
            this.balanceLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.balanceLabel.Location = new System.Drawing.Point(559, 447);
            this.balanceLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.balanceLabel.Name = "balanceLabel";
            this.balanceLabel.Size = new System.Drawing.Size(149, 31);
            this.balanceLabel.TabIndex = 3;
            this.balanceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.balanceLabel.Click += new System.EventHandler(this.balanceLabel_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(240, 478);
            this.exitButton.Margin = new System.Windows.Forms.Padding(4);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(112, 32);
            this.exitButton.TabIndex = 4;
            this.exitButton.Text = "Exit";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // createAccountButton
            // 
            this.createAccountButton.Location = new System.Drawing.Point(361, 235);
            this.createAccountButton.Margin = new System.Windows.Forms.Padding(4);
            this.createAccountButton.Name = "createAccountButton";
            this.createAccountButton.Size = new System.Drawing.Size(112, 32);
            this.createAccountButton.TabIndex = 5;
            this.createAccountButton.Text = "Create Account";
            this.createAccountButton.UseVisualStyleBackColor = true;
            this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click);
            // 
            // accountNumberTextBox
            // 
            this.accountNumberTextBox.Location = new System.Drawing.Point(279, 29);
            this.accountNumberTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.accountNumberTextBox.Name = "accountNumberTextBox";
            this.accountNumberTextBox.Size = new System.Drawing.Size(148, 29);
            this.accountNumberTextBox.TabIndex = 6;
            // 
            // ownerNameTextBox
            // 
            this.ownerNameTextBox.Location = new System.Drawing.Point(279, 80);
            this.ownerNameTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.ownerNameTextBox.Name = "ownerNameTextBox";
            this.ownerNameTextBox.Size = new System.Drawing.Size(148, 29);
            this.ownerNameTextBox.TabIndex = 7;
            // 
            // openingAmountTextBox
            // 
            this.openingAmountTextBox.Location = new System.Drawing.Point(279, 142);
            this.openingAmountTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.openingAmountTextBox.Name = "openingAmountTextBox";
            this.openingAmountTextBox.Size = new System.Drawing.Size(148, 29);
            this.openingAmountTextBox.TabIndex = 8;
            // 
            // accountNumberLabel
            // 
            this.accountNumberLabel.AutoSize = true;
            this.accountNumberLabel.Location = new System.Drawing.Point(39, 29);
            this.accountNumberLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.accountNumberLabel.Name = "accountNumberLabel";
            this.accountNumberLabel.Size = new System.Drawing.Size(130, 18);
            this.accountNumberLabel.TabIndex = 9;
            this.accountNumberLabel.Text = "Account Number:";
            // 
            // ownerNameLabel
            // 
            this.ownerNameLabel.AutoSize = true;
            this.ownerNameLabel.Location = new System.Drawing.Point(54, 83);
            this.ownerNameLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.ownerNameLabel.Name = "ownerNameLabel";
            this.ownerNameLabel.Size = new System.Drawing.Size(115, 18);
            this.ownerNameLabel.TabIndex = 10;
            this.ownerNameLabel.Text = "Owner\'s Name:";
            // 
            // openingAmountLabel
            // 
            this.openingAmountLabel.AutoSize = true;
            this.openingAmountLabel.Location = new System.Drawing.Point(40, 145);
            this.openingAmountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.openingAmountLabel.Name = "openingAmountLabel";
            this.openingAmountLabel.Size = new System.Drawing.Size(129, 18);
            this.openingAmountLabel.TabIndex = 11;
            this.openingAmountLabel.Text = "Opening Amount:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.accountNumberTextBox);
            this.groupBox2.Controls.Add(this.openingAmountLabel);
            this.groupBox2.Controls.Add(this.accountNumberLabel);
            this.groupBox2.Controls.Add(this.openingAmountTextBox);
            this.groupBox2.Controls.Add(this.ownerNameLabel);
            this.groupBox2.Controls.Add(this.createAccountButton);
            this.groupBox2.Controls.Add(this.ownerNameTextBox);
            this.groupBox2.Location = new System.Drawing.Point(27, 18);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(480, 274);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox2";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 523);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.balanceLabel);
            this.Controls.Add(this.balanceDescriptionLabel);
            this.Controls.Add(this.withdrawGroupBox);
            this.Controls.Add(this.depositGroupBox);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form1";
            this.Text = "Account Simulator";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.depositGroupBox.ResumeLayout(false);
            this.depositGroupBox.PerformLayout();
            this.withdrawGroupBox.ResumeLayout(false);
            this.withdrawGroupBox.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox depositGroupBox;
        private System.Windows.Forms.Button depositButton;
        private System.Windows.Forms.TextBox depositTextBox;
        private System.Windows.Forms.Label depositAmountDescriptionLabel;
        private System.Windows.Forms.GroupBox withdrawGroupBox;
        private System.Windows.Forms.Button withdrawButton;
        private System.Windows.Forms.TextBox withdrawTextBox;
        private System.Windows.Forms.Label withdrawAmountDescriptionLabel;
        private System.Windows.Forms.Label balanceDescriptionLabel;
        private System.Windows.Forms.Label balanceLabel;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button createAccountButton;
        private System.Windows.Forms.TextBox accountNumberTextBox;
        private System.Windows.Forms.TextBox ownerNameTextBox;
        private System.Windows.Forms.TextBox openingAmountTextBox;
        private System.Windows.Forms.Label accountNumberLabel;
        private System.Windows.Forms.Label ownerNameLabel;
        private System.Windows.Forms.Label openingAmountLabel;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}

