using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;
using DG.Tweening;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.UI;
using Button = UnityEngine.UIElements.Button;

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
        public GameObject SkipButton;

        public RenderTexture StartVideoRender;
        
        public void Awake()
        {
            MenuScene.alpha=1;
        }

        public void SkipScene()
        {
            SceneManager.LoadScene(2);
        }

        private IEnumerator SkipButtonShow()
        {
            yield return new WaitForSeconds(2);
            
            Color ButtonColor = SkipButton.GetComponent<Image>().color;
            Color TextColor = SkipButton.GetComponentInChildren<TextMeshProUGUI>().color;

            while (ButtonColor.a != 1)
            {
                ButtonColor.a += 0.1f;
                TextColor.a += 0.1f;
                SkipButton.GetComponent<Image>().color = ButtonColor;
                SkipButton.GetComponentInChildren<TextMeshProUGUI>().color = TextColor;
                yield return new WaitForSeconds(0.1f);
            }

            yield return null;
        }

        public void VideoPlayer()
        {
            videoPlayer.Play();
            VideoImage.SetActive(true);
            SkipButton.SetActive(true);
            StartCoroutine(SkipButtonShow());
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
                    FindObjectOfType<AudioSource>().volume = PlayerPrefs.GetFloat("musicVolume");

                }
                if (!PlayerPrefs.HasKey("audioVolume"))
                    PlayerPrefs.SetFloat("audioVolume", 1.0f);
                FirstEntry = false;
            }
        }
    }
}
