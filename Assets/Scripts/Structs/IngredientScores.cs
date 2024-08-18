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

    [System.Serializable]
    public struct Recipe //The recipe that will be compared against for the three ratios of ingredient types
    {
        [Range(0, 100)]
        public float margin_of_error; //How much margin of error can the player make on the sandwhich?

        [Range(0, 100)]
        public float proteinPercent; //How much protein is desired?

        [Range(0, 100)]
        public float vegetablePercent;  //How much vegetables is desired?

        [Range(0, 100)]
        public float fruitPercent;  //How much fruit is desired?
        
        public Recipe(float r_proPerc, float r_vegPerc, float r_fruitPerc, float r_margin)
        {
            proteinPercent = r_proPerc;
            vegetablePercent = r_vegPerc;
            fruitPercent = r_fruitPerc;
            margin_of_error = r_margin;
        }
    }
}