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

    int i = 0, sumVariable, desirableCount, initialCount, checker;
    bool desirableBool;
    Scene currentScene;

    private SpriteRenderer[] sprites;

    private void Start()
    {
        currentScene = SceneManager.GetActiveScene();
        switch (currentScene.buildIndex)
        {
            case 0:
                initialCount = 0;
                desirableCount = 3;
                sumVariable = 1;

                checker = initialCount;
                desirableBool = true;

                sprites = new SpriteRenderer[candles.Length];
                for (i = 0; i < candles.Length; i++)
                {
                    sprites[i] = candles[i].GetComponentInChildren<SpriteRenderer>();

                    if (i != 0)
                        sprites[i].enabled = false;
                }
                break;


            case 1:
                initialCount = 3;
                desirableCount = 0;
                sumVariable = -1;

                checker = initialCount;
                desirableBool = false;
                
                sprites = new SpriteRenderer[candles.Length];
                for (i = 0; i < candles.Length; i++)
                {
                    sprites[i] = candles[i].GetComponentInChildren<SpriteRenderer>();
                }

                break;
        }


        
    }

    private void Update()
    {


        for (i = 0; i < candles.Length; i++)
        {
            
            if (sprites[i].enabled == desirableBool)
            {
                checker += sumVariable;
            }
        }

        if (checker == desirableCount)
            ChangeHint();
        else
            checker = initialCount;
       
    }

    public void ChangeHint()
    {
        LocalizeStringEvent stringEvent = hintText.gameObject.GetComponent<LocalizeStringEvent>();
        switch (currentScene.buildIndex)
        {
            case 0:

                stringEvent.SetEntry("Transition_to_scene_2");

                nextLevelBtn.gameObject.SetActive(true);

                break;

            case 1:

                stringEvent.SetEntry("Another_transition_to_scene_1");

                nextLevelBtn.gameObject.SetActive(true);

                break;
        }
    }

    public void PunishmentHint()
    {
        LocalizeStringEvent stringEvent = hintText.gameObject.GetComponent<LocalizeStringEvent>();

        stringEvent.SetEntry("Punishment");
    }

    public void OkExodus()
    {
        nextLevelBtn.gameObject.SetActive(true);
    }

    public void NextLevel(int level)
    {
        SceneManager.LoadScene(level, LoadSceneMode.Single);
    }
}
