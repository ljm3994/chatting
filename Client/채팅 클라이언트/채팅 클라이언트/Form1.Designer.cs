namespace 채팅_클라이언트
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다.
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.열기ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.채팅서버접속Menu = new System.Windows.Forms.ToolStripMenuItem();
            this.접속포트변경ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UserList = new System.Windows.Forms.ListBox();
            this.MsgList = new System.Windows.Forms.ListBox();
            this.MsgText = new System.Windows.Forms.TextBox();
            this.btn_send = new System.Windows.Forms.Button();
            this.파일FToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.파일전송SToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.열기ToolStripMenuItem,
            this.파일FToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(521, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 열기ToolStripMenuItem
            // 
            this.열기ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.채팅서버접속Menu,
            this.접속포트변경ToolStripMenuItem});
            this.열기ToolStripMenuItem.Name = "열기ToolStripMenuItem";
            this.열기ToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.열기ToolStripMenuItem.Text = "열기(&O)";
            // 
            // 채팅서버접속Menu
            // 
            this.채팅서버접속Menu.Name = "채팅서버접속Menu";
            this.채팅서버접속Menu.Size = new System.Drawing.Size(166, 22);
            this.채팅서버접속Menu.Text = "채팅서버 접속(&C)";
            this.채팅서버접속Menu.Click += new System.EventHandler(this.채팅서버접속ToolStripMenuItem_Click);
            // 
            // 접속포트변경ToolStripMenuItem
            // 
            this.접속포트변경ToolStripMenuItem.Name = "접속포트변경ToolStripMenuItem";
            this.접속포트변경ToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.접속포트변경ToolStripMenuItem.Text = "접속포트 변경(&P)";
            this.접속포트변경ToolStripMenuItem.Click += new System.EventHandler(this.접속포트변경ToolStripMenuItem_Click);
            // 
            // UserList
            // 
            this.UserList.FormattingEnabled = true;
            this.UserList.ItemHeight = 12;
            this.UserList.Location = new System.Drawing.Point(330, 48);
            this.UserList.Name = "UserList";
            this.UserList.Size = new System.Drawing.Size(172, 448);
            this.UserList.TabIndex = 1;
            // 
            // MsgList
            // 
            this.MsgList.FormattingEnabled = true;
            this.MsgList.ItemHeight = 12;
            this.MsgList.Location = new System.Drawing.Point(12, 48);
            this.MsgList.Name = "MsgList";
            this.MsgList.Size = new System.Drawing.Size(299, 448);
            this.MsgList.TabIndex = 2;
            // 
            // MsgText
            // 
            this.MsgText.Location = new System.Drawing.Point(12, 532);
            this.MsgText.Multiline = true;
            this.MsgText.Name = "MsgText";
            this.MsgText.Size = new System.Drawing.Size(337, 73);
            this.MsgText.TabIndex = 3;
            // 
            // btn_send
            // 
            this.btn_send.Location = new System.Drawing.Point(362, 532);
            this.btn_send.Name = "btn_send";
            this.btn_send.Size = new System.Drawing.Size(139, 73);
            this.btn_send.TabIndex = 4;
            this.btn_send.Text = "전송";
            this.btn_send.UseVisualStyleBackColor = true;
            this.btn_send.Click += new System.EventHandler(this.btn_send_Click);
            // 
            // 파일FToolStripMenuItem
            // 
            this.파일FToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.파일전송SToolStripMenuItem});
            this.파일FToolStripMenuItem.Name = "파일FToolStripMenuItem";
            this.파일FToolStripMenuItem.Size = new System.Drawing.Size(57, 20);
            this.파일FToolStripMenuItem.Text = "파일(&F)";
            // 
            // 파일전송SToolStripMenuItem
            // 
            this.파일전송SToolStripMenuItem.Name = "파일전송SToolStripMenuItem";
            this.파일전송SToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.파일전송SToolStripMenuItem.Text = "파일 전송(&S)";
            this.파일전송SToolStripMenuItem.Click += new System.EventHandler(this.파일전송SToolStripMenuItem_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 622);
            this.Controls.Add(this.btn_send);
            this.Controls.Add(this.MsgText);
            this.Controls.Add(this.MsgList);
            this.Controls.Add(this.UserList);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Form1";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 열기ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 채팅서버접속Menu;

        public System.Windows.Forms.ToolStripMenuItem 채팅서버접속Menu1
        {
            get { return 채팅서버접속Menu; }
            set { 채팅서버접속Menu = value; }
        }
        private System.Windows.Forms.ToolStripMenuItem 접속포트변경ToolStripMenuItem;
        private System.Windows.Forms.ListBox UserList;
        private System.Windows.Forms.ListBox MsgList;
        private System.Windows.Forms.TextBox MsgText;
        private System.Windows.Forms.Button btn_send;
        private System.Windows.Forms.ToolStripMenuItem 파일FToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 파일전송SToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

