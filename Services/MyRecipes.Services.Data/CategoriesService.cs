namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using MyRecipes.Data.Common.Repositories;
    using MyRecipes.Data.Models;
	using MyRecipes.Services.Mapping;

	public class CategoriesService : ICategoriesService
    {
        private readonly IDeletableEntityRepository<Category> categoriesRepository;

        public CategoriesService(IDeletableEntityRepository<Category> categoriesRepository)
        {
            this.categoriesRepository = categoriesRepository;
        }

        public IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs()
        {
            return this.categoriesRepository.All().Select(x => new
            {
                x.Id,
                x.Name,
            })
            .OrderBy(x => x.Name)
            .ToList().Select(x => new KeyValuePair<string, string>(x.Id.ToString(), x.Name));
        }

        public IEnumerable<T> GetAllPopular<T>()
        {
            return this.categoriesRepository.All()
                .Where(x => x.Recipes.Count() >= 1)
                .OrderByDescending(x => x.Recipes.Count())
                .Take(3)
                .To<T>()
                .ToList();
        }
    }
}
