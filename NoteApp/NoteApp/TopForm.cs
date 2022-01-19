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

            // ListViewコントロールにデータを追加します。
            string[] item1 = { "外郎売PT.1", "2022/01/01", "田中", "拙者親方と申すは、お立会いの内に" };
            listViewNote.Items.Add(new ListViewItem(item1));
            string[] item2 = { "外郎売PT.2", "2022/02/01", "加藤", "ご存じのお方もござりましょうが、" };
            listViewNote.Items.Add(new ListViewItem(item2));
            string[] item3 = { "外郎売PT.3", "2022/03/01", "佐藤", "お江戸をたってにじゅうりかみがた、" };
            listViewNote.Items.Add(new ListViewItem(item3));
        }

        private void TopForm_Load(object sender, EventArgs e)
        {
            InitializeListView();
            RefreshListView();
        }
    }
}