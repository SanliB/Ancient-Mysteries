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
            SoundManager.Instance.Audio(11,PlayerPrefs.GetFloat("audioVolume"));
            canvasManagerforGameEpisodes.Instance.AddItemForEnv(keyimage);
            KeyAll.SetActive(false);
            gameObject.GetComponent<BoxCollider>().enabled = false;
            //KeyImage.enabled = true;
            //gameObject.SetActive(false);
            if (PlayerPrefs.GetString("Language") == "EN")
                SoundManager.Instance.Audio(23, 0.8f);
            else
                SoundManager.Instance.Audio(36, 0.8f);
            status = true;
        }

    }
}