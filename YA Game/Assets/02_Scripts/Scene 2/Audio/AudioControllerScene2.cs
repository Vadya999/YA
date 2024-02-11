using System;
using System.Collections;
using System.Collections.Generic;
using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using UnityEngine;

public class AudioControllerScene2 : MonoBehaviour
{
    [Header("Links")] 
    [SerializeField] private SourceAudio _audioSource;

    [Header("Audio Keys")] 
    [SerializeField] private AudioDataProperty _clipFon;
    [SerializeField] private AudioDataProperty _clipTab;

    public void PlayTab()
    {
        if (Game.Instance.sound)
        {
            _audioSource.PlayOneShot(_clipTab.Key);
        }
    }

    private void Start()
    {
        if (Game.Instance.sound)
        {
            _audioSource.Play(_clipFon.Key);
        }
    }
}
