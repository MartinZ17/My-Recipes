namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;

    public interface ICategoriesService
    {
        IEnumerable<KeyValuePair<string, string>> GetAllAsKeyValuePairs();

        IEnumerable<T> GetAllPopular<T>();
    }
}
