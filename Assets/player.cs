using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class player : MonoBehaviour
{
    /// <summary>
    /// Rigidbody2D for the player
    /// </summary>
    public Rigidbody2D playerbody;

    /// <summary>
    /// Prefab for the player
    /// </summary>
    public GameObject cannon_preab;

    /// <summary>
    /// Prefab for cannonballs
    /// </summary>
    public GameObject cannonball_prefab;

    ///<summary>
    /// Prefab for the explosion of the player upon death
    ///</summary>
    public GameObject explosion_prefab;

    /// <summary>
    /// Movement speed of the player
    /// </summary>
    public float cannon_speed;

    /// <summary>
    /// Number of cannon balls the cannon fires everytime it fires
    /// </summary>
    public int cannonball_count = 2;

    /// <summary>
    /// Size of the cannon relative to its standard size
    /// </summary>
    public float cannon_size = 1f;

    /// <summary>
    /// Force the cannon shoots the cannonballs with
    /// </summary>
    public float cannonball_velocity = 5f;

    ///<summary>
    /// Fire rate of the player (sec) - delay time
    ///</summary>
    public float fire_rate = 0.33f; 

    ///<summary>
    /// Time of last fire
    /// </summary>
    public float last_fire;

    /// <summary>
    /// Health for the cannon
    /// </summary>
    public int health = 250;

    /// <summary>
    /// The threshold for a rock to do damage to the cannon.
    /// If below threshold, the rock will be destroyed.
    /// </summary>
    public int threshold = 10;

    // Start is called before the first frame update
    void Start()
    {
        // Set playerbody to Rigidbody2D to make things more efficient
        playerbody = GetComponent<Rigidbody2D>();
        playerbody.gravityScale = 0;
        playerbody.mass = 1000000;
        cannon_speed = playerbody.mass * 5f;
        gameObject.transform.localScale *= 4f;
        last_fire = 0;
        transform.position = new Vector2(0.01887059f, -3.503732f);
        gameObject.tag = "cannon";
    }

    /// <summary>
    /// Moves player based on the user's input using a button
    /// </summary>
    private void Move()
    {
        Vector2 force = new Vector2(Input.GetAxis("Horizontal") * cannon_speed, 0);
        playerbody.AddForce(force);
    }

    /// <summary>
    /// Fire if the player is pushing the button for the Fire axis
    /// Unlike the Enemies, the player has no cooldown, so they shoot a whole blob of orbs
    /// </summary>
    private void MaybeFire()
    {
        var is_firing = Input.GetAxis("Fire1");

        if (is_firing == 1 && Mathf.Abs(Time.time - last_fire) > fire_rate)
        {
            last_fire = Time.time;
            FireCannonBall();
        }
    }

    /// <summary>
    /// Fires the necessary number of cannonballs and then starts cooldown
    /// </summary>
    private void FireCannonBall()
    {
        for (int i = 0; i < cannonball_count; i++)
        {
            Vector2 direction = transform.up;
            var ball_point = playerbody.position + direction;
            var cannon_ball = Instantiate(cannonball_prefab, ball_point, Quaternion.identity);

            cannon_ball.GetComponent<Rigidbody2D>().velocity = transform.up * cannonball_velocity;
        }

        soundplayer.playsound(3);

    }

    /// <summary>
    /// Destroys player gameobject
    /// </summary>
    private void Destruct()
    {
        Destroy(gameObject);

    }

    /// <summary>
    /// Destroys the player object and executes explosion animation.
    /// If it is the last player have a repulse effect upon death
    /// </summary>
    private void Death()
    {
        if (FindObjectsOfType<player>().Length == 1)
        {
            gameObject.GetComponent<PointEffector2D>().enabled = true;
        }
        gameObject.GetComponent<SpriteRenderer>().forceRenderingOff = true;

        GameObject go = Instantiate(explosion_prefab, transform.position, Quaternion.identity, transform.parent);

        soundplayer.playsound(2);

        Invoke("Destruct", 0.1f);
    }

    /// <summary>
    /// If the player collides with an object with a rock tag,
    /// deduct points from the health of the player object if the value of the
    /// rock is above the player object's threshold
    /// </summary>
    /// <param name="collision"></param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject collider_object = collision.collider.gameObject;
        if (collider_object.tag == "rock")
        {
            if (collider_object.GetComponent<rock>().hits > threshold)
            {
                health -= collider_object.GetComponent<rock>().hits;
            }
        } else if (collider_object.tag == "resource")
        {

            resourcekeeper.CaughtResource();

            if (collider_object.GetComponent<resource>().isgold)
            {
                soundplayer.playsound(1);
                scorekeeper.ScorePoints(250);
            }
            
        }
        
    }

    public void unhinge()
    {
        cannonball_velocity *= 5;
        fire_rate = 0;
        cannonball_count *= 4;
        health *= 3;
        GetComponent<SpriteRenderer>().color = Color.black;
    }

    /// <summary>
    /// Resets the game
    /// </summary>
    private void Resetgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        MaybeFire();

        if (health <= 0)
        {
            Death();
        }

        // If player presses reset button reset game
        if (Input.GetAxis("Fire2") == 1)
        {
            Resetgame();
        }

    }
}
