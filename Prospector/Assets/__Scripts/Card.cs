﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card : MonoBehaviour
{
    public string suit;
    public int    rank;
    public Color  color;
    public string colS = "Black";
    public List<GameObject> decoGOs = new List<GameObject>();
    public List<GameObject> pipGos = new List<GameObject>();
    public GameObject back;
    public CardDefinition def;
    public SpriteRenderer[] spriteRenderers;
    void Start()
    {
        SetSortOrder(0);
    }
    public bool faceUp
    {
        get { return !back.activeSelf; }
        set {  back.SetActive(!value); }
    }
    public void PopulateSpriteRenderers()
    {
        if(spriteRenderers == null|| spriteRenderers.Length == 0)
        {
            spriteRenderers = GetComponentsInChildren<SpriteRenderer>();
        }
    }
    public void SetSortingSortingLayerName(string tSLN)
    {
        PopulateSpriteRenderers();
        foreach(SpriteRenderer tSR in spriteRenderers)
        {
            tSR.sortingLayerName = tSLN;
        }
    }
    public void SetSortOrder(int sOrd)
    {
        PopulateSpriteRenderers();
        foreach(SpriteRenderer tSR in spriteRenderers)
        {
            if(tSR.gameObject == this.gameObject)
            {
                tSR.sortingOrder = sOrd;
                continue;
            }
            switch (tSR.gameObject.name)
            {
                case "back":
                    tSR.sortingOrder = sOrd + 2;
                    break;
                case "face":
                default:
                    tSR.sortingOrder = sOrd + 1;
                    break;
            }
        }


    }
}

[System.Serializable]
public class Decorator
{
    public string type;
    public Vector3 loc;
    public bool flip = false;
    public float scale = 1f; 
}
[System.Serializable]
public class CardDefinition
{
    public string face;
    public int rank;
    public List<Decorator> pips = new List<Decorator>();
}

