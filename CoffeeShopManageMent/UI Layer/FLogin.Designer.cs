namespace CoffeeShopManageMent.UI_Layer
{
    partial class FLogin
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
            this.UserBox = new System.Windows.Forms.TextBox();
            this.PasswordBox = new System.Windows.Forms.TextBox();
            this.UserNameLabel = new System.Windows.Forms.Label();
            this.PasswordLabel = new System.Windows.Forms.Label();
            this.FLoginBut = new System.Windows.Forms.Button();
            this.ShowPassCheck = new System.Windows.Forms.CheckBox();
            this.SignUpLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Ravie", 30F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(19)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(79, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(220, 66);
            this.label1.TabIndex = 0;
            this.label1.Text = "LOGIN";
            // 
            // UserBox
            // 
            this.UserBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserBox.Location = new System.Drawing.Point(79, 156);
            this.UserBox.Name = "UserBox";
            this.UserBox.Size = new System.Drawing.Size(220, 28);
            this.UserBox.TabIndex = 1;
            this.UserBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.UserBox_PreviewKeyDown);
            // 
            // PasswordBox
            // 
            this.PasswordBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordBox.Location = new System.Drawing.Point(79, 246);
            this.PasswordBox.Name = "PasswordBox";
            this.PasswordBox.Size = new System.Drawing.Size(220, 28);
            this.PasswordBox.TabIndex = 2;
            this.PasswordBox.UseSystemPasswordChar = true;
            this.PasswordBox.PreviewKeyDown += new System.Windows.Forms.PreviewKeyDownEventHandler(this.PassWordBox_PreviewKeyDown);
            // 
            // UserNameLabel
            // 
            this.UserNameLabel.AutoSize = true;
            this.UserNameLabel.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.UserNameLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(19)))), ((int)(((byte)(83)))));
            this.UserNameLabel.Location = new System.Drawing.Point(74, 126);
            this.UserNameLabel.Name = "UserNameLabel";
            this.UserNameLabel.Size = new System.Drawing.Size(99, 27);
            this.UserNameLabel.TabIndex = 3;
            this.UserNameLabel.Text = "User name";
            // 
            // PasswordLabel
            // 
            this.PasswordLabel.AutoSize = true;
            this.PasswordLabel.Font = new System.Drawing.Font("Monotype Corsiva", 13.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PasswordLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(19)))), ((int)(((byte)(83)))));
            this.PasswordLabel.Location = new System.Drawing.Point(74, 216);
            this.PasswordLabel.Name = "PasswordLabel";
            this.PasswordLabel.Size = new System.Drawing.Size(91, 27);
            this.PasswordLabel.TabIndex = 4;
            this.PasswordLabel.Text = "Password";
            // 
            // FLoginBut
            // 
            this.FLoginBut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(209)))), ((int)(((byte)(249)))));
            this.FLoginBut.Font = new System.Drawing.Font("Monotype Corsiva", 13.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FLoginBut.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(19)))), ((int)(((byte)(83)))));
            this.FLoginBut.Location = new System.Drawing.Point(127, 340);
            this.FLoginBut.Name = "FLoginBut";
            this.FLoginBut.Size = new System.Drawing.Size(124, 40);
            this.FLoginBut.TabIndex = 5;
            this.FLoginBut.Text = "Login";
            this.FLoginBut.UseVisualStyleBackColor = false;
            this.FLoginBut.Click += new System.EventHandler(this.FLoginBut_Click);
            // 
            // ShowPassCheck
            // 
            this.ShowPassCheck.AutoSize = true;
            this.ShowPassCheck.Font = new System.Drawing.Font("Monotype Corsiva", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ShowPassCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(19)))), ((int)(((byte)(83)))));
            this.ShowPassCheck.Location = new System.Drawing.Point(246, 295);
            this.ShowPassCheck.Name = "ShowPassCheck";
            this.ShowPassCheck.Size = new System.Drawing.Size(133, 25);
            this.ShowPassCheck.TabIndex = 6;
            this.ShowPassCheck.Text = "Show Password";
            this.ShowPassCheck.UseVisualStyleBackColor = true;
            this.ShowPassCheck.Click += new System.EventHandler(this.ShowPassCheck_Click);
            // 
            // SignUpLabel
            // 
            this.SignUpLabel.AutoSize = true;
            this.SignUpLabel.Font = new System.Drawing.Font("Arial Narrow", 10.8F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SignUpLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(28)))), ((int)(((byte)(19)))), ((int)(((byte)(83)))));
            this.SignUpLabel.Location = new System.Drawing.Point(84, 428);
            this.SignUpLabel.Name = "SignUpLabel";
            this.SignUpLabel.Size = new System.Drawing.Size(212, 22);
            this.SignUpLabel.TabIndex = 7;
            this.SignUpLabel.Text = "Don\'t have an account ? Signup";
            this.SignUpLabel.Click += new System.EventHandler(this.SignUpLabel_Click);
            // 
            // FLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.MistyRose;
            this.ClientSize = new System.Drawing.Size(391, 481);
            this.Controls.Add(this.SignUpLabel);
            this.Controls.Add(this.ShowPassCheck);
            this.Controls.Add(this.FLoginBut);
            this.Controls.Add(this.PasswordLabel);
            this.Controls.Add(this.UserNameLabel);
            this.Controls.Add(this.PasswordBox);
            this.Controls.Add(this.UserBox);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(243)))), ((int)(((byte)(129)))));
            this.Name = "FLogin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FLogin";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox UserBox;
        private System.Windows.Forms.TextBox PasswordBox;
        private System.Windows.Forms.Label UserNameLabel;
        private System.Windows.Forms.Label PasswordLabel;
        private System.Windows.Forms.Button FLoginBut;
        private System.Windows.Forms.CheckBox ShowPassCheck;
        private System.Windows.Forms.Label SignUpLabel;
    }
}