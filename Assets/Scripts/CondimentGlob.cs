/* The follower condimentGlob of the COndimentSplatter prefab.
 * This glob follows the leader glob and stays invisible. Only once it hits a valid ingredient does it become visible.
 * These are on their own special CondimentGlob layer so they fall through all ingredients until it finds the primary one hit by the leader.
 * Then, after it sticks to the primary ingredient, it heads to to the Ingredient layer so it can stick to any other ingredients that touch the primary one.
 * 
 * It does this by having to joints. One that connects the glob and the primary ingredient, and second that connects the glob and the secondary ingredient.
 * The joint is updated on collision.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondimentGlob : MonoBehaviour
{
    [SerializeField] FixedJoint2D primaryJoint;
    [SerializeField] FixedJoint2D secondJoint;
    [SerializeField] SpriteRenderer sprite;

    bool hasFirstJoint = false;
    bool hasSecondJoint = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(!hasFirstJoint)
        {
            //Glob doesn't have its first joint, then the condiment must have just been spawned by the player.
            //Attach to the primary ingredient and change physics layers so it can touch other ingredients
            primaryJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            int globInteractLayer = LayerMask.NameToLayer("Ingredient");
            this.gameObject.layer = globInteractLayer;
            hasFirstJoint = true;
            sprite.enabled = true;
        }
        else if(!hasSecondJoint)
        {
            //Glob has the first joint AKA it is attached to primary ingredient, then the primary food has touched some other piece of food
            secondJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
