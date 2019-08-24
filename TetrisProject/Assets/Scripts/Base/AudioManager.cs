using System;
using UnityEngine;
using UnityEngine.Audio;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;
    [Range(0f,1f)]
    public float volume = 1f;
    [Range(.1f,3f)]
    public float pitch = 0f;
    public bool loop = false;
    [HideInInspector]
    public AudioSource source;
}

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public Sound[] musicTracks;
    private static AudioManager audioManager;
    public static AudioManager Instance
    {
        get
        {
            if (!audioManager)
            {
                audioManager = FindObjectOfType(typeof(AudioManager)) as AudioManager;
                if (!audioManager)
                    Debug.LogError("Need the AudioManager script on an object in the scene.");
                else
                    audioManager.ManualInit();
            }
            return audioManager;
        }
    }
    
    private void ManualInit()
    {
        foreach (var sound in Instance.sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }

        foreach (var sound in Instance.musicTracks)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            sound.source.volume = sound.volume;
            sound.source.pitch = sound.pitch;
            sound.source.loop = sound.loop;
        }
    }

    public static void PlaySound(string name)
    {
        Array.Find(Instance.sounds, sound => sound.name == name)?.source.Play();
    }

    public static void PlayMusic(string name)
    {
        Array.Find(Instance.musicTracks, track => track.name == name)?.source.Play();
    }

    public static void StopSound(string name)
    {
        Array.Find(Instance.sounds, sound => sound.name == name)?.source.Stop();
    }

    public static void StopMusic(string name)
    {
        Array.Find(Instance.musicTracks, track => track.name == name)?.source.Stop();
    }
}
