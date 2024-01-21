﻿namespace MyRecipes.Web.ViewModels.Recipes
{
    using System;
    using System.Collections.Generic;

    using AutoMapper;
    using Microsoft.EntityFrameworkCore.Storage;
    using MyRecipes.Data.Models;
    using MyRecipes.Services.Mapping;

    public class EditRecipeInputModel : BaseRecipeInputModel, IMapFrom<Recipe>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Recipe, EditRecipeInputModel>()
                .ForMember(x => x.CookingTime, opt =>
                    opt.MapFrom(x => (int)x.CookingTime.TotalMinutes))
                .ForMember(x => x.PreparationTime, opt =>
                    opt.MapFrom(x => (int)x.PreparationTime.TotalMinutes));
        }
    }
}
