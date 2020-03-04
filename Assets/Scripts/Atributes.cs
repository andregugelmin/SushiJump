using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atributes : MonoBehaviour
{
    SpriteRenderer sprt;
    Color cor;
    private float alpha = 0.5f;
    void Start()
    {
        sprt = GetComponent<SpriteRenderer>();
        cor = new Color(255, 0, 0, alpha);
        sprt.color = cor;
    }

    private void Update()
    {
        cor = new Color(255, 0, 0, alpha);
        sprt.color = cor;
        alpha -= 0.3f*Time.deltaTime;

        if (alpha <= 0)
        {
            Destroy(gameObject);
        }
    }

}
