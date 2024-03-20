using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;

public class Chest : MonoBehaviour
{
    public bool ChestStatus, a = false;
    private void Update()   
    {
        if (ChestStatus)
        {
            gameObject.GetComponent<Animation>().Play();
            ChestStatus = false;
            a= true;
        }
    }

    private void OnMouseDown()
    {
        if(!a && Key.Instance.status)
        {
            ChestStatus = true;
        }
       
    }

}


