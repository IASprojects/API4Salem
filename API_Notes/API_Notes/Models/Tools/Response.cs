using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Notes.Models
{
  public class Response
  {
    public Response() {
      Success = false;
      Message = "";
      Data = null;
    
    }
    public bool Success { get; set; }
    public string Message { get; set; }
    public Object Data { get; set; }
  }
}
