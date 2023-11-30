using System.Collections;
using System.Collections.Generic;
using Ring;
using UnityEngine;

public class MusicManager : RingSingleton<MusicManager>
{
    [HeaderTextColor(.55f, .55f, .55f, headerText = "Music")]
    public MusicController _musicController;
    private void Start()
    {
        PlayerBackGround();
    }

    public void PlayAudio_AddBrick()
    {
        _musicController.audioSource_Brick.PlayOneShot(_musicController.audioClip_AddBrick);
    }
    public void PlayAudio_RemoveBrick()
    {
        _musicController.audioSource_Brick.PlayOneShot(_musicController.audioClip_RemoveBrick);
    }
    public void PlayerBackGround()
    {
        //_musicController.audioSource_BackGround.Play();
    }
}
