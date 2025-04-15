using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class cannonball : MonoBehaviour
{
    /// <summary>
    /// How much damage the cannonball does to rocks
    /// </summary>
    public int power = 1;

    /// <summary>
    /// Body of cannonball
    /// </summary>
    public Rigidbody2D cannonballbody;

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.collider.gameObject;
        if (go.tag == "rock" || go.tag == "resource")
        {
            Destroy(gameObject);
        }
            
    }

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "cannonball";
        cannonballbody = GetComponent<Rigidbody2D>();
        cannonballbody.mass = 0;
        cannonballbody.gravityScale = 0;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!cannonballbody.IsAwake())
        {
            Destroy(gameObject);
        }
        
    }
}
