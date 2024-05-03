using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class EndGameText : MonoBehaviour
{
    //public FinalPanel FinalPanel;
    public TextMeshProUGUI EndText;
    public GameObject EndGamePanel;
    public IEnumerator typingCoroutine;
    public GameObject UITools;

    
    void Start()
    {
        EndGamePanel.SetActive(false);
        typingCoroutine = TypingCoroutine();
    }

    public void TextStart()
    {
        UITools.SetActive(false);
        EndGamePanel.SetActive(true);
        StartCoroutine(GoEndText());
        StartCoroutine(typingCoroutine);
    }

    private IEnumerator GoEndText()
    {
        Color temp=EndGamePanel.GetComponent<Image>().color;
        while (temp.a!=1)
        {
            temp.a += 0.1f;
            EndGamePanel.GetComponent<Image>().color = temp;
            yield return new WaitForSeconds(0.1f);
        }

        yield return null;
    }
    
    private IEnumerator GoBackEndText()
    {
        Color temp=EndGamePanel.GetComponent<Image>().color;
        while (temp.a!=1)
        {
            temp.a -= 0.1f;
            EndGamePanel.GetComponent<Image>().color = temp;
            yield return new WaitForSeconds(0.1f);
        }
        EndGamePanel.SetActive(false);
        yield return null;
    }

    public IEnumerator TypingCoroutine()
    {
        yield return new WaitForSeconds(1.7f);
        SoundManager.Instance.Audio(28,1);
        if (PlayerPrefs.GetString("Language") == "EN")
            DOTween.To(() => EndText.text, (yazi) => EndText.text = yazi, "The archaeologist, unfortunately, couldn't gather sufficient information during the research expedition to the pyramids despite long efforts. However, the limited information obtained from thorough examination of ancient inscriptions and the discovery of ancient artifacts provided him with a new perspective in unraveling the secrets of ancient civilizations. Perhaps the true discovery lies not in solving the secrets of a lost civilization, but in understanding the legacy they left behind."
                                                                      , 17f).SetOptions(true, ScrambleMode.None);
        else
            DOTween.To(() => EndText.text, (yazi) => EndText.text = yazi, "Arkeolog, maalesef, piramitlere yapýlan araþtýrma seferi sýrasýnda uzun çabalarýna raðmen yeterli bilgi toplayamadý. Ancak, eski yazýtlarýn dikkatli incelenmesi ve eski eserlerin keþfi sayesinde elde edilen sýnýrlý bilgiler, ona antik uygarlýklarýn sýrlarýný çözme konusunda yeni bir bakýþ açýsý saðladý. Belki de gerçek keþif, kayýp bir uygarlýðýn sýrlarýný çözmekte deðil, onlarýn býraktýðý mirasý anlamaktadýr."
                                                              , 17f).SetOptions(true, ScrambleMode.None);

        yield return new WaitForSeconds(24);
        EndText.text = "";
        SoundManager.Instance.Audio(28,1);
        if (PlayerPrefs.GetString("Language") == "EN")
            DOTween.To(() => EndText.text, (yazi) => EndText.text = yazi, "And thus, the archaeologist's journey signified not just an end, but a new beginning. Ready to embark on further exploration journeys to trace the footsteps of ancient civilizations, the archaeologist was filled with new excitement and curiosity. Perhaps in the future, another adventure filled with mysterious relics and lost civilizations awaited him. But for now, emerging from the depths of the pyramids, he felt the excitement of taking a step towards future discoveries with a sparkle in his eyes and enthusiasm in his heart. And this, was just the beginning of opening the doors to a new adventure filled with ancient secrets..."
                                                                        , 17f).SetOptions(true, ScrambleMode.None);
        else
            DOTween.To(() => EndText.text, (yazi) => EndText.text = yazi, "Ve böylece, arkeoloðun yolculuðu sadece bir son deðil, ayný zamanda yeni bir baþlangýç anlamýna geliyordu. Antik uygarlýklarýn izlerini sürmek için daha fazla keþif yolculuðuna çýkmaya hazýr olan arkeolog, yeni bir heyecan ve merakla doluydu. Belki de gelecekte, gizemli kalýntýlar ve kayýp uygarlýklarla dolu baþka bir macera onu bekliyordu. Ama þimdilik, piramitlerin derinliklerinden çýkarken, gözlerinde bir parýltý ve kalbinde bir coþkuyla gelecek keþiflere doðru attýðý adýmýn heyecanýný hissediyordu. Ve bu, antik sýrlarla dolu yeni bir maceranýn kapýlarýný açmanýn sadece baþlangýcýydý..."
                                                            , 17f).SetOptions(true, ScrambleMode.None);
        yield return new WaitForSeconds(20);//21
        PlayerPrefs.SetFloat("CharacterPosX", 38.87f);
        PlayerPrefs.SetFloat("CharacterPosY", -1.81f);
        PlayerPrefs.SetFloat("CharacterPosZ", 28.08f);
        PlayerPrefs.SetString("PlayerGameStatus", "Finish");
        PlayerPrefs.SetInt("FlashLight", 0);

        StartCoroutine(GoBackEndText());
        gameObject.GetComponent<FinalPanel>().FinalScreen();
    }
    
    

    
}

