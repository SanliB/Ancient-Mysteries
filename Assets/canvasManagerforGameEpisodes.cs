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
    public GameObject[] EnvItemImages;
    public GameObject MenuPanel;
    public GameObject ComeBackGameButtonForMenuPanel;
    public GameObject SettingsButtonForMenuPanel; 
    public GameObject MainMenuButtonForMenuPanel;
    public GameObject SettingsPanel;
    public GameObject VolumeSlider;
    public GameObject ComeBackButtonForSettings;
    public GameObject MenuPanelforBackground;
    private bool[] ButtonisActive;
    private bool EnvOpenorClose;
    private float envstartposy;
    private Transform EnvPanelTransform;
    private Transform MenuTransform;
    private Transform MenuPanelTransform;
    private Transform BackPackTransform;
    private Transform FlashLightTransform;
    protected Dictionary<int, bool> EnvDictionary;

    private void Awake()
    {
        ButtonisActive = new bool[6];
        EnvDictionary = new Dictionary<int, bool>();
        for (int i = 0; i < EnvPanelButtonsSelectedImages.Length; i++)
        {
            ButtonisActive[i] = false;
            EnvDictionary[i] = false;
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

    private int SearchFreeEnvIndex()
    {
        for (int i = 0; i < EnvPanelButtonsSelectedImages.Length; i++)
        {
            if (EnvDictionary[i] == false)
                return (i);
        }

        return (-1);
    }

    private int SearchItemForEnv(Sprite Item)
    {
        for (int i = 0; i < EnvPanelButtonsSelectedImages.Length; i++)
            if (EnvItemImages[i].GetComponent<Image>().sprite == Item)
                return (i);
        return (-1);
    }
    
    public void AddItemForEnv(Sprite additem)
    {
        EnvItemImages[SearchFreeEnvIndex()].GetComponent<Image>().sprite = additem;
        EnvDictionary[SearchFreeEnvIndex()] = true;
    }

    public void DeleteItemForEnv(Sprite deleteItem)
    {
        EnvDictionary[SearchItemForEnv(deleteItem)] = false;
        EnvItemImages[SearchItemForEnv(deleteItem)].GetComponent<Image>().sprite = null;
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
        MenuPanelforBackground.SetActive(true);
        MenuTransform.DOMoveX(MenuTransform.position.x - 152, 0.5f).SetUpdate(true); // -1179 -1331
        BackPackTransform.DOMoveX(BackPackTransform.position.x + 152, 0.5f).SetUpdate(true);
        FlashLightTransform.DOMoveX(FlashLightTransform.position.x + 152, 0.5f).SetUpdate(true);
        EnvPanelTransform.DOMoveY(EnvPanelTransform.position.y - 244, 0.5f).SetUpdate(true);
    }

    public void ifClickComeBackButton()
    {
        Time.timeScale = 1;
        MenuPanel.SetActive(false);
        MenuPanelforBackground.SetActive(false);
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
