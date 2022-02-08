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
using static System.Windows.Forms.ListView;
using NoteApp.Models;
using System.IO;
using NoteApp.UtilityClasses;
using MetroFramework.Forms;

namespace NoteApp
{
    public partial class TopForm : MetroForm
    {
        NoteService noteService = new NoteService();
        private ListViewColumnSorter _columnSorter;

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
                string dispBody = note.body.Length > 15 ? note.body.Substring(0, 15) : note.body;
                string[] item = { note.title, note.date,note.user,dispBody}; 
                listViewNote.Items.Add(new ListViewItem(item));
            }
        }

        private void TopForm_Load(object sender, EventArgs e)
        {
            _columnSorter = new ListViewColumnSorter();
            listViewNote.ListViewItemSorter = _columnSorter;

            InitializeListView();
            RefreshListView();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            AddEditForm addEditForm = new AddEditForm(true,noteService);
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
            // 選択しているタスクがなかったら何もしない
            if (listViewNote.SelectedItems.Count == 0) return;

            AddEditForm addEditForm = new AddEditForm(false, noteService);
            
            // 編集対象は選択されている最初のタスク
            ListViewItem itemx = listViewNote.SelectedItems[0];

            // 選択されている行の名前検索
            var matchedNote = noteService.GetNoteByName(itemx.Text);       // for explain: port to service class
            if (matchedNote == null) return;
            addEditForm.currentTargetNote = matchedNote;

            addEditForm.FormClosed += (closedSender, closedE) =>
            {
                // ✕ボタンでEditFormが終了される可能性がある
                if (addEditForm.currentTargetNote == null) return;
                // AddEditFormから追加対象のNoteを取得
                var note = addEditForm.currentTargetNote;
                // NoteServiceに更新依頼
                noteService.UpdateNote(note);
                // ListViewの更新
                RefreshListView();
            };

            addEditForm.ShowDialog();
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // If no selected, do nothing.
            if (listViewNote.SelectedItems.Count == 0) return;

            // create target note for remove
            SelectedListViewItemCollection selectedItems = listViewNote.SelectedItems;
            List<string> targetNames = new List<string>();
            string dispStr = "";
            foreach (ListViewItem item in selectedItems)
            {
                targetNames.Add(item.Text);
                dispStr = dispStr + "・" + item.Text + $"\n";
            }
            DialogResult result = MessageBox.Show(
                $"以下のメモを削除しますか？\n{dispStr}",
                "確認",
                MessageBoxButtons.OKCancel,
                MessageBoxIcon.Question
            );
            if (result == DialogResult.Cancel) return;

            var targetNotes = noteService.GetNotesByNames(targetNames);
            if (targetNotes == null || targetNotes.Count == 0) return;
            // get remove notes
            noteService.RemoveNotes(targetNotes);
            RefreshListView();
        }

        private void buttonExport_Click(object sender, EventArgs e)
        {
            // 選択しているタスクがなかったら何もしない
            if (listViewNote.SelectedItems.Count == 0) return;

            // 編集対象は選択されている最初のタスク
            ListViewItem itemx = listViewNote.SelectedItems[0];

            // 選択されている行の名前検索
            var matchedNote = noteService.GetNoteByName(itemx.Text);       // for explain: port to service class
            if (matchedNote == null) return;
            SaveFile(matchedNote);

        }

        private void SaveFile(Note matchedNote)
        {
            //SaveFileDialogクラスのインスタンスを作成
            SaveFileDialog sfd = new SaveFileDialog();
            //はじめに「ファイル名」で表示される文字列を指定する
            sfd.FileName = $"{matchedNote.title}.txt";
            //はじめに表示されるフォルダを指定する
            sfd.InitialDirectory = @"C:\";
            //[ファイルの種類]に表示される選択肢を指定する
            //指定しない（空の文字列）の時は、現在のディレクトリが表示される
            sfd.Filter = "テキスト ファイル (*.txt)|*.txt|すべてのファイル (*.*)|*.*";
            //タイトルを設定する
            sfd.Title = "保存先のファイルを選択してください";
            //ダイアログボックスを閉じる前に現在のディレクトリを復元するようにする
            sfd.RestoreDirectory = true;

            //ダイアログを表示する
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                File.WriteAllText(sfd.FileName, matchedNote.body);
            }
        }

        private void listViewNote_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (e.Column == _columnSorter.SortColumn)
            {
                if (_columnSorter.Order == SortOrder.Ascending)
                {
                    _columnSorter.Order = SortOrder.Descending;
                }
                else
                {
                    _columnSorter.Order = SortOrder.Ascending;
                }
            }
            else
            {
                _columnSorter.SortColumn = e.Column;
                _columnSorter.Order = SortOrder.Ascending;
            }
            listViewNote.Sort();
        }
    }
}