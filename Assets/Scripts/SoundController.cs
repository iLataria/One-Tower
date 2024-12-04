using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] fireSounds;
    
    void Update()
    {
        PlaySound();
    }

    public void PlaySound()
    {
      int soundNumber=Random.Range(0, fireSounds.Length);

        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Space");
            fireSounds[soundNumber].Play();
        }
        if (Input.GetKey(KeyCode.P))
        {
            Debug.Log("P");
            fireSounds[soundNumber].Stop();
        }
     

    }
}
