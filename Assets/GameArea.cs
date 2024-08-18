using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameArea : MonoBehaviour
{
    [SerializeField] GlobalController globalController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateIngredients(GameObject ingredient){
        if (ingredient.CompareTag("Protein")){
            globalController.placedProteins.Add(ingredient);
        }else if (ingredient.CompareTag("Veggie")){
            globalController.placedVeggies.Add(ingredient);
        }else if (ingredient.CompareTag("Fruit")){
            globalController.placedFruits.Add(ingredient);
        }
        globalController.CalculatePercentages();
    }
}
