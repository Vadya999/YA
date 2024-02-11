using UnityEngine;
using UnityEngine.UI;

public class AddCoins : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private CoinsView _coinsView;
    [SerializeField] private Button _addCoinsButton;
    [SerializeField] private Button _cleanCoinsButton;
    
    [Header("General Settings")]
    [SerializeField] private int _addCount;
    
    private void Awake()
    {
        _addCoinsButton.onClick.AddListener(AddCoin);
        _cleanCoinsButton.onClick.AddListener(CleanCoin);
    }

    private void CleanCoin()
    {
        Game.Instance.CleanSavedData();
        _coinsView.UpdateCounter();
    }

    private void AddCoin()
    {
        Game.Instance.coins += _addCount;
        _coinsView.UpdateCounter();
    }
    
}
