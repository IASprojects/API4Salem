using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Notes.Models
{
  public class Note : IDataObject
  {
    private int _ID;
    public int ID { get => _ID; set => _ID=value; }

    private DateTime _DateCreation;
    public DateTime DateCreation { get => _DateCreation; set => _DateCreation = value; }

    public string Text { get; set; }

    public Note() {
  
    }
    public Note(int id, string text)
    {
      ID = id;
      Text = text;
      DateCreation = DateTime.Now;
    }
  }
}
