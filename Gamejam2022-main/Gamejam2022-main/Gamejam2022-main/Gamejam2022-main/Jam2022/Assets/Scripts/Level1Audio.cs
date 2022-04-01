using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelAudio : MonoBehaviour
{
    public AudioClip MusicClip;
    public AudioSource MusicSource;
    public Slider volume_slider;

    private float volume = 1f;

    void Start()
    {
        volume = PlayerPrefs.GetFloat("volume", 1f);
        volume_slider.value = volume;
        MusicSource.volume = volume_slider.value;

        MusicSource.clip = MusicClip;
    }

    void Update()
    {
        SoundSlider();
    }

    public void SoundSlider()
    {
        MusicSource.volume = volume_slider.value;

        volume = volume_slider.value;
        PlayerPrefs.SetFloat("volume", volume);
    }
}
