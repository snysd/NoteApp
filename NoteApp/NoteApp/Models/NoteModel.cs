using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteApp.Models
{
    public class Note
    {
        public string id { get; set; }
        public int alias { get; set; }
        public string title { get; set; }
        public string date { get; set; }
        public string user { get; set; }
        public string body { get; set; }
    }
}
