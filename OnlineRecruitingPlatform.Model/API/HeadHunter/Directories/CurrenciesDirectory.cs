﻿using Newtonsoft.Json;
using OnlineRecruitingPlatform.Model.Database.Entities;

namespace OnlineRecruitingPlatform.Model.API.HeadHunter.Directories
{
    public class CurrenciesDirectory
    {
        [JsonProperty("currency")]
        public Currency[] Currencies { get; set; }
    }

    public class CurrenciesDirectory<T> where T : Currency
    {
        [JsonProperty("currency")]
        public T[] Currencies { get; set; }
    }
}
