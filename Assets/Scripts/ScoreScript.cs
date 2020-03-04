using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
    public static int scorevalue = 0;
    Text score;
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + scorevalue;
    }
    public void resetScore()
    {
        scorevalue = 0;
    }
    public static void getCombo(int combo)
    {
        for(int i=1; i<=combo; i++)
        {
            scorevalue += 10 * i;
        }
    }
        
}
