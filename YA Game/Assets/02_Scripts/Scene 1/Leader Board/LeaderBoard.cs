using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using YG;

public class LeaderBoard : MonoBehaviour
{
    [Header("Links")] 
    [SerializeField] private Button _openLeaderBoard;
    [SerializeField] private GameObject _leaderBoardObject;

    [Header("General Settings")] 
    [SerializeField] private float _leaderboardSaveInterval = 3f;

    
    private const string LeaderboardName = "simple";
    
    private void Start()
    {
        _openLeaderBoard.onClick.AddListener((() => OpenCloseLeaderBoard()));

        StartCoroutine(SaveLB());
    }

    private IEnumerator SaveLB()
    {
        while (true)
        {
            YandexGame.NewLeaderboardScores(LeaderboardName, Game.Instance.coins);
            
            yield return new WaitForSeconds(_leaderboardSaveInterval);
        }
    }

    private void OpenCloseLeaderBoard()
    {
        if (_leaderBoardObject.gameObject.activeSelf)
        {
            _leaderBoardObject.gameObject.SetActive(false);
        }
        else
        {
            _leaderBoardObject.gameObject.SetActive(true);
        }
    }

    private void OnApplicationQuit()
    {
        YandexGame.NewLeaderboardScores(LeaderboardName, Game.Instance.coins);
    }
}
