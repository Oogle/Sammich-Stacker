using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using TMPro;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public enum ingredients{protein,veggie,fruit};
    [SerializeField] private GameObject[] proteins,veggies,fruits; 
    [SerializeField] private Transform foodSpawnerTransform;
    public List<GameObject> placedIngredients = new List<GameObject>();
    public List<GameObject> placedProteins = new List<GameObject>();
    public List<GameObject> placedVeggies = new List<GameObject>();
    public List<GameObject> placedFruits = new List<GameObject>();
    public float proteinPercentage, veggiePercentage, fruitPercentage;
    [SerializeField] TextMeshProUGUI proteinPercentageDisplay, veggiePercentageDisplay, fruitPercentageDisplay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CalculatePercentages();
    }
    private void CalculatePercentages(){
        int totalIngredientCount = placedProteins.Count + placedVeggies.Count + placedFruits.Count;
        if (totalIngredientCount == 0) return;
        proteinPercentage = placedProteins.Count * 100 / totalIngredientCount;
        veggiePercentage = placedVeggies.Count * 100 / totalIngredientCount;
        fruitPercentage = placedFruits.Count * 100 / totalIngredientCount;
        proteinPercentageDisplay.text = proteinPercentage.ToString() + "%";
        veggiePercentageDisplay.text = veggiePercentage.ToString() + "%";
        fruitPercentageDisplay.text = fruitPercentage.ToString() + "%";
    }
    public void SpawnProtein(){
        int whichProtein = UnityEngine.Random.Range(0, proteins.Length);
        GameObject protein = Instantiate(proteins[whichProtein],foodSpawnerTransform.position,foodSpawnerTransform.rotation);
    }
    public void SpawnVeggie(){
        int whichVeggie = UnityEngine.Random.Range(0, veggies.Length);
        GameObject veggie = Instantiate(proteins[whichVeggie],foodSpawnerTransform.position,foodSpawnerTransform.rotation);
    }
    public void SpawnFruit(){
        int whichFruit = UnityEngine.Random.Range(0, fruits.Length);
        GameObject fruit = Instantiate(proteins[whichFruit],foodSpawnerTransform.position,foodSpawnerTransform.rotation);
    }
    public void SpawnIngredient(int ingredient){ //0 = protein, 1 = veggie, 2 = fruit. Less than 0 = protein, greater than 2 = fruit.
        GameObject whatToSpawn;
        if (ingredient <= 0){
            whatToSpawn = proteins[Random.Range(0, proteins.Length)];
        }else if (ingredient == 1){
            whatToSpawn = veggies[Random.Range(0, veggies.Length)];
        }else{ //if it's equal to 2 or greater
            whatToSpawn = fruits[Random.Range(0, fruits.Length)];
        }
        Instantiate(whatToSpawn,foodSpawnerTransform.position,foodSpawnerTransform.rotation);
    }
}
