using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDestination : MonoBehaviour
{
    [SerializeField] Transform _winPosition;
    [SerializeField] JoystickPlayerExample _stickPlayer;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Settings.Tag_Player))
        {
            Debug.Log("Player Winner");
            _stickPlayer.isUsing = false;
            _stickPlayer._animator.SetInteger("State", 1);
            _stickPlayer._animator.applyRootMotion = true;
            collision.transform.position = _winPosition.position;
            
            GameManager.Instance._gameController.meshRotation.transform.localEulerAngles = new Vector3(0f,180f,0f);
            UiManager.Instance._UiController._winGameObject.SetActive(true);
            if (PlayerController.Instance._playerController._listBringBrick.Count > 0)
            {
                Debug.Log(PlayerController.Instance._playerController._listBringBrick.Count);
                for (int i = 0; i < PlayerController.Instance._playerController._listBringBrick.Count; i++)
                {
                    var a = PlayerController.Instance._playerController._listBringBrick[i]._rigidbody;
                    if (a != null)
                    {
                        a.transform.SetParent(null);
                        a.isKinematic = false;
                        a.useGravity = true;
                        a.AddExplosionForce(1900, PlayerController.Instance.transform.position, 1.5f);
                    }
                    if (i == PlayerController.Instance._playerController._listBringBrick.Count - 1)
                    {
                        PlayerController.Instance._playerController._listBringBrick[i].collider.enabled = false;
                        PlayerController.Instance._playerController._listBringBrick.Clear();
                        PlayerController.Instance._playerController.inDexDotWeen = 0;
                    }
                }

            }
        }
    }
}
