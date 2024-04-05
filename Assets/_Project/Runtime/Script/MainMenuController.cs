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
        public AudioSource audio;
        private static AudioSource FirstAudio;

        public void ifclickplaybutton()
        {
            // DontDestroyOnLoad(audio);
            FirstAudio.Play();
            SceneManager.LoadScene(0);
        }

        public void ifclicksettingsbutton()
        {
            // DontDestroyOnLoad(audio);
            FirstAudio.Play();
            SceneManager.LoadScene(1);
        }

        public void ifclickquitbutton()
        {
            Application.Quit();
        }

        void Start()
        {
            if (FirstAudio == null)
                FirstAudio = audio;
            else
                Destroy(audio);
            if (FirstEntry)
            {
                if (PlayerPrefs.HasKey("musicVolume"))
                {
                    FindObjectOfType<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");
                }
                else
                {
                    PlayerPrefs.SetFloat("musicVolume", FindObjectOfType<AudioSource>().volume);
                }
                if (!PlayerPrefs.HasKey("audioVolume"))
                    PlayerPrefs.SetFloat("audioVolume", 100);
                FirstEntry = false;
            }
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}
