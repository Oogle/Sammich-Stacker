using UnityEngine;

namespace Structs
{
    [System.Serializable]
    public struct IngredientScores
    {
        [Min(0)]
        public int calories;

        [Range(0, 10)]
        public int taste;
        
        [Range(0, 10)]
        public int looks;
    }
}