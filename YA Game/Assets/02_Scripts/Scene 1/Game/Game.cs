using System.Collections;
using UnityEngine;
using YG;

public class Game : MonoBehaviour
{
    [HideInInspector] public int coins;
    [HideInInspector] public bool sound;

    [Header("General Settings")] 
    [SerializeField] private float _saveDtaInterval = 1f;

    private static Game _instance;

    public static Game Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<Game>();

                if (_instance == null)
                {
                    GameObject singletonObject = new GameObject("Game");
                    _instance = singletonObject.AddComponent<Game>();
                }
            }

            return _instance;
        }
    }

    public void CleanSavedData()
    {
        YandexGame.ResetSaveProgress();
        GetSavedData();
    }

    private void Start()
    {
        DontDestroyOnLoad(gameObject);
        
        GetSavedData();

        StartCoroutine(SaveDataCor());

    }

    private void SaveData()
    {
        YandexGame.savesData.coinsYG = coins;
        YandexGame.SaveProgress();
    }

    private IEnumerator SaveDataCor()
    {
        while (true)
        {
            SaveData();
            yield return new WaitForSeconds(_saveDtaInterval);
        }
    }

    private void GetSavedData()
    {
        if (YandexGame.SDKEnabled)
        {
            coins = YandexGame.savesData.coinsYG;
        }
        else
        {
            Debug.Log("SDKEnabled failed");
        }
        
    }

    private void OnApplicationQuit()
    {
        SaveData();
    }
}
