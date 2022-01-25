using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteApp
{
    public partial class AddEditForm : Form
    {
        bool addMode;
        public Note note;
        public AddEditForm(bool addMode)
        {
            this.addMode = addMode;
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            note = new Note();
            note.title = textBoxTitle.Text;
            note.date = DateTime.Now.ToString();
            note.user = textBoxName.Text;
            note.body = textBoxBody.Text;
            this.Close();
        }
    }
}
