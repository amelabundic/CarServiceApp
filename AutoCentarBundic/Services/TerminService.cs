using AutoCentarBundic.Data;
using System.Net.Http.Json;

public class TerminService
{
    private readonly HttpClient _http;

    public TerminService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Termin>> GetTerminiAsync()
    {
        return await _http.GetFromJsonAsync<List<Termin>>("api/termin");
    }
    public async Task<bool> AddTerminAsync(Termin noviTermin)
    {
        var response = await _http.PostAsJsonAsync("api/termin", noviTermin);
        return response.IsSuccessStatusCode;
    }
    public async Task<bool> DeleteTerminAsync(int id)
    {
        var response = await _http.DeleteAsync($"api/termin/{id}");
        return response.IsSuccessStatusCode;
    }
    public async Task<Termin?> GetTerminByIdAsync(int id)
    {
        return await _http.GetFromJsonAsync<Termin>($"api/termin/{id}");
    }

    public async Task<bool> UpdateTerminAsync(int id, Termin termin)
    {
        var response = await _http.PutAsJsonAsync($"api/termin/{id}", termin);

        if (!response.IsSuccessStatusCode)
        {
            var error = await response.Content.ReadAsStringAsync();
            Console.WriteLine(error);
        }
        return response.IsSuccessStatusCode;
    }


}

