namespace MyRecipes.Services.Data
{
    using System;
    using MyRecipes.Services.Data.Models;

    public interface IGetCountsService
    {
        // 1. Use the vies model
        // 2. Create DTO (data transfer object) -> view model
        CountsDto GetCounts();
    }
}
