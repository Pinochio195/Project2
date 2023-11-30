using UnityEngine;
using UnityEngine.UI;

public class Sound_Vibrate : BaseClickButton
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
        }
        else
        {
            _image.sprite = _spriteOn;
        }
        isCheck = !isCheck;
    }
}