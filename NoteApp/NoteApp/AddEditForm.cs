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
        public Note currentTargetNote;
        public AddEditForm(bool addMode)
        {
            this.addMode = addMode;
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            currentTargetNote = new Note();
            currentTargetNote.title = textBoxTitle.Text;
            currentTargetNote.date = DateTime.Now.ToString();
            currentTargetNote.user = textBoxName.Text;
            currentTargetNote.body = textBoxBody.Text;
            this.Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AddEditForm_Load(object sender, EventArgs e)
        {
            if (addMode == false)
            {
                textBoxTitle.Text = currentTargetNote.title;
                textBoxName.Text = currentTargetNote.user;
                textBoxBody.Text = currentTargetNote.body;
                //初期値設定
            }
        }
    }
}
