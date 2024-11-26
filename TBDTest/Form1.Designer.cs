namespace TBDTest
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            newOrderBtn = new Button();
            connectBtn = new Button();
            cancelBtn = new Button();
            positionsBtn = new Button();
            SuspendLayout();
            // 
            // newOrderBtn
            // 
            newOrderBtn.Location = new Point(153, 22);
            newOrderBtn.Name = "newOrderBtn";
            newOrderBtn.Size = new Size(115, 58);
            newOrderBtn.TabIndex = 0;
            newOrderBtn.Text = "测试新订单";
            newOrderBtn.UseVisualStyleBackColor = true;
            newOrderBtn.Click += newOrderBtn_Click;
            // 
            // connectBtn
            // 
            connectBtn.Location = new Point(32, 22);
            connectBtn.Name = "connectBtn";
            connectBtn.Size = new Size(115, 58);
            connectBtn.TabIndex = 1;
            connectBtn.Text = "连接服务器";
            connectBtn.UseVisualStyleBackColor = true;
            connectBtn.Click += connectBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(32, 86);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(115, 58);
            cancelBtn.TabIndex = 2;
            cancelBtn.Text = "测试撤单";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // positionsBtn
            // 
            positionsBtn.Location = new Point(153, 86);
            positionsBtn.Name = "positionsBtn";
            positionsBtn.Size = new Size(115, 58);
            positionsBtn.TabIndex = 2;
            positionsBtn.Text = "测试持仓";
            positionsBtn.UseVisualStyleBackColor = true;
            positionsBtn.Click += positionsBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(318, 177);
            Controls.Add(positionsBtn);
            Controls.Add(cancelBtn);
            Controls.Add(connectBtn);
            Controls.Add(newOrderBtn);
            Name = "Form1";
            Text = "TBox FIX测试";
            Load += Form1_Load;
            ResumeLayout(false);
        }

        #endregion

        private Button newOrderBtn;
        private Button connectBtn;
        private Button cancelBtn;
        private Button positionsBtn;
    }
}