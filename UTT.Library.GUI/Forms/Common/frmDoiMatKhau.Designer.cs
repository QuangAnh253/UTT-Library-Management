namespace UTT.Library.GUI.Forms.Common
{
    partial class frmDoiMatKhau
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
            this.txtMatKhauMoi = new System.Windows.Forms.TextBox();
            this.lblHuy = new System.Windows.Forms.Label();
            this.btnDoiMatKhau = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblLogin = new System.Windows.Forms.Label();
            this.picToggleNew = new System.Windows.Forms.PictureBox();
            this.logoUTT = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picToggleOld = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.picToggleConfirm = new System.Windows.Forms.PictureBox();
            this.txtXacNhanMatKhau = new System.Windows.Forms.TextBox();
            this.txtMatKhauCu = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.picToggleNew)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoUTT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToggleOld)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToggleConfirm)).BeginInit();
            this.SuspendLayout();
            // 
            // txtMatKhauMoi
            // 
            this.txtMatKhauMoi.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhauMoi.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtMatKhauMoi.Location = new System.Drawing.Point(151, 267);
            this.txtMatKhauMoi.Multiline = true;
            this.txtMatKhauMoi.Name = "txtMatKhauMoi";
            this.txtMatKhauMoi.PasswordChar = '*';
            this.txtMatKhauMoi.Size = new System.Drawing.Size(196, 24);
            this.txtMatKhauMoi.TabIndex = 9;
            this.txtMatKhauMoi.UseSystemPasswordChar = true;
            // 
            // lblHuy
            // 
            this.lblHuy.AutoSize = true;
            this.lblHuy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblHuy.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblHuy.Location = new System.Drawing.Point(241, 416);
            this.lblHuy.Name = "lblHuy";
            this.lblHuy.Size = new System.Drawing.Size(0, 16);
            this.lblHuy.TabIndex = 15;
            // 
            // btnDoiMatKhau
            // 
            this.btnDoiMatKhau.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnDoiMatKhau.FlatAppearance.BorderSize = 0;
            this.btnDoiMatKhau.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDoiMatKhau.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoiMatKhau.ForeColor = System.Drawing.Color.White;
            this.btnDoiMatKhau.Location = new System.Drawing.Point(111, 397);
            this.btnDoiMatKhau.Name = "btnDoiMatKhau";
            this.btnDoiMatKhau.Size = new System.Drawing.Size(236, 33);
            this.btnDoiMatKhau.TabIndex = 11;
            this.btnDoiMatKhau.Text = "Đổi mật khẩu";
            this.btnDoiMatKhau.UseVisualStyleBackColor = false;
            this.btnDoiMatKhau.Click += new System.EventHandler(this.btnDoiMatKhau_Click);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel2.Location = new System.Drawing.Point(148, 307);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(236, 1);
            this.panel2.TabIndex = 17;
            // 
            // lblLogin
            // 
            this.lblLogin.AutoSize = true;
            this.lblLogin.Font = new System.Drawing.Font("Bauhaus 93", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.lblLogin.Location = new System.Drawing.Point(174, 136);
            this.lblLogin.Name = "lblLogin";
            this.lblLogin.Size = new System.Drawing.Size(114, 36);
            this.lblLogin.TabIndex = 10;
            this.lblLogin.Text = "LOG IN";
            // 
            // picToggleNew
            // 
            this.picToggleNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picToggleNew.Image = global::UTT.Library.GUI.Properties.Resources.eye_close;
            this.picToggleNew.Location = new System.Drawing.Point(390, 267);
            this.picToggleNew.Name = "picToggleNew";
            this.picToggleNew.Size = new System.Drawing.Size(24, 24);
            this.picToggleNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picToggleNew.TabIndex = 18;
            this.picToggleNew.TabStop = false;
            this.picToggleNew.Click += new System.EventHandler(this.picToggleNew_Click);
            // 
            // logoUTT
            // 
            this.logoUTT.Image = global::UTT.Library.GUI.Properties.Resources.Asset_1;
            this.logoUTT.Location = new System.Drawing.Point(176, 42);
            this.logoUTT.Name = "logoUTT";
            this.logoUTT.Size = new System.Drawing.Size(112, 77);
            this.logoUTT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoUTT.TabIndex = 8;
            this.logoUTT.TabStop = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Gray;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Bahnschrift", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(111, 453);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(236, 33);
            this.button1.TabIndex = 19;
            this.button1.Text = "HỦY";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel1.Location = new System.Drawing.Point(148, 248);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(236, 1);
            this.panel1.TabIndex = 17;
            // 
            // picToggleOld
            // 
            this.picToggleOld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picToggleOld.Image = global::UTT.Library.GUI.Properties.Resources.eye_close;
            this.picToggleOld.Location = new System.Drawing.Point(390, 208);
            this.picToggleOld.Name = "picToggleOld";
            this.picToggleOld.Size = new System.Drawing.Size(24, 24);
            this.picToggleOld.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picToggleOld.TabIndex = 18;
            this.picToggleOld.TabStop = false;
            this.picToggleOld.Click += new System.EventHandler(this.picToggleOld_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.panel3.Location = new System.Drawing.Point(148, 366);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(236, 1);
            this.panel3.TabIndex = 17;
            // 
            // picToggleConfirm
            // 
            this.picToggleConfirm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picToggleConfirm.Image = global::UTT.Library.GUI.Properties.Resources.eye_close;
            this.picToggleConfirm.Location = new System.Drawing.Point(390, 326);
            this.picToggleConfirm.Name = "picToggleConfirm";
            this.picToggleConfirm.Size = new System.Drawing.Size(24, 24);
            this.picToggleConfirm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picToggleConfirm.TabIndex = 18;
            this.picToggleConfirm.TabStop = false;
            this.picToggleConfirm.Click += new System.EventHandler(this.picToggleConfirm_Click);
            // 
            // txtXacNhanMatKhau
            // 
            this.txtXacNhanMatKhau.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtXacNhanMatKhau.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtXacNhanMatKhau.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtXacNhanMatKhau.Location = new System.Drawing.Point(151, 323);
            this.txtXacNhanMatKhau.Multiline = true;
            this.txtXacNhanMatKhau.Name = "txtXacNhanMatKhau";
            this.txtXacNhanMatKhau.PasswordChar = '*';
            this.txtXacNhanMatKhau.Size = new System.Drawing.Size(196, 24);
            this.txtXacNhanMatKhau.TabIndex = 9;
            this.txtXacNhanMatKhau.UseSystemPasswordChar = true;
            // 
            // txtMatKhauCu
            // 
            this.txtMatKhauCu.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMatKhauCu.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMatKhauCu.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.txtMatKhauCu.Location = new System.Drawing.Point(151, 208);
            this.txtMatKhauCu.Multiline = true;
            this.txtMatKhauCu.Name = "txtMatKhauCu";
            this.txtMatKhauCu.PasswordChar = '*';
            this.txtMatKhauCu.Size = new System.Drawing.Size(196, 24);
            this.txtMatKhauCu.TabIndex = 9;
            this.txtMatKhauCu.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label1.Location = new System.Drawing.Point(12, 212);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Mật khẩu cũ:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label2.Location = new System.Drawing.Point(12, 271);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 20);
            this.label2.TabIndex = 21;
            this.label2.Text = "Mật khẩu mới:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 11.25F);
            this.label3.Location = new System.Drawing.Point(12, 327);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(137, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Xác nhận mật khẩu:";
            // 
            // frmDoiMatKhau
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(485, 498);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.picToggleConfirm);
            this.Controls.Add(this.picToggleOld);
            this.Controls.Add(this.picToggleNew);
            this.Controls.Add(this.txtMatKhauCu);
            this.Controls.Add(this.txtXacNhanMatKhau);
            this.Controls.Add(this.txtMatKhauMoi);
            this.Controls.Add(this.lblHuy);
            this.Controls.Add(this.btnDoiMatKhau);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lblLogin);
            this.Controls.Add(this.logoUTT);
            this.Name = "frmDoiMatKhau";
            this.Text = "frmDoiMatKhau";
            this.Load += new System.EventHandler(this.frmDoiMatKhau_Load);
            ((System.ComponentModel.ISupportInitialize)(this.picToggleNew)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logoUTT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToggleOld)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picToggleConfirm)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox picToggleNew;
        private System.Windows.Forms.TextBox txtMatKhauMoi;
        private System.Windows.Forms.Label lblHuy;
        private System.Windows.Forms.Button btnDoiMatKhau;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblLogin;
        private System.Windows.Forms.PictureBox logoUTT;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox picToggleOld;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.PictureBox picToggleConfirm;
        private System.Windows.Forms.TextBox txtXacNhanMatKhau;
        private System.Windows.Forms.TextBox txtMatKhauCu;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}