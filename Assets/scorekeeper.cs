using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class scorekeeper : MonoBehaviour
{
    /// <summary>
    /// There will only ever be one scorekeeper object
    /// </summary>
    public static scorekeeper scoreobject;

    /// <summary>
    /// Current score
    /// </summary>
    public int score;

    /// <summary>
    /// Score needed to reach goal
    /// </summary>
    public static int score_needed;

    ///<summary>
    /// Swithc to indicate what phase of the game we are in
    /// </summary>
    private bool phase_witch = true;

    /// <summary>
    /// Add points to the score
    /// </summary>
    /// <param name="points">Number of points to add to the score; can be positive or negative</param>
    public static void ScorePoints(int points)
    {
        scoreobject.ScorePointsInternal(points);
    }

    /// <summary>
    /// Text component for displaying the score
    /// </summary>
    private TMP_Text scoredisplay;

    /// <summary>
    /// Initialize scorepbject and scoredisplay.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        scoreobject = this;
        scoredisplay = GetComponent<TMP_Text>();
        ScorePointsInternal(0);
        int score_needed1 = UnityEngine.Random.Range(500, 1001);
        int score_needed2 = UnityEngine.Random.Range(Mathf.RoundToInt(resourcekeeper.resource_needed / 2) * 100, Mathf.RoundToInt(resourcekeeper.resource_needed * 100));
        score_needed = score_needed1 + score_needed2;
    }

    /// <summary>
    /// Internal way to add points to score
    /// </summary>
    /// <param name="delta"></param>
    private void ScorePointsInternal(int delta)
    {
        score += delta;
        scoredisplay.text = score.ToString();
    }

    private void Update()
    {
        if (phase_witch)
        {
            if (resourcekeeper.Resourcesmet())
            {
                phase_witch = false;
                if (score >= score_needed)
                {
                    StartCoroutine(soundplayer.playsuccess());
                }
                else
                {
                    StartCoroutine(soundplayer.playfailure());
                }
            }

        }
        
        
    }
}

