using Structs;
using UnityEngine;

namespace Controllers
{
    public class IngredientController : MonoBehaviour
    {
        [SerializeField]
        private IngredientScores scores;

        public IngredientScores Scores => scores;
    }
}