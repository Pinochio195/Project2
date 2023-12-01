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

    public void AddBrick(AddBrick addbrick , MeshRenderer mesh, List<GameObject> trails, ParticleSystem trail)
    {
        _playerController.inDexDotWeen++;
        float index = _playerController.inDexDotWeen * 0.34f;
        mesh.material = _playerController._materialPlayer;
        addbrick.transform.SetParent(_playerController._parentListTransform);
        addbrick.transform.DOLocalMove(new Vector3(0, index, 0), 0.25f).SetEase(Ease.InBounce).OnComplete(() =>
        {
            //Debug.Log(_playerController.inDexDotWeen);
            trails.ForEach(trail => { trail.gameObject.SetActive(false); });
            addbrick._rigidbody.useGravity = false;
            addbrick._rigidbody.isKinematic = true;
            addbrick._rigidbody.transform.localEulerAngles = new Vector3(0, 90, 0);
            _playerController._listBringBrick.Add(addbrick);
            MusicManager.Instance.PlayAudio_AddBrick();
            Vibrate();
            trail.Play();
        });
    }

    public void Vibrate()
    {
        if (PlayerPrefs.GetInt(Settings.Vibrate, 0) == 1)
        {
            Handheld.Vibrate();
        }
    }

    public void RemoveBrick()
    {
        MusicManager.Instance.PlayAudio_RemoveBrick();
        LeanPool.Despawn(_playerController._listBringBrick[_playerController._listBringBrick.Count - 1]);//lean pool
        _playerController._listBringBrick.RemoveAt(_playerController._listBringBrick.Count - 1);
        _playerController.inDexDotWeen--;
    }

    public void ClearBrick()
    {
    }

    #endregion Move Brick
    
}