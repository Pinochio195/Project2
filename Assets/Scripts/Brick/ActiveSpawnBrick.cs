using UnityEngine;

public class ActiveSpawnBrick : MonoBehaviour
{
    [SerializeField] private SpawnBrick _spawnBrick;
    [SerializeField] private Collider _collider;
    [SerializeField] private ActiveSpawnBrick _activeSpawnBrick;
    public bool isCheck;

    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tag_Player) || other.gameObject.CompareTag(Settings.Tag_Bot1) || other.gameObject.CompareTag(Settings.Tag_Bot2) || other.gameObject.CompareTag(Settings.Tag_Bot3))
        {
            if (!isCheck)
            {
                isCheck = true;
                if (_activeSpawnBrick != null)
                {
                    _activeSpawnBrick.isCheck = true;
                }
                _spawnBrick.isCheck = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tag_Player))
        {
            _collider.isTrigger = false;
        }
    }
}