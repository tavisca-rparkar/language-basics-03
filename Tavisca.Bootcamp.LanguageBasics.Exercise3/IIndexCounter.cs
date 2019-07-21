using System;

namespace Tavisca.Bootcamp.LanguageBasics.Exercise1
{
    public interface INutritionSelector
    {
        Nutrition[] ComputeIndexes(Nutrition[] nutritions, string diet);
    }
}
