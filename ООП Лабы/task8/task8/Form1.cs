using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task8
{
    public partial class Form1 : Form
    {
        Student[] collection=null;
        int size=10;
        public Form1()
        {
            InitializeComponent();
        }

        void ClearRichTextBox()
        {
            richTextBox1.Text = "";
        }
        void ShowCollection()
        {
            foreach(Student s in collection)
            {
                richTextBox1.Text += s.ToString() + "\n";
            }

        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void создатьДСЧToolStripMenuItem_Click(object sender, EventArgs e)
        {
            collection=Controller.MakeCollection(size);
            ShowCollection();
            изменитьToolStripMenuItem.Enabled = true;
            удалитьToolStripMenuItem.Enabled = true;
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            int number = (int)numericUpDown1.Value;
            collection = Controller.RemoveCollection(collection, number);
            numericUpDown1.Maximum = collection.Length;
            ClearRichTextBox();
            ShowCollection();
        }
    }
}
