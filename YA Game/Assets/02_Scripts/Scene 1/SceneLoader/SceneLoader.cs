using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("Links")] 
    [SerializeField] private Button _nextSceneButton;

    [Header("General Settings")] 
    [SerializeField] private int _sceneIndexToLoad = 1;

    private void Awake()
    {
        _nextSceneButton.onClick.AddListener((() => LoadScene(_sceneIndexToLoad)));
    }

    private void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
