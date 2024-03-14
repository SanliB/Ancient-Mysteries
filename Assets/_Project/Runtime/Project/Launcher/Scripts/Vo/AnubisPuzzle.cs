using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class AnubisPuzzle : MonoBehaviour
{
    private Vector3 _catStatus;
    public Vector3 TrueRot;
    public bool _trueRotStatus=false;

    public List<GameObject> CatList;


    void Start()
    {
        //transform.rotation= Quaternion.Euler(0,0,0);
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        //_catStatus += new Vector3(0,transform.rotation.y+45,0);
        Debug.Log(gameObject.tag);
        if(gameObject.tag=="Cat"){
            transform.Rotate(0,45,0);
            _catStatus=transform.rotation.eulerAngles;
            Debug.Log(_catStatus.y+"  "+TrueRot.y);
            if(TrueRot.y <= _catStatus.y &&  _catStatus.y<=TrueRot.y+1){
                _trueRotStatus=true;
            }
            else{
                _trueRotStatus=false;
            }
            Debug.Log(_trueRotStatus);
        }
        
        
        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0,cat.y,0) , 1f);
    }
}
