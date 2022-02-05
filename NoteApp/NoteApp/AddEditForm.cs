using NoteApp.Models;
using NoteApp.Services;
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
        NoteService noteService;
        public Note currentTargetNote;
        public AddEditForm(bool addMode, NoteService noteService)
        {
            this.addMode = addMode;
            this.noteService = noteService;
            InitializeComponent();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            List<TextBox> contents = new List<TextBox>() { textBoxTitle, textBoxName, textBoxBody };
            foreach(var content in contents)
            {
                if( content.Text == "" )
                {
                    MessageBox.Show(
                        "全ての入力欄を記述してください", 
                        "エラー",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error
                    );
                    return;
                }
            }
            // 同じ名前のNoteを作成させない
            if (addMode == true)
            {
                if (IsShowSameNameFileError() == true) return;
            }
            else
            {
                if (currentTargetNote.title != textBoxTitle.Text)
                {
                    if (IsShowSameNameFileError() == true) return;
                }
            }
            if (addMode == true) currentTargetNote = new Note();
            currentTargetNote.title = textBoxTitle.Text;
            currentTargetNote.date = DateTime.Now.ToString();
            currentTargetNote.user = textBoxName.Text;
            currentTargetNote.body = textBoxBody.Text;
            this.Close();
        }

        private bool IsShowSameNameFileError()
        {
            if (noteService.GetNoteByName(textBoxTitle.Text) != null)
            {
                MessageBox.Show(
                    "同じ名前のメモは作成できません",
                    "エラー",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                return true;
            }
            return false;
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
