﻿namespace MyRecipes.Services.Data
{
    using System.Collections.Generic;

    public interface IIngredientsService
    {
        IEnumerable<T> GetAllPopular<T>();
    }
}
