using System.Collections.Generic;
using System.Linq;

namespace MedicalCentre.Services;

internal static class SearchFilterService<T>
{
    public static List<T> GetFilteredList(List<T> items, string property)
    {
        return items.Where(item => item.ToString().ToLower().Contains(property.ToLower())).ToList();
    }
}
