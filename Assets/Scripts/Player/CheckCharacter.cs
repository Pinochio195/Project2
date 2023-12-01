using UnityEngine;

public class CheckCharacter : MonoBehaviour
{
    [SerializeField]BotController botController;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tag_Bot1) || other.gameObject.CompareTag(Settings.Tag_Bot2) || other.gameObject.CompareTag(Settings.Tag_Bot3))
        {
        }
        else if (other.gameObject.CompareTag(Settings.Tag_Player))
        {
            botController._botController.isCheckFallDown = true;
        }
    }
}