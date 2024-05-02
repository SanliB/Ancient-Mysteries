using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using UnityEngine;

public class WallPuzzle : MonoBehaviour
{
    public Vector3 TrueRot;
    public bool _trueRotStatus=false;
    public GameObject[] ButtonList;
    public int Counter1=0, Counter;
    public bool status=false;
    private GameObject door;
    private bool isFinish = true;

    private Transform Angles;

    public void Awake()
    {
        door = DoorController.Instance.Door(1);
        Counter=7;
    }
    IEnumerator WaitSecond(bool TrueOrFalse, float duration)
    {
        yield return new WaitForSeconds(duration);
        isFinish = TrueOrFalse;
    }

    private void OnMouseDown()
    {
        if(gameObject.tag=="WallKey"){
            if (isFinish)
            {
                isFinish = false;
                Angles = gameObject.GetComponent<Transform>();
                SoundManager.Instance.Audio(0,PlayerPrefs.GetFloat("audioVolume"));
                Vector3 newEulerAngles = new Vector3(Angles.eulerAngles.x, Angles.eulerAngles.y, Angles.eulerAngles.z + 72);
                Angles.DORotate(newEulerAngles, 0.3f);
                StartCoroutine(WaitSecond(true, 0.3f));
                if ((TrueRot.z - 1) <= (Angles.eulerAngles.z - 18) &&  (Angles.eulerAngles.z - 18) <= (TrueRot.z + 1))
                    _trueRotStatus=true;
                else
                    _trueRotStatus=false;
            }
        }
    }
}
