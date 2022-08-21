using Copa_De_Filmes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Copa_De_Filmes.Services
{
  public class FilmsApiService : IFilmsApiService
  {
    private static readonly HttpClient httpClient;

    static FilmsApiService()
    {
      httpClient = new HttpClient() { BaseAddress = new Uri("https://copafilmes.azurewebsites.net") };
    }

    public async Task<List<FilmModel>> GetAllFilms()
    {
      var url = "/api/filmes";
      var result = new List<FilmModel>();
      var response = await httpClient.GetAsync(url);

      if (response.IsSuccessStatusCode)
      {
        var stringResponse = await response.Content.ReadAsStringAsync();
        result = JsonSerializer.Deserialize<List<FilmModel>>(stringResponse,
          new JsonSerializerOptions() { PropertyNamingPolicy = JsonNamingPolicy.CamelCase}
          );
      }
      else 
        throw new HttpRequestException(response.ReasonPhrase); 

      return result;
    }
  }
}
