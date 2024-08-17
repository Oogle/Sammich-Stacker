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
            
            foreach (var collider in overlapColliders)
            {
                var name = collider.gameObject.name;
                Debug.Log(name);
            }
        }
    }
}
