using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [SerializeField]
    private AudioClip[] playlist;

    private int musicIndex = 0;

    [SerializeField]
    private AudioSource audioSource;
    // Start is called before the first frame update
    void Start()
    {
        audioSource.clip = playlist[0];
        audioSource.Play();

    }

    // Update is called once per frame
    void Update()
    {
        if (!audioSource.isPlaying || Input.GetKeyDown(KeyCode.M))
        {
            PlayNextSong();
        }
    }

    void PlayNextSong()
    {
        musicIndex = (musicIndex+1) % playlist.Length;
        audioSource.clip = playlist[musicIndex];
        audioSource.Play();

    }
}
