using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using DG.Tweening;

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
        public CanvasGroup MenuScene;
        public bool StartVideo;

        public RenderTexture StartVideoRender;
        
        public void Awake()
        {
            MenuScene.alpha=1;
        }
        
        public void VideoPlayer()
        {
            videoPlayer.Play();
            VideoImage.SetActive(true);
            videoPlayer.loopPointReached += EndReached;
        }
        
        void EndReached(VideoPlayer vp)
        {
            SceneManager.LoadScene(2);
        }

        public void ifclickplaybutton()
        {
            RenderTexture.active = StartVideoRender;
            GL.Clear(true, true, Color.clear);
            RenderTexture.active = null;
            StartVideo = true;
            FirstAudio.Play();
            if (StartVideo)
            {
                DOTween.To(() => MenuScene.alpha, x => MenuScene.alpha = x, 0, 1).OnComplete(() => { VideoPlayer(); });
            }
        }
        
        public void ifclicksettingsbutton()
        {
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
                    PlayerPrefs.SetFloat("musicVolume",1.0f);
                    
                }
                if (!PlayerPrefs.HasKey("audioVolume"))
                    PlayerPrefs.SetFloat("audioVolume", 1.0f);
                FirstEntry = false;
            }
        }
    }
}
