using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InteractiveNotes : MonoBehaviour
{
    Vector3 currentMousePosition;
    [SerializeField] GameObject burningEffect;
    BoxCollider2D noteCollider;
    public event Action animationTriggered;

    private void Start()
    {
        noteCollider = GetComponent<BoxCollider2D>();
    }

    private void Awake()
    {
        animationTriggered += EndOfAnimation;
    }

    private Vector3 GetMousePosition()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        currentMousePosition = Input.mousePosition - GetMousePosition();
        burningEffect.SetActive(true);
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - currentMousePosition);
    }

    private void OnMouseUp()
    {
        burningEffect.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] colliders = Physics2D.OverlapBoxAll(transform.position, noteCollider.size, LayerMask.GetMask("Candles"));
        
        if(colliders != null)
        {
            collision.GetComponent<PutOutCandle>().candleAnimObj.SetActive(true);
            OnMouseUp();
            gameObject.SetActive(false);
        }
    }

    public void TriggeredAnimation() =>
        animationTriggered?.Invoke();


    private void EndOfAnimation()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        animationTriggered -= EndOfAnimation;
    }

}
