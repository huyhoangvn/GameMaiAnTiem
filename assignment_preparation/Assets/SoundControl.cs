using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundControl : MonoBehaviour
{
    public AudioManager audio;
    // Start is called before the first frame update
    void Start()
    {
        audio = FindObjectOfType<AudioManager>();
        audio.Play("intro");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
