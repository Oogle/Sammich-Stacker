using System.Collections;
using System.Collections.Generic;
using Controllers;
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
    [SerializeField] TextMeshProUGUI proteinPercentageDisplay, veggiePercentageDisplay, fruitPercentageDisplay,calorieDisplay;
    [SerializeField] private IngredientArea ingredientArea;
    [SerializeField] private int totalCalories;
    public bool isDone = false;

    // AUDIO
    public AudioSource audioSource;
    public AudioClip dropIngredientSound;


    public void Calculate(){
        //Calculate Ratio Percentages
        int totalIngredientCount = placedProteins.Count + placedVeggies.Count + placedFruits.Count;
        if (totalIngredientCount == 0) return;
        proteinPercentage = placedProteins.Count * 100 / totalIngredientCount;
        veggiePercentage = placedVeggies.Count * 100 / totalIngredientCount;
        fruitPercentage = placedFruits.Count * 100 / totalIngredientCount;
        proteinPercentageDisplay.text = proteinPercentage.ToString() + "%";
        veggiePercentageDisplay.text = veggiePercentage.ToString() + "%";
        fruitPercentageDisplay.text = fruitPercentage.ToString() + "%";
        //Calculate Calories
        totalCalories = 0;
        foreach (GameObject ingredient in placedIngredients){
            print(ingredient.GetComponent<IngredientData>().Scores.calories);
            totalCalories += ingredient.GetComponent<IngredientData>().Scores.calories;
        }
        calorieDisplay.text = totalCalories.ToString() + "kCal";
    }
    public void SpawnIngredient(int ingredient){ //0 = protein, 1 = veggie, 2 = fruit. Less than 0 = protein, greater than 2 = fruit.
        if (ingredientArea.hasIngredient) return;
        GameObject whatToSpawn;
        if (ingredient <= 0){
            whatToSpawn = proteins[Random.Range(0, proteins.Length)];
        }else if (ingredient == 1){
            whatToSpawn = veggies[Random.Range(0, veggies.Length)];
        }else{ //if it's equal to 2 or greater
            whatToSpawn = fruits[Random.Range(0, fruits.Length)];
        }
        Instantiate(whatToSpawn,foodSpawnerTransform.position,foodSpawnerTransform.rotation);

        audioSource.PlayOneShot(dropIngredientSound);
    }
}
