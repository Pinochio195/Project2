using UnityEngine;
using UnityEngine.UI;

public class SoundMusic : BaseClickButton
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
            MusicManager.Instance.TurnOffMusic();
        }
        else
        {
            _image.sprite = _spriteOn;
            MusicManager.Instance.TurnOnMusic();
        }
        isCheck = !isCheck;
    }
}