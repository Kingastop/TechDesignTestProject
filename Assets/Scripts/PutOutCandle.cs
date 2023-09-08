using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOutCandle : MonoBehaviour
{
    public SpriteRenderer candleAnimObj;

    private void OnMouseDown()
    {
        if (candleAnimObj)
        {
            candleAnimObj.enabled = false;
        }
    }
}
