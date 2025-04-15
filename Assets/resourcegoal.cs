using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class resourcegoal : MonoBehaviour
{
    /// <summary>
    /// There will only ever be one resourcegoal object
    /// </summary>
    public static resourcegoal resourcegoalobj;

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
        resourcegoalobj = this;
        neededdisplay = GetComponent<TMP_Text>();
        needed = 0;
    }

    private void Update()
    {
        needed = resourcekeeper.resource_needed;
        neededdisplay.text = needed.ToString();
    }
}
