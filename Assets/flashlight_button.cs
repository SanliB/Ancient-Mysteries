using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight_button : MonoBehaviour
{
    public GameObject Flash_Button;
    public Sprite FlashlightImage;
    private GameObject _door;
    // Start is called before the first frame update
    void Start()
    {
        _door= DoorController.Instance.Door(3);
    }

    public void OnMouseDown()
    {
        SoundManager.Instance.Audio(7,PlayerPrefs.GetFloat("audioVolume"));
        deneme.canvasManagerforGameEpisodes.Instance.AddItemForEnv(FlashlightImage);
        Debug.Log("flash alindi");
        Flash_Button.SetActive(true);
        gameObject.SetActive(false);
        _door.transform.Rotate(0,90,0);
        SoundManager.Instance.Audio(12,PlayerPrefs.GetFloat("audioVolume"));
    }
}
