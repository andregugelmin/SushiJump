using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Life : MonoBehaviour
{
    public int life = 3;
    Transform playerTransform;
    public GameObject score;
    // Start is called before the first frame update
    void Start()
    {
        life = 3;
        playerTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTransform.position.y > 5.3 || playerTransform.position.y < -5)
        {
            restartCurrentScene();
        }
    }

    public void restartCurrentScene()
    {
        life = 3;
        score.gameObject.GetComponent<ScoreScript>().resetScore();
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);        
    }

    public void LoseLife()
    {
        life -= 1;
        Sounds.PlaySound("dano-01");
        if (life <= 0){
            Sounds.PlaySound("Morte");
            restartCurrentScene();
        }
    }
}
