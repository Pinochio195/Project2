using DG.Tweening;
using Lean.Pool;
using Ring;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : RingSingleton<PlayerController>, CharacterInterface
{
    [HeaderTextColor(0.2f, .7f, .8f, headerText = "PlayerCOntroller For Player")] public Player_Manager _playerController;

    // Start is called before the first frame update
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
    }

    #region Move Brick

    public void AddBrick(Transform _brick,List<GameObject> trails,ParticleSystem trail)
    {

        _playerController.inDexDotWeen++;
        float index = _playerController.inDexDotWeen * 0.34f;

        _brick.transform.SetParent(_playerController._parentListTransform);
        _brick.transform.DOLocalMove(new Vector3(0, index, 0), 0.25f).SetEase(Ease.InBounce).OnComplete(() =>
        {
            Debug.Log(_playerController.inDexDotWeen);
            trails.ForEach(trail => { trail.gameObject.SetActive(false); });
            _brick.transform.localEulerAngles = new Vector3(0, 90, 0);
            _playerController._listBringBrick.Add(_brick.gameObject);
            MusicManager.Instance.PlayAudio_AddBrick();
            Vibrate();
            trail.Play();
        });
    }

    private static void Vibrate()
    {
        Handheld.Vibrate();
    }

    public void RemoveBrick()
    {
        MusicManager.Instance.PlayAudio_RemoveBrick();
        LeanPool.Despawn(_playerController._listBringBrick[_playerController._listBringBrick.Count-1]);//lean pool
        _playerController._listBringBrick.RemoveAt(_playerController._listBringBrick.Count - 1);
        _playerController.inDexDotWeen--;
    }
    public void ClearBrick()
    {

    }
    #endregion Move Brick
}