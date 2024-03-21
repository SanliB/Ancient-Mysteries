using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using System.IO;

public class dontdestroyonmainaudiosource : MonoBehaviour
{
    // Start is called before the first frame update

    public GameObject olusanikincises;
    private static GameObject ilkses;

    private void Awake()
    {
        if (ilkses == null)
        {
            ilkses = this.gameObject;
            AudioSource audioSource = ilkses.GetComponent<AudioSource>();
            string musicSettingsPath = Application.dataPath + "/musicSettings.json";
            if (File.Exists(musicSettingsPath))
            {
                string json = File.ReadAllText(musicSettingsPath);
                audioSource.volume = JsonUtility.FromJson<float>(json);
            }
            else
                audioSource.volume = 1.0f;
        }
        if (this.gameObject != ilkses)
        {
            this.gameObject.SetActive(false);
        }
        DontDestroyOnLoad(ilkses);
    }

    public void OnClickStartOrQuit()
    {
        Destroy(ilkses);
    }
}
