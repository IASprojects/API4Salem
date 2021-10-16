using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API_Notes.Models;
namespace API_Notes.Data
{
  public class NoteData
  {
    private static NoteData _Instance;
    public static NoteData Instance
    { 
      get {
        if (_Instance == null)
        {
          _Instance = new NoteData();
        }
        return _Instance;
      } 
    }
    private NoteData()
    {
      SetDefaultList();
    }
    public void SetDefaultList()
    {
      _List = new List<Note>
      {
        new Note { ID = 1, Text = "Take out the trash tomorrow", DateCreation = DateTime.Now },
        new Note { ID = 2, Text = "When I stand before God at the end of my life, I would hope that I would not have a single bit of talent left and could say, I used everything you gave me.  -Erma Bombeck", DateCreation = DateTime.Now },
        new Note { ID = 3, Text = "Either you run the day, or the day runs you.  –Jim Rohn", DateCreation = DateTime.Now },
        new Note { ID = 4, Text = "C# Programing class notes every sentence finish with ';'...", DateCreation = DateTime.Now },
        new Note { ID = 5, Text = "The two most important days in your life are the day you are born and the day you find out why.  –Mark Twain", DateCreation = DateTime.Now }
      };
    }
    public Note GetNote(int ID)
    {
      Note result = FilterNote(ID);
      if (result == null)
        throw new ArgumentException("The Note does not exist"); 

      return result;
    }
    private Note FilterNote(int ID) {
      Note result = (from p in _List
                     where p.ID == ID
                     select p).FirstOrDefault();
      return result;
    }
    public void AddNote(Note item) {

      if (FilterNote(item.ID)!=null) 
      {
        throw new ArgumentException("The Note Id exists");
      }
      _List.Add(item);
    
    }
    public void EditNote(Note item)
    {
      Note edit = FilterNote(item.ID);
      if (edit == null)
      {
        throw new ArgumentException("The Note does not exist");
      }
      edit.Text = item.Text;
    }
    public void DeleteNote(int id)
    {
      Note remove = FilterNote(id);
      if (remove == null)
      {
        throw new ArgumentException("The Note does not exist");
      }
      _List.Remove(remove);

    }
    protected List<Note> _List;
    public List<Note> List { get=>_List; }


  }
}
