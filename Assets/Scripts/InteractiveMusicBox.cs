using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveMusicBox : MonoBehaviour
{
    [SerializeField] GameObject[] notes;
    private bool playing = false;
    private Animator animator;
    private AudioSource audioSource;

    private Vector3[] notesPos;

    private void Start()
    { 
        audioSource = GetComponent<AudioSource>();
        audioSource.Pause();

        animator = GetComponentInChildren<Animator>();
        animator.speed = 0;


        notesPos = new Vector3[notes.Length];

        for (int i = 0; i < notes.Length; i++)
        {
            notesPos[i] = notes[i].transform.position;
        }
    }

    private void OnMouseDown()
    {
        playing = !playing;
        if (playing)
        {
            animator.speed = 1;
            audioSource.Play();
            for (int i = 0; i < notes.Length; i++)
            {
                notes[i].transform.position = notesPos[i];
                notes[i].SetActive(true);
                notes[i].GetComponent<Animator>().SetBool("Playing?", true);
            }
        }
        else
        {
            animator.speed = 0;
            audioSource.Pause();

            for (int i = 0; i < notes.Length; i++)
            {
                notes[i].GetComponent<Animator>().SetBool("Playing?", false);

            }
        }
    }
}
