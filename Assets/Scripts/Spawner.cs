using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject objReference;
    private float force;
    private Vector3 pos;
    private float waitTime;
    private float timer;
    void Update()
    {
        pos = new Vector3(Random.Range(-1.5f, 1.5f), 1, 0);
        force = Random.Range(9.0f, 12.5f);
        timer += Time.deltaTime;
        waitTime = Random.Range(1.0f, 4.0f);
       
    }

    void FixedUpdate()
    {
        GameObject auxGameObject;
        if (timer > waitTime)
        {
            auxGameObject = Instantiate(objReference, transform.position + pos, transform.rotation);
            auxGameObject.GetComponent<Rigidbody2D>().AddForce(transform.up * force, ForceMode2D.Impulse);
            timer = 0f;
            Debug.Log(pos);
            Debug.Log(force);
        }

    }
}
