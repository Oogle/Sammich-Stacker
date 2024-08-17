using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CalculateButtonController : MonoBehaviour
    {
        [SerializeField]
        public Collider2D collectionArea;
        
        private ContactFilter2D contactFilter;

        private void Start()
        {
            contactFilter.SetLayerMask(LayerMask.GetMask("Ingredient"));
        }

        private void OnMouseDown()
        {
            List<Collider2D> overlapColliders = new List<Collider2D>();
            collectionArea.OverlapCollider(contactFilter, overlapColliders);

            var ingredientCount = 0;
            var calories = 0;
            var taste = 0;
            var looks = 0;
            
            foreach (var overlapCollider in overlapColliders)
            {
                var colliderGameObject = overlapCollider.gameObject;
                var ingredientController = colliderGameObject.GetComponent<IngredientData>();
                
                if(ingredientController == null) continue;

                var scores = ingredientController.Scores;
                calories += scores.calories;
                taste += scores.taste;
                looks += scores.looks;
                ingredientCount++;
            }

            if (ingredientCount == 0)
            {
                Debug.Log("No ingredient found");
                return;
            }
            
            Debug.Log($"Total Calories: {calories}, Average Taste: {taste/ingredientCount}, Average Looks: {looks/ingredientCount}");
        }
    }
}
