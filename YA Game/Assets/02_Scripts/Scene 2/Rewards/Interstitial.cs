using Plugins.Audio.Core;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Interstitial : MonoBehaviour
{
    [Header("Links")] 
    [SerializeField] private Button _interstitialButton;

    private void OnEnable()
    {
        YandexGame.OpenFullAdEvent += FullOpen;
        YandexGame.CloseFullAdEvent += FullClose;
    }


    private void Start()
    {
        _interstitialButton.onClick.AddListener((() => YandexGame.FullscreenShow()));
    }

    private void FullOpen()
    {
        if(Game.Instance.sound) AudioPauseHandler.Instance.PauseAudio();
    }

    private void FullClose()
    {
        if(Game.Instance.sound) AudioPauseHandler.Instance.UnpauseAudio();
    }

    private void OnApplicationQuit()
    {
        YandexGame.OpenFullAdEvent -= FullOpen;
        YandexGame.CloseFullAdEvent -= FullClose;
    }
}
