namespace WandioComLib.Demo.Forms
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
            this.textBoxCheckClass1 = new WandioComLib.Controls.TextBoxCheckClass();
            this.SuspendLayout();
            // 
            // textBoxCheckClass1
            // 
            this.textBoxCheckClass1.Location = new System.Drawing.Point(13, 13);
            this.textBoxCheckClass1.Name = "textBoxCheckClass1";
            this.textBoxCheckClass1.PlaceHolder = "";
            this.textBoxCheckClass1.Size = new System.Drawing.Size(153, 22);
            this.textBoxCheckClass1.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textBoxCheckClass1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Controls.TextBoxCheckClass textBoxCheckClass1;
    }
}

