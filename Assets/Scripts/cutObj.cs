using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cutObj : MonoBehaviour
{

    public Rigidbody2D player;
    public GameObject particles;
    public GameObject particles2;
    public GameObject inksplash;
    public float timeScaleValue;
    private float timeClock;
    public float timeScaleDuration;
    private bool moving;
    public int combo;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.velocity.x != 0 && player.velocity.y != 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (timeClock > 0)
        {
            timeClock -= 0.1f;
            Time.timeScale = timeScaleValue;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }
        else{
            Time.timeScale = 1.0f;
            Time.fixedDeltaTime = 0.02f * Time.timeScale;
        }

        if (!moving)
        {
            ScoreScript.getCombo(combo);
            combo = 0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (moving && collision.gameObject.tag == "Obj")
        {
            combo += 1;
            Destroy(collision.gameObject);


            Instantiate(particles, collision.transform.position, Quaternion.identity);

            GameObject ink;
            ink = Instantiate(inksplash, new Vector3(collision.transform.position.x, collision.transform.position.y, 0.5f), Quaternion.identity);
            SpriteRenderer sprRend = collision.GetComponent<SpriteRenderer>();
            ink.GetComponent<SpriteRenderer>().color = sprRend.color;

            timeClock = timeScaleDuration;
        }
        if (moving && collision.gameObject.tag == "baiacu")
        {
            Destroy(collision.gameObject);
            Instantiate(particles2, collision.transform.position, Quaternion.identity);
            GameObject ink;
            ink = Instantiate(inksplash, new Vector3(collision.transform.position.x, collision.transform.position.y, 0.5f), Quaternion.identity);
            SpriteRenderer sprRend = collision.GetComponent<SpriteRenderer>();
            ink.GetComponent<SpriteRenderer>().color = sprRend.color;
            FindObjectOfType<ShakeBehavior>().TriggerShake();
            player.GetComponent<Life>().LoseLife();
            
        }
    }
}
