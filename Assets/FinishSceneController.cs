using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class yaziKaydir : MonoBehaviour
{
    public AudioSource audio;
    public Transform yazi;
    public float ilkyekseni;
    public int sonYKonumu;
    public float yukariCikmaHizi;

    // Start is called before the first frame update
    private static int yekseni;

    private void Awake()
    {
        audio.GetComponent<AudioSource>().volume = PlayerPrefs.GetFloat("musicvolume");
    }

    void Start()
    {
        yekseni = 0;
    }

    // Update is called once per frame
    void Update()
    {
        yazi.position = yazi.position + new Vector3(0, yukariCikmaHizi, 0);
        yekseni++;
        if (yekseni >= ((sonYKonumu - ilkyekseni)) * (1 / yukariCikmaHizi))
        {
            SceneManager.LoadScene(2);
        }
    }
}
