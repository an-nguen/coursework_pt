﻿namespace TP_coursework
{
    partial class ResForm
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
            this.quiz1 = new System.Windows.Forms.Label();
            this.r1 = new System.Windows.Forms.Label();
            this.buttonEnd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // quiz1
            // 
            this.quiz1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quiz1.AutoSize = true;
            this.quiz1.BackColor = System.Drawing.Color.Transparent;
            this.quiz1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.quiz1.Location = new System.Drawing.Point(14, 21);
            this.quiz1.Margin = new System.Windows.Forms.Padding(5);
            this.quiz1.Name = "quiz1";
            this.quiz1.Size = new System.Drawing.Size(435, 33);
            this.quiz1.TabIndex = 15;
            this.quiz1.Text = "Средний балл вашего ВУЗа: ";
            // 
            // r1
            // 
            this.r1.AutoSize = true;
            this.r1.BackColor = System.Drawing.Color.Transparent;
            this.r1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.r1.Location = new System.Drawing.Point(457, 21);
            this.r1.Name = "r1";
            this.r1.Size = new System.Drawing.Size(72, 33);
            this.r1.TabIndex = 23;
            this.r1.Text = "res1";
            // 
            // buttonEnd
            // 
            this.buttonEnd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonEnd.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.buttonEnd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.buttonEnd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.buttonEnd.Location = new System.Drawing.Point(524, 130);
            this.buttonEnd.Name = "buttonEnd";
            this.buttonEnd.Size = new System.Drawing.Size(86, 23);
            this.buttonEnd.TabIndex = 31;
            this.buttonEnd.Text = "Закрыть";
            this.buttonEnd.UseVisualStyleBackColor = false;
            this.buttonEnd.Click += new System.EventHandler(this.ButtonEnd_Click);
            // 
            // ResForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::TP_coursework.Properties.Resources.ulyanovsk_politeh_blurred;
            this.ClientSize = new System.Drawing.Size(622, 165);
            this.Controls.Add(this.buttonEnd);
            this.Controls.Add(this.r1);
            this.Controls.Add(this.quiz1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ResForm";
            this.Text = "App - Соц.опрос студентов";
            this.Load += new System.EventHandler(this.ResForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label quiz1;
        private System.Windows.Forms.Label r1;
        private System.Windows.Forms.Button buttonEnd;
    }
}