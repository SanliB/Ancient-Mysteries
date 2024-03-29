using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using deneme;

public class Key : MonoSingleton<Key>
{
    public bool status = false;
    public GameObject KeyAll;
    public Image KeyImage;
    public Sprite keyimage;

    private void OnMouseDown()
    {
        if (gameObject.tag == "Key")
        {
            SoundManager.Instance.Audio(11);
            canvasManagerforGameEpisodes.Instance.AddItemForEnv(keyimage);
            KeyAll.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //KeyImage.enabled = true;
            //gameObject.SetActive(false);
            status = true;
        }

    }
}