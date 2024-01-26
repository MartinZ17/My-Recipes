namespace MyRecipes.Web.ViewModels.Home
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class IndexListCategoriesViewModel
    {
        public IEnumerable<IndexCategoryViewModel> Categories { get; set; }
    }
}
