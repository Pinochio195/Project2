using UnityEngine;

public class SettingButton : BaseClickButton
{
    [SerializeField] private Animator _settings;

    protected override void OnButtonClick()
    {
        _settings.SetTrigger("Transition");
    }
}