using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CellArranger : MonoBehaviour
{
    public Cell playerTemplate;
    public List<Cell> templates;

    public GameObject cellPrefab;

    public List<CellObject> cells;

    public CellObject playerObj;

    // Start is called before the first frame update
    void Start()
    {
        generate();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void generate(int width = 10)
    {
        cells?.ForEach(cell => Destroy(cell.gameObject));
        cells = new List<CellObject>();
        playerObj = generateCell(0, 0, playerTemplate);
        for (int i = 0; i < width; i++)
        {
            float min = -(i + 1.0f) / 2.0f;
            float max = (i + 1.0f) / 2.0f;
            for (int j = 0; j <= i + 1; j++)
            {
                float yPos = j/(i+1.0f) * (max-min) + min;
                int rand = Random.Range(0, templates.Count);
                generateCell(i + 1, yPos, templates[rand]);
            }
        }
    }

    public CellObject generateCell(float x, float y, Cell cell)
    {
        GameObject go = Instantiate(cellPrefab);
        CellObject cellObject = go.GetComponent<CellObject>();
        cellObject.acceptCell(cell);
        go.transform.position = new Vector2(x, y);
        return cellObject;
    }
}
