using System.Collections;
using UnityEngine;

public class TransitionScene : MonoBehaviour
{
    public Animator _animatorTransition;

    public void LoadSceneAsync()
    {
        Debug.Log(GameManager.Instance._gameController._nameScene);
        if (GameManager.Instance._gameController._nameScene.Equals("4"))
        {
            GameManager.Instance._gameController._nameScene = "1";
            GameManager.Instance.SetTextNameLevel("1");
        }
        StartCoroutine(LoadPrefabCoroutine(GameManager.Instance._gameController.nameScene));
    }

    private IEnumerator LoadPrefabCoroutine(string prefabPath)
    {
        ResourceRequest request = Resources.LoadAsync(prefabPath);
        GameManager.Instance.RemoveScene();
        while (!request.isDone)
        {
            yield return null;
        }
        GameObject prefab = request.asset as GameObject;

        if (prefab != null)
        {
            var scene = Instantiate(prefab);
            GameManager.Instance.AddScene(scene);
            GameManager.Instance.SetTextNameLevel(GameManager.Instance._gameController.nameScene);
            yield return new WaitForEndOfFrame(); // Wait until prefab instantiation has completed
            _animatorTransition.SetTrigger(Settings.Animation_Transition);
        }
    }

    public void StartOffScene()
    {
        _animatorTransition.SetTrigger(Settings.Animation_Transition);
    }


    public void LoadPLayerRestart()
    {
        //UiManager.Instance.TurnOnUIInGame();
        //PlayerController.Instance.ClearBrick();
        //GameManager.Instance._gameController._player.transform.position = GameManager.Instance._gameController._startPosition.position;
        // Set góc cho object con
        //float targetXAngle = 180f;
        //float targetYAngle = -30f;
        //float targetZAngle = -180f;
        //Vector3 targetRotation = new Vector3(targetXAngle, targetYAngle, targetZAngle);
        //PlayerController.Instance._playerComponent._modelPlayer.transform.rotation = Quaternion.Euler(targetRotation);
    }
}