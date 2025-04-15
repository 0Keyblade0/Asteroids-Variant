using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Rendering;

public class rock : MonoBehaviour
{
    /// <summary>
    /// Rock's rigidbody
    /// </summary>
    public Rigidbody2D rockbody;

    /// <summary>
    /// Prefab for rocks
    /// </summary>
    public GameObject rockprefab;

    ///<summary>
    /// Prefab for explosion
    /// </summary>
    public GameObject explosionprefab;

    ///<summary>
    /// Prefab for gold resource
    /// </summary>
    public GameObject goldprefab;

    ///<summary>
    /// Prefab for non-gold resource
    /// </summary>
    public GameObject nongoldprefab;

    /// <summary>
    /// Number of hits required to destroy rock
    /// Also represents how much damage rock will do to player object
    /// if it hits one.
    /// </summary>
    public int hits;

    /// <summary>
    /// Number of points for destroying this block
    /// </summary>
    public int points;

    /// <summary>
    /// Is carrying gold
    /// </summary>
    public bool carryinggold;

    void Start()
    {
        gameObject.transform.localScale *= Random.Range(4, 9);
        rockbody = GetComponent<Rigidbody2D>();

        if (FindObjectOfType<player>() != null)
        {
            if (FindObjectOfType<player>().fire_rate == 0)
            {
                rockbody.gravityScale = 0.01f;
                hits = Random.Range(50, 151);
                points = hits * 10;
            }
            else
            {
                rockbody = GetComponent<Rigidbody2D>();
                rockbody.gravityScale = 0.005f;
                hits = Random.Range(1, 31);
                points = hits * 3;
            }
        }
        
        
        gameObject.tag = "rock";

        float special_roll = Random.Range(1, 101);
        if (special_roll <= 20)
        {
            carryinggold = true;
        }
        else
        {
             carryinggold = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject go = collision.collider.gameObject;

        if (go.tag == "cannon")
        {
            Explode();

        } else if (go.tag == "cannonball")
        {
            hits -= go.GetComponent<cannonball>().power;
        }
    }

    /// <summary>
    /// Checks if rock has been destroyed, meaning hits = 0
    /// </summary>
    /// <returns></returns>
    private bool isDestroyed()
    {
        return hits <= 0;
    }

    /// <summary>
    /// Destroys rock gameobject
    /// </summary>
    private void Destruct()
    {
        Destroy(gameObject);

    }

    private void OnBecameInvisible()
    {
        if (gameObject.transform.localPosition.y < 0) 
        {
            Destruct();
        }
    }

    /// <summary>
    /// Destroys the rock object and executes explosion animation.
    /// </summary>
    private void Explode()
    {
        scorekeeper.ScorePoints(points);
        gameObject.GetComponent<SpriteRenderer>().forceRenderingOff = true;
        GameObject go = Instantiate(explosionprefab, transform.position, Quaternion.identity, transform.parent);
        if (carryinggold)
        {
            GameObject go1 = Instantiate(goldprefab, transform.position, Quaternion.identity, transform.parent);
            go1.GetComponent<resource>().isgold = true;

        } else
        {
            float speciall_roll = Random.Range(1, 100);

            if (speciall_roll >= 50)
            {
                GameObject go2 = Instantiate(nongoldprefab, transform.position, Quaternion.identity, transform.parent);
                go2.GetComponent<resource>().isgold = false;
            }
        }
        soundplayer.playsound(2);

        Invoke("Destruct", 0.001f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isDestroyed())
        {
            Explode();
        }

        if (!(rockbody.IsAwake()))
        {
            Destruct();
        }
        
    }
}
