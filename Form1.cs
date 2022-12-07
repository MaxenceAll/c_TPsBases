using System.Diagnostics;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace c_TPsBases
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int[] tabQ1 = new int[5];
        }
        private void button2_Click(object sender, EventArgs e)
        {
            char[] tabQ2 = new char[6];
            tabQ2[0] = 'a';            tabQ2[1] = 'e';
            tabQ2[2] = 'i';            tabQ2[3] = 'o';
            tabQ2[4] = 'u';            tabQ2[5] = 'y';
        }
        private void button3_Click(object sender, EventArgs e)
        {
            char[] tabQ3 = new char[6] { 'a', 'e', 'i', 'o', 'u', 'y' };
        }
        private void button4_Click(object sender, EventArgs e)
        {
            int[] tabQ4 = new int[6];
            tabQ4[0] = 1;            tabQ4[1] = 2;            tabQ4[2] = 3;            tabQ4[3] = 4;
            tabQ4[4] = 5;            tabQ4[5] = 6;            
        }
        private void button5_Click(object sender, EventArgs e)
        {
            int somme = 0;
            int[] tabQ5 = new int[6] {1,2,3,4,5,6};
            for ( int i = 0; i < 6; i++ )
            {
                somme += tabQ5[i];
            }
            MessageBox.Show(Convert.ToString(somme));
        }
        private void button6_Click(object sender, EventArgs e)
        {
            int i = 0;
            int somme = 0;
            int[] tabQ5 = new int[6] { 1, 2, 3, 4, 5, 6 };
            while(i < 6)
            {
                somme += tabQ5[i];
                i++;
            }
            MessageBox.Show(Convert.ToString(somme));
        }
        private void button7_Click(object sender, EventArgs e)
        {
            int i = 0;
            int somme = 0;
            int[] tabQ7 = new int[6] { 1, 2, 3, 4, 5, 6 };
            do
            {
                somme += tabQ7[i];
                i++;
            } while (i < 6);
            MessageBox.Show(Convert.ToString(somme));
        }

        private void button8_Click(object sender, EventArgs e)
        {
            int somme = 0;
            int[] tabQ8 = new int[6] { 1, 2, 3, 4, 5, 6 };
            foreach (int i in tabQ8)
            {
                somme += tabQ8[i];
            }
            MessageBox.Show(Convert.ToString(somme));
        }

        private void button9_Click(object sender, EventArgs e)
        {
            int somme = 0;
            int[] tabQ9 = new int[6] { 20, 20, 20, 10, 10, 10 };
            for (int i = 0; i < 6; i++)
            {
                somme += tabQ9[i];
            }
            MessageBox.Show(Convert.ToString(somme/tabQ9.Length));
        }

        private async void button10_Click(object sender, EventArgs e)
        {
            for (int i = 10; i >= 0; i--)
            {
                countDown.Text = Convert.ToString(i);
                await Task.Delay(1000);
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            int nombreNote = Convert.ToInt32( Prompt.ShowDialog("Nombre de notes ?", "Saisie nombre notes") );
            int[] notes = new int[nombreNote];
            int number;
            int somme=0;
            int noteMax = 0;
            int noteMin = -1;
            for (int i = 0 ; i < notes.Length; i++)
            {
                if (Int32.TryParse(Prompt.ShowDialog("Note " + i + "/" + nombreNote + " ?", "Saisie notes"), out number))
                {
                    notes[i] = number;
                    if (noteMin==-1) noteMin = number;
                }
                somme += notes[i];
                if (notes[i] > noteMax) { noteMax= notes[i]; }
                if (notes[i] < noteMin) { noteMin = notes[i]; }

            }
            MessageBox.Show("Moyenne = " + somme / notes.Length);
            MessageBox.Show("Note Maxi (method max() )= " + notes.Max());
            MessageBox.Show("Note Maxi (method for)= " + noteMax);
            MessageBox.Show("Note Mini (method min() )= " + notes.Min());
            MessageBox.Show("Note Mini (method for)= " + noteMin);

        }
        private void button12_Click(object sender, EventArgs e)
        {
            int nombreNote = saisieNotes.Lines.Count();
            int[] notes = new int[nombreNote];
            int number;
            int somme = 0;
            int noteMax = 0;
            int noteMin = -1;
            for (int i = 0; i < notes.Length; i++)
            {
                if (Int32.TryParse(saisieNotes.Lines[i], out number))
                {
                    notes[i] = number;
                    if (noteMin == -1) noteMin = number;
                }
                somme += notes[i];
                if (notes[i] > noteMax) { noteMax = notes[i]; }
                if (notes[i] < noteMin) { noteMin = notes[i]; }

            }
            MessageBox.Show("Moyenne = " + somme / notes.Length);
            MessageBox.Show("Note Maxi (method max() )= " + notes.Max());
            MessageBox.Show("Note Maxi (method for)= " + noteMax);
            MessageBox.Show("Note Mini (method min() )= " + notes.Min());
            MessageBox.Show("Note Mini (method for)= " + noteMin);

        }

        // Outils :
        public static class Prompt
        {
            public static string ShowDialog(string text, string caption)
            {
                Form prompt = new Form()
                {
                    Width = 500,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = caption,
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = text };
                System.Windows.Forms.TextBox textBox = new System.Windows.Forms.TextBox() { Left = 50, Top = 50, Width = 400 };
                System.Windows.Forms.Button confirmation = new System.Windows.Forms.Button() { Text = "Ok", Left = 350, Width = 100, Top = 70, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }
    }
}