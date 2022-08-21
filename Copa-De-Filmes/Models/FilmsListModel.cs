using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Copa_De_Filmes.Models
{
  public class FilmsListModel
  {
    public List<FilmModel> Films { get; private set; }

    public FilmsListModel()
    {
      this.Films = new List<FilmModel>();
    }

    public List<FilmModel> FindFilms(List<FilmModel> allFilms, SelectedFilmsID selectedFilmsID)
    {
      foreach (var filmId in selectedFilmsID.Ids)
      {
        Films.Add(allFilms.Find(f => f.Id == filmId));
      }
      return this.Films;
    }

    public List<FilmModel> SortFilmsAlphabetically()
    {
      return this.Films = this.Films.OrderBy(f => f.Titulo).ToList(); ;
    }

    public List<FilmModel> SortConflicts()
    {
      List<FilmModel> conflicts = new List<FilmModel>();
      int last = this.Films.Count - 1;

      for (int i = 0; i <= (this.Films.Count / 2) - 1; i++)
      {
        var firstItem = Films[i];
        var lastItem = Films[last];

        conflicts.Add(firstItem);
        conflicts.Add(lastItem);
        last--;
      }

      return conflicts;
    }

    public List<List<FilmModel>> FirstSwitching(List<FilmModel> conflicts)
    {
      List<List<FilmModel>> firstSwitching = new List<List<FilmModel>>();

      /// separando as chaves
      var aux = 0;
      for (int i = 0; i <= (conflicts.Count / 2) - 1; i++)
      {
        firstSwitching.Add(conflicts.Skip(aux).Take(2).ToList());
        aux = aux + 2;
      }

      return firstSwitching;
    }


    internal List<List<FilmModel>> SecondSwitching(List<FilmModel> winnersOffirstSwitching)
    {
      List<List<FilmModel>> secondSwitching = new List<List<FilmModel>>();
      var aux = 0;

      for (int i = 0; i <= (winnersOffirstSwitching.Count / 2) - 1; i++)
      {
        secondSwitching.Add(winnersOffirstSwitching.Skip(aux).Take(2).ToList());
        aux += 2;
      }

      return secondSwitching;
    }

    public List<FilmModel> WinnersEachKey(List<List<FilmModel>> switching)
    {
      /// comparando as notas
      for (int i = 0; i <= switching.Count - 1; i++)
      {
        switching[i] = switching[i].OrderBy(f => f.Titulo).OrderByDescending(f => f.Nota).Take(1).ToList();
      }

      /// unindo vencedores em uma lista
      List<FilmModel> winnersEachKey = new List<FilmModel>();

      for (int i = 0; i <= switching.Count - 1; i++)
      {
        for (int j = 0; j <= switching[j].Count - 1; j++)
        {
          winnersEachKey.Add(switching[i][j]);
        }
      }

      return winnersEachKey;
    }

    public List<FilmModel> Winners(List<FilmModel> switching)
    {
      switching = switching.OrderBy(f => f.Titulo).OrderByDescending(f => f.Nota).ToList();
      return switching;
    }
  }
}
