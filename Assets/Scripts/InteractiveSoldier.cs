using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class InteractiveSoldier : MonoBehaviour
{
    [SerializeField] Canvas openDialogWindow;

    private SkeletonAnimation skeletonAnim;

    private void Start()
    {
        skeletonAnim = GetComponent<SkeletonAnimation>(); 
    }


    private void OnMouseDown()
    {
        skeletonAnim.AnimationName = "Parried";
        Spine.Animation animationObject = skeletonAnim.skeletonDataAsset.GetSkeletonData(false).FindAnimation(skeletonAnim.AnimationName);
        skeletonAnim.loop = false;

        openDialogWindow.gameObject.SetActive(true);
        GetComponent<AudioSource>().Play();
    }

    private void OnMouseUp()
    {
        skeletonAnim.AnimationName = "Idle";
        Spine.Animation animationObject = skeletonAnim.skeletonDataAsset.GetSkeletonData(false).FindAnimation(skeletonAnim.AnimationName);
        skeletonAnim.loop = true;
    }
}
