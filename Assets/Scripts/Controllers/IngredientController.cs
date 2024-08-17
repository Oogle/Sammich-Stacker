using System;
using Components;
using UnityEngine;

namespace Controllers
{
    [RequireComponent(typeof(DragComponent))]
    [RequireComponent(typeof(Collider2D))]
    public class IngredientController: MonoBehaviour
    {
        [SerializeField]
        private LayerMask killDraggableMask;
        private void OnCollisionEnter(Collision other)
        {
            var otherLayer = other.gameObject.layer;
            

            // if ((killDraggableMask.value | (1 << otherLayer)))
            // {
            //     
            // }
        }
    }
}