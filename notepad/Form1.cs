using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace notepad
{
    public partial class Notepad : Form
    {
        public string nameOfFile;
        public string pathOfFile;

        public Notepad()
        {
            InitializeComponent();
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_interface.Clear();
            pathOfFile = "";
            this.Text = " - Notepad";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog open = new OpenFileDialog();
            if(open.ShowDialog() == DialogResult.OK){
                notepad_interface.LoadFile(open.FileName, RichTextBoxStreamType.PlainText);
            }
            nameOfFile = System.IO.Path.GetFileNameWithoutExtension(open.FileName);
            pathOfFile = open.FileName;
            this.Text = nameOfFile + " - Notepad";
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.Filter = "text Document(*.txt)|*.txt|All Files(*.*)|*.*";
            if(save.ShowDialog() == DialogResult.OK){
                notepad_interface.SaveFile(save.FileName, RichTextBoxStreamType.PlainText);
            }
            nameOfFile = System.IO.Path.GetFileNameWithoutExtension(save.FileName);
            this.Text = nameOfFile + " - Notepad";
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(pathOfFile)){
                this.saveAsToolStripMenuItem_Click(sender, e);
            }else{
                notepad_interface.SaveFile(pathOfFile, RichTextBoxStreamType.PlainText);
                nameOfFile = System.IO.Path.GetFileNameWithoutExtension(pathOfFile);
                this.Text = nameOfFile + " - Notepad";
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult close = MessageBox.Show("Do you want to exit", "?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
            if(close == DialogResult.Yes){ 
                Application.Exit();
            }
            else if(close == DialogResult.Cancel){ 
                return; 
            }
        }

        private void fontToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FontDialog font = new FontDialog();
            font.Font = notepad_interface.SelectionFont;
            if (font.ShowDialog() == DialogResult.OK){
                notepad_interface.SelectionFont = font.Font;
            }
        }

        private void backgroundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ColorDialog backgroundColor = new ColorDialog();
            if (backgroundColor.ShowDialog() == DialogResult.OK){
                notepad_interface.BackColor = backgroundColor.Color;
            }
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("1.0\nCreated By John Smith\nPublished Sept 22, 2015");
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_interface.Cut();
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_interface.Copy();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_interface.Paste();
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_interface.Undo();
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notepad_interface.Redo();
        }
    }
}
