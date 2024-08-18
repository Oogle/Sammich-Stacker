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
        public int calories; //Determined by weight of the sandwhich created

        [Range(0, 10)]
        public int taste; //Determined by how closely the ratio of the three food types was matched
        
        [Range(0, 10)]
        public int looks; //Determined by heigh of the sandwhich
    }
}