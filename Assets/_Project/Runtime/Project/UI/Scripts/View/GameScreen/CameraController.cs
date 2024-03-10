using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public TouchController Controller;
    public Transform Character;
    public float Sensivity;
    private float _limitX, _limitY;
    private float _xRot, _yRot;
    
    void Start()
    {
        
    }

    void Update()
    {
        Rot();
        transform.position= Vector3.Lerp(transform.position,Character.transform.position,0.3f);
    }

     void Rot(){
        _limitX += Controller.SliderHorizontal * Sensivity * Time.fixedDeltaTime;
        _limitY += -Controller.SliderVertical * Sensivity * Time.fixedDeltaTime;
        _xRot = Mathf.Clamp(_limitY, -30f, 30f);
        transform.localRotation=Quaternion.Euler(_xRot,_limitX, 0);
    }
}

