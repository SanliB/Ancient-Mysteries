using DG.Tweening;
using System.Collections;
using UnityEngine;

public class AnubisPuzzle : MonoBehaviour
{
    private Vector3 _catStatus;
    public Vector3 TrueRot;
    public bool _trueRotStatus=false;
    public GameObject[] CatList;
    public int Counter=0;
    public bool status=false;
    private GameObject _door;
    float a;
    public Light Anubislight;
    private bool isfinish = true;
    
    void Awake(){
        _door= DoorController.Instance.Door(0);
        a=_door.transform.position.y+4;
    }

    IEnumerator WaitSecond(bool TrueOrFalse, float duration)
    {
        yield return new WaitForSeconds(duration);
        isfinish = TrueOrFalse;
    }
    private void OnMouseDown()
    {
        Debug.Log(gameObject.tag);
        if (gameObject.tag=="Cat"){
            if (isfinish)
            {
                isfinish = false;
                SoundManager.Instance.Audio(0);

                //transform.Rotate(0,45,0);
                Vector3 newEulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y + 45, transform.eulerAngles.z);
                transform.DORotate(newEulerAngles, 0.3f);
                StartCoroutine(WaitSecond(true, 0.3f));
                _catStatus = newEulerAngles;
                if (TrueRot.y <= _catStatus.y &&  _catStatus.y<=TrueRot.y+1)
                {
                    _trueRotStatus=true;
                }
                else
                {
                    _trueRotStatus=false;
                }
            }
        }
        if (gameObject.tag=="Anubis"){
            Counter=0;
            for (int i=0; i<CatList.Length;i++)
            {
                if (CatList[i].GetComponent<AnubisPuzzle>()._trueRotStatus)
                {
                    Counter++;
                }
            }
            if (Counter==CatList.Length && status==false)
            {
                status=true;
                SoundManager.Instance.Audio(1);
                _door.transform.position=new Vector3(_door.transform.position.x,a,_door.transform.position.z);
                Anubislight.enabled = true;
                Debug.Log("kapı açıldı");
            }
        }
    }
}
