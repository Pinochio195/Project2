using System.Collections.Generic;
using UnityEngine;

public class AddBrick : MonoBehaviour
{
    [SerializeField] private List<GameObject> trails;
    [SerializeField] private ParticleSystem trail;
    [SerializeField] public MeshRenderer mesh;
    public Rigidbody _rigidbody;
    public bool isCheck;

    public enum MyColor
    {
        Blue, Green, Red, All
    }

    public MyColor color;
    public Material material;
    public Material materialAll;

    private void OnEnable()
    {
        isCheck = false;
    }

    private void Update()
    {
        if (transform.parent == null && isCheck)
        {
            isCheck = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!isCheck)
        {
            if (other.gameObject.CompareTag(Settings.Tag_Player))
            {
                if (color.ToString().Equals(PlayerController.Instance._playerController._colorPlayer.ToString()) || color == MyColor.All)
                {
                    isCheck = true;
                    PlayerController.Instance.AddBrick(this, mesh, trails, trail);
                }
            }
            else if (other.gameObject.CompareTag(Settings.Tag_Bot1) || other.gameObject.CompareTag(Settings.Tag_Bot2) || other.gameObject.CompareTag(Settings.Tag_Bot3))
            {
                for (int i = 0; i < GameManager.Instance._gameController._listBotController.Count; i++)
                {
                    if (color.ToString().Equals(GameManager.Instance._gameController._listBotController[i]._botController.botName.ToString()))
                    {
                        mesh.material = material;
                        isCheck = true;
                        GameManager.Instance._gameController._listBotController[i].AddBrick(this, mesh, trails, trail);
                        Debug.Log(other.gameObject.name);
                    }
                }
            }
        }
    }
}