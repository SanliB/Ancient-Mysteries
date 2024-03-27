using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T>
{
    private static T _instance;

    public static T Instance{
        get
        {
            return _instance;
        }
    }
}
