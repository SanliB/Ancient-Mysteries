using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassController : MonoBehaviour
{
    public Lever_puzzle Lever1, Lever2, Lever3, Lever4, Lever5;
    private bool firstEntry = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Lever1._trueRotStatus && Lever2._trueRotStatus && Lever3._trueRotStatus && Lever4._trueRotStatus && Lever5._trueRotStatus && firstEntry == false)
        {
            firstEntry = true;
            gameObject.transform.DOMoveY(gameObject.transform.position.y + 1f, 1);
        }
    }
}
