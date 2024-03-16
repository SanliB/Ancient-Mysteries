using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoSingleton<DoorController>
{
    public GameObject[] DoorList;

    public GameObject Door(int a)
    {
        return DoorList[a];
    }
}
