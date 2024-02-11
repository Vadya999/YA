using System.Collections;
using TMPro;
using UnityEngine;

public class CoinsView : MonoBehaviour
{
    [Header("Links")]
    [SerializeField] private TextMeshProUGUI _coisCounter;

    [Header("General Settings")] 
    [SerializeField] private float _viewScoreDelay = 0.4f;


    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_viewScoreDelay);
        _coisCounter.text = Game.Instance.coins.ToString();
    }

    public void UpdateCounter()
    {
        _coisCounter.text = Game.Instance.coins.ToString();
    }
}
