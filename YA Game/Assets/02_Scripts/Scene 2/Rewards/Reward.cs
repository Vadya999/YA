using Plugins.Audio.Core;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class Reward : MonoBehaviour
{
    [Header("Links")] 
    [SerializeField] private Button _rewardButton;
    [SerializeField] private CoinsView _coinsView;
    
    private const int СoefficientReward = 2;
    
    private void OnEnable() => YandexGame.CloseVideoEvent += Rewarded;
    private void OnDisable() => YandexGame.CloseVideoEvent -= Rewarded;


    private void Awake()
    {
        _rewardButton.onClick.AddListener(ShowReward);
    }

    private void Rewarded()
    {
        int currentValue = Game.Instance.coins;
        currentValue *= СoefficientReward;
        Game.Instance.coins = currentValue;
        
        YandexGame.savesData.coinsYG = currentValue ;
        YandexGame.SaveProgress();

        if(Game.Instance.sound) AudioPauseHandler.Instance.UnpauseAudio();
        
        _coinsView.UpdateCounter();
    }


    private void ShowReward()
    {
        YandexGame.RewVideoShow(0);
        
        if(Game.Instance.sound) AudioPauseHandler.Instance.PauseAudio();
    }
    
}
