/*The CondimentBottle Script
 * Uses on the condiment bottle itself. It expects a trigger object around the desired play area. This trigger should be tagged "PlayArea".
 * Once the bottle enters the area, the bottle's sprite will flip upside down. When it exits, the sprite will turn back up again.
 * If the player presses the right mouse button
 *              -If inside the play area, the bottle will spawn the globPrefab and let it fall down.
 * When the player releases the left mouse button, then the condiment bottle goes back to the original coords
 * See the Glob prefab for more info on how the globs actually work.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondimentBottle : MonoBehaviour
{
    public AudioSource audioSource;
    private Vector3 startCoords;
    [SerializeField] private float moveSpeed = 30; //How fast the tween towards the start coordinates should be when player releases mouse button
    [SerializeField] private float spinSpeed = 15; //How fast the rotation tween should play
    [SerializeField] private Transform bottleSprite;
    [SerializeField] private Transform tip; //The bottle tip transform object that will be used to spray to condiment
    [SerializeField] private GameObject globPrefab; //The prefab to spawn when the player stops holding down the mouse
    private bool movingToStart = false; //Is the bottle trying to go back to the start?
    private bool rotateUp = true; //Should the bottle be rotating up?
    private bool inPlayArea = false; //Is the bottle inside the acceptable play area?


    [SerializeField] float sprayDelay; //How long (in seconds) should be between glob sprays?
    float sprayTimer; //A countdown timer that counts from sprayDelay to 0. Represents how long until the next condiment glob can spawn
    [SerializeField] private int globsLeft; //How many more globs can be sprayed out? Will eventually become zero
    private int maxGlobs; //The original value of globsLeft

    // Start is called before the first frame update
    void Start()
    {
        sprayTimer = sprayDelay; //Maybe start this at zero?
        startCoords = bottleSprite.position;
        maxGlobs = globsLeft;
    }

    void OnMouseUp()
    {
         movingToStart = true;
    }

    //Sprays the condiment on to the sandwich
    void sprayCondiment()
    {
        Instantiate(globPrefab, tip.position, Quaternion.identity);
        globsLeft -= 1;
        //movingToStart = true;
    }

    //The CondimentBottle layer cannot interact with any other physics layers. This assumes the ONLY other thing on the CondimentBottle layer is the bottleBoundry
    //When entering play area, face down.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayArea"))
        {
            inPlayArea = true;
            rotateUp = false;
        }
    }

    //When leaving the player area, rotate back to up 
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayArea"))
        {
            inPlayArea = false;
            rotateUp = true;
        }
    }

    void checkMouse()
    {
        //Allow the player to spray condiment if timer has been fully delayed
        if (globsLeft > 0 && sprayTimer <= 0 && Input.GetMouseButton(1))
        {
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            
            sprayCondiment();
            sprayTimer = sprayDelay;
        }
        if (globsLeft <= 0 || !Input.GetMouseButton(1))
        {
            audioSource.Stop();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(inPlayArea)
        {
            sprayTimer -= Time.deltaTime;
            checkMouse(); //check if the right mouse buttons is being clicked
        }



        if(movingToStart)
        {
            //Smoothly tween the sandwhich back to the start area
            transform.position = Vector3.MoveTowards(transform.position, startCoords, moveSpeed * Time.deltaTime);

            if (transform.position == startCoords)
            {
                //Debug just in case the bottle doesn't flip fast enough by the time it gets to the start point
                //Then just set it manually straight up
                movingToStart = false;
                bottleSprite.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        if (rotateUp)
        {
            Quaternion upRotation = Quaternion.Euler(0, 0, 0);
            bottleSprite.rotation = Quaternion.Lerp(bottleSprite.rotation, upRotation, Time.deltaTime * spinSpeed);
        }
        else
        {
            Quaternion downRotation = Quaternion.Euler(0, 0, -180);
            bottleSprite.rotation = Quaternion.Lerp(bottleSprite.rotation, downRotation, Time.deltaTime * spinSpeed);

        }

    }
}
