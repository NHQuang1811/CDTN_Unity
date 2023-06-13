using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio; 
using UnityEngine;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sound[] musicSounds, sfxSounds;
    [SerializeField] private AudioSource musicSource, sfxSource;
    [SerializeField] private Image BGMButton;
    [SerializeField] private Image BGMMuteButton;
    [SerializeField] private Image SFXButton;
    [SerializeField] private Image SFXMuteButton;
    private bool BGMmuted = false;
    private bool SFXmuted = false;

    private void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this; 
            DontDestroyOnLoad(gameObject); 
        } 
        else 
        { 
            Destroy(gameObject); 
        }
    }

    private void Start()
    {
        if (!PlayerPrefs.HasKey("SFXmuted") && !PlayerPrefs.HasKey("BGMmuted"))
        {
            PlayerPrefs.SetInt("SFXmuted", 0);
            PlayerPrefs.SetInt("BGMmuted", 0);
            Load();
        }
        else
        {
            Load(); 
        }
        UpdateButtonIcon();
    }

    public void PlayMusic(string name)
    {
        Sound s = Array.Find(musicSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            musicSource.clip = s.clip;
            musicSource.volume = s.volume;
            musicSource.pitch = s.pitch;
            musicSource.loop = s.Looping;
            musicSource.Play();
        }
    }
    public void PlaySFX(string name)
    {
        Sound s = Array.Find(sfxSounds, x => x.name == name);
        if (s == null)
        {
            Debug.Log("Sound not found");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.volume = s.volume;
            sfxSource.pitch = s.pitch;
            sfxSource.loop = s.Looping;
            sfxSource.spatialBlend = s.SpatialBlend;
            sfxSource.PlayOneShot(s.clip, s.volume);
        }
    }
    public void BGMpress()
    {
        if (BGMmuted == false)
        {
            BGMmuted = true;
            musicSource.mute = true;
        }
        else
        {
            BGMmuted = false;
            musicSource.mute = false;
        }

        Save();
        UpdateButtonIcon();
    }
    public void SFXpress()
    {
        if (SFXmuted == false)
        {
            SFXmuted = true;
            sfxSource.mute = true;
        }
        else
        {
            SFXmuted = false;
            sfxSource.mute = false;
        }

        Save();
        UpdateButtonIcon();
    }
    private void UpdateButtonIcon()
    {
        if (BGMmuted == false)
        {
            BGMButton.enabled = true;
            BGMMuteButton.enabled = false;
        }
        else
        {
            BGMButton.enabled = false;
            BGMMuteButton.enabled = true;
        }

        if (SFXmuted == false)
        {
            SFXButton.enabled = true;
            SFXMuteButton.enabled = false;
        }
        else
        {
            SFXButton.enabled = false;
            SFXMuteButton.enabled = true;
        }
    }
    private void Load()
    {
        SFXmuted = PlayerPrefs.GetInt("SFXmuted") == 1;
        BGMmuted = PlayerPrefs.GetInt("BGMmuted") == 1;
    }
    private void Save()
    {
        PlayerPrefs.GetInt("SFXmuted", SFXmuted ? 1 : 0);
        PlayerPrefs.GetInt("BGMmuted", BGMmuted ? 1 : 0);
    }
}
