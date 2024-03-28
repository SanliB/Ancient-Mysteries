using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using static UnityEngine.GraphicsBuffer;
using deneme;

public class Chest : MonoBehaviour
{
    public bool ChestStatus, a = false;
    public Sprite KeySprite;
    private void Update()   
    {
        if (ChestStatus)
        {
            deneme.canvasManagerforGameEpisodes.Instance.DeleteItemForEnv(KeySprite);
            gameObject.GetComponent<Animation>().Play();
            ChestStatus = false;
            a= true;
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }

    private void OnMouseDown()
    {
        if(!a && Key.Instance.status)
        {
            SoundManager.Instance.Audio(13);
            ChestStatus = true;
        }
        else
        {
            SoundManager.Instance.Audio(9);
        }
    }
}


