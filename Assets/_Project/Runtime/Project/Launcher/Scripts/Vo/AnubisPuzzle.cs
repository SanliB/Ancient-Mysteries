using UnityEngine;

public class AnubisPuzzle : MonoSingleton<AnubisPuzzle>
{
    private Vector3 _catStatus;
    public Vector3 TrueRot;
    public bool _trueRotStatus=false;
    public GameObject[] CatList;
    public int sayac=0;

    public bool status=false;

    GameObject door;
    float a;
    
    void Awake(){
        door= DoorController.Instance.Door(0);
        a=door.transform.position.y+4;
    }
    private void OnMouseDown()
    {
        Debug.Log(gameObject.tag);
        if(gameObject.tag=="Cat"){
            SoundManager.Instance.Audio(0);
            transform.Rotate(0,45,0);
            _catStatus=transform.rotation.eulerAngles;
            if(TrueRot.y <= _catStatus.y &&  _catStatus.y<=TrueRot.y+1){
                _trueRotStatus=true;
            }
            else{
                _trueRotStatus=false;
            }
        }
        if(gameObject.tag=="Anubis"){
            sayac=0;
            for(int i=0; i<CatList.Length;i++){
                if(CatList[i].GetComponent<AnubisPuzzle>()._trueRotStatus){
                    sayac++;
                }
            }
            if(sayac==CatList.Length){
                status=true;
                SoundManager.Instance.Audio(1);
                door.transform.position=new Vector3(door.transform.position.x,a,door.transform.position.z);
                Debug.Log("kapı açıldı");
            }
        }
    }
}
