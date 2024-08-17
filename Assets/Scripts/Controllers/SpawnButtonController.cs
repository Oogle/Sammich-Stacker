using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Controllers
{
    public class SpawnButtonController : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> ingredients;
    
        [SerializeField]
        private Transform spawnPoint;

        private void OnMouseDown()
        {
            var ingredient = ingredients[Random.Range(0, ingredients.Count)];
            Instantiate(ingredient, spawnPoint.position, Quaternion.identity);
        }
    }
}
