namespace RDZavia
{
    partial class StartForm
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
            this.SupportButt = new System.Windows.Forms.Button();
            this.RegisterButt = new System.Windows.Forms.Button();
            this.SingInButt = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // SupportButt
            // 
            this.SupportButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SupportButt.Location = new System.Drawing.Point(227, 253);
            this.SupportButt.Margin = new System.Windows.Forms.Padding(2);
            this.SupportButt.Name = "SupportButt";
            this.SupportButt.Size = new System.Drawing.Size(28, 33);
            this.SupportButt.TabIndex = 31;
            this.SupportButt.Text = "?";
            this.SupportButt.UseVisualStyleBackColor = true;
            this.SupportButt.Click += new System.EventHandler(this.SupportButt_Click);
            // 
            // RegisterButt
            // 
            this.RegisterButt.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.RegisterButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.RegisterButt.Location = new System.Drawing.Point(66, 214);
            this.RegisterButt.Name = "RegisterButt";
            this.RegisterButt.Size = new System.Drawing.Size(112, 33);
            this.RegisterButt.TabIndex = 32;
            this.RegisterButt.Text = "Регистрация";
            this.RegisterButt.UseVisualStyleBackColor = true;
            this.RegisterButt.Click += new System.EventHandler(this.RegisterButt_Click);
            // 
            // SingInButt
            // 
            this.SingInButt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.SingInButt.Location = new System.Drawing.Point(82, 253);
            this.SingInButt.Name = "SingInButt";
            this.SingInButt.Size = new System.Drawing.Size(82, 33);
            this.SingInButt.TabIndex = 33;
            this.SingInButt.Text = "Вход";
            this.SingInButt.UseVisualStyleBackColor = true;
            this.SingInButt.Click += new System.EventHandler(this.SingInButt_Click);
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(23, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(226, 18);
            this.label1.TabIndex = 34;
            this.label1.Text = "Система онлайн бронирования";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(23, 181);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(165, 18);
            this.label2.TabIndex = 35;
            this.label2.Text = "билетов на авиарейсы";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pictureBox1.Image = global::RDZavia.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(55, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(143, 148);
            this.pictureBox1.TabIndex = 36;
            this.pictureBox1.TabStop = false;
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(266, 297);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.SingInButt);
            this.Controls.Add(this.RegisterButt);
            this.Controls.Add(this.SupportButt);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.Name = "StartForm";
            this.Text = " RDZAvia ";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SupportButt;
        private System.Windows.Forms.Button RegisterButt;
        private System.Windows.Forms.Button SingInButt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}