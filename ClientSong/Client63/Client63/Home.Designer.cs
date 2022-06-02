namespace Client63
{
    partial class HomeForm
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
            this.JoinedChatsCombo = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NotJoinedChatsCombo = new System.Windows.Forms.ComboBox();
            this.MessagesTextBox = new System.Windows.Forms.RichTextBox();
            this.msgText = new System.Windows.Forms.RichTextBox();
            this.SendMsgButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.leaveChatsCombo = new System.Windows.Forms.ComboBox();
            this.CreateChatBttn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // JoinedChatsCombo
            // 
            this.JoinedChatsCombo.FormattingEnabled = true;
            this.JoinedChatsCombo.Location = new System.Drawing.Point(20, 52);
            this.JoinedChatsCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.JoinedChatsCombo.Name = "JoinedChatsCombo";
            this.JoinedChatsCombo.Size = new System.Drawing.Size(249, 24);
            this.JoinedChatsCombo.TabIndex = 0;
            this.JoinedChatsCombo.SelectedIndexChanged += new System.EventHandler(this.JoinedChatsCombo_SelectedIndexChanged);
            this.JoinedChatsCombo.Click += new System.EventHandler(this.update);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(153, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select a Chat to enter: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(17, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select a Chat to join:";
            // 
            // NotJoinedChatsCombo
            // 
            this.NotJoinedChatsCombo.FormattingEnabled = true;
            this.NotJoinedChatsCombo.Location = new System.Drawing.Point(20, 126);
            this.NotJoinedChatsCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.NotJoinedChatsCombo.Name = "NotJoinedChatsCombo";
            this.NotJoinedChatsCombo.Size = new System.Drawing.Size(249, 24);
            this.NotJoinedChatsCombo.TabIndex = 3;
            this.NotJoinedChatsCombo.SelectedIndexChanged += new System.EventHandler(this.NotJoinedChatsCombo_SelectedIndexChanged);
            // 
            // MessagesTextBox
            // 
            this.MessagesTextBox.Location = new System.Drawing.Point(329, 28);
            this.MessagesTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MessagesTextBox.Name = "MessagesTextBox";
            this.MessagesTextBox.Size = new System.Drawing.Size(372, 194);
            this.MessagesTextBox.TabIndex = 4;
            this.MessagesTextBox.Text = "";
            this.MessagesTextBox.TextChanged += new System.EventHandler(this.MessagesTextBox_TextChanged);
            // 
            // msgText
            // 
            this.msgText.Location = new System.Drawing.Point(329, 255);
            this.msgText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.msgText.Name = "msgText";
            this.msgText.Size = new System.Drawing.Size(372, 53);
            this.msgText.TabIndex = 5;
            this.msgText.Text = "";
            // 
            // SendMsgButton
            // 
            this.SendMsgButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendMsgButton.Location = new System.Drawing.Point(329, 323);
            this.SendMsgButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.SendMsgButton.Name = "SendMsgButton";
            this.SendMsgButton.Size = new System.Drawing.Size(372, 27);
            this.SendMsgButton.TabIndex = 6;
            this.SendMsgButton.Text = "Send Message";
            this.SendMsgButton.UseVisualStyleBackColor = true;
            this.SendMsgButton.Click += new System.EventHandler(this.SendMsgButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select a Chat to leave:";
            // 
            // leaveChatsCombo
            // 
            this.leaveChatsCombo.FormattingEnabled = true;
            this.leaveChatsCombo.Location = new System.Drawing.Point(20, 199);
            this.leaveChatsCombo.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.leaveChatsCombo.Name = "leaveChatsCombo";
            this.leaveChatsCombo.Size = new System.Drawing.Size(249, 24);
            this.leaveChatsCombo.TabIndex = 8;
            this.leaveChatsCombo.SelectedIndexChanged += new System.EventHandler(this.leaveChatsCombo_SelectedIndexChanged);
            this.leaveChatsCombo.Click += new System.EventHandler(this.update);
            // 
            // CreateChatBttn
            // 
            this.CreateChatBttn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateChatBttn.Location = new System.Drawing.Point(20, 255);
            this.CreateChatBttn.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CreateChatBttn.Name = "CreateChatBttn";
            this.CreateChatBttn.Size = new System.Drawing.Size(249, 27);
            this.CreateChatBttn.TabIndex = 10;
            this.CreateChatBttn.Text = "Create Chatroom";
            this.CreateChatBttn.UseVisualStyleBackColor = true;
            this.CreateChatBttn.Click += new System.EventHandler(this.CreateChatBttn_Click);
            // 
            // HomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaGreen;
            this.ClientSize = new System.Drawing.Size(711, 360);
            this.Controls.Add(this.CreateChatBttn);
            this.Controls.Add(this.leaveChatsCombo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.SendMsgButton);
            this.Controls.Add(this.msgText);
            this.Controls.Add(this.MessagesTextBox);
            this.Controls.Add(this.NotJoinedChatsCombo);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.JoinedChatsCombo);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "HomeForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Home";
            this.Load += new System.EventHandler(this.HomeForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox JoinedChatsCombo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox NotJoinedChatsCombo;
        private System.Windows.Forms.RichTextBox MessagesTextBox;
        private System.Windows.Forms.RichTextBox msgText;
        private System.Windows.Forms.Button SendMsgButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox leaveChatsCombo;
        private System.Windows.Forms.Button CreateChatBttn;
    }
}