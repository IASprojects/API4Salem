using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_Notes.Models
{
  interface IDataObject
  {
    public int ID { get; set; }
    public DateTime DateCreation { get; set; }
  }
}
