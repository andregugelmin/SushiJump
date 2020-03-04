using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeUI : MonoBehaviour
{
    public int lifeValue;
    Text life;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        life = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        lifeValue = player.gameObject.GetComponent<Life>().life;
        life.text = "Lifes: " + lifeValue;
    }    
}