using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sounds : MonoBehaviour
{
    public static AudioClip corteSound, danoSound, jumpSound, morteSound, paredeSound;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        corteSound = Resources.Load<AudioClip>("Corte");
        danoSound = Resources.Load<AudioClip>("dano-01");
        jumpSound = Resources.Load<AudioClip>("Jump_Rever");
        morteSound = Resources.Load<AudioClip>("Morte");
        paredeSound = Resources.Load<AudioClip>("Parede");

        audioSrc = GetComponent<AudioSource> ();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static void PlaySound (string clip)
    {
        switch (clip)
        {
            case "Corte":
                audioSrc.PlayOneShot(corteSound);
                break;
            case "dano-01":
                audioSrc.PlayOneShot(danoSound);
                break;
            case "Jump_Rever":
                audioSrc.PlayOneShot(jumpSound);
                break;
            case "Morte":
                audioSrc.PlayOneShot(morteSound);
                break;
            case "Parede":
                audioSrc.PlayOneShot(paredeSound);
                break;
        }
    }
}
