using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDoorController : MonoBehaviour
{
    public WallPuzzle Cylinder1, Cylinder2, Cylinder3, Cylinder4, Cylinder5, Cylinder6;
    private bool firstEntry = false;
    private int Counter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Cylinder1._trueRotStatus && Cylinder2._trueRotStatus && Cylinder3._trueRotStatus && Cylinder4._trueRotStatus && Cylinder5._trueRotStatus && Cylinder6._trueRotStatus && firstEntry == false)
        {
            firstEntry = true;
            SoundManager.Instance.Audio(10, PlayerPrefs.GetFloat("audioVolume"));
            gameObject.GetComponent<Animator>().SetBool("DoorStatus", true);
        }
    }
    private void OnMouseDown()
    {
        if (!gameObject.GetComponent<Animator>().GetBool("DoorStatus"))
        {
            SoundManager.Instance.Audio(2, PlayerPrefs.GetFloat("audioVolume"));
            Counter++;
            if (Counter == 8)
            {
                if (PlayerPrefs.GetString("Language") == "EN")
                    SoundManager.Instance.Audio(19, 0.8f);
                else
                    SoundManager.Instance.Audio(34, 0.8f);
                Counter = 0;
            }
        }
    }
}
