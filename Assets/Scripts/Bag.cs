﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Bag : MonoBehaviour, IDropHandler
{
    [SerializeField] public Boolean unlock = true;
    private Boolean empty = true;
    public GameObject butin;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
    }
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("drop in bag");
        if (eventData.pointerDrag != null & empty & unlock)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            eventData.pointerDrag.transform.parent = transform;
            eventData.pointerDrag.GetComponent<DragDrop>().inThePocket = true;
            empty = false;
            canvasGroup.blocksRaycasts = false;
            Debug.Log("bag is full");
            butin = eventData.pointerDrag;
        }
    }
}
