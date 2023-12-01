using Ring;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameManager : RingSingleton<GameManager>
{
    [HeaderTextColor(0.2f, .7f, .8f, headerText = "CheckBox For Player")] public GameController _gameController;

    private void Start()
    {
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60; 
        _gameController.nameScene = GetSceneSave();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    #region Scene

    #region List Scene

    public void AddScene(GameObject scene)
    {
        _gameController._listScene.Add(scene);
    }

    public void RemoveScene()
    {
        if (_gameController._listScene.Count >= 1)
        {
            Destroy(_gameController._listScene[0].gameObject);
            _gameController._listScene.RemoveAt(_gameController._listScene.Count - 1);
        }
    }

    public void ClearScene()
    {
        _gameController._listScene.Clear();
    }

    #endregion List Scene

    #endregion Scene

    #region Save
    public void OnVibrate()
    {
        PlayerPrefs.SetInt(Settings.Vibrate, 1);
    }
    public void OffVibrate()
    {
        PlayerPrefs.SetInt(Settings.Vibrate, 0);
    }
    //sound
    public float GetSoundSave()
    {
        return PlayerPrefs.GetFloat(Settings.Sound, 1);
    }

    public void SetSoundSave(float volum)
    {
        PlayerPrefs.SetFloat(Settings.Sound, volum);
    }

    //scene
    public string GetSceneSave()
    {
        string name = PlayerPrefs.GetString(Settings.Name_Scene, "1");
        SetTextNameLevel(name);
        return name;
    }

    public void SetTextNameLevel(string name)
    {
        UiManager.Instance._UiController._textLevel.text = $"Leveel {name}";
    }

    public void SetSceneSave(string name)
    {
        PlayerPrefs.SetString(Settings.Name_Scene, name);
    }

    //coint
    public int GetGold()
    {
        return PlayerPrefs.GetInt(Settings.GoldSave, 0);
    }

    public void SetGold()
    {
        int gold = PlayerPrefs.GetInt(Settings.GoldSave, 0);
        gold += 50;
        UiManager.Instance._UiController._textGold.text = gold.ToString();
        PlayerPrefs.SetInt(Settings.GoldSave, gold);
    }

    #endregion Save

    public void Vibrate()
    {
        Handheld.Vibrate();
    }

    #region Method Game

    public bool CheckUIReturn()
    {
        #region Kiểm tra xem có nhấn va UI nào không , nếu không thì return

#if UNITY_EDITOR || UNITY_STANDALONE
        if (EventSystem.current.IsPointerOverGameObject())
        {
            GameObject selectedObj = EventSystem.current.currentSelectedGameObject;
            if (selectedObj != null)
            {
                return true;
            }
        }
#else
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
            {
                GameObject selectedObj = EventSystem.current.currentSelectedGameObject;
                if (selectedObj != null)
                {
                    return true;
                }
            }
        }
#endif

        #endregion Kiểm tra xem có nhấn va UI nào không , nếu không thì return

        return false;
    }

    #endregion Method Game
}