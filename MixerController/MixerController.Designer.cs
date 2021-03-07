namespace MixerController
{
    partial class MixerController
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.com_ports = new System.Windows.Forms.ComboBox();
            this.refresh_com_ports = new System.Windows.Forms.Button();
            this.list_0 = new System.Windows.Forms.ComboBox();
            this.select_device_0 = new System.Windows.Forms.RadioButton();
            this.select_app_0 = new System.Windows.Forms.RadioButton();
            this.refresh_0 = new System.Windows.Forms.Button();
            this.refresh_1 = new System.Windows.Forms.Button();
            this.list_1 = new System.Windows.Forms.ComboBox();
            this.refresh_2 = new System.Windows.Forms.Button();
            this.list_2 = new System.Windows.Forms.ComboBox();
            this.refresh_3 = new System.Windows.Forms.Button();
            this.list_3 = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.select_device_1 = new System.Windows.Forms.RadioButton();
            this.select_app_1 = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.select_device_2 = new System.Windows.Forms.RadioButton();
            this.select_app_2 = new System.Windows.Forms.RadioButton();
            this.flowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.select_device_3 = new System.Windows.Forms.RadioButton();
            this.select_app_3 = new System.Windows.Forms.RadioButton();
            this.start = new System.Windows.Forms.Button();
            this.flowLayoutPanel1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.flowLayoutPanel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // com_ports
            // 
            this.com_ports.FormattingEnabled = true;
            this.com_ports.Location = new System.Drawing.Point(63, 2);
            this.com_ports.Name = "com_ports";
            this.com_ports.Size = new System.Drawing.Size(70, 21);
            this.com_ports.TabIndex = 0;
            // 
            // refresh_com_ports
            // 
            this.refresh_com_ports.Location = new System.Drawing.Point(139, 1);
            this.refresh_com_ports.Name = "refresh_com_ports";
            this.refresh_com_ports.Size = new System.Drawing.Size(62, 23);
            this.refresh_com_ports.TabIndex = 1;
            this.refresh_com_ports.Text = "Refresh";
            this.refresh_com_ports.UseVisualStyleBackColor = true;
            this.refresh_com_ports.Click += new System.EventHandler(this.refresh_com_ports_Click);
            // 
            // list_0
            // 
            this.list_0.FormattingEnabled = true;
            this.list_0.Location = new System.Drawing.Point(12, 67);
            this.list_0.Name = "list_0";
            this.list_0.Size = new System.Drawing.Size(138, 21);
            this.list_0.TabIndex = 2;
            this.list_0.SelectedIndexChanged += new System.EventHandler(this.list_0_SelectedIndexChanged);
            // 
            // select_device_0
            // 
            this.select_device_0.AutoSize = true;
            this.select_device_0.Checked = true;
            this.select_device_0.Location = new System.Drawing.Point(3, 3);
            this.select_device_0.Name = "select_device_0";
            this.select_device_0.Size = new System.Drawing.Size(59, 17);
            this.select_device_0.TabIndex = 0;
            this.select_device_0.TabStop = true;
            this.select_device_0.Text = "Device";
            this.select_device_0.UseVisualStyleBackColor = true;
            this.select_device_0.CheckedChanged += new System.EventHandler(this.select_device_0_CheckedChanged);
            // 
            // select_app_0
            // 
            this.select_app_0.AutoSize = true;
            this.select_app_0.Location = new System.Drawing.Point(68, 3);
            this.select_app_0.Name = "select_app_0";
            this.select_app_0.Size = new System.Drawing.Size(77, 17);
            this.select_app_0.TabIndex = 0;
            this.select_app_0.Text = "Application";
            this.select_app_0.UseVisualStyleBackColor = true;
            this.select_app_0.CheckedChanged += new System.EventHandler(this.select_app_0_CheckedChanged);
            // 
            // refresh_0
            // 
            this.refresh_0.Location = new System.Drawing.Point(156, 66);
            this.refresh_0.Name = "refresh_0";
            this.refresh_0.Size = new System.Drawing.Size(84, 23);
            this.refresh_0.TabIndex = 5;
            this.refresh_0.Text = "Refresh";
            this.refresh_0.UseVisualStyleBackColor = true;
            this.refresh_0.Click += new System.EventHandler(this.refresh_0_Click);
            // 
            // refresh_1
            // 
            this.refresh_1.Location = new System.Drawing.Point(156, 122);
            this.refresh_1.Name = "refresh_1";
            this.refresh_1.Size = new System.Drawing.Size(84, 23);
            this.refresh_1.TabIndex = 9;
            this.refresh_1.Text = "Refresh";
            this.refresh_1.UseVisualStyleBackColor = true;
            this.refresh_1.Click += new System.EventHandler(this.refresh_1_Click);
            // 
            // list_1
            // 
            this.list_1.FormattingEnabled = true;
            this.list_1.Location = new System.Drawing.Point(12, 123);
            this.list_1.Name = "list_1";
            this.list_1.Size = new System.Drawing.Size(138, 21);
            this.list_1.TabIndex = 6;
            this.list_1.SelectedIndexChanged += new System.EventHandler(this.list_1_SelectedIndexChanged);
            // 
            // refresh_2
            // 
            this.refresh_2.Location = new System.Drawing.Point(156, 179);
            this.refresh_2.Name = "refresh_2";
            this.refresh_2.Size = new System.Drawing.Size(84, 23);
            this.refresh_2.TabIndex = 13;
            this.refresh_2.Text = "Refresh";
            this.refresh_2.UseVisualStyleBackColor = true;
            this.refresh_2.Click += new System.EventHandler(this.refresh_2_Click);
            // 
            // list_2
            // 
            this.list_2.FormattingEnabled = true;
            this.list_2.Location = new System.Drawing.Point(12, 180);
            this.list_2.Name = "list_2";
            this.list_2.Size = new System.Drawing.Size(138, 21);
            this.list_2.TabIndex = 10;
            this.list_2.SelectedIndexChanged += new System.EventHandler(this.list_2_SelectedIndexChanged);
            // 
            // refresh_3
            // 
            this.refresh_3.Location = new System.Drawing.Point(156, 239);
            this.refresh_3.Name = "refresh_3";
            this.refresh_3.Size = new System.Drawing.Size(84, 23);
            this.refresh_3.TabIndex = 17;
            this.refresh_3.Text = "Refresh";
            this.refresh_3.UseVisualStyleBackColor = true;
            this.refresh_3.Click += new System.EventHandler(this.refresh_3_Click);
            // 
            // list_3
            // 
            this.list_3.FormattingEnabled = true;
            this.list_3.Location = new System.Drawing.Point(12, 240);
            this.list_3.Name = "list_3";
            this.list_3.Size = new System.Drawing.Size(138, 21);
            this.list_3.TabIndex = 14;
            this.list_3.SelectedIndexChanged += new System.EventHandler(this.list_3_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.select_device_0);
            this.flowLayoutPanel1.Controls.Add(this.select_app_0);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(11, 41);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(148, 26);
            this.flowLayoutPanel1.TabIndex = 18;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.select_device_1);
            this.flowLayoutPanel2.Controls.Add(this.select_app_1);
            this.flowLayoutPanel2.Location = new System.Drawing.Point(11, 95);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(149, 28);
            this.flowLayoutPanel2.TabIndex = 19;
            // 
            // select_device_1
            // 
            this.select_device_1.AutoSize = true;
            this.select_device_1.Location = new System.Drawing.Point(3, 3);
            this.select_device_1.Name = "select_device_1";
            this.select_device_1.Size = new System.Drawing.Size(59, 17);
            this.select_device_1.TabIndex = 0;
            this.select_device_1.Text = "Device";
            this.select_device_1.UseVisualStyleBackColor = true;
            this.select_device_1.CheckedChanged += new System.EventHandler(this.select_device_1_CheckedChanged);
            // 
            // select_app_1
            // 
            this.select_app_1.AutoSize = true;
            this.select_app_1.Checked = true;
            this.select_app_1.Location = new System.Drawing.Point(68, 3);
            this.select_app_1.Name = "select_app_1";
            this.select_app_1.Size = new System.Drawing.Size(77, 17);
            this.select_app_1.TabIndex = 1;
            this.select_app_1.TabStop = true;
            this.select_app_1.Text = "Application";
            this.select_app_1.UseVisualStyleBackColor = true;
            this.select_app_1.CheckedChanged += new System.EventHandler(this.select_app_1_CheckedChanged);
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.select_device_2);
            this.flowLayoutPanel3.Controls.Add(this.select_app_2);
            this.flowLayoutPanel3.Location = new System.Drawing.Point(11, 150);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(148, 29);
            this.flowLayoutPanel3.TabIndex = 20;
            // 
            // select_device_2
            // 
            this.select_device_2.AutoSize = true;
            this.select_device_2.Location = new System.Drawing.Point(3, 3);
            this.select_device_2.Name = "select_device_2";
            this.select_device_2.Size = new System.Drawing.Size(59, 17);
            this.select_device_2.TabIndex = 2;
            this.select_device_2.Text = "Device";
            this.select_device_2.UseVisualStyleBackColor = true;
            this.select_device_2.CheckedChanged += new System.EventHandler(this.select_device_2_CheckedChanged);
            // 
            // select_app_2
            // 
            this.select_app_2.AutoSize = true;
            this.select_app_2.Checked = true;
            this.select_app_2.Location = new System.Drawing.Point(68, 3);
            this.select_app_2.Name = "select_app_2";
            this.select_app_2.Size = new System.Drawing.Size(77, 17);
            this.select_app_2.TabIndex = 2;
            this.select_app_2.TabStop = true;
            this.select_app_2.Text = "Application";
            this.select_app_2.UseVisualStyleBackColor = true;
            this.select_app_2.CheckedChanged += new System.EventHandler(this.select_app_2_CheckedChanged);
            // 
            // flowLayoutPanel4
            // 
            this.flowLayoutPanel4.Controls.Add(this.select_device_3);
            this.flowLayoutPanel4.Controls.Add(this.select_app_3);
            this.flowLayoutPanel4.Location = new System.Drawing.Point(12, 208);
            this.flowLayoutPanel4.Name = "flowLayoutPanel4";
            this.flowLayoutPanel4.Size = new System.Drawing.Size(148, 31);
            this.flowLayoutPanel4.TabIndex = 21;
            // 
            // select_device_3
            // 
            this.select_device_3.AutoSize = true;
            this.select_device_3.Location = new System.Drawing.Point(3, 3);
            this.select_device_3.Name = "select_device_3";
            this.select_device_3.Size = new System.Drawing.Size(59, 17);
            this.select_device_3.TabIndex = 3;
            this.select_device_3.Text = "Device";
            this.select_device_3.UseVisualStyleBackColor = true;
            this.select_device_3.CheckedChanged += new System.EventHandler(this.select_device_3_CheckedChanged);
            // 
            // select_app_3
            // 
            this.select_app_3.AutoSize = true;
            this.select_app_3.Checked = true;
            this.select_app_3.Location = new System.Drawing.Point(68, 3);
            this.select_app_3.Name = "select_app_3";
            this.select_app_3.Size = new System.Drawing.Size(77, 17);
            this.select_app_3.TabIndex = 4;
            this.select_app_3.TabStop = true;
            this.select_app_3.Text = "Application";
            this.select_app_3.UseVisualStyleBackColor = true;
            this.select_app_3.CheckedChanged += new System.EventHandler(this.select_app_3_CheckedChanged);
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(89, 269);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(71, 24);
            this.start.TabIndex = 22;
            this.start.Text = "Start";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // MixerController
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(255, 315);
            this.Controls.Add(this.start);
            this.Controls.Add(this.flowLayoutPanel4);
            this.Controls.Add(this.flowLayoutPanel3);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.refresh_3);
            this.Controls.Add(this.list_3);
            this.Controls.Add(this.refresh_2);
            this.Controls.Add(this.list_2);
            this.Controls.Add(this.refresh_1);
            this.Controls.Add(this.list_1);
            this.Controls.Add(this.refresh_0);
            this.Controls.Add(this.list_0);
            this.Controls.Add(this.refresh_com_ports);
            this.Controls.Add(this.com_ports);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MixerController";
            this.Text = "MixerController";
            this.Load += new System.EventHandler(this.MixerController_Load);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.flowLayoutPanel4.ResumeLayout(false);
            this.flowLayoutPanel4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox com_ports;
        private System.Windows.Forms.Button refresh_com_ports;
        private System.Windows.Forms.ComboBox list_0;
        private System.Windows.Forms.RadioButton select_device_0;
        private System.Windows.Forms.RadioButton select_app_0;
        private System.Windows.Forms.Button refresh_0;
        private System.Windows.Forms.Button refresh_1;
        private System.Windows.Forms.ComboBox list_1;
        private System.Windows.Forms.Button refresh_2;
        private System.Windows.Forms.ComboBox list_2;
        private System.Windows.Forms.Button refresh_3;
        private System.Windows.Forms.ComboBox list_3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel4;
        private System.Windows.Forms.RadioButton select_device_1;
        private System.Windows.Forms.RadioButton select_app_1;
        private System.Windows.Forms.RadioButton select_device_2;
        private System.Windows.Forms.RadioButton select_app_2;
        private System.Windows.Forms.RadioButton select_device_3;
        private System.Windows.Forms.RadioButton select_app_3;
        private System.Windows.Forms.Button start;
    }
}

