using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class DeathPanel : MonoSingleton<DeathPanel>
{
    public bool b;
    public TextMeshProUGUI YouDiedText;
    public Button TryAgainButton;
    public TextMeshProUGUI TryAgainButtonText;
    public Volume v;
    private Vignette vg;
    private Image TryAgainButtonImage;
    public GameObject DieVolume;
    public GameObject OpenVolume;
    public GameObject FinalVolume;
    

    private void Awake()
    {
        TryAgainButtonImage = TryAgainButton.GetComponent<Image>();
    }

    public void returnGame()
    {
        OpenVolume.SetActive(false);
        FinalVolume.SetActive(false);
        DieVolume.SetActive(true);

        SoundManager.Instance.Audio(4,PlayerPrefs.GetFloat("audioVolume"));
        b = true;
        gameObject.SetActive(true);
        StartCoroutine(TextFont(YouDiedText, 77.5f));
        StartCoroutine(ScaleUIOverTime(TryAgainButtonImage.GetComponent<RectTransform>(), new Vector3(1f, 1f, 1f), 0.5f));
        //a = vignette.Instance.vg;
        v.profile.TryGet(out vg);
        vg.intensity.value = 0;
        Time.timeScale = 0;
    }

    IEnumerator ScaleUIOverTime(RectTransform uiElement, Vector3 targetScale, float duration)
    {
        Vector3 initialScale = uiElement.localScale; // Ba�lang�� �l�e�i
        float time = 0;

        while (time < duration)
        {
            // Time.timeScale 0 iken bile zaman� art�r
            time += Time.unscaledDeltaTime;

            // UI elementini yava��a hedef �l�e�e do�ru �l�eklendir
            uiElement.localScale = Vector3.Lerp(initialScale, targetScale, time / duration);

            yield return null; // Bir sonraki frame'e kadar bekle
        }

        // Son �l�e�i hedef �l�e�e ayarla
        uiElement.localScale = targetScale;
    }

    IEnumerator TextFont(TextMeshProUGUI text, float FinishFontSize)
    {
        float startRealTime = Time.realtimeSinceStartup;
        float delay = 0.02f; // Bekleme s�resi 0.02 saniye olarak ayarland�
        while (text.fontSize > FinishFontSize)
        {
            text.fontSize--;

            // Ger�ek zamanl� bekleme s�resi hesaplama
            while (Time.realtimeSinceStartup < startRealTime + delay)
            {
                yield return null; // Bir sonraki frame'e kadar bekle
            }
            startRealTime += delay; // Sonraki iterasyon i�in ba�lang�� zaman�n� g�ncelle
        }
    }

    public void DieScene()
    {
        vg.intensity.value = 0;
        gameObject.SetActive(false);
        Time.timeScale = 1;
        YouDiedText.fontSize = 100;
        TryAgainButtonImage.GetComponent<RectTransform>().localScale = new Vector3(1.5f, 1.5f, 1f);
        //TryAgainButtonText.fontSize = 50;
        CharacterController _cc = CharacterController2.Instance._cc;
        _cc.enabled = false;
        _cc.transform.position=new Vector3(-19,-8.5f,18);
        _cc.enabled = true;
    }

    void Update()
    {
        if (b && vg.intensity.value <= 0.7f)
        {
            vg.intensity.value += 0.0003f*Time.fixedTime;
        }
    }
}
