using UnityEngine;

public class AnubisPuzzle : MonoBehaviour
{
    private Vector3 _catStatus;
    public Vector3 TrueRot;
    public bool _trueRotStatus=false;
    public GameObject[] CatList;
    public int sayac=0;

    private void OnMouseDown()
    {
        Debug.Log(gameObject.tag);
        if(gameObject.tag=="Cat"){
            transform.Rotate(0,45,0);
            _catStatus=transform.rotation.eulerAngles;
            //Debug.Log(_catStatus.y+"  "+TrueRot.y);
            if(TrueRot.y <= _catStatus.y &&  _catStatus.y<=TrueRot.y+1){
                _trueRotStatus=true;
            }
            else{
                _trueRotStatus=false;
            }
            //Debug.Log(_trueRotStatus);
        }
        if(gameObject.tag=="Anubis"){
            sayac=0;
            for(int i=0; i<CatList.Length;i++){
                if(CatList[i].GetComponent<AnubisPuzzle>()._trueRotStatus){
                    sayac++;
                }
            }
            if(sayac==CatList.Length){
                Debug.Log("kapı açıldı");
            }
        }
    }
}
