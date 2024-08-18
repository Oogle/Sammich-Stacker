using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientArea : MonoBehaviour
{
    public bool hasIngredient = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D other) {
       if (other.gameObject.CompareTag("Protein") || other.gameObject.CompareTag("Veggie") || other.gameObject.CompareTag("Fruit")){
            hasIngredient = true;
        }    
    }
    private void OnTriggerExit2D(Collider2D other) {
       if (other.gameObject.CompareTag("Protein") || other.gameObject.CompareTag("Veggie") || other.gameObject.CompareTag("Fruit")){
            hasIngredient = false;
        }    
    }
}
