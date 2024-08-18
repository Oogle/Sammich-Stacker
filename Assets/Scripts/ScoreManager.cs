/* ScoreManager script
 * This manager simply reads values from other gameObjects in the food prep scene and calculates
 * the score the player receives returned as a IngredientScores variable.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Structs;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    //The three texts on the receipt that correspond to the desiredFood percentages
    [SerializeField] TextMeshProUGUI proteinText;
    [SerializeField] TextMeshProUGUI vegetableText;
    [SerializeField] TextMeshProUGUI fruitText;
    [SerializeField] GlobalController controller;

    Recipe desiredFood; //The ratio of the three ingredient types the customer wants
    [SerializeField] private float forgiveness_margin; //How forgiving do we want to be regarding three ingredient ratios?

    // Start is called before the first frame update
    void Start()
    {
        generateRecipe();
        updateReceipt();
    }

    //Generates a new recipe for the next sandwhich and sets the desiredFood to the new recipe
    void generateRecipe()
    {
        float ratioPerc = 100f; //The total ratio percentage that will be split into the three ingredient types
        float proteinPerc = Random.Range(0f, 90f);
        ratioPerc -= proteinPerc;
        float vegPerc = Random.Range(0f, ratioPerc);
        ratioPerc -= vegPerc;
        float fruitPerc = ratioPerc; //Give the final percentage whatever is left over so it adds up to 100%

        desiredFood = new Recipe(Mathf.Round(proteinPerc), Mathf.Round(vegPerc), Mathf.Round(fruitPerc), forgiveness_margin);
    }

    //Updates the text objects in the receipt
    void updateReceipt()
    {
        
        proteinText.text = desiredFood.proteinPercent.ToString() + "%";
        vegetableText.text = desiredFood.vegetablePercent.ToString() + "%";
        fruitText.text = desiredFood.fruitPercent.ToString() + "%";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            generateRecipe();
            updateReceipt();
        }
    }

    //Calculates the player's score by comparing desiredFood percentages with the GlobalController's percentages
    void calculateScore()
    {
        float baseScore = 0f;

        //First, calculate how close each ingredient ratio is. Either the player has gotten into the margin or not
        bool gotProtein = (desiredFood.proteinPercent <= controller.proteinPercentage+forgiveness_margin || desiredFood.proteinPercent >= controller.proteinPercentage - forgiveness_margin);
        bool gotVeggies = (desiredFood.vegetablePercent <= controller.veggiePercentage + forgiveness_margin || desiredFood.vegetablePercent >= controller.veggiePercentage - forgiveness_margin);
        bool gotFruit = (desiredFood.fruitPercent <= controller.fruitPercentage + forgiveness_margin || desiredFood.fruitPercent >= controller.fruitPercentage - forgiveness_margin);

        if(gotProtein)
        {
            baseScore += 30f;
        }

        if(gotVeggies)
        {
            baseScore += 30f;
        }

        if(gotFruit)
        {
            baseScore += 30f;
        }
        //Next, calculate the calories based on the weight of the sandwhich


        //Finally, calculate the looks based on the height of the sandwhich


        //Then wrap up the scores into a single IngredientScores variable to be used by the next scene
    }

}
