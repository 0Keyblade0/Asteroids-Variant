using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class resourcekeeper : MonoBehaviour
{
    /// <summary>
    /// There will only ever be one resourckeeper object
    /// </summary>
    public static resourcekeeper resourceobject;

    ///<summary>
    /// Current amount of resources collected
    /// </summary>
    public static int resource_collected;

    ///<summary>
    /// Resorces needed to meet to get to end pahse
    /// </summary>
    public static int resource_needed;

    public static bool Resourcesmet()
    {
        return resource_collected >= resource_needed;
    }

    /// <summary>
    /// Add points to the score
    /// </summary>
    public static void CaughtResource()
    {
        resourceobject.CaughtResourceInternal();
    }

    /// <summary>
    /// Text component for displaying the number of resources_collected
    /// </summary>
    private TMP_Text resourcedisplay;

    /// <summary>
    /// Initialize scorepbject and scoredisplay.
    /// </summary>
    // ReSharper disable once UnusedMember.Local
    void Start()
    {
        resourceobject = this;
        resourcedisplay = GetComponent<TMP_Text>();
        resource_collected = 0;
        resource_needed = Random.Range(5, 16);
    }

    /// <summary>
    /// Internal way to increment Gold caught
    /// </summary>
    private void CaughtResourceInternal()
    {
        resource_collected += 1;
        resourcedisplay.text = resource_collected.ToString();
    }
}
