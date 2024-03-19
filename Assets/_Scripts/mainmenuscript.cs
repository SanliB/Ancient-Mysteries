using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace MainMenu
{
    public class mainmenuscript : MonoBehaviour
    {
        // Start is called before the first frame update
        public static bool FirstEntry = true;

        public void    ifclickplaybutton()
        {
            SceneManager.LoadScene(1);
        }

        public void    ifclicksettingsbutton()
        {
            SceneManager.LoadScene(2);
        }

        public void    ifclickquitbutton()
        {
            Application.Quit();
        }

        void Start()
        {
            if (FirstEntry)
            {
                if (PlayerPrefs.HasKey("musicvolume"))
                {
                    FindObjectOfType<AudioSource>().volume = PlayerPrefs.GetFloat("musicvolume");
                }
                else
                {
                    PlayerPrefs.SetFloat("musicvolume", FindObjectOfType<AudioSource>().volume);
                }
                if (!PlayerPrefs.HasKey("generalvolume"))
                    PlayerPrefs.SetFloat("generalvolume", 100);
                FirstEntry = false;
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
