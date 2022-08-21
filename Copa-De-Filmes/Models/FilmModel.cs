using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Copa_De_Filmes.Models
{
  public class FilmModel
  {
    public string Id { get; set; }
    public string Titulo { get; set; }
    public int Ano { get; set; }
    public double Nota { get; set; }
  }
}
