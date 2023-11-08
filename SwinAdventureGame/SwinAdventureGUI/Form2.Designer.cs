
namespace SwinAdventureGUI
{
    partial class Form2
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
            this.outputLabel = new System.Windows.Forms.Label();
            this.commandTextBox = new System.Windows.Forms.TextBox();
            this.nameLabel = new System.Windows.Forms.Label();
            this.executeButton = new System.Windows.Forms.Button();
            this.pInvInfoLabel = new System.Windows.Forms.Label();
            this.playerInvLabel = new System.Windows.Forms.Label();
            this.locInvInfoLabel = new System.Windows.Forms.Label();
            this.locationInvLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // outputLabel
            // 
            this.outputLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.outputLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.outputLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.outputLabel.Location = new System.Drawing.Point(23, 21);
            this.outputLabel.Name = "outputLabel";
            this.outputLabel.Size = new System.Drawing.Size(414, 179);
            this.outputLabel.TabIndex = 1;
            this.outputLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // commandTextBox
            // 
            this.commandTextBox.Location = new System.Drawing.Point(84, 286);
            this.commandTextBox.Name = "commandTextBox";
            this.commandTextBox.Size = new System.Drawing.Size(279, 23);
            this.commandTextBox.TabIndex = 0;
            // 
            // nameLabel
            // 
            this.nameLabel.AutoSize = true;
            this.nameLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nameLabel.Location = new System.Drawing.Point(84, 252);
            this.nameLabel.Name = "nameLabel";
            this.nameLabel.Size = new System.Drawing.Size(162, 20);
            this.nameLabel.TabIndex = 10;
            this.nameLabel.Text = "Enter command below:";
            // 
            // executeButton
            // 
            this.executeButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.executeButton.Location = new System.Drawing.Point(156, 342);
            this.executeButton.Name = "executeButton";
            this.executeButton.Size = new System.Drawing.Size(134, 78);
            this.executeButton.TabIndex = 1;
            this.executeButton.Text = "Execute";
            this.executeButton.UseVisualStyleBackColor = true;
            this.executeButton.Click += new System.EventHandler(this.executeButton_Click);
            // 
            // pInvInfoLabel
            // 
            this.pInvInfoLabel.AutoSize = true;
            this.pInvInfoLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.pInvInfoLabel.Location = new System.Drawing.Point(468, 21);
            this.pInvInfoLabel.Name = "pInvInfoLabel";
            this.pInvInfoLabel.Size = new System.Drawing.Size(126, 20);
            this.pInvInfoLabel.TabIndex = 14;
            this.pInvInfoLabel.Text = "Player\'s Inventory:";
            // 
            // playerInvLabel
            // 
            this.playerInvLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.playerInvLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.playerInvLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.playerInvLabel.Location = new System.Drawing.Point(468, 51);
            this.playerInvLabel.Name = "playerInvLabel";
            this.playerInvLabel.Size = new System.Drawing.Size(217, 149);
            this.playerInvLabel.TabIndex = 13;
            this.playerInvLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // locInvInfoLabel
            // 
            this.locInvInfoLabel.AutoSize = true;
            this.locInvInfoLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.locInvInfoLabel.Location = new System.Drawing.Point(468, 227);
            this.locInvInfoLabel.Name = "locInvInfoLabel";
            this.locInvInfoLabel.Size = new System.Drawing.Size(158, 20);
            this.locInvInfoLabel.TabIndex = 18;
            this.locInvInfoLabel.Text = "Location\'s Description:";
            // 
            // locationInvLabel
            // 
            this.locationInvLabel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.locationInvLabel.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.locationInvLabel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.locationInvLabel.Location = new System.Drawing.Point(468, 257);
            this.locationInvLabel.Name = "locationInvLabel";
            this.locationInvLabel.Size = new System.Drawing.Size(217, 224);
            this.locationInvLabel.TabIndex = 17;
            this.locationInvLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(713, 507);
            this.Controls.Add(this.locInvInfoLabel);
            this.Controls.Add(this.locationInvLabel);
            this.Controls.Add(this.pInvInfoLabel);
            this.Controls.Add(this.playerInvLabel);
            this.Controls.Add(this.executeButton);
            this.Controls.Add(this.nameLabel);
            this.Controls.Add(this.commandTextBox);
            this.Controls.Add(this.outputLabel);
            this.Name = "Form2";
            this.Text = "Form2";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form2_FormClosed);
            this.Load += new System.EventHandler(this.Form2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label outputLabel;
        private System.Windows.Forms.TextBox commandTextBox;
        private System.Windows.Forms.Label nameLabel;
        private System.Windows.Forms.Button executeButton;
        private System.Windows.Forms.Label pInvInfoLabel;
        private System.Windows.Forms.Label playerInvLabel;
        private System.Windows.Forms.Label locInvInfoLabel;
        private System.Windows.Forms.Label locationInvLabel;
    }
}