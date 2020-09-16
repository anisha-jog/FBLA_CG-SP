using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchRotate : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            transform.Rotate(0f, 0f, 90f);
    }
}
