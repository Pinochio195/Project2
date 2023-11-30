using Lean.Pool;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBrick : MonoBehaviour
{
    [SerializeField] private List<GameObject> _prefabBrick;
    public bool isCheck;
    private void Awake()
    {
        Spawn();
    }
    private void Update()
    {
        Spawn();
    }

    private void Spawn()
    {
        if (isCheck)
        {
            isCheck = false;
            for (int i = 0; i < 20; i++)
            {
                for (int j = 0; j < 20; j++)
                {
                    // Chọn ngẫu nhiên một prefabBrick từ list
                    int randomIndex = Random.Range(0, _prefabBrick.Count);
                    GameObject _brick = LeanPool.Spawn(_prefabBrick[randomIndex], new Vector3(transform.position.x + 1.5f * j, transform.position.y, transform.position.z + 1.5f * i), Quaternion.identity, transform);
                    GameManager.Instance._gameController._listBrickSpawnAddBrick.Add(_brick.GetComponent<AddBrick>());
                }
            }
        }
    }

}