using System;
using System.Windows.Forms;

namespace VAPW_zkouska
{
    public partial class Form2 : Form
    {
        private Form1 mainForm;
        private int playerIndex;

        public Form2(Form1 mainForm, int playerIndex)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.playerIndex = playerIndex;
            textBox1.Text = $"Hráč {playerIndex}";
            textBox1.TextChanged += textBox1_TextChanged;
            //button1.Click += stopButton_Click;
        }

        // aktualizace jmena hrace
        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            mainForm.AktualizaceJmenaHrace(playerIndex - 1, textBox1.Text);
        }

        // STOP
        private void stopButton_Click(object sender, EventArgs e)
        {
            mainForm.HracStopka(playerIndex - 1);
        }

        // zavreni formulare
        protected override void OnFormClosed(FormClosedEventArgs e)
        {
            mainForm.OdstraneniHrace(this);
            base.OnFormClosed(e);
        }

        public void AktualizaceCiselPanelHrace(string text1, string text2, string text3)
        {
            label2.Text = text1;
            label3.Text = text2;
            label4.Text = text3;
        }

    }
}
