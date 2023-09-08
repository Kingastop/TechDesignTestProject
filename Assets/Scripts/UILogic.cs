using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.Localization.Components;
using UnityEngine.UI;

public class UILogic : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI hintText;
    [SerializeField] Button nextLevelBtn;
    [SerializeField] GameObject[] candles;

    int i = 0, checker = 0;

    private void FixedUpdate()
    {
        if (checker == 0)
        {
            for (i = 0; i < candles.Length; i++)
            {
                if (candles[i].activeSelf)
                {
                    checker++;
                }
            }

            if (checker > 2)
                ChangeHint();
            else
                checker = 0;
        }

    }

    public void ChangeHint()
    {
        LocalizeStringEvent stringEvent = hintText.gameObject.GetComponent<LocalizeStringEvent>();
        stringEvent.SetEntry("Transition_to_scene_2");

        nextLevelBtn.gameObject.SetActive(true);
    }

    public void NextLevel(int level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
}
