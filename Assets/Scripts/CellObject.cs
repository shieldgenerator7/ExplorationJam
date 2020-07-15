using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellObject : MonoBehaviour
{
    public Cell cell;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void acceptCell(Cell cell)
    {
        this.cell = cell;
        GetComponent<SpriteRenderer>().sprite = cell.sprite;
    }
}
