using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] private Rigidbody _rigidbody;
    public void FallBackDown()
    {
        _rigidbody.velocity = Vector3.up * 10;
        Debug.Log(_rigidbody.velocity);
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            FallBackDown();
        }
    }
}
