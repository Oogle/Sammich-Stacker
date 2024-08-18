/* The condimentLeader script
 * Used in the giant condimentGlob prefab, this special object will fall down first straight from the condimentBottle.
 * By default, no globs of condiment can interact with an ingredient UNLESS this leader object collides with it.
 * To allow the ingredient to interact, there have been 3 special physics layers for this purpose:
 *          -The ingredient layer, where ingredients interact with each other
 *          -The GlobAndIngreds layer, where ingredients AND globs can interacts with each other
 *          -The CondimentGlob layer, where follower globs will fall through everything.
 * By default, the globs and ingredients are on totally separate physics layers so they never interact.
 * Once the leader glob collides, it switches the collided ingredient to the GlobAndIngreds layer.
 * That way, once the globs touch ONLY that ingredient, it will be covered in the condiment.
 * It gives the illusion of the condiment spreading out on the object instead of the wide berth needed for actual physics to collide,
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondimentLeader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    //Leader glob collided with an ingredient, swap it on to the intermediate layer so the follow globs can stick to the ingredient
    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collided = collision.gameObject;
        int globInteractLayer = LayerMask.NameToLayer("GlobAndIngreds");
        collided.layer = globInteractLayer;
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
