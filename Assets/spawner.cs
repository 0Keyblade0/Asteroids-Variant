using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.SceneManagement;

public class spawner : MonoBehaviour
{
    /// <summary>
    /// Object to spawn
    /// </summary>
    public GameObject prefab;

    /// <summary>
    /// Seconds between spawn operations
    /// </summary>
    public float spawninterval = 10;

    /// <summary>
    /// How many units of free space to try to find around the spawned object
    /// </summary>
    public float FreeRadius = 10;

    /// <summary>
    /// The time of the next spawn
    /// </summary>
    public float nextspawn;

    ///<summary>
    /// Number of rocks to spawn
    /// </summary>
    public int numrocks = 2;

    /// <summary>
    /// World coordinates of the top-left corner of the screen.
    /// </summary>
    public static Vector2 Min;
    /// <summary>
    /// World coordinates of the upper-right x2 corner of the screen
    /// </summary>
    public static Vector2 Max;

    /// <summary>
    /// Check if we need to spawn and if so, do so.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Update()
    {
        if (CheckPlayer())
        {
            Invoke("Resetgame", 7);
        }

        if (Time.time >= nextspawn)
        {
            for (int i = 0; i < numrocks; i++)
            {
                var free_point = RandomFreePoint(FreeRadius);
                Instantiate(prefab, free_point, Quaternion.identity);
            }

            if (FindObjectOfType<player>().fire_rate == 0)
            {
                numrocks += 5;
            } else
            {
                numrocks += 1;
            }
            
            nextspawn += spawninterval;
        }

    }

    /// <summary>
    /// Find the bounds of spwan locations
    /// </summary>
    private void Start()
    {
        Min = Camera.main.ScreenToWorldPoint(new Vector2(0, Screen.height));
        Max = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height * 2));
        nextspawn = Time.time;

        if (FindObjectOfType<player>().fire_rate == 0)
        {
            spawninterval = 5;
        }
    }

    /// <summary>
    /// Random point in the spawn bounds
    /// </summary>
    public static Vector2 RandomPoint
        => new Vector2(Random.Range(Min.x, Max.x),
            Random.Range(Min.y, Max.y));

    /// <summary>
    /// Find a random point in the spawn space that doesn't have anything within radius units
    /// Gives random location if one cannot be found with sufficient emptiness.
    /// </summary>
    public static Vector2 RandomFreePoint(float radius)
    {
        var position = RandomPoint;
        for (var i = 0; i < 50 && !PointFree(position, radius); i++)
            position = RandomPoint;
        return position;
    }

    /// <summary>
    /// Check if the specified point is free of any objects for a distance of radius.
    /// </summary>
    public static bool PointFree(Vector2 position, float radius)
    {
        return Physics2D.CircleCast(position, radius, Vector2.up, 0);
    }

    ///<summary>
    /// Resets Game
    /// </summary>
    public void Resetgame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /// <summary>
    /// Restart game if there are no more player objects
    /// </summary>
    private bool CheckPlayer()
    {
        return (FindObjectOfType<player>() == null);

    }

}

