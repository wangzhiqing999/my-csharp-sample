namespace A5010_WinPopForm.Sample
{
    partial class PopForm
    {

        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }




        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.moveTimer = new System.Windows.Forms.Timer(this.components);
            this.stopTimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            //  
            // moveTimer 
            //  
            this.moveTimer.Interval = 1;
            this.moveTimer.Tick += new System.EventHandler(this.moveTimer_Tick);
            //  
            // stopTimer 
            //  
            this.stopTimer.Interval = 2000;
            this.stopTimer.Tick += new System.EventHandler(this.stopTimer_Tick);
            //  
            // popForm 
            //  
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(243, 189);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "popForm";
            this.ShowInTaskbar = false;
            this.Text = "TaskbarForm";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PopForm_MouseMove);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PopForm_MouseDown);
            this.ResumeLayout(false);

        }

  

        private System.Windows.Forms.Timer moveTimer;
        private System.Windows.Forms.Timer stopTimer; 

    }
}