using Plugins.Audio.Core;
using Plugins.Audio.Utils;
using UnityEngine;
using UnityEngine.UI;

public class SoundController : MonoBehaviour
{
    [Header("Links")] 
    [SerializeField] private Button _buttonSound;
    [SerializeField] private Image _buttonImage;
    [SerializeField] private SourceAudio _audioSource;

    [Header("Audio Clips")] 
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
        _buttonSound.onClick.AddListener(SwitchSound);
        
        SetDefaultSoundSettings();
    }

    private void SetDefaultSoundSettings()
    {
        _buttonImage.color = Color.green;
        _audioSource.Play(_clipFon.Key);
        
        Game.Instance.sound = true;
    }

    private void SwitchSound()
    {
        if (_buttonImage.color == Color.green)
        {
            _buttonImage.color = Color.red;
            _audioSource.Stop();
            Game.Instance.sound = false;
        }
        else
        {
            _buttonImage.color = Color.green;
            _audioSource.Play(_clipFon.Key);
            Game.Instance.sound = true;
        }
    }
}