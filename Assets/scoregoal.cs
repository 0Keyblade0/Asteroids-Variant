using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class scoregoal : MonoBehaviour
{
    /// <summary>
    /// There will only ever be one resourcegoal object
    /// </summary>
    public static scoregoal scoregoalobj;

    ///<summary>
    /// Resorces needed to meet to get to end pahse
    /// </summary>
    public static int needed;

    /// <summary>
    /// Text component for displaying the goal
    /// </summary>
    private TMP_Text neededdisplay;


    // Start is called before the first frame update
    void Start()
    {
        scoregoalobj = this;
        neededdisplay = GetComponent<TMP_Text>();
        needed = 0;
    }
    // Update is called once per frame
    void Update()
    {
        needed = scorekeeper.score_needed;
        neededdisplay.text = needed.ToString();
    }
}
