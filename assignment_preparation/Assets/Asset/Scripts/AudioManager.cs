using UnityEngine.Audio;
using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] clips;
    // Start is called before the first frame update
    void Awake()
    {
        foreach (Sound clip in clips)
        {
            clip.volumeClip = gameObject.AddComponent<AudioSource>();
            clip.volumeClip.clip = clip.clip;
            clip.volumeClip.volume = clip.volume;
            clip.volumeClip.pitch = clip.pitch;
        }
    }

    // Update is called once per frame
    public void Play(string name)
    {
       Sound s = Array.Find(clips, clips => clips.name == name);
        s.volumeClip.Play();
    }

    public bool IsPLaying(string name)
    {
        Sound s = Array.Find(clips, clips => clips.name == name);
        return s.volumeClip.isPlaying;
    }
}
