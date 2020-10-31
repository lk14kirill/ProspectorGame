using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CardState
{
    drawpile,
    tableau,
    target,
    discard
}

public class CardProspector : Card
{
    public CardState state = CardState.drawpile;
    public List<CardProspector> hiddenby = new List<CardProspector>();
    public int layoutId;
    public SlotDef slotDef;

}
