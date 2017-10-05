namespace iCampProject
{
    partial class HomePage
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_register = new System.Windows.Forms.Button();
            this.btn_choose_activeties = new System.Windows.Forms.Button();
            this.btn_register_activities = new System.Windows.Forms.Button();
            this.btn_export_signup_sheet = new System.Windows.Forms.Button();
            this.btn_export_detail = new System.Windows.Forms.Button();
            this.btn_new_session = new System.Windows.Forms.Button();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.combo_session = new System.Windows.Forms.ComboBox();
            this.menuStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(766, 25);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(39, 21);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(95, 68);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(203, 35);
            this.label1.TabIndex = 1;
            this.label1.Text = "Camp Session:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_register_activities);
            this.groupBox1.Controls.Add(this.btn_choose_activeties);
            this.groupBox1.Controls.Add(this.btn_register);
            this.groupBox1.Location = new System.Drawing.Point(32, 156);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(323, 261);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dateTimePicker1);
            this.groupBox2.Controls.Add(this.btn_export_detail);
            this.groupBox2.Controls.Add(this.btn_export_signup_sheet);
            this.groupBox2.Location = new System.Drawing.Point(361, 156);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(323, 261);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Export";
            // 
            // btn_register
            // 
            this.btn_register.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_register.Location = new System.Drawing.Point(27, 30);
            this.btn_register.Name = "btn_register";
            this.btn_register.Size = new System.Drawing.Size(269, 49);
            this.btn_register.TabIndex = 0;
            this.btn_register.Text = "Register/Edit";
            this.btn_register.UseVisualStyleBackColor = true;
            // 
            // btn_choose_activeties
            // 
            this.btn_choose_activeties.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_choose_activeties.Location = new System.Drawing.Point(27, 106);
            this.btn_choose_activeties.Name = "btn_choose_activeties";
            this.btn_choose_activeties.Size = new System.Drawing.Size(269, 49);
            this.btn_choose_activeties.TabIndex = 1;
            this.btn_choose_activeties.Text = "Choose Activities";
            this.btn_choose_activeties.UseVisualStyleBackColor = true;
            // 
            // btn_register_activities
            // 
            this.btn_register_activities.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_register_activities.Location = new System.Drawing.Point(27, 182);
            this.btn_register_activities.Name = "btn_register_activities";
            this.btn_register_activities.Size = new System.Drawing.Size(269, 49);
            this.btn_register_activities.TabIndex = 2;
            this.btn_register_activities.Text = "Register Activities ";
            this.btn_register_activities.UseVisualStyleBackColor = true;
            // 
            // btn_export_signup_sheet
            // 
            this.btn_export_signup_sheet.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_export_signup_sheet.Location = new System.Drawing.Point(28, 106);
            this.btn_export_signup_sheet.Name = "btn_export_signup_sheet";
            this.btn_export_signup_sheet.Size = new System.Drawing.Size(269, 49);
            this.btn_export_signup_sheet.TabIndex = 3;
            this.btn_export_signup_sheet.Text = "Signup Sheet";
            this.btn_export_signup_sheet.UseVisualStyleBackColor = true;
            // 
            // btn_export_detail
            // 
            this.btn_export_detail.Font = new System.Drawing.Font("微软雅黑", 20.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_export_detail.Location = new System.Drawing.Point(28, 182);
            this.btn_export_detail.Name = "btn_export_detail";
            this.btn_export_detail.Size = new System.Drawing.Size(269, 49);
            this.btn_export_detail.TabIndex = 4;
            this.btn_export_detail.Text = "Detail";
            this.btn_export_detail.UseVisualStyleBackColor = true;
            // 
            // btn_new_session
            // 
            this.btn_new_session.Location = new System.Drawing.Point(583, 75);
            this.btn_new_session.Name = "btn_new_session";
            this.btn_new_session.Size = new System.Drawing.Size(101, 28);
            this.btn_new_session.TabIndex = 5;
            this.btn_new_session.Text = "New";
            this.btn_new_session.UseVisualStyleBackColor = true;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(28, 41);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(269, 21);
            this.dateTimePicker1.TabIndex = 5;
            // 
            // combo_session
            // 
            this.combo_session.FormattingEnabled = true;
            this.combo_session.Location = new System.Drawing.Point(316, 78);
            this.combo_session.Name = "combo_session";
            this.combo_session.Size = new System.Drawing.Size(228, 20);
            this.combo_session.TabIndex = 6;
            // 
            // HomePage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 455);
            this.Controls.Add(this.combo_session);
            this.Controls.Add(this.btn_new_session);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HomePage";
            this.Text = "Home Page";
            this.Load += new System.EventHandler(this.HomePage_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btn_register_activities;
        private System.Windows.Forms.Button btn_choose_activeties;
        private System.Windows.Forms.Button btn_register;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_export_detail;
        private System.Windows.Forms.Button btn_export_signup_sheet;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Button btn_new_session;
        private System.Windows.Forms.ComboBox combo_session;
    }
}

