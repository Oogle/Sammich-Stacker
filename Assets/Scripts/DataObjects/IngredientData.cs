using Structs;
using UnityEngine;

namespace Controllers
{
    public class IngredientData : MonoBehaviour
    {
        [SerializeField]
        private IngredientScores scores;

        public IngredientScores Scores => scores;
    }
}