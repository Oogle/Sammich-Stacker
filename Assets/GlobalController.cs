using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalController : MonoBehaviour
{
    public enum ingredients{protein,veggie,fruit};
    [SerializeField] private GameObject[] proteins,veggies,fruits; 
    [SerializeField] private Transform foodSpawnerTransform;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
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
