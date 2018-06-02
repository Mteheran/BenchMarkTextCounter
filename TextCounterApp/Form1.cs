using System;
using System.Windows.Forms;
using TextCounterLibrary;

namespace TextCounterApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();

            openFileDialog.Multiselect = false;

            openFileDialog.Filter = "*.txt|*.txt";

            openFileDialog.ShowDialog();

            textBox1.Text = openFileDialog.FileName;

            ITextCounterManager ITextManager = new TextCounterManager();

            var result = ITextManager.ProcessFile(textBox1.Text);

            listBox1.Items.Add(textBox1.Text  + " - " + result);

        }
    }
}
