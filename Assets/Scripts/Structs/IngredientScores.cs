using UnityEngine;

namespace Structs
{
    public enum IngredientTypes
    {
        PROTEIN, VEGETABLE, FRUIT
    }
    [System.Serializable]
    public struct IngredientScores
    {
        public IngredientTypes ingredientType;
        
        [Min(0)]
        public int calories;

        [Range(0, 10)]
        public int taste;
        
        [Range(0, 10)]
        public int looks;
    }
}