using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Timers;

namespace VAPW_zkouska
{
    public partial class Form1 : Form
    {
        // seznam hracu
        private List<Hrac> players = new List<Hrac>();

        // generator nahodnych cisel
        private Random random = new Random();

        // timer pro zmenu cisla
        private System.Timers.Timer timer1, timer2, timer3;

        // aktualni cisla
        private int[] noveCislaRandom = new int[3];

        public Form1()
        {
            InitializeComponent();

            // timery
            timer1 = new System.Timers.Timer();
            timer2 = new System.Timers.Timer();
            timer3 = new System.Timers.Timer();

            // pri ubehnuti timeru se vygeneruje nove cislo
            timer1.Elapsed += (sender, e) => ZmenaCisel(0);
            timer2.Elapsed += (sender, e) => ZmenaCisel(1);
            timer3.Elapsed += (sender, e) => ZmenaCisel(2);

            // nastavení intervalu z numbericUpDown
            timer1.Interval = (int)numericUpDown1.Value;
            timer2.Interval = (int)numericUpDown2.Value;
            timer3.Interval = (int)numericUpDown3.Value;
        }

        // pri nacteni formulare se spusti timery
        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer2.Start();
            timer3.Start();
        }

        // inicializace hry
        private void InitializeGame()
        {
            // mnozstvi hracu z numericUpDown
            int playerCount = (int)numericUpDown4.Value;

            // vytvoreni hracu & zobrazeni jejich ovladani
            for (int i = 0; i < playerCount; i++)
            {   
                Form2 playerForm = new Form2(this, i + 1);
                playerForm.Show();
                players.Add(new Hrac { Form = playerForm, Skore = 0, Jmeno = $"Hráč {i + 1}" });
                listBox1.Items.Add($"Hráč {i + 1} - Skóre: 0");
                //players = players.OrderByDescending(player => player.Score).ToList();
            }

        }

        // zmena cisla
        private void ZmenaCisel(int index)
        {
            if (InvokeRequired)
            {
                Invoke(new Action<int>(ZmenaCisel), index);
                return;
            }

            noveCislaRandom[index] = random.Next(1, 4);
            switch (index)
            {
                case 0:
                    label1.Text = noveCislaRandom[index].ToString();
                    break;
                case 1:
                    label2.Text = noveCislaRandom[index].ToString();
                    break;
                case 2:
                    label3.Text = noveCislaRandom[index].ToString();
                    break;
            }

            // zmena cisel ve Form2 v labelech
            foreach (Form form in Application.OpenForms)
            {
                if (form is Form2 playerForm)
                {
                    playerForm.AktualizaceCiselPanelHrace(label1.Text, label2.Text, label3.Text);
                }
            }
        }

        // trida hrace
        public class Hrac
        {
            public Form2 Form { get; set; }
            public int Skore { get; set; }
            public string Jmeno { get; set; }
        }

        // event handler pro zmenu hodnoty numericUpDown
        private void NumericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            timer1.Interval = (double)numericUpDown1.Value;
        }

        private void NumericUpDown2_ValueChanged(object sender, EventArgs e)
        {
            timer2.Interval = (double)numericUpDown2.Value;
        }

        private void NumericUpDown3_ValueChanged(object sender, EventArgs e)
        {
            timer3.Interval = (double)numericUpDown3.Value;
        }

        public void AktualizaceJmenaHrace(int index, string newName)
        {
            if (index >= 0 && index < players.Count)
            {
                players[index].Jmeno = newName;
                AktualizaceListBoxHracu();
            }
        }

        public void HracStopka(int index)
        {
            if (index >= 0 && index < players.Count)
            {
                if (noveCislaRandom[0] == noveCislaRandom[1] && noveCislaRandom[1] == noveCislaRandom[2])
                {
                    players[index].Skore++;
                }
                else
                {
                    players[index].Skore--;
                }
                AktualizaceListBoxHracu();
            }
        }

        private void AktualizaceListBoxHracu()
        {
            listBox1.Items.Clear();
            foreach (var player in players.OrderByDescending(x=>x.Skore))
            {
                listBox1.Items.Add($"{player.Jmeno} - Skóre: {player.Skore}");
            }
        }

        public void OdstraneniHrace(Form2 playerForm)
        {
            var playerToRemove = players.Find(p => p.Form == playerForm);
            if (playerToRemove != null)
            {
                players.Remove(playerToRemove);
                AktualizaceListBoxHracu();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }
    }
}
