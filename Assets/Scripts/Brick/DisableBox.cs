using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableBox : MonoBehaviour
{
    [SerializeField] Collider collider;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Settings.Tag_Player))
        {
            collider.enabled = false;
        }
    }
}
