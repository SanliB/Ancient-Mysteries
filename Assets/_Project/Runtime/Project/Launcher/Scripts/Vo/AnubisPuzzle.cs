using DG.Tweening;
using System.Collections;
using UnityEngine;

public class AnubisPuzzle : MonoBehaviour
{
    private Vector3 _catStatus;
    public Vector3 TrueRot;
    public bool _trueRotStatus=false;
    public GameObject[] CatList;
    public bool status=false;
    private bool isfinish = true;
    
    void Awake(){
    }

    IEnumerator WaitSecond(bool TrueOrFalse, float duration)
    {
        yield return new WaitForSeconds(duration);
        isfinish = TrueOrFalse;
    }
    private void OnMouseDown()
    {
        if (gameObject.tag=="Cat"){
            if (isfinish)
            {
                isfinish = false;
                SoundManager.Instance.Audio(0,PlayerPrefs.GetFloat("audioVolume")*0.5f);

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
    }
}
