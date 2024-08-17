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
            //Without first joint, then the condiment must have just been spawned by the player
            primaryJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
            int globInteractLayer = LayerMask.NameToLayer("Ingredient");
            this.gameObject.layer = globInteractLayer;
            print("Glob found first joint!");
            hasFirstJoint = true;
            sprite.enabled = true;
        }
        else if(!hasSecondJoint)
        {
            print("Glob found second joint!");
            //With the first joint, then the primary food has touched some over piece of food
            secondJoint.connectedBody = collision.gameObject.GetComponent<Rigidbody2D>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
