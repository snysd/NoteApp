using NoteApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Net;
using System.Net.Http;

namespace NoteApp.Services
{
    public class NoteService
    {
        public List<Note> notes = new List<Note>();
        private HttpClient client;

        public NoteService()
        {
            ServicePointManager.ServerCertificateValidationCallback += (o, c, ch, er) => true;
            client = new HttpClient();
            GetAllNotes();
        }

        public void GetAllNotes()
        {
            var content = client.GetStringAsync("http://localhost:5000/api/notes/");
            notes = JsonConvert.DeserializeObject<List<Note>>(content.Result);
        }

        private bool CreateNote(Note note)
        {
            var json = JsonConvert.SerializeObject(note);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = client.PostAsync("http://localhost:5000/api/notes/",content);
            notes = JsonConvert.DeserializeObject<List<Note>>(res.Result.Content.ReadAsStringAsync().Result);
            if (res == null)
            {
                return false;
            }
            return true;
        }

        // 現在保持しているnoteのIDが最も大きい値を計算
        private int GetMaxId()
        {
            List<int> Ids = new List<int>();
            foreach (Note note in notes)
            {
                Ids.Add(note.alias);
            }
            Ids.Reverse();
            return Ids[0];
        }

        public void AddNote(Note note)
        {
            note.alias = (GetMaxId() + 1);
            CreateNote(note);
        }
        public Note GetNoteByName(string title)
        {
            Note matchedNote = null;
            foreach (Note note in notes)
            {
                if (title == note.title)
                {
                    matchedNote = note;
                    break;
                }
            }
            return matchedNote;
        }

        public List<Note> GetNotesByNames(List<string> names)
        {
            List<Note> targetNotes = new List<Note>();

            // if current note contains selected note's name, update targetNotes.
            foreach (string name in names)
            {
                var matchedNote = GetNoteByName(name);
                targetNotes.Add(matchedNote);
            }
            return targetNotes;
        }

        public void UpdateNote(Note editedNote)
        {
            var json = JsonConvert.SerializeObject(editedNote);
            var content = new StringContent(json, Encoding.UTF8, "application/json");
            var res = client.PutAsync($"http://localhost:5000/api/notes/{editedNote.id}", content);
             notes = JsonConvert.DeserializeObject<List<Note>>(res.Result.Content.ReadAsStringAsync().Result);
        }

        // Noteの削除
        public void RemoveNotes(List<Note> targetNotes)
        {
            Task<HttpResponseMessage> res = null;

            foreach (Note targetNote in targetNotes)
            {
                res = client.DeleteAsync($"http://localhost:5000/api/notes/{targetNote.id}");
            }
            if (res == null) return;
            notes = JsonConvert.DeserializeObject<List<Note>>(res.Result.Content.ReadAsStringAsync().Result);
        }
    }
}
