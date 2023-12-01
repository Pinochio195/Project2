using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishDestination : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Settings.Tag_Player))
        {
            Debug.Log("Player Winner");
        }
    }
}
