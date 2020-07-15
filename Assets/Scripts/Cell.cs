using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="Cell", menuName ="Cell")]
public class Cell : ScriptableObject
{
    public Sprite sprite;
    public Color color = Color.white;
    public enum Type
    {
        NONE,
        PLAYER,
        ENEMY,
        ITEM
    }
    public Type type;
    public List<string> rpsList;
    public int score;
}
