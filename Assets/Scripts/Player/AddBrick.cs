using System.Collections.Generic;
using UnityEngine;

public class AddBrick : MonoBehaviour
{
    [SerializeField] private List<GameObject> trails;
    [SerializeField] private ParticleSystem trail;

    public enum MyColor
    {
        Blue, Green, Red, All
    }

    public MyColor color;
    public Material material;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tag_Player))
        {
            if (color.ToString().Equals(PlayerController.Instance._playerController._colorPlayer.ToString()) || color == MyColor.All)
            {
                PlayerController.Instance.AddBrick(transform, trails, trail);
            }
        }
        else if (other.gameObject.CompareTag(Settings.Tag_Bot1)|| other.gameObject.CompareTag(Settings.Tag_Bot2)|| other.gameObject.CompareTag(Settings.Tag_Bot3))
        {
            for (int i = 0; i < GameManager.Instance._gameController._listBotController.Count; i++)
            {
                if (color.ToString().Equals(GameManager.Instance._gameController._listBotController[i]._botController.botName.ToString()))
                {
                    //Debug.Log(GameManager.Instance._gameController._listBotController[i]._botController.botName.ToString());
                    //Debug.Log(color.ToString());
                    GameManager.Instance._gameController._listBotController[i].AddBrick(transform, trails, trail);  
                }
            }
        }
    }
}