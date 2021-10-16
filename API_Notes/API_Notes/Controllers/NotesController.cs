using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using API_Notes.Models;
using API_Notes.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Notes.Controllers
{
  [Route("api/[controller]")]

  [ApiController]
  public class NotesController : ControllerBase
  {
    private readonly NoteData request;
    public NotesController()
    {
      request = NoteData.Instance;
    }
    
    [HttpGet] 
    public Response Get()
    {
      Response resp = new();
      try
      {
        resp.Data = request.List;
        resp.Success = true;
      }
      catch (Exception ex)
      {
        resp.Message = ex.Message;
      }
      return resp;

    }
    [HttpGet("{id}")]

    public Response GetDetails(int id)
    {
      Response resp = new();
      try
      {
        resp.Data = request.GetNote(id);
        resp.Success = true;
      }
      catch (Exception ex)
      {
        resp.Message = ex.Message;
      }
      return resp;

    }
    [HttpPost]

    public Response Add(Note item)
    {
      Response resp = new();
      try
      {
        request.AddNote(item);
        resp.Success = true;
      }
      catch (Exception ex)
      {
        resp.Message = ex.Message;
      }
      return resp;
    }
    [HttpPut]
   
    public Response Edit(Note item)
    {
      Response resp = new();
      try
      {
        request.EditNote(item);
        resp.Success = true;
      }
      catch (Exception ex)
      {
        resp.Message = ex.Message;
      }
      return resp;
    }
    [HttpDelete("{id}")] 
    public Response Delete(int id)
    {
      Response resp = new();
      try
      {
        request.DeleteNote(id);
        resp.Success = true;
      }
      catch (Exception ex)
      {
        resp.Message = ex.Message;
      }
      return resp;
    }
  }
}
