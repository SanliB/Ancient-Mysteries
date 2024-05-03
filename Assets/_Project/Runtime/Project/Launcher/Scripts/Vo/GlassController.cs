using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlassController : MonoBehaviour
{
    public Lever_puzzle Lever1, Lever2, Lever3, Lever4, Lever5;
    private bool firstEntry = false;
    private float LockedGlass;

    // Start is called before the first frame update
    void Start()
    {
        LockedGlass = gameObject.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Lever1._trueRotStatus && Lever2._trueRotStatus && Lever3._trueRotStatus && Lever4._trueRotStatus && Lever5._trueRotStatus && firstEntry == false)
        {
            firstEntry = true;
            gameObject.transform.DOMoveY(LockedGlass + 1f, LockedGlass + 1 - gameObject.transform.position.y);
        }
        else if (!Lever1._trueRotStatus || !Lever2._trueRotStatus || !Lever3._trueRotStatus || !Lever4._trueRotStatus || !Lever5._trueRotStatus)
        {
            if (firstEntry && LockedGlass != gameObject.transform.position.y)
            {
                firstEntry = false;
                gameObject.transform.DOMoveY(LockedGlass, 1f);
            }
        }
    }
}
