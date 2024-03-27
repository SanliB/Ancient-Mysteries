using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class flashlight_button : MonoBehaviour
{
    public GameObject flash_button;
    public Sprite flashlightImage;
    public GameObject flash;

    public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void OnMouseDown()
    {
        deneme.canvasManagerforGameEpisodes.Instance.AddItemForEnv(flashlightImage);
        Debug.Log("flash alindi");
        flash_button.SetActive(true);
        flash.SetActive(false);
        door.transform.Rotate(0,90,0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
