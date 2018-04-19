using UnityEngine;
using UnityEngine.Audio;
using System;



public class Sound : MonoBehaviour {
    // Audio stuff
    [Range(0f, 1f)]
    public float masterVolume = 1f;
    public AudioClip audioClip1;
    private AudioSource audioSrc1;
    [Range(0f, 1f)]
    public float Volume1 = 1f;
    [Range(0f, 1f)]
    public float VolumeVariance1 = 0f;
    [Range(.1f, 3f)]
    public float Pitch1 = 1f;
    [Range(0f, 1f)]
    public float pitchVariance1 = 0f;


    void Awake()
    {
        audioSrc1 = gameObject.AddComponent<AudioSource>();
        audioSrc1.clip = audioClip1;
        audioSrc1.volume = Volume1 * masterVolume;
        audioSrc1.pitch = Pitch1;
        audioSrc1.spatialBlend = 1;
    }

    public void playSound()
    {
        audioSrc1.volume = Volume1 * (1f + UnityEngine.Random.Range(VolumeVariance1 / 2f, VolumeVariance1 / 2f));
        audioSrc1.pitch = Pitch1 * (1f + UnityEngine.Random.Range(pitchVariance1 / 2f, pitchVariance1 / 2f));
        audioSrc1.Play();
    }

}

/*    // Audio stuff
    [Range(0f, 1f)]
    public float masterVolume = 1f;
    public AudioClip audioClip1;
    private AudioSource audioSrc1;
    [Range(0f, 1f)]
    public float Volume1 = 1f;
    [Range(0f, 1f)]
    public float VolumeVariance1 = 0f;
    [Range(.1f, 3f)]
    public float Pitch1 = 1f;
    [Range(0f, 1f)]
    public float Variance1 = 0f;


    void Awake () {
        audioSrc1 = gameObject.AddComponent<AudioSource>();
        audioSrc1.clip = audioClip1;
        audioSrc1.volume = Volume1 * masterVolume;
        audioSrc1.pitch = Pitch1;
        audioSrc1.spatialBlend = 1;
    }
	
	void public playSound (AudioClip name) {

        // Allows to play with broken sounds
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "was not found");
            return;
        }

        name.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        name.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
        name.source.Play();
    }

    public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup mixerGroup;
    public Sound[] sounds;
    void Awake()
    {
        foreach (Sound s in sounds)
        {
            s.name = name;
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.loop = s.loop;
            s.source.spatialBlend = s.spatialBlend;
            s.source.spread = s.spread;
            s.source.minDistance = s.minDistance;
            s.source.maxDistance = s.maxDistance;
            s.source.outputAudioMixerGroup = mixerGroup;
        }
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, Sound => Sound.name == name);

        // Allows to play with broken sounds
        if (s == null)
        {
            Debug.LogWarning("Sound: " + name + "was not found");
            return;
        }

        s.source.volume = s.volume * (1f + UnityEngine.Random.Range(-s.volumeVariance / 2f, s.volumeVariance / 2f));
        s.source.pitch = s.pitch * (1f + UnityEngine.Random.Range(-s.pitchVariance / 2f, s.pitchVariance / 2f));
        s.source.Play();

    }

}
*/
