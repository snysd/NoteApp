using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Services
{
    class NoteService
    {
        public List<Note> notes = new List<Note>();

        public NoteService()
        {

            string[] item1 = { "外郎売PT.1", "2022/01/01", "田中", "拙者親方と申すは、お立会いの内にうううううううううううううううううううううう" };
            string[] item2 = { "外郎売PT.2", "2022/02/01", "加藤", "ご存じのお方もござりましょうが、いいいいいいいいいいいいいいいいいいいいいいい" };
            string[] item3 = { "外郎売PT.3", "2022/03/01", "佐藤", "お江戸をたってにじゅうりかみがた、あああああああああああああああああああああああ" };
            List<string[]> items = new List<string[]>();
            items.Add(item1);
            items.Add(item2);
            items.Add(item3);
            int i = 0;
            foreach (var item in items)
            {
                Note note = new Note();
                note.id = i;
                note.title = item[0];
                note.date = item[1];
                note.user = item[2];
                note.body = item[3];
                i++;
                notes.Add(note);
            }
        }
    }
}
