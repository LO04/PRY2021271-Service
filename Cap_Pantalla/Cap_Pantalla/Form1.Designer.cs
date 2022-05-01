
namespace Cap_Pantalla
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
            this.components = new System.ComponentModel.Container();
            this.pictureBoxing = new System.Windows.Forms.PictureBox();
            this.btcapturar = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btguardar = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxing)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBoxing
            // 
            this.pictureBoxing.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxing.Name = "pictureBoxing";
            this.pictureBoxing.Size = new System.Drawing.Size(950, 502);
            this.pictureBoxing.TabIndex = 0;
            this.pictureBoxing.TabStop = false;
            // 
            // btcapturar
            // 
            this.btcapturar.Location = new System.Drawing.Point(693, 35);
            this.btcapturar.Name = "btcapturar";
            this.btcapturar.Size = new System.Drawing.Size(75, 23);
            this.btcapturar.TabIndex = 1;
            this.btcapturar.Text = "Capturar";
            this.btcapturar.UseVisualStyleBackColor = true;
            this.btcapturar.Visible = false;
            this.btcapturar.Click += new System.EventHandler(this.btcapturar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(693, 87);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            // 
            // btguardar
            // 
            this.btguardar.Location = new System.Drawing.Point(693, 133);
            this.btguardar.Name = "btguardar";
            this.btguardar.Size = new System.Drawing.Size(75, 23);
            this.btguardar.TabIndex = 3;
            this.btguardar.Text = "Guardar";
            this.btguardar.UseVisualStyleBackColor = true;
            this.btguardar.Visible = false;
            this.btguardar.Click += new System.EventHandler(this.btguardar_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 10000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // timer2
            // 
            this.timer2.Interval = 15000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(974, 526);
            this.Controls.Add(this.btguardar);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.btcapturar);
            this.Controls.Add(this.pictureBoxing);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxing)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxing;
        private System.Windows.Forms.Button btcapturar;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btguardar;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
    }
}

