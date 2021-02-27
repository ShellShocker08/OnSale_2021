using OnSale.Common.Entities;
using OnSale.Web.Models;
using System;

namespace OnSale.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public Category ToCategory(CategoryViewModel model, string imagePath, bool isNew)
        {
            return new Category
            {
                Id = isNew ? 0 : model.Id,
                ImagePath = imagePath,
                Name = model.Name
            };
        }

        public CategoryViewModel ToCategoryViewModel(Category category)
        {
            return new CategoryViewModel
            {
                Id = category.Id,
                ImagePath = category.ImagePath,
                Name = category.Name
            };
        }
    }
}