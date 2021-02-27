using OnSale.Common.Entities;
using OnSale.Web.Models;
using System;

namespace OnSale.Web.Helpers
{
    public interface IConverterHelper
    {
        Category ToCategory(CategoryViewModel model, string imagePath, bool isNew);
        CategoryViewModel ToCategoryViewModel(Category category);

    }
}
