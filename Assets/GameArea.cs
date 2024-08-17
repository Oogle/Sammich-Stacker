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
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Protein")){
            globalController.placedProteins.Add(other.gameObject);
        }else if (other.gameObject.CompareTag("Veggie")){
            globalController.placedVeggies.Add(other.gameObject);
        }else if (other.gameObject.CompareTag("Fruit")){
            globalController.placedFruits.Add(other.gameObject);
        }
    }
}
