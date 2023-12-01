using UnityEngine;

public class EventBot : MonoBehaviour
{
    [SerializeField] private BotController botController;
    [SerializeField] private Rigidbody _rigidbody;
    [SerializeField] private Collider _collider;

    private void Start()
    {
        botController._botController._nameOldTag = botController.tag;
    }

    public void ReturnIdleCharacter()
    {
        botController._botController.isCheckFallDown = false;
    }

    public void FallBackDown()
    {
        Vector3 direction = (botController.transform.position - PlayerController.Instance.transform.position).normalized;
        _rigidbody.AddForce(Vector3.up * 45 + direction * 20, ForceMode.Impulse);
    }

    public void TurnOffNav()
    {
        botController.tag = Settings.Tag_NotTouchBrick;
        botController._botController.agent.enabled = false;
        _collider.enabled = false;
    }



    public void TurnOnCollider()
    {
        _collider.enabled = true;
        botController.tag = botController._botController._nameOldTag;
        /*if (botController._botController.isCheckFallDown)
        {
            botController._botController.isCheckFallDown = false;
        }*/
    }
}