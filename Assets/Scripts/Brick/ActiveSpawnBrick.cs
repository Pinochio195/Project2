using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveSpawnBrick : MonoBehaviour
{
    [SerializeField] private SpawnBrick _spawnBrick;
    [SerializeField] private Collider _collider;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tag_Player))
        {
            _spawnBrick.isCheck = true;
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
