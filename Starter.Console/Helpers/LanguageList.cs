using Starter.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starter.Console.Helpers
{
    public class LanguageList
    {
        private readonly ILanguageService languageService;
        private List<Models.Language> languages;

        public LanguageList(ILanguageService languageService)
        {
            var langs = Task.Run(async () =>
            {
                this.languages = await this.languageService.GetAllAsync();
            });
            langs.Wait();
        }

        public IList<Models.Language> Languages { get { return this.languages; } }
    }
}
