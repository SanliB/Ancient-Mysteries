using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Key : MonoSingleton<Key>
{

    public bool status = false;
    public GameObject KeyAll;
    private void OnMouseDown()
    {
        if (gameObject.tag == "Key")
        {
            KeyAll.SetActive(false);
            status = true;
        }
         
    }
}
