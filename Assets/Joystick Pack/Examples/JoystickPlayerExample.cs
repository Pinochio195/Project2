using UnityEngine;

public class JoystickPlayerExample : MonoBehaviour
{
    public float speed;
    public VariableJoystick variableJoystick;
    public Rigidbody rb;
    [SerializeField] private Transform _meshPlayer;
    [SerializeField] public Animator _animator;
    public bool isUsing;

    private void Start()
    {
        isUsing = true;
    }

    public void FixedUpdate()
    {
        if (isUsing)
        {
            Vector3 direction = (Vector3.forward * variableJoystick.Vertical + Vector3.right * variableJoystick.Horizontal).normalized;
            //rb.velocity = direction * speed;
            rb.velocity = new Vector3(direction.x * speed, rb.velocity.y, direction.z * speed);
            if (direction != Vector3.zero)
            {
                Quaternion toRotation = Quaternion.LookRotation(direction, Vector3.up);
                _meshPlayer.transform.rotation = toRotation;
                _animator.SetInteger("State", 3);
            }
            else
            {
                _animator.SetInteger("State", 0);
            }
        }
    }
}