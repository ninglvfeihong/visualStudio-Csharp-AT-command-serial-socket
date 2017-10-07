namespace uartCsharp
{
    partial class AT_Form
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
            this.components = new System.ComponentModel.Container();
            this.serialPort = new System.IO.Ports.SerialPort(this.components);
            this.comb_COM_Ports = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comb_Baud_Rate = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_COM_Open = new System.Windows.Forms.Button();
            this.btn_COM_Send = new System.Windows.Forms.Button();
            this.text_COM_Send = new System.Windows.Forms.TextBox();
            this.text_info = new System.Windows.Forms.TextBox();
            this.btn_Socket_Open = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.text_Socket_port = new System.Windows.Forms.TextBox();
            this.text_Sock_Addr = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tool_COM_Status = new System.Windows.Forms.ToolStripProgressBar();
            this.tool_Sock_Address = new System.Windows.Forms.ToolStripStatusLabel();
            this.tool_Sock_Client_n = new System.Windows.Forms.ToolStripStatusLabel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // serialPort
            // 
            this.serialPort.WriteTimeout = 1000;
            // 
            // comb_COM_Ports
            // 
            this.comb_COM_Ports.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_COM_Ports.FormattingEnabled = true;
            this.comb_COM_Ports.Location = new System.Drawing.Point(77, 12);
            this.comb_COM_Ports.Name = "comb_COM_Ports";
            this.comb_COM_Ports.Size = new System.Drawing.Size(76, 20);
            this.comb_COM_Ports.TabIndex = 0;
            this.comb_COM_Ports.SelectedIndexChanged += new System.EventHandler(this.COM_Ports_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM Ports";
            // 
            // comb_Baud_Rate
            // 
            this.comb_Baud_Rate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comb_Baud_Rate.FormattingEnabled = true;
            this.comb_Baud_Rate.Items.AddRange(new object[] {
            "115200",
            "57600",
            "38400",
            "28800",
            "19200",
            "14400",
            "9600",
            "4800"});
            this.comb_Baud_Rate.Location = new System.Drawing.Point(77, 51);
            this.comb_Baud_Rate.Name = "comb_Baud_Rate";
            this.comb_Baud_Rate.Size = new System.Drawing.Size(76, 20);
            this.comb_Baud_Rate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "Baud Rate";
            // 
            // btn_COM_Open
            // 
            this.btn_COM_Open.Location = new System.Drawing.Point(14, 89);
            this.btn_COM_Open.Name = "btn_COM_Open";
            this.btn_COM_Open.Size = new System.Drawing.Size(57, 23);
            this.btn_COM_Open.TabIndex = 4;
            this.btn_COM_Open.Text = "Open";
            this.btn_COM_Open.UseVisualStyleBackColor = true;
            this.btn_COM_Open.Click += new System.EventHandler(this.btn_COM_Open_Click);
            // 
            // btn_COM_Send
            // 
            this.btn_COM_Send.Location = new System.Drawing.Point(78, 88);
            this.btn_COM_Send.Name = "btn_COM_Send";
            this.btn_COM_Send.Size = new System.Drawing.Size(75, 23);
            this.btn_COM_Send.TabIndex = 5;
            this.btn_COM_Send.Text = "Send";
            this.btn_COM_Send.UseVisualStyleBackColor = true;
            this.btn_COM_Send.Click += new System.EventHandler(this.btn_COM_Send_Click);
            // 
            // text_COM_Send
            // 
            this.text_COM_Send.Location = new System.Drawing.Point(14, 118);
            this.text_COM_Send.Multiline = true;
            this.text_COM_Send.Name = "text_COM_Send";
            this.text_COM_Send.Size = new System.Drawing.Size(139, 21);
            this.text_COM_Send.TabIndex = 6;
            this.text_COM_Send.Text = "Send Here";
            // 
            // text_info
            // 
            this.text_info.BackColor = System.Drawing.Color.AliceBlue;
            this.text_info.Location = new System.Drawing.Point(181, 15);
            this.text_info.Multiline = true;
            this.text_info.Name = "text_info";
            this.text_info.ReadOnly = true;
            this.text_info.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.text_info.Size = new System.Drawing.Size(269, 270);
            this.text_info.TabIndex = 7;
            this.text_info.Text = "Here display information\n\r";
            // 
            // btn_Socket_Open
            // 
            this.btn_Socket_Open.Location = new System.Drawing.Point(109, 212);
            this.btn_Socket_Open.Name = "btn_Socket_Open";
            this.btn_Socket_Open.Size = new System.Drawing.Size(44, 23);
            this.btn_Socket_Open.TabIndex = 8;
            this.btn_Socket_Open.Text = "Open";
            this.btn_Socket_Open.UseVisualStyleBackColor = true;
            this.btn_Socket_Open.Click += new System.EventHandler(this.btn_Socket_Open_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 215);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "Port";
            // 
            // text_Socket_port
            // 
            this.text_Socket_port.Location = new System.Drawing.Point(47, 212);
            this.text_Socket_port.Name = "text_Socket_port";
            this.text_Socket_port.Size = new System.Drawing.Size(49, 21);
            this.text_Socket_port.TabIndex = 10;
            // 
            // text_Sock_Addr
            // 
            this.text_Sock_Addr.Enabled = false;
            this.text_Sock_Addr.Location = new System.Drawing.Point(2, 260);
            this.text_Sock_Addr.Name = "text_Sock_Addr";
            this.text_Sock_Addr.ReadOnly = true;
            this.text_Sock_Addr.Size = new System.Drawing.Size(151, 21);
            this.text_Sock_Addr.TabIndex = 11;
            this.text_Sock_Addr.Text = "IP:port";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 245);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Status";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tool_COM_Status,
            this.tool_Sock_Address,
            this.tool_Sock_Client_n});
            this.statusStrip1.Location = new System.Drawing.Point(0, 307);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(462, 22);
            this.statusStrip1.TabIndex = 13;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tool_COM_Status
            // 
            this.tool_COM_Status.Name = "tool_COM_Status";
            this.tool_COM_Status.Size = new System.Drawing.Size(100, 16);
            // 
            // tool_Sock_Address
            // 
            this.tool_Sock_Address.Name = "tool_Sock_Address";
            this.tool_Sock_Address.Size = new System.Drawing.Size(72, 17);
            this.tool_Sock_Address.Text = "unknown   ";
            // 
            // tool_Sock_Client_n
            // 
            this.tool_Sock_Client_n.Name = "tool_Sock_Client_n";
            this.tool_Sock_Client_n.Size = new System.Drawing.Size(116, 17);
            this.tool_Sock_Client_n.Text = " Current Clents: 0  ";
            this.tool_Sock_Client_n.Click += new System.EventHandler(this.tool_Sock_Client_n_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(32, 164);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 20);
            this.comboBox1.TabIndex = 14;
            // 
            // AT_Form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Turquoise;
            this.ClientSize = new System.Drawing.Size(462, 329);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.text_Sock_Addr);
            this.Controls.Add(this.text_Socket_port);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Socket_Open);
            this.Controls.Add(this.text_info);
            this.Controls.Add(this.text_COM_Send);
            this.Controls.Add(this.btn_COM_Send);
            this.Controls.Add(this.btn_COM_Open);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comb_Baud_Rate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comb_COM_Ports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "AT_Form";
            this.Text = "AT Command Server";
            this.Load += new System.EventHandler(this.AT_Form_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.IO.Ports.SerialPort serialPort;
        private System.Windows.Forms.ComboBox comb_COM_Ports;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comb_Baud_Rate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_COM_Open;
        private System.Windows.Forms.Button btn_COM_Send;
        private System.Windows.Forms.TextBox text_COM_Send;
        private System.Windows.Forms.TextBox text_info;
        private System.Windows.Forms.Button btn_Socket_Open;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox text_Socket_port;
        private System.Windows.Forms.TextBox text_Sock_Addr;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripProgressBar tool_COM_Status;
        private System.Windows.Forms.ToolStripStatusLabel tool_Sock_Address;
        private System.Windows.Forms.ToolStripStatusLabel tool_Sock_Client_n;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

