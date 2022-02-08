﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NoteApp.UtilityClasses
{
    public class ListViewColumnSorter : IComparer
    {
        #region フィールド
        /// <summary>
        　　/// ソート対象列
        　　/// </summary>
        private int _columnToSort;
        /// <summary>
        　　/// ソートオーダー
        　　/// </summary>
        private SortOrder _orderOfSort;
        /// <summary>
        　　/// 比較オブジェクト
        　　/// </summary>
        private CaseInsensitiveComparer _objectCompare;
        #endregion



        #region プロパティ
        /// <summary>
        　　/// ソート対象列
        　　/// </summary>
        public int SortColumn
        {
            get { return _columnToSort; }
            set { _columnToSort = value; }
        }
        /// <summary>
        　　/// ソートオーダー
        　　/// </summary>
        public SortOrder Order
        {
            get { return _orderOfSort; }
            set { _orderOfSort = value; }
        }
        #endregion

        #region メソッド
        /// <summary>
        　　/// コンストラクタ
        　　/// </summary>
        public ListViewColumnSorter()
        {
            _orderOfSort = SortOrder.None;
            _objectCompare = new CaseInsensitiveComparer(CultureInfo.CurrentUICulture);
        }

        /// <summary>
        　　/// IComparerインターフェース実装
        　　/// </summary>
        　　/// <param name="x"></param>
        　　/// <param name="y"></param>
        　　/// <returns></returns>
        public int Compare(object x, object y)
        {
            int result = 0;
            ListViewItem listViewX = x as ListViewItem;
            ListViewItem listViewY = y as ListViewItem;

            result = _objectCompare.Compare(
            listViewX.SubItems[_columnToSort].Text, listViewY.SubItems[_columnToSort].Text);

            if (_orderOfSort == SortOrder.Ascending)
            {
                return result;
            }
            else if (_orderOfSort == SortOrder.Descending)
            {
                return (-result);
            }
            else
            {
                return 0;
            }
        }
        #endregion
    }
}
