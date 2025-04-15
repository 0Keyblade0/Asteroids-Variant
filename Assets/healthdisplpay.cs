using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class healthdisplpay : MonoBehaviour
{
    /// <summary>
    /// There will only ever be one resourcegoal object
    /// </summary>
    public static healthdisplpay healthdisobj;

    ///<summary>
    /// Health value
    /// </summary>
    public static int health;

    /// <summary>
    /// Text component for displaying the goal
    /// </summary>
    private TMP_Text healthdisplay1;


    // Start is called before the first frame update
    void Start()
    {
        healthdisobj = this;
        healthdisplay1 = GetComponent<TMP_Text>();
        health = 0;
    }
    // Update is called once per frame
    void Update()
    {
        health = FindObjectOfType<player>().health;
        healthdisplay1.text = health.ToString();
    }
}
