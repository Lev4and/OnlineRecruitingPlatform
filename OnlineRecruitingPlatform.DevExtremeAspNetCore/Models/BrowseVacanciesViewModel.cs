using OnlineRecruitingPlatform.Model.Formatters.String;
using System.Collections.Generic;

namespace OnlineRecruitingPlatform.DevExtremeAspNetCore.Models
{
    public class BrowseVacanciesViewModel
    {
        public int NumberPage { get; set; }

        public int CountItems { get; set; }

        public List<int> Pagination { get; set; }

        public string SearchStringByCityAddressOrZip { get; set; }

        public string SearchStringByJobTitleSkillsOrCompany { get; set; }

        public List<dynamic> VacanciesHeadHunter { get; set; }

        public List<dynamic> VacanciesZarplataRu { get; set; }

        public string GetFormattedStringRange()
        {
            var from = 0;
            var to = 0;

            if (NumberPage > 1)
            {
                from = (NumberPage - 1) * 50;
                to = NumberPage * 50 <= CountItems ? NumberPage * 50 : CountItems;
            }
            else
            {
                if (CountItems > 0)
                {
                    from = 1;
                    to = NumberPage * 50 <= CountItems ? NumberPage * 50 : CountItems;
                }
                else
                {
                    from = 0;
                    to = 0;
                }
            }
            return $"Мы нашли <strong>{CountItems}</strong> {Declension.DeclensionByNumeral(CountItems, new string[3] { "совпадение", "совпадения", "совпадений" }, false)}, вы смотрите с <i>{from}</i> по <i>{to}</i>";
        }

        public void GeneratePagination()
        {
            Pagination = new List<int>();

            var pages = CountItems % 50 != 0 ? (CountItems / 50) + 1 : CountItems / 50;
            var from = 0;
            var to = 0;

            if (NumberPage > 1 && NumberPage < pages)
            {
                from = NumberPage - 1;
                to = NumberPage + 1;
            }
            else
            {
                if (NumberPage == 1)
                {
                    from = 1;
                    to = pages > 3 ? 3 : pages;
                }
                else
                {
                    from = pages - 3 > 0 ? pages - 3 : 1;
                    to = pages;
                }
            }

            for (int i = from; i <= to; i++)
            {
                Pagination.Add(i);
            }
        }
    }
}
