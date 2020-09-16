using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControl : MonoBehaviour
{
    [SerializeField]
    private Transform[] pictures;

    public static bool youWin;

    public void Start()
    {
        youWin = true;
    }

    private void Update()
    {
        foreach(Transform t in pictures)
        {
            if (t.rotation.z != 0)
                youWin = false;
        }
    }
}
