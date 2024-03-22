using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnvController : MonoBehaviour
{
    public GameObject[] Env;
    public GameObject[] EnvSelectedPictures;
    public GameObject[] EnvItemPictures;
    private bool[] EnvSelectedStatus;
    // Start is called before the first frame update

    private void Awake()
    {
        EnvSelectedStatus = new bool[Env.Length];
        for (int i = 0; i < Env.Length; i++)
            EnvSelectedStatus[i] = false;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void clearSelectedStatus()
    {
        for (int i = 0; i < Env.Length; i++)
        {
            EnvSelectedPictures[i].SetActive(false);
            EnvSelectedStatus[i] = false;
        }
    }

    public void ifbuttonselected(int index)
    {
        if (EnvSelectedStatus[index] == true)
        {
            EnvSelectedStatus[index] = false;
            EnvSelectedPictures[index].SetActive(false);
            return;
        }
        clearSelectedStatus();
        EnvSelectedStatus[index] = true;
        EnvSelectedPictures[index].SetActive(true);
    }
}
