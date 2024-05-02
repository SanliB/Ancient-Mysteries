using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigAnubisController : MonoBehaviour
{
    public AnubisPuzzle Anubis1, Anubis2, Anubis3, Anubis4;
    public Light Anubislight;
    private GameObject _door;
    private bool firstEntry = false;
    float a;

    // Start is called before the first frame update
    private void Awake()
    {
        _door = DoorController.Instance.Door(0);
        a = _door.transform.position.y + 4;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Anubis1._trueRotStatus && Anubis2._trueRotStatus && Anubis3._trueRotStatus && Anubis4._trueRotStatus && firstEntry == false)
        {
            firstEntry = true;
            SoundManager.Instance.Audio(1, PlayerPrefs.GetFloat("audioVolume"));
            _door.transform.position = new Vector3(_door.transform.position.x, a, _door.transform.position.z);
            Anubislight.enabled = true;
        }
    }
}
