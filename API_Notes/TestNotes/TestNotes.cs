using Microsoft.VisualStudio.TestTools.UnitTesting;
using API_Notes.Data;
using API_Notes.Models;
using System.Collections.Generic;

namespace TestNotes
{
  [TestClass]
  public class TestNotes
  {
    NoteData request = NoteData.Instance;
    [TestMethod]
    public void TestGetListOk()
    {
      request.SetDefaultList();
      List<Note> result= request.List;

      Assert.IsTrue(result.Count == 5,"Dont load the list complete");
    }
    [TestMethod]
    public void TestAddOk()
    {
      string NoteText = "You can’t use up creativity. The more you use, the more you have.";
      string ErrorMessage = "The Note Id exists";
      int IdCorrect = 6;
      try
      {        
        request.SetDefaultList();
        request.AddNote(new Note(IdCorrect, NoteText));
        Note note = request.GetNote(IdCorrect);
        Assert.AreEqual(NoteText, note.Text, "Create have errors adding");
        request.AddNote(new Note(IdCorrect, NoteText));
        Note noteRepetida = request.GetNote(IdCorrect);
        Assert.AreEqual(noteRepetida.ID, note.ID, "Allow duplicate Note Id");
      }
      catch (System.ArgumentException ex)
      {
        Assert.AreEqual(ErrorMessage,ex.Message, "Validation message incorrect");
      }
    }
    [TestMethod]
    public void TestEditOk()
    {
      string NoteText = "You can’t use up creativity. The more you use, the more you have.";
      string NewNoteText = "Every child is an artist. The problem is how to remain an artist once he grows up..";
      string ErrorMessage = "The Note does not exist";
      int IdCorrect = 6;
      int IdIncorrect = 10;
      try
      {
        request.SetDefaultList();
        request.AddNote(new Note(IdCorrect, NoteText));
        Note note = request.GetNote(IdCorrect);
        note.Text = NewNoteText;
        request.EditNote(note);
        Assert.AreNotEqual(NoteText, note.Text, "Text does not change");
        Assert.AreEqual(NewNoteText, note.Text, "New text incorrect");
        request.EditNote(new Note(IdIncorrect, "Text"));

      }
      catch (System.ArgumentException ex)
      {
        Assert.AreEqual(ErrorMessage, ex.Message, "Validation message incorrect");
      }
    }
    [TestMethod]
    public void TestDeleteOk()
    {
  
      string ErrorMessage = "The Note does not exist";
      int IdCorrect = 5;
  
      try
      {
        request.SetDefaultList();
        request.DeleteNote(IdCorrect);
        Note note = request.GetNote(IdCorrect);
        Assert.AreEqual(null, note, "The Note does not delete");
      }
      catch (System.ArgumentException ex)
      {
        Assert.AreEqual(ErrorMessage, ex.Message, "Delete have errors");
      }
    }
    [TestMethod]
    public void TestDetailOk()
    {
      string NoteText = "You can’t use up creativity. The more you use, the more you have.";
      string ErrorMessage = "The Note Id exists";
      try
      {
        request.SetDefaultList();
        request.AddNote(new Note(6, NoteText));
        Note note = request.GetNote(6);
        Assert.AreEqual(NoteText, note.Text, "Create have errors");
        request.AddNote(new Note(6, NoteText));
      }
      catch (System.ArgumentException ex)
      {
        Assert.AreEqual(ErrorMessage, ex.Message, "Create have errors");
      }
    }

  }
}
