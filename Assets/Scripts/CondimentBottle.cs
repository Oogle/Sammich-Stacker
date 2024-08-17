using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondimentBottle : MonoBehaviour
{
    private Vector3 startCoords;
    [SerializeField] private float moveSpeed = 30; //How fast the tween towards the start coordinates should be when player releases mouse button
    [SerializeField] private float spinSpeed = 15; //How fast the rotation tween should play
    [SerializeField] private Transform bottleSprite;
    private bool movingToStart = false; //Is the bottle trying to go back to the start?
    private bool rotateUp = true; //Should the bottle be rotating up?
    private bool inPlayArea = false; //Is the bottle inside the acceptable play area?

    // Start is called before the first frame update
    void Start()
    {
        startCoords = bottleSprite.position;
    }

    void OnMouseUp()
    {
        if(inPlayArea)
        {

        }
        else
        {
            movingToStart = true;
        }
        
    }

    //Sprays the condiment on to the sandwich
    void sprayCondiment()
    {

    }

    //The CondimentBottle layer cannot interact with any other physics layers. This assumes the ONLY other thing on the CondimentBottle layer is the bottleBoundry
    //When entering play area, face down.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        inPlayArea = true;
        rotateUp = false;
    }

    //When leaving the player area, rotate back to up 
    private void OnTriggerExit2D(Collider2D collision)
    {
        inPlayArea = false;
        rotateUp = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingToStart)
        {
            transform.position = Vector3.MoveTowards(transform.position, startCoords, moveSpeed * Time.deltaTime);

            if (transform.position == startCoords)
            {
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
