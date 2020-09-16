using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollect : MonoBehaviour
{
    private static bool isCollected;

    // Start is called before the first frame update
    void Start()
    {
        isCollected = false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown("x"))
        {
            Destroy(gameObject);
            isCollected = true;
            MenuNav.addItemToInventory();
        }
    }

    public static bool getCollected()
    {
        return isCollected;
    }
}
