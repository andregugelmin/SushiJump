using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Button_Play()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void Button_Exit()
    {
        Application.Quit();
    }
}
