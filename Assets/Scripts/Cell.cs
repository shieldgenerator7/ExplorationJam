using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Cell", menuName ="Cell")]
public class Cell : ScriptableObject
{
    public Sprite sprite;
    public enum Type
    {
        PLAYER,
        ENEMY,
        ITEM
    }
    public Type type;
    public List<string> rpsList;
}
