using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class SpawnButtonController : MonoBehaviour
    {
        [SerializeField]
        private GameObject ingredient;
    
        [SerializeField]
        private Transform spawnPoint;

        private void OnMouseDown()
        {
            Instantiate(ingredient, spawnPoint.position, Quaternion.identity);
        }
    }
}
