using System.Windows.Forms;

namespace XShort
{
    public partial class ProgressForm : Form
    {
        bool close = false;
        public ProgressForm()
        {
            InitializeComponent();
            circularProgressBar1.Text = "Loading...";

        }


        public void changeDisplay(int phase)
        {
            if (phase == 1)
            {

                circularProgressBar1.Text = "Loading name";

            }
            else if (phase == 2)
            {

                circularProgressBar1.Text = "Loading path";

            }
            else if (phase == 3)
            {

                circularProgressBar1.Text = "Loading para";

            }
            else if (phase == 4)
            {

                circularProgressBar1.Text = "Saving...";

            }
            else if (phase == 5)
            {

                circularProgressBar1.Text = "Scanning...";

            }
            else if (phase == 6)
            {

                circularProgressBar1.Text = "Checking...";

            }
        }

        public void closeForm()
        {
            close = true;
            this.Close();
            this.Dispose();
        }

        private void Form3_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close != true)
            {
                e.Cancel = true;
                return;
            }
        }
    }
}
