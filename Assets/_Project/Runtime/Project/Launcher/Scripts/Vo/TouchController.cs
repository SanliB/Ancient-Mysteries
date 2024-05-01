using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class TouchController : MonoBehaviour, IPointerDownHandler, IDragHandler, IPointerUpHandler
{
    private float _startPosX, _startPosY;
    private float _currentPosX, _currentPosY;

    public float SliderHorizontal{get; private set;}
    public float SliderVertical{get; private set;}

     public void OnPointerDown(PointerEventData eventData)
    {
        _startPosX=eventData.position.x;
        _startPosY=eventData.position.y;
    }

    public void OnDrag(PointerEventData eventData)
    {
        float Sensitivity = PlayerPrefs.GetFloat("Sensitivity");
        _currentPosX=eventData.position.x;
        _currentPosY=eventData.position.y;
        //sağa dönüş
        if(_startPosX-_currentPosX < -20){
            SliderHorizontal=Mathf.Clamp(SliderHorizontal += 0.5f, -Sensitivity, Sensitivity);
            _startPosX=_currentPosX;
        }
        //sola dönüş
        if(_startPosX-_currentPosX > 20){
            SliderHorizontal=Mathf.Clamp(SliderHorizontal -= 0.5f, -Sensitivity, Sensitivity);
            _startPosX=_currentPosX;
        }
        // Yukarı
        if (_startPosY - _currentPosY < -20)
        {
            SliderVertical = Mathf.Clamp(SliderVertical += 0.5f, -Sensitivity, Sensitivity);
            _startPosY = _currentPosY;
        }
        // Aşağı 
        if (_startPosY - _currentPosY > 20)
        {
            SliderVertical = Mathf.Clamp(SliderVertical -= 0.5f, -Sensitivity, Sensitivity);
            _startPosY = _currentPosY;
        }
    }

    public void OnPointerUp(PointerEventData eventData){
        SliderHorizontal=0;
        SliderVertical=0;
    }
    
}
