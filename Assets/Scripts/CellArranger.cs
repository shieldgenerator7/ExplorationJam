using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CellArranger : MonoBehaviour
{
    public float range = 1.5f;
    public Cell playerTemplate;
    public List<Cell> templates;

    public GameObject cellPrefab;

    public List<CellObject> cells;

    public CellObject playerObj;
    public GameObject canvas;
    public GameObject camera;
    public Text text;

    // Start is called before the first frame update
    void Start()
    {
        generate();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D rch2d =Physics2D.Raycast(mousePos, Vector2.up, 0.1f);
            if (rch2d.collider && rch2d.collider.gameObject != playerObj.gameObject)
            {
                if ((rch2d.collider.transform.position - playerObj.transform.position).magnitude <= range)
                {
                    CellObject co = rch2d.collider.gameObject.GetComponent<CellObject>();
                    adjustScore(co.cell.score);
                    playerObj.transform.position = rch2d.collider.transform.position;
                    Destroy(rch2d.collider.gameObject);
                }
            }
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene("SampleScene");
        }
    }

    public void generate(int width = 10)
    {
        canvas.transform.parent = null;
        camera.transform.parent = null;
        cells?.ForEach(cell => Destroy(cell.gameObject));
        cells = new List<CellObject>();
        playerObj = generateCell(0, 0, playerTemplate);
        canvas.transform.parent = playerObj.transform;
        canvas.transform.position = Vector2.up;
        camera.transform.parent = playerObj.transform;
        camera.transform.position = new Vector3(0,0,-10);
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

    public int score;
    public void adjustScore(int add)
    {
        score += add;
        text.text = ""+score;
    }
}
