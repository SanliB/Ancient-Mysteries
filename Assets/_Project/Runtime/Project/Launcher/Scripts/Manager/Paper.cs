using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Paper : MonoSingleton<Paper>
{
    public bool status = false;
    public GameObject Chest;
    public GameObject PaperPanel;
    public Image PaperImage;

    private void OnMouseDown()
    {
        Debug.Log("sdad");
        if(Chest.GetComponent<Chest>().a==true)
        {
            Debug.Log("dsgfdsfdsf");
            
            if (gameObject.tag == "Paper")
            {
                PaperPanel.SetActive(true);
                Debug.Log("sfasfas");
                gameObject.SetActive(false);
                status = true;
                PaperImage.enabled = true;
            }
        }
    }

    public void PaperOnClick() 
    {
        PaperPanel.SetActive(false);
    }
}
