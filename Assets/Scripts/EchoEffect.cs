using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoEffect : MonoBehaviour
{
    private float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject echo;
    private Rigidbody2D rb;
    private Transform player;
    void Start()
    {
        rb = GetComponentInParent<Rigidbody2D>();
        player = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if(rb.velocity.x != 0)
        {
            if (timeBtwSpawns <= 0)
            {
                GameObject instance = (GameObject)Instantiate(echo, transform.position, Quaternion.identity);
                instance.transform.localScale = player.localScale;
                Destroy(instance, 0.5f);
                timeBtwSpawns = startTimeBtwSpawns;
            }
            else
            {
                timeBtwSpawns -= Time.deltaTime;
            }
        }
       
    }
}
