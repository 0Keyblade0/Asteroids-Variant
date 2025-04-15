using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resource : MonoBehaviour
{
    /// <summary>
    /// Resource Body
    /// </summary>
    public Rigidbody2D resourcebody;

    ///<summary>
    /// Resource prefab
    /// </summary>
    public GameObject resourceprefab;

    /// <summary>
    /// Is this resource gold
    /// </summary>
    public bool isgold;

    // Start is called before the first frame update
    void Start()
    {
        resourcebody = GetComponent<Rigidbody2D>();
        resourcebody.gravityScale = 0.01f;
        gameObject.transform.localScale *= Random.Range(1, 5);
        gameObject.tag = "resource";
        // isgold = false;
    }

    public void ChangeToType( int resource_type)
    {
        if (resource_type == 1)
        {
            isgold = true;

        } else if (resource_type == 0) 
        {
            isgold = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.gameObject.tag != "rock") 
        {
            Destroy(gameObject);
        }
            
    }

    private void OnBecameInvisible()
    {
        if (gameObject.transform.localPosition.y < 0)
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
