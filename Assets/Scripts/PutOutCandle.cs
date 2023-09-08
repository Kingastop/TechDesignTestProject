using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOutCandle : MonoBehaviour
{
    public SpriteRenderer candleAnimObj;
    public Light lightSource;

    private void OnMouseDown()
    {
        if (candleAnimObj)
        {
            candleAnimObj.enabled = false;
            lightSource.enabled = false;
        }
    }
}
