using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Paper : MonoSingleton<Paper>
{
    public bool status = false;
    public GameObject Chest;
    public GameObject PaperPanel;

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
            }
        }
    }

    public void PaperOnClick() 
    {
        PaperPanel.SetActive(false);
    }
}
