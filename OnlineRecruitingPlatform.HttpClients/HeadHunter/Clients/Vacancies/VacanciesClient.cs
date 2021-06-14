using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace OnlineRecruitingPlatform.HttpClients.HeadHunter.Clients.Vacancies
{
    public class VacanciesClient : BaseHttpClient
    {
        public VacanciesClient() : base("vacancies/")
        {


        }

        public async Task<HttpResponseMessage> GetVacancies(int perPage, int page)
        {
            try
            {
                return await _client.GetAsync($"?per_page={perPage}&page={page}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetVacancies(DateTime dateFrom, DateTime dateTo, int perPage, int page)
        {
            try
            {
                return await _client.GetAsync($"?date_from={dateFrom.ToString("yyyy-MM-ddTHH:mm:ss")}&date_to={dateTo.ToString("yyyy-MM-ddTHH:mm:ss")}&per_page={perPage}&page={page}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetActiveVacancies(DateTime dateFrom, DateTime dateTo, int perPage, int page)
        {
            try
            {
                return await _client.GetAsync($"?date_from={dateFrom.ToString("yyyy-MM-ddTHH:mm:ss")}&date_to={dateTo.ToString("yyyy-MM-ddTHH:mm:ss")}&per_page={perPage}&page={page}");
            }
            catch
            {
                return null;
            }
        }

        public async Task<HttpResponseMessage> GetVacancy(int id)
        {
            try
            {
                return await _client.GetAsync($"{id}/");
            }
            catch
            {
                return null;
            }
        }
    }
}
