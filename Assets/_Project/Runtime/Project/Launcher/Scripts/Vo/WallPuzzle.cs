using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPuzzle : MonoBehaviour
{
    private Vector3 _buttonStatus;
    public Vector3 TrueRot;
    public bool _trueRotStatus=false;
    public GameObject[] ButtonList;
    public int sayac=0;
    public bool status=false;
    private GameObject door;
    private bool isFinish = true;

    public void Awake()
    {
        door = DoorController.Instance.Door(1);
    }
    IEnumerator WaitSecond(bool TrueOrFalse, float duration)
    {
        yield return new WaitForSeconds(duration);
        isFinish = TrueOrFalse;
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.tag);
        if(gameObject.tag=="WallKey"){
            if (isFinish)
            {
                isFinish = false;
                SoundManager.Instance.Audio(0);
                Vector3 newEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, transform.eulerAngles.z + 72);
                transform.DORotate(newEulerAngles, 0.3f);
                StartCoroutine(WaitSecond(true, 0.3f));
                _buttonStatus = newEulerAngles;
                if (TrueRot.y <= _buttonStatus.y &&  _buttonStatus.y <= TrueRot.y+1){
                    _trueRotStatus=true;
                }
                else{
                    _trueRotStatus=false;
                }
            }
        }
        if(gameObject.tag=="WallPuzzleButton"){
            sayac=0;
            for(int i=0; i<ButtonList.Length;i++){
                if(ButtonList[i].GetComponent<WallPuzzle>()._trueRotStatus){
                    sayac++;
                }
            }
            if(sayac==ButtonList.Length && status==false){
                SoundManager.Instance.Audio(10);
                status=true;
                door.GetComponent<Animator>().SetBool("DoorStatus", true);
                Debug.Log("kapı açıldı");
            }
            else{
                SoundManager.Instance.Audio(2);
            }
        }
    }
}
