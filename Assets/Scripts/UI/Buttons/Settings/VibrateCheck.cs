using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VibrateCheck : BaseClickButton
{
    [SerializeField] private Sprite _spriteOn;
    [SerializeField] private Sprite _spriteOff;
    [SerializeField] private Image _image;
    public bool isCheck;

    protected override void OnButtonClick()
    {
        if (!isCheck)
        {
            _image.sprite = _spriteOff;
            GameManager.Instance.OnVibrate();
            MusicManager.Instance.TurnOffMusic();
        }
        else
        {
            _image.sprite = _spriteOn;
            MusicManager.Instance.TurnOnMusic();
            GameManager.Instance.OffVibrate();
        }
        isCheck = !isCheck;
    }
}
