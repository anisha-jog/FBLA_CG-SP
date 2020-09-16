using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_collider_script : MonoBehaviour {

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triggered");
    }
}
