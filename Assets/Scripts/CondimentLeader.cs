using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CondimentLeader : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collided = collision.gameObject;
        int globInteractLayer = LayerMask.NameToLayer("GlobAndIngreds");
        collided.layer = globInteractLayer;
        print("Modified layer!");
        Destroy(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
