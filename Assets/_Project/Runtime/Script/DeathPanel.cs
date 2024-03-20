using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathPanel : MonoSingleton<DeathPanel>
{
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void returnGame()
    {
        
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void DieScene()
    {
        
        gameObject.SetActive(false);
        Time.timeScale = 1;
        CharacterController.Instance._rb.transform.position= new Vector3(-18,-10,18);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
