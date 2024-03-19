using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using MainMenu;
using DG.Tweening;

public class canvasManagerforGameEpisodes : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject Menu;
    public GameObject BackPack;
    public GameObject FlashLight;
    public GameObject EnvPanel;
    public GameObject[] EnvPanelButtons;
    public GameObject[] EnvPanelButtonsSelectedImages;
    public GameObject MenuPanel;
    public GameObject ComeBackGameButtonForMenuPanel;
    public GameObject SettingsButtonForMenuPanel;
    public GameObject MainMenuButtonForMenuPanel;
    public GameObject SettingsPanel;
    public GameObject VolumeSlider;
    public GameObject ComeBackButtonForSettings;
    private bool[] ButtonisActive;
    private bool EnvOpenorClose;
    private float envstartposy;
    private Transform EnvPanelTransform;
    private Transform MenuTransform;
    private Transform MenuPanelTransform;
    private Transform BackPackTransform;
    private Transform FlashLightTransform;

    private void Awake()
    {
        ButtonisActive = new bool[6];
        for (int i = 0; i < EnvPanelButtonsSelectedImages.Length; i++)
        {
            ButtonisActive[i] = false;
            //EnvPanelButtonsSelectedImages[i].active = false;
        }
        EnvOpenorClose = false;
        EnvPanelTransform = EnvPanel.GetComponent<Transform>();
        MenuPanelTransform = MenuPanel.GetComponent<Transform>();
        MenuTransform = Menu.GetComponent<Transform>();
        BackPackTransform = BackPack.GetComponent<Transform>();
        FlashLightTransform = FlashLight.GetComponent<Transform>();
        envstartposy = EnvPanelTransform.position.y;
    }

    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ifclickbackpack()
    {
        float currentposy = EnvPanelTransform.position.y;
        if (currentposy == envstartposy || currentposy == envstartposy + 244)
        {
            float targetPosition = EnvOpenorClose ? EnvPanelTransform.position.y - 244 : EnvPanelTransform.position.y + 244;
            EnvPanelTransform.DOMoveY(targetPosition, 1);
            EnvOpenorClose = !EnvOpenorClose;
        }
    }

    public void ifClickMenuButton()
    {
        Time.timeScale = 0;
        MenuPanel.SetActive(true);
        MenuTransform.DOMoveX(MenuTransform.position.x - 152, 0.5f).SetUpdate(true); // -1179 -1331
        BackPackTransform.DOMoveX(BackPackTransform.position.x + 152, 0.5f).SetUpdate(true);
        FlashLightTransform.DOMoveX(FlashLightTransform.position.x + 152, 0.5f).SetUpdate(true);
        EnvPanelTransform.DOMoveY(EnvPanelTransform.position.y - 244, 0.5f).SetUpdate(true);
        //Menu.SetActive(false);
        //BackPack.SetActive(false);
        //FlashLight.SetActive(false);
        //EnvPanel.SetActive(false);
    }

    public void ifClickComeBackButton()
    {
        Time.timeScale = 1;
        MenuPanel.SetActive(false);
        Menu.SetActive(true);
        BackPack.SetActive(true);
        FlashLight.SetActive(true);
        EnvPanel.SetActive(true);
        MenuTransform.DOMoveX(MenuTransform.position.x + 152, 0.5f);
        BackPackTransform.DOMoveX(BackPackTransform.position.x - 152, 0.5f);
        FlashLightTransform.DOMoveX(FlashLightTransform.position.x - 152, 0.5f);
        EnvPanelTransform.DOMoveY(EnvPanelTransform.position.y + 244, 0.5f);
    }

    public void ifClickSettingsButton()
    {
        MenuPanel.SetActive(false);
        SettingsPanel.SetActive(true);
        VolumeSlider.GetComponent<Slider>().value = PlayerPrefs.GetFloat("generalvolume");
    }

    public void ifClickComeBackButtonForSettings()
    {
        MenuPanel.SetActive(true);
        SettingsPanel.SetActive(false);
    }

    public void ifChangeVolume()
    {
        PlayerPrefs.SetFloat("generalvolume", VolumeSlider.GetComponent<Slider>().value);
        //VolumeSlider.GetComponent<Slider>().value = 50;
    }

    public void ifClickMainMenuButton()
    {
        mainmenuscript.FirstEntry = true;
        SceneManager.LoadScene(3);
    }
}
