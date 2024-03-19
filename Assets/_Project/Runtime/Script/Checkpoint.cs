using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    public Button yourButton;
    // Start is called before the first frame update
    void Start()
    {
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
        Invoke("TaskOnClick",1);
    }
    void TaskOnClick(){
        
        SceneManager.LoadScene("Demo_Scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
