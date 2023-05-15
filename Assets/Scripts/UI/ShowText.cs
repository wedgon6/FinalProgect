using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShowText : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject _text;

    private void Start()
    {
        _text.SetActive(false);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _text.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _text.SetActive(false);
    }
}
