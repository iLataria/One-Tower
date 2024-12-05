using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private AudioSource[] fireSounds;
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            Debug.Log("Space");
            PlaySound();
        }
    }

    public void PlaySound()
    {
        int soundNumber = Random.Range(0, fireSounds.Length);

        fireSounds[soundNumber].Play();
    }
}
