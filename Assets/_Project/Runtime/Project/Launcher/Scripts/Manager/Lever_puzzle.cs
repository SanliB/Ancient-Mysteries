using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever_puzzle : MonoBehaviour
{
    private Vector3 _leverStatus;
    public Vector3 TrueRot;
    public bool _trueRotStatus=false;
    public GameObject[] LeverList;
    public int counter=0;
    public bool status=false;
    GameObject glass;
    float a;
    private int lever=70;
    
    void Awake(){
        glass= DoorController.Instance.Door(2);
    }

    private void OnMouseDown()
    {
        Debug.Log(gameObject.tag);
        if(gameObject.tag=="Lever"){
            SoundManager.Instance.Audio(6,PlayerPrefs.GetFloat("audioVolume"));
            if (lever==70)
            {
                transform.rotation = Quaternion.Euler(220, 0, 0);
                lever = -70;
            }
            else if (lever==-70)
            {
                transform.rotation = Quaternion.Euler(150, 0, 0);
                lever = 70;
            }
            _leverStatus=transform.rotation.eulerAngles;
            
            if(TrueRot.x <= _leverStatus.x &&  _leverStatus.x<=TrueRot.x+1){
                _trueRotStatus=true;
            }
            else{
                _trueRotStatus=false;
            }
        }
        if(gameObject.tag=="Glass"){
            counter=0;
            for(int i=0; i<LeverList.Length;i++){
                if(LeverList[i].GetComponent<Lever_puzzle>()._trueRotStatus){
                    counter++;
                }
            }
            if(counter==LeverList.Length && status==false){
                status=true;
                
                glass.transform.position=new Vector3(glass.transform.position.x,glass.transform.position.y+1,glass.transform.position.z);
            }
        }
    }
}
