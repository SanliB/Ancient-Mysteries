using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResumeGame : MonoBehaviour
{
    public GameObject Character;
    // Start is called before the first frame update

    private void Awake()
    {
        Vector3 CharacterPos;
        CharacterPos.x = PlayerPrefs.GetFloat("CharacterPosX");
        CharacterPos.y = PlayerPrefs.GetFloat("CharacterPosY");
        CharacterPos.z = PlayerPrefs.GetFloat("CharacterPosZ");
        Character.GetComponent<Transform>().position = CharacterPos;
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
