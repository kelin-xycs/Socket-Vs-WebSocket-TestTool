namespace SocketTestTool
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
            this.btnStop = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtSendInfo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtConnCount = new System.Windows.Forms.TextBox();
            this.txtMsg = new System.Windows.Forms.TextBox();
            this.btnTest = new System.Windows.Forms.Button();
            this.txtThreadCount = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(95, 54);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(75, 23);
            this.btnStop.TabIndex = 29;
            this.btnStop.Text = "停止";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(262, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 28;
            this.label4.Text = "发送内容";
            // 
            // txtSendInfo
            // 
            this.txtSendInfo.Location = new System.Drawing.Point(321, 20);
            this.txtSendInfo.Name = "txtSendInfo";
            this.txtSendInfo.Size = new System.Drawing.Size(63, 21);
            this.txtSendInfo.TabIndex = 27;
            this.txtSendInfo.Text = "aa";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 23;
            this.label1.Text = "连接数";
            // 
            // txtConnCount
            // 
            this.txtConnCount.Location = new System.Drawing.Point(61, 20);
            this.txtConnCount.Name = "txtConnCount";
            this.txtConnCount.Size = new System.Drawing.Size(63, 21);
            this.txtConnCount.TabIndex = 22;
            this.txtConnCount.Text = "800";
            // 
            // txtMsg
            // 
            this.txtMsg.Location = new System.Drawing.Point(14, 83);
            this.txtMsg.Multiline = true;
            this.txtMsg.Name = "txtMsg";
            this.txtMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtMsg.Size = new System.Drawing.Size(577, 250);
            this.txtMsg.TabIndex = 21;
            // 
            // btnTest
            // 
            this.btnTest.Location = new System.Drawing.Point(14, 54);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(75, 23);
            this.btnTest.TabIndex = 20;
            this.btnTest.Text = "测试";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // txtThreadCount
            // 
            this.txtThreadCount.Location = new System.Drawing.Point(185, 20);
            this.txtThreadCount.Name = "txtThreadCount";
            this.txtThreadCount.Size = new System.Drawing.Size(65, 21);
            this.txtThreadCount.TabIndex = 30;
            this.txtThreadCount.Text = "4";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(41, 12);
            this.label5.TabIndex = 31;
            this.label5.Text = "线程数";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(176, 54);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 32;
            this.btnClear.Text = "清空";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 352);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtThreadCount);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtSendInfo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConnCount);
            this.Controls.Add(this.txtMsg);
            this.Controls.Add(this.btnTest);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtSendInfo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtConnCount;
        private System.Windows.Forms.TextBox txtMsg;
        private System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.TextBox txtThreadCount;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnClear;
    }
}