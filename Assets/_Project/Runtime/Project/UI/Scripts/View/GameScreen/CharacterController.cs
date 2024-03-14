using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

using TMPro;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CharacterController : MonoBehaviour
{
    public FixedJoystick Joystick;
    private Rigidbody _rb;
    public NavMeshAgent Agent;
    private float _horizontal;
    private float _vertical;
    public float speed;
    Vector3 move = Vector3.zero;
    public Transform Cam;
    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        _horizontal = Joystick.Horizontal;
        _vertical = Joystick.Vertical;

        if(_horizontal!=0 || _vertical!=0){
            transform.rotation=Quaternion.Lerp(transform.rotation,Cam.transform.rotation,0.3f);
        }

        move=new Vector3(_horizontal,0,_vertical)*Time.deltaTime*speed;

        _rb.MovePosition(transform.position+transform.TransformDirection(move));
    }

    public void DieScene()
    {
        Debug.Log("die...");
    }
}
