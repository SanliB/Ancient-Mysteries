using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;


namespace MainMenu
{
    public class mainmenuscript : MonoBehaviour
    {
        // Start is called before the first frame update
        public static bool FirstEntry = true;
        public AudioSource audio;
        private static AudioSource FirstAudio;
        public GameObject VideoImage;
        public VideoPlayer videoPlayer;

        public void VideoPlayer()
        {
            VideoImage.SetActive(true);
            // Get the VideoPlayer component

            // Subscribe to the loopPointReached event
            videoPlayer.loopPointReached += EndReached;
        }
        
        void EndReached(VideoPlayer vp)
        {
            Debug.Log("asdasd");
            // Video playback reached the end
            SceneManager.LoadScene(0);
            // You can put your code here to do something when the video ends
        }

        public void ifclickplaybutton()
        {
            VideoPlayer();
            
            FirstAudio.Play();
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
