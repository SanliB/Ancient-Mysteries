using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Key : MonoSingleton<Key>
{

    public bool status = false;
    public GameObject KeyAll;
    public Image KeyImage;
    private void OnMouseDown()
    {
        if (gameObject.tag == "Key")
        {
            KeyAll.SetActive(false);
            KeyImage.enabled = true;
            status = true;
        }
         
    }
}
