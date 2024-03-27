using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace EnvController
{
    public class EnvController : MonoBehaviour
    {
        public static EnvController Instance { get; private set; }

        public GameObject[] Env;
        public GameObject[] EnvSelectedPictures;
        public GameObject[] EnvItemPictures;
        public GameObject PaperPanel;
        public Sprite Paper;
        private bool[] EnvSelectedStatus;
        // Start is called before the first frame update

        private void Awake()
        {
            Instance = this;
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

        public void clearSelectedStatus()
        {
            for (int i = 0; i < Env.Length; i++)
            {
                EnvSelectedPictures[i].SetActive(false);
                EnvSelectedStatus[i] = false;
            }
        }

        public bool WhichButtonSelected()
        {
            int index = 0;
            while (index < EnvSelectedPictures.Length)
            {
                if (EnvSelectedPictures[index].active)
                {
                    return (true);
                }
                index++;
            }
            return (false);
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
            if (EnvItemPictures[index].GetComponent<Image>().sprite == Paper)
            {
                PaperPanel.SetActive(true);
            }
        }
    }
}