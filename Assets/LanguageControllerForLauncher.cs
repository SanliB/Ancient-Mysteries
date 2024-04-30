using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class LanguageControllerForLauncher : MonoBehaviour
{
    public TextMeshProUGUI MusicSliderText;
    public TextMeshProUGUI EffectSliderText;
    public TextMeshProUGUI ReturnMenuButtonTextForSettings;
    public TextMeshProUGUI ContinueButtonText;
    public TextMeshProUGUI SettingsButtonText;
    public TextMeshProUGUI ReturnMenuButtonTextForMenu;
    public TextMeshProUGUI LanguageText;
    public Image LangButton;
    public Sprite LangTR;
    public Sprite LangEN;
    // Start is called before the first frame update

    private void Awake()
    {
        ChangeLanguage(0);
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ChangeLanguage(int i)
    {
        if (i == 1)
        {
            if (LangButton.sprite == LangEN)
                PlayerPrefs.SetString("Language", "TR");
            else
                PlayerPrefs.SetString("Language", "EN");
        }
        if (PlayerPrefs.GetString("Language") == "TR")
        {
            MusicSliderText.text = "Muzik";
            EffectSliderText.text = "Efektler";
            ReturnMenuButtonTextForSettings.text = "Menuye Don";
            ContinueButtonText.text = "Devam Et";
            SettingsButtonText.text = "Ayarlar";
            ReturnMenuButtonTextForMenu.text = "Ana Menu";
            LanguageText.text = "Dil";
            LangButton.sprite = LangTR;
        }
        else
        {
            MusicSliderText.text = "Music";
            EffectSliderText.text = "Effect";
            ReturnMenuButtonTextForSettings.text = "Return Menu";
            ContinueButtonText.text = "Continue";
            SettingsButtonText.text = "Settings";
            ReturnMenuButtonTextForMenu.text = "Return Menu";
            LanguageText.text = "Language";
            LangButton.sprite = LangEN;
        }
    }
}
