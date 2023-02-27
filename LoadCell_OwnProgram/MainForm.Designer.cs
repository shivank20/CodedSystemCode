namespace LoadCell_OwnProgram
{
    partial class MainForm
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
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.ResultsLab = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.Lime;
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button3.Location = new System.Drawing.Point(233, 264);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(243, 77);
            this.button3.TabIndex = 0;
            this.button3.Text = "Start";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.Red;
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F);
            this.button4.Location = new System.Drawing.Point(913, 264);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(243, 77);
            this.button4.TabIndex = 1;
            this.button4.Text = "Stop";
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // ResultsLab
            // 
            this.ResultsLab.AutoSize = true;
            this.ResultsLab.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.6F);
            this.ResultsLab.Location = new System.Drawing.Point(589, 112);
            this.ResultsLab.Name = "ResultsLab";
            this.ResultsLab.Size = new System.Drawing.Size(134, 39);
            this.ResultsLab.TabIndex = 2;
            this.ResultsLab.Text = "Results";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.6F);
            this.label1.Location = new System.Drawing.Point(694, 129);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 22);
            this.label1.TabIndex = 3;
            this.label1.Text = "lbf";
            // 
            // MainForm
            // 
            this.ClientSize = new System.Drawing.Size(1342, 413);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ResultsLab);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Name = "MainForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label ResultsLab;
        private System.Windows.Forms.Label label1;
    }
}