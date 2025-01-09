using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] _fireSounds;

    private AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }
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
        int soundNumber = Random.Range(0, _fireSounds.Length);

        _audioSource.clip=_fireSounds[soundNumber];
        _audioSource.Play();
    }
}
