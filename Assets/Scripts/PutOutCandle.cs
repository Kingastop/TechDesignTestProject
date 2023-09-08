using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PutOutCandle : MonoBehaviour
{
    public GameObject candleAnimObj;

    private void OnMouseDown()
    {
        if (candleAnimObj)
        {
            candleAnimObj.SetActive(false);
        }
    }
}
