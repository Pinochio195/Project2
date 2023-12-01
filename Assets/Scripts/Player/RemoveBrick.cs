using UnityEngine;

public class RemoveBrick : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshRenderer;
    [SerializeField] private Collider _collider;

    private void OnTriggerEnter(Collider other)
    {
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Settings.Tag_Player) && PlayerController.Instance._playerController._listBringBrick.Count > 0)
        {
            if (PlayerController.Instance._playerController._colorPlayer == Ring.Player_Manager.Color.Blue)
            {
                _meshRenderer.material = GameManager.Instance._gameController._listMaterial[0];
            }
            else if (PlayerController.Instance._playerController._colorPlayer == Ring.Player_Manager.Color.Green)
            {
                _meshRenderer.material = GameManager.Instance._gameController._listMaterial[1];
            }
            else if (PlayerController.Instance._playerController._colorPlayer == Ring.Player_Manager.Color.Red)
            {
                _meshRenderer.material = GameManager.Instance._gameController._listMaterial[3];
            }
            _collider.enabled = false;//Attention
            PlayerController.Instance.RemoveBrick();
        }
        else if (collision.gameObject.CompareTag(Settings.Tag_Bot1))
        {
            if (GameManager.Instance._gameController._listBotController[0]._botController.botName.ToString().Equals( Ring.Player_Manager.Color.Blue.ToString()))
            {
                _meshRenderer.material = GameManager.Instance._gameController._listMaterial[0];
            }
            else if (GameManager.Instance._gameController._listBotController[0]._botController.botName.ToString().Equals(Ring.Player_Manager.Color.Green.ToString()))
            {
                _meshRenderer.material = GameManager.Instance._gameController._listMaterial[1];
            }
            else if (GameManager.Instance._gameController._listBotController[0]._botController.botName.ToString().Equals(Ring.Player_Manager.Color.Red.ToString()))
            {
                _meshRenderer.material = GameManager.Instance._gameController._listMaterial[3];
            }
            _collider.enabled = false;//Attention
            GameManager.Instance._gameController._listBotController[0].RemoveBrick();
        }
    }
}