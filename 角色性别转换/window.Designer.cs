namespace Tool
{
    partial class Window
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.lblCard = new System.Windows.Forms.Label();
            this.txtCard = new System.Windows.Forms.TextBox();
            this.lblPath = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.btnPath = new System.Windows.Forms.Button();
            this.txtFilename = new System.Windows.Forms.TextBox();
            this.lblFilename = new System.Windows.Forms.Label();
            this.rbtnMale = new System.Windows.Forms.RadioButton();
            this.rbtnFemale = new System.Windows.Forms.RadioButton();
            this.btnActive = new System.Windows.Forms.Button();
            this.gbxGender = new System.Windows.Forms.GroupBox();
            this.gbxGender.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblCard
            // 
            this.lblCard.BackColor = System.Drawing.SystemColors.Window;
            this.lblCard.Location = new System.Drawing.Point(12, 9);
            this.lblCard.Name = "lblCard";
            this.lblCard.Size = new System.Drawing.Size(252, 352);
            this.lblCard.TabIndex = 0;
            this.lblCard.Text = "点击选择角色卡";
            this.lblCard.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtCard
            // 
            this.txtCard.BackColor = System.Drawing.SystemColors.Window;
            this.txtCard.Location = new System.Drawing.Point(13, 370);
            this.txtCard.Name = "txtCard";
            this.txtCard.ReadOnly = true;
            this.txtCard.Size = new System.Drawing.Size(251, 21);
            this.txtCard.TabIndex = 1;
            this.txtCard.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lblPath
            // 
            this.lblPath.Location = new System.Drawing.Point(270, 8);
            this.lblPath.Name = "lblPath";
            this.lblPath.Size = new System.Drawing.Size(41, 21);
            this.lblPath.TabIndex = 2;
            this.lblPath.Text = "路径";
            this.lblPath.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(317, 9);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(178, 21);
            this.txtPath.TabIndex = 3;
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(501, 9);
            this.btnPath.Name = "btnPath";
            this.btnPath.Size = new System.Drawing.Size(21, 21);
            this.btnPath.TabIndex = 4;
            this.btnPath.Text = "…";
            this.btnPath.UseVisualStyleBackColor = true;
            // 
            // txtFilename
            // 
            this.txtFilename.Location = new System.Drawing.Point(317, 37);
            this.txtFilename.Name = "txtFilename";
            this.txtFilename.Size = new System.Drawing.Size(205, 21);
            this.txtFilename.TabIndex = 5;
            // 
            // lblFilename
            // 
            this.lblFilename.Location = new System.Drawing.Point(270, 37);
            this.lblFilename.Name = "lblFilename";
            this.lblFilename.Size = new System.Drawing.Size(41, 21);
            this.lblFilename.TabIndex = 6;
            this.lblFilename.Text = "文件名";
            this.lblFilename.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // rbtnMale
            // 
            this.rbtnMale.Location = new System.Drawing.Point(6, 14);
            this.rbtnMale.Name = "rbtnMale";
            this.rbtnMale.Size = new System.Drawing.Size(112, 24);
            this.rbtnMale.TabIndex = 7;
            this.rbtnMale.TabStop = true;
            this.rbtnMale.Text = "男性";
            this.rbtnMale.UseVisualStyleBackColor = true;
            // 
            // rbtnFemale
            // 
            this.rbtnFemale.Location = new System.Drawing.Point(134, 14);
            this.rbtnFemale.Name = "rbtnFemale";
            this.rbtnFemale.Size = new System.Drawing.Size(112, 24);
            this.rbtnFemale.TabIndex = 8;
            this.rbtnFemale.TabStop = true;
            this.rbtnFemale.Text = "女性";
            this.rbtnFemale.UseVisualStyleBackColor = true;
            // 
            // btnActive
            // 
            this.btnActive.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnActive.Location = new System.Drawing.Point(272, 370);
            this.btnActive.Name = "btnActive";
            this.btnActive.Size = new System.Drawing.Size(250, 21);
            this.btnActive.TabIndex = 9;
            this.btnActive.Text = "生成";
            this.btnActive.UseVisualStyleBackColor = false;
            // 
            // gbxGender
            // 
            this.gbxGender.Controls.Add(this.rbtnMale);
            this.gbxGender.Controls.Add(this.rbtnFemale);
            this.gbxGender.Location = new System.Drawing.Point(270, 64);
            this.gbxGender.Name = "gbxGender";
            this.gbxGender.Size = new System.Drawing.Size(252, 44);
            this.gbxGender.TabIndex = 10;
            this.gbxGender.TabStop = false;
            this.gbxGender.Text = "性别";
            // 
            // Window
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 401);
            this.Controls.Add(this.gbxGender);
            this.Controls.Add(this.btnActive);
            this.Controls.Add(this.lblFilename);
            this.Controls.Add(this.txtFilename);
            this.Controls.Add(this.btnPath);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.lblPath);
            this.Controls.Add(this.txtCard);
            this.Controls.Add(this.lblCard);
            this.Name = "Window";
            this.Text = "角色卡性别转换工具";
            this.gbxGender.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblCard;
        private System.Windows.Forms.TextBox txtCard;
        private System.Windows.Forms.Label lblPath;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button btnPath;
        private System.Windows.Forms.TextBox txtFilename;
        private System.Windows.Forms.Label lblFilename;
        private System.Windows.Forms.RadioButton rbtnMale;
        private System.Windows.Forms.RadioButton rbtnFemale;
        private System.Windows.Forms.Button btnActive;
        private System.Windows.Forms.GroupBox gbxGender;
    }
}

