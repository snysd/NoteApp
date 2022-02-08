
namespace NoteApp
{
    partial class TopForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.listViewNote = new MetroFramework.Controls.MetroListView();
            this.buttonAdd = new MetroFramework.Controls.MetroButton();
            this.buttonEdit = new MetroFramework.Controls.MetroButton();
            this.buttonDelete = new MetroFramework.Controls.MetroButton();
            this.buttonExport = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // listViewNote
            // 
            this.listViewNote.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.listViewNote.FullRowSelect = true;
            this.listViewNote.HideSelection = false;
            this.listViewNote.Location = new System.Drawing.Point(12, 78);
            this.listViewNote.Name = "listViewNote";
            this.listViewNote.OwnerDraw = true;
            this.listViewNote.Size = new System.Drawing.Size(776, 308);
            this.listViewNote.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.listViewNote.TabIndex = 0;
            this.listViewNote.UseCompatibleStateImageBehavior = false;
            this.listViewNote.UseSelectable = true;
            this.listViewNote.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listViewNote_ColumnClick);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(12, 404);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(93, 39);
            this.buttonAdd.TabIndex = 1;
            this.buttonAdd.Text = "新規";
            this.buttonAdd.UseSelectable = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonEdit
            // 
            this.buttonEdit.Location = new System.Drawing.Point(121, 404);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(90, 39);
            this.buttonEdit.TabIndex = 2;
            this.buttonEdit.Text = "編集";
            this.buttonEdit.UseSelectable = true;
            this.buttonEdit.Click += new System.EventHandler(this.buttonEdit_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(226, 404);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(87, 39);
            this.buttonDelete.TabIndex = 3;
            this.buttonDelete.Text = "削除";
            this.buttonDelete.UseSelectable = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonExport
            // 
            this.buttonExport.Location = new System.Drawing.Point(330, 404);
            this.buttonExport.Name = "buttonExport";
            this.buttonExport.Size = new System.Drawing.Size(85, 39);
            this.buttonExport.TabIndex = 4;
            this.buttonExport.Text = "出力";
            this.buttonExport.UseSelectable = true;
            this.buttonExport.Click += new System.EventHandler(this.buttonExport_Click);
            // 
            // TopForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(803, 466);
            this.Controls.Add(this.buttonExport);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.listViewNote);
            this.Name = "TopForm";
            this.Text = "NoteApp";
            this.Load += new System.EventHandler(this.TopForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroListView listViewNote;
        private MetroFramework.Controls.MetroButton buttonAdd;
        private MetroFramework.Controls.MetroButton buttonEdit;
        private MetroFramework.Controls.MetroButton buttonDelete;
        private MetroFramework.Controls.MetroButton buttonExport;
    }
}

