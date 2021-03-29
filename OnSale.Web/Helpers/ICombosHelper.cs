using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnSale.Web.Helpers
{
    public interface ICombosHelper
    {
        IEnumerable<SelectListItem> GetComboCategories();
        IEnumerable<SelectListItem> GetComboCountries();
        IEnumerable<SelectListItem> GetComboStates(int countryId);
        IEnumerable<SelectListItem> GetComboCities(int departmentId);
    }
}
