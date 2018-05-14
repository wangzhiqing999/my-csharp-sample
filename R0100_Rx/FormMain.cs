using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using R0100_Rx.UI;
using R0100_Rx.UI2;


namespace R0100_Rx
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }


        private void newObservableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormNewObservable();
            subForm.MdiParent = this;
            subForm.Show();
        }


        private void subscribeOnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormSubscribeOn();
            subForm.MdiParent = this;
            subForm.Show();
        }


        private void mergeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormMerge();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void combineLatestToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormCombineLatest();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void zipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormZip();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void ambToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormAmb();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void takeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormTake();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void takeWhileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormTakeWhile();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void takeUntilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormTakeUntil();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void skipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormSkip();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void skipWhileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormSkipWhile();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void skipUntilToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormSkipUntil();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void whereToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormWhere();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void allToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormAll();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void anyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormAny();
            subForm.MdiParent = this;
            subForm.Show();
        }


        private void helloWorldToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormHelloWorld();
            subForm.MdiParent = this;
            subForm.Show();
        }


        private void newObservablePlusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormNewObservablePlus();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void transformingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormTransforming();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void filteringToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormFiltering();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void combiningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormCombining();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void errorHandlingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormErrorHandling();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void utilityOperatorsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormUtilityOperators();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void conditionalAndBooleanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormConditionalAndBoolean();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void mathematicalAndAggregateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormMathematicalAndAggregate();
            subForm.MdiParent = this;
            subForm.Show();
        }

        private void connectableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var subForm = new FormConnectable();
            subForm.MdiParent = this;
            subForm.Show();
        }






    }
}
