
namespace ATM_Project
{
    partial class Dashboard
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
            this.btnCashWithdraw = new System.Windows.Forms.Button();
            this.btnTransferMoney = new System.Windows.Forms.Button();
            this.btnBalanceInquiry = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnMiniStatement = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pbReturnCard = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReturnCard)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCashWithdraw
            // 
            this.btnCashWithdraw.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCashWithdraw.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCashWithdraw.Font = new System.Drawing.Font("Futura Bk BT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCashWithdraw.ForeColor = System.Drawing.Color.White;
            this.btnCashWithdraw.Location = new System.Drawing.Point(373, 246);
            this.btnCashWithdraw.Name = "btnCashWithdraw";
            this.btnCashWithdraw.Size = new System.Drawing.Size(198, 190);
            this.btnCashWithdraw.TabIndex = 6;
            this.btnCashWithdraw.Text = "Cash Withdraw";
            this.btnCashWithdraw.UseVisualStyleBackColor = false;
            this.btnCashWithdraw.Click += new System.EventHandler(this.button7_Click);
            // 
            // btnTransferMoney
            // 
            this.btnTransferMoney.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnTransferMoney.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnTransferMoney.Font = new System.Drawing.Font("Futura Bk BT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferMoney.ForeColor = System.Drawing.Color.White;
            this.btnTransferMoney.Location = new System.Drawing.Point(577, 246);
            this.btnTransferMoney.Name = "btnTransferMoney";
            this.btnTransferMoney.Size = new System.Drawing.Size(198, 190);
            this.btnTransferMoney.TabIndex = 6;
            this.btnTransferMoney.Text = "Transfer Money";
            this.btnTransferMoney.UseVisualStyleBackColor = false;
            this.btnTransferMoney.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnBalanceInquiry
            // 
            this.btnBalanceInquiry.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnBalanceInquiry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBalanceInquiry.Font = new System.Drawing.Font("Futura Bk BT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBalanceInquiry.ForeColor = System.Drawing.Color.White;
            this.btnBalanceInquiry.Location = new System.Drawing.Point(169, 246);
            this.btnBalanceInquiry.Name = "btnBalanceInquiry";
            this.btnBalanceInquiry.Size = new System.Drawing.Size(198, 190);
            this.btnBalanceInquiry.TabIndex = 6;
            this.btnBalanceInquiry.Text = "Balance Inquiry";
            this.btnBalanceInquiry.UseVisualStyleBackColor = false;
            this.btnBalanceInquiry.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Futura Bk BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(161, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(251, 45);
            this.label3.TabIndex = 7;
            this.label3.Text = "Select Service";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Futura Bk BT", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(929, 583);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(227, 45);
            this.label1.TabIndex = 7;
            this.label1.Text = "Return Card";
            // 
            // btnMiniStatement
            // 
            this.btnMiniStatement.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnMiniStatement.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnMiniStatement.Font = new System.Drawing.Font("Futura Bk BT", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMiniStatement.ForeColor = System.Drawing.Color.White;
            this.btnMiniStatement.Location = new System.Drawing.Point(781, 246);
            this.btnMiniStatement.Name = "btnMiniStatement";
            this.btnMiniStatement.Size = new System.Drawing.Size(198, 190);
            this.btnMiniStatement.TabIndex = 6;
            this.btnMiniStatement.Text = "Mini Statements";
            this.btnMiniStatement.UseVisualStyleBackColor = false;
            this.btnMiniStatement.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ATM_Project.Properties.Resources.bb1;
            this.pictureBox2.Location = new System.Drawing.Point(996, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(176, 69);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pbReturnCard
            // 
            this.pbReturnCard.Image = global::ATM_Project.Properties.Resources.takeout;
            this.pbReturnCard.Location = new System.Drawing.Point(853, 569);
            this.pbReturnCard.Name = "pbReturnCard";
            this.pbReturnCard.Size = new System.Drawing.Size(70, 70);
            this.pbReturnCard.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbReturnCard.TabIndex = 8;
            this.pbReturnCard.TabStop = false;
            this.pbReturnCard.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Dashboard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.CornflowerBlue;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pbReturnCard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnBalanceInquiry);
            this.Controls.Add(this.btnMiniStatement);
            this.Controls.Add(this.btnTransferMoney);
            this.Controls.Add(this.btnCashWithdraw);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbReturnCard)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCashWithdraw;
        private System.Windows.Forms.Button btnTransferMoney;
        private System.Windows.Forms.Button btnBalanceInquiry;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbReturnCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnMiniStatement;
    }
}