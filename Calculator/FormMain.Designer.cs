
namespace Calculator
{
    partial class FormMain
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
            this.entry = new System.Windows.Forms.TextBox();
            this.calculate = new System.Windows.Forms.Button();
            this.result = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // entry
            // 
            this.entry.Location = new System.Drawing.Point(77, 49);
            this.entry.Name = "entry";
            this.entry.Size = new System.Drawing.Size(404, 22);
            this.entry.TabIndex = 0;
            this.entry.TextChanged += new System.EventHandler(this.entry_TextChanged);
            // 
            // calculate
            // 
            this.calculate.Location = new System.Drawing.Point(210, 104);
            this.calculate.Name = "calculate";
            this.calculate.Size = new System.Drawing.Size(100, 43);
            this.calculate.TabIndex = 1;
            this.calculate.Text = "Izračunaj";
            this.calculate.UseVisualStyleBackColor = true;
            this.calculate.Click += new System.EventHandler(this.calculate_Click);
            // 
            // result
            // 
            this.result.Location = new System.Drawing.Point(197, 173);
            this.result.Name = "result";
            this.result.ReadOnly = true;
            this.result.Size = new System.Drawing.Size(124, 22);
            this.result.TabIndex = 2;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(611, 253);
            this.Controls.Add(this.result);
            this.Controls.Add(this.calculate);
            this.Controls.Add(this.entry);
            this.Name = "FormMain";
            this.Text = "FormMain";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox entry;
        private System.Windows.Forms.Button calculate;
        private System.Windows.Forms.TextBox result;
    }
}