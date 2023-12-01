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
        _musicController.audioSource_Brick.volume = GameManager.Instance.GetSoundSave();
    }

    public void PlayAudio_AddBrick()
    {
        _musicController.audioSource_Brick.PlayOneShot(_musicController.audioClip_AddBrick);
    }
    public void PlayAudio_RemoveBrick()
    {
        _musicController.audioSource_Brick.PlayOneShot(_musicController.audioClip_RemoveBrick);
    }
    public void TurnOffMusic()
    {
        _musicController.audioSource_Brick.volume = 0;
        GameManager.Instance.SetSoundSave(0);
    }
    public void TurnOnMusic()
    {
        _musicController.audioSource_Brick.volume = 1;
        GameManager.Instance.SetSoundSave(1);
    }
}
