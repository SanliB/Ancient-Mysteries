using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoSingleton<Key>
{

    public bool status = false;
    private void OnMouseDown()
    {
        status = true;
        if (gameObject.tag == "Key")
        {
            gameObject.SetActive(false);
        }
         
    }
}
