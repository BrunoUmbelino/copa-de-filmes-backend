using Copa_De_Filmes.Models;
using Copa_De_Filmes.Services;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Copa_De_Filmes.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class FilmsController : ControllerBase
  {
    private readonly IFilmsApiService _filmsApiService;

    public FilmsController(IFilmsApiService filmsService)
    {
      _filmsApiService = filmsService;
    }

    // GET: api/<FilmsController>
    [HttpGet]
    public async Task<ActionResult<List<FilmModel>>> GetAllFilms()
    {
      List<FilmModel> films = new List<FilmModel>();
      films = await _filmsApiService.GetAllFilms();
      return films;
    }

    [HttpPost]
    public async Task<ActionResult<List<FilmModel>>> MovieCup([FromBody] SelectedFilmsID selectedFilmsID)
    {
      List<FilmModel> allFilms = new List<FilmModel>();
      allFilms = await _filmsApiService.GetAllFilms();

      FilmsListModel Films = new FilmsListModel();
      var selectedFilms = Films.FindFilms(allFilms, selectedFilmsID);

      if (selectedFilms[0] == null) return NotFound();

      Films.SortFilmsAlphabetically();
      List<FilmModel> orderedConflicts = Films.SortConflicts();

      List<List<FilmModel>> firstSwitching = Films.FirstSwitching(orderedConflicts);
      List<FilmModel> winnersOfFirstSwitching = Films.WinnersEachKey(firstSwitching);

      List<List<FilmModel>> secondswitching = Films.SecondSwitching(winnersOfFirstSwitching);
      List<FilmModel> winnersOfSecondSwitching = Films.WinnersEachKey(secondswitching);

      List<FilmModel> champions = Films.Winners(winnersOfSecondSwitching);

      return champions;
    }
  }
}
