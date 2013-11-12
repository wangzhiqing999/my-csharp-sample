namespace G0071_BlackJack.App
{
    partial class FormOnePlayer
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
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnHit = new System.Windows.Forms.Button();
            this.btnStand = new System.Windows.Forms.Button();
            this.pnlCards = new System.Windows.Forms.Panel();
            this.tlpUser = new System.Windows.Forms.TableLayoutPanel();
            this.tlpComputer = new System.Windows.Forms.TableLayoutPanel();
            this.lblResult = new System.Windows.Forms.Label();
            this.tlpMain.SuspendLayout();
            this.pnlCards.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 4;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpMain.Controls.Add(this.tlpComputer, 0, 0);
            this.tlpMain.Controls.Add(this.btnStart, 0, 2);
            this.tlpMain.Controls.Add(this.btnHit, 1, 2);
            this.tlpMain.Controls.Add(this.btnStand, 2, 2);
            this.tlpMain.Controls.Add(this.pnlCards, 3, 0);
            this.tlpMain.Controls.Add(this.tlpUser, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpMain.Size = new System.Drawing.Size(608, 357);
            this.tlpMain.TabIndex = 0;
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.Location = new System.Drawing.Point(38, 315);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始游戏";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnHit
            // 
            this.btnHit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnHit.Location = new System.Drawing.Point(190, 315);
            this.btnHit.Name = "btnHit";
            this.btnHit.Size = new System.Drawing.Size(75, 23);
            this.btnHit.TabIndex = 3;
            this.btnHit.Text = "要牌";
            this.btnHit.UseVisualStyleBackColor = true;
            this.btnHit.Visible = false;
            this.btnHit.Click += new System.EventHandler(this.btnHit_Click);
            // 
            // btnStand
            // 
            this.btnStand.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStand.Location = new System.Drawing.Point(342, 315);
            this.btnStand.Name = "btnStand";
            this.btnStand.Size = new System.Drawing.Size(75, 23);
            this.btnStand.TabIndex = 4;
            this.btnStand.Text = "停止要牌";
            this.btnStand.UseVisualStyleBackColor = true;
            this.btnStand.Visible = false;
            this.btnStand.Click += new System.EventHandler(this.btnStand_Click);
            // 
            // pnlCards
            // 
            this.pnlCards.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pnlCards.Controls.Add(this.lblResult);
            this.pnlCards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlCards.Location = new System.Drawing.Point(459, 3);
            this.pnlCards.Name = "pnlCards";
            this.tlpMain.SetRowSpan(this.pnlCards, 2);
            this.pnlCards.Size = new System.Drawing.Size(146, 290);
            this.pnlCards.TabIndex = 6;
            // 
            // tlpUser
            // 
            this.tlpUser.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpUser.ColumnCount = 5;
            this.tlpMain.SetColumnSpan(this.tlpUser, 3);
            this.tlpUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpUser.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpUser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpUser.Location = new System.Drawing.Point(3, 151);
            this.tlpUser.Name = "tlpUser";
            this.tlpUser.RowCount = 1;
            this.tlpUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpUser.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpUser.Size = new System.Drawing.Size(450, 142);
            this.tlpUser.TabIndex = 7;
            // 
            // tlpComputer
            // 
            this.tlpComputer.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Inset;
            this.tlpComputer.ColumnCount = 5;
            this.tlpMain.SetColumnSpan(this.tlpComputer, 3);
            this.tlpComputer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpComputer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpComputer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpComputer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpComputer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpComputer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpComputer.Location = new System.Drawing.Point(3, 3);
            this.tlpComputer.Name = "tlpComputer";
            this.tlpComputer.RowCount = 1;
            this.tlpComputer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpComputer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpComputer.Size = new System.Drawing.Size(450, 142);
            this.tlpComputer.TabIndex = 8;
            // 
            // lblResult
            // 
            this.lblResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblResult.Location = new System.Drawing.Point(0, 0);
            this.lblResult.Name = "lblResult";
            this.lblResult.Size = new System.Drawing.Size(142, 286);
            this.lblResult.TabIndex = 0;
            this.lblResult.Text = "-";
            this.lblResult.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormOnePlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(608, 357);
            this.Controls.Add(this.tlpMain);
            this.Name = "FormOnePlayer";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "单人游戏";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormOnePlayer_FormClosing);
            this.Load += new System.EventHandler(this.FormOnePlayer_Load);
            this.tlpMain.ResumeLayout(false);
            this.pnlCards.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Button btnHit;
        private System.Windows.Forms.Button btnStand;
        private System.Windows.Forms.Panel pnlCards;
        private System.Windows.Forms.TableLayoutPanel tlpUser;
        private System.Windows.Forms.TableLayoutPanel tlpComputer;
        private System.Windows.Forms.Label lblResult;
    }
}