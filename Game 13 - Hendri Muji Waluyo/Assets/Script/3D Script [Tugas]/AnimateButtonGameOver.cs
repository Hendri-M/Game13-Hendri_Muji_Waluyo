using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimateButtonGameOver : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] AudioSource hoverSFX;
    [SerializeField] AudioSource clickSFX;
    public RectTransform button;

    void Start()
    {
        button.GetComponent<Animator>().Play("Hover Off (GameOver)");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("Hover On (GameOver)");
        hoverSFX.Play();

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("Hover Off (GameOver)");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickSFX.Play();
    }

}
