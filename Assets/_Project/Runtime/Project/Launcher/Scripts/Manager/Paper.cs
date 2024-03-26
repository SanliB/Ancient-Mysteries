using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using deneme;

public class Paper : MonoSingleton<Paper>
{
    public bool status = false;
    public GameObject Chest;
    public GameObject PaperPanel;
    public Image PaperImage;
    public Sprite PaperSprite;

    private void OnMouseDown()
    {
        Debug.Log("sdad");
        if(Chest.GetComponent<Chest>().a==true)
        {
            Debug.Log("dsgfdsfdsf");
            
            if (gameObject.tag == "Paper")
            {
                deneme.canvasManagerforGameEpisodes.Instance.AddItemForEnv(PaperSprite);
                PaperPanel.SetActive(true);
                gameObject.SetActive(false);

                status = true;
                //PaperImage.enabled = true;
            }
        }
    }

    public void PaperOnClick() 
    {
        PaperPanel.SetActive(false);
    }
}
