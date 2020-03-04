using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class purungo : MonoBehaviour
{
    public float force;
    public Color color;

    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        GetComponent<SpriteRenderer>().color = color;
        force = Random.Range(10.5f, 12.5f);
        GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
        player = GameObject.Find("Player");
    }
  
    void FixedUpdate()
    {
        Rigidbody2D rb;
        rb = GetComponent<Rigidbody2D>();
        if (rb.velocity.y <0 && transform.position.y < -5.5f)
        {
            FindObjectOfType<ShakeBehavior>().TriggerShake();
            player.GetComponent<Life>().LoseLife();
            Destroy(gameObject);            
        }
    }  
}
