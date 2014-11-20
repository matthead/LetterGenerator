namespace allstate
{
    partial class PopUp
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
            this.addPolicy = new System.Windows.Forms.Button();
            this.addPolicyLabel = new System.Windows.Forms.Label();
            this.addPolicyBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addPolicy
            // 
            this.addPolicy.Location = new System.Drawing.Point(201, 97);
            this.addPolicy.Name = "addPolicy";
            this.addPolicy.Size = new System.Drawing.Size(75, 23);
            this.addPolicy.TabIndex = 0;
            this.addPolicy.Text = "Add Policy";
            this.addPolicy.UseVisualStyleBackColor = true;
            this.addPolicy.Click += new System.EventHandler(this.addPolicy_Click);
            // 
            // addPolicyLabel
            // 
            this.addPolicyLabel.AutoSize = true;
            this.addPolicyLabel.Location = new System.Drawing.Point(22, 9);
            this.addPolicyLabel.Name = "addPolicyLabel";
            this.addPolicyLabel.Size = new System.Drawing.Size(57, 13);
            this.addPolicyLabel.TabIndex = 1;
            this.addPolicyLabel.Text = "Add Policy";
            // 
            // addPolicyBox
            // 
            this.addPolicyBox.Location = new System.Drawing.Point(25, 25);
            this.addPolicyBox.Name = "addPolicyBox";
            this.addPolicyBox.Size = new System.Drawing.Size(100, 20);
            this.addPolicyBox.TabIndex = 2;
            // 
            // PopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 132);
            this.Controls.Add(this.addPolicyBox);
            this.Controls.Add(this.addPolicyLabel);
            this.Controls.Add(this.addPolicy);
            this.Name = "PopUp";
            this.Text = "PopUp";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addPolicy;
        private System.Windows.Forms.Label addPolicyLabel;
        private System.Windows.Forms.TextBox addPolicyBox;
    }
}