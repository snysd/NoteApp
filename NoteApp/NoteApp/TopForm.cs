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
    public partial class TopForm : Form
    {
        NoteService noteService = new NoteService();
        public TopForm()
        {
            InitializeComponent();
        }
        private void InitializeListView()
        {
            // ListViewコントロールのプロパティを設定
            listViewNote.FullRowSelect = true;
            listViewNote.GridLines = true;
            listViewNote.Sorting = SortOrder.Ascending;
            listViewNote.View = View.Details;

            // 列（コラム）ヘッダの作成
            var columnTitle = new ColumnHeader();
            var columnDate = new ColumnHeader();
            var columnUser = new ColumnHeader();
            var columnData = new ColumnHeader();
            columnTitle.Text = "タイトル";
            columnTitle.Width = 150;
            columnDate.Text = "更新日時";
            columnDate.Width = 100;
            columnUser.Text = "作成者";
            columnUser.Width = 100;
            columnData.Text = "本文";
            columnData.Width = 300;
            ColumnHeader[] colHeaderRegValue =
              {columnTitle,columnDate,columnUser,columnData };
            listViewNote.Columns.AddRange(colHeaderRegValue);
        }
        private void RefreshListView()
        {
            // ListViewコントロールのデータをすべて消去します。
            listViewNote.Items.Clear();
            var notes = noteService.notes;
            foreach (var note in notes)
            {
                // ToDo 「…」入れるようにする。
                string[] item = { note.title, note.date,note.user,note.body.Substring(0,15) };
                listViewNote.Items.Add(new ListViewItem(item));
            }
        }

        private void TopForm_Load(object sender, EventArgs e)
        {
            InitializeListView();
            RefreshListView();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm(true);
            addEditForm.FormClosed += (closedSender, closedE) =>
            {
                // ✕ボタンでEditFormが終了される可能性がある
                if (addEditForm.currentTargetNote == null) return;
                // AddEditFormから追加対象のNoteを取得
                var note = addEditForm.currentTargetNote;
                // NoteServiceに追加依頼
                noteService.AddNote(note);
                // ListViewの更新
                RefreshListView();
            };

            addEditForm.ShowDialog();
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm(false);
            
            // 編集対象は選択されている最初のタスク
            ListViewItem itemx = listViewNote.SelectedItems[0];

            // 選択されているタスクをID検索
            var matchedTask = noteService.GetNoteByName(itemx.Text);       // for explain: port to service class
            if (matchedTask == null) return;
            addEditForm.currentTargetNote = matchedTask;

            //addEditForm.FormClosed += (closedSender, closedE) =>
            //{
            //    // ✕ボタンでEditFormが終了される可能性がある
            //    if (addEditForm.note == null) return;
            //    // AddEditFormから追加対象のNoteを取得
            //    var note = addEditForm.note;
            //    // NoteServiceに追加依頼
            //    noteService.AddNote(note);
            //    // ListViewの更新
            //    RefreshListView();
            //};

            addEditForm.ShowDialog();
        }
    }
}