using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimateButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField] AudioSource hoverSFX;
    [SerializeField] AudioSource clickSFX;
    public RectTransform button;

    void Start()
    {
        button.GetComponent<Animator>().Play("Hover Off");
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("Hover On");
        hoverSFX.Play();

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        button.GetComponent<Animator>().Play("Hover Off");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        clickSFX.Play();
    }

}
