using Copa_De_Filmes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Copa_De_Filmes.Services
{
  public interface IFilmsApiService
  {
    Task<List<FilmModel>> GetAllFilms();
 
  }
}
