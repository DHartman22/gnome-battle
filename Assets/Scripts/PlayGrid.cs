using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGrid : MonoBehaviour
{
    // Linerenderers?
    [SerializeField] bool generateGrid;
    [SerializeField] int size;
    [SerializeField] float cellSize;
    [SerializeField] GameObject linesContainer;
    [SerializeField] Material lineMat;
    [SerializeField] float width;
    List<List<Tile>> tiles;
    [SerializeField] Grid grid;

    public static PlayGrid instance;
    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
            instance = this;
    }
    void DrawGrid()
    {
        foreach(LineRenderer r in linesContainer.GetComponentsInChildren<LineRenderer>())
        {
            Destroy(r.gameObject);
        }
        for(int i = 0; i <= size; i++)
        {
            GameObject lineobj = new GameObject();
            lineobj.transform.parent = linesContainer.transform;
            LineRenderer line = lineobj.AddComponent<LineRenderer>();

            line.SetPosition(0, new Vector3(0, i * cellSize) + transform.position);
            line.SetPosition(1, new Vector3(size * cellSize, i * cellSize) + transform.position);
            line.material = lineMat;
            line.startWidth = width;
            line.endWidth = width;

            lineobj = new GameObject();
            lineobj.transform.parent = linesContainer.transform;
            line = lineobj.AddComponent<LineRenderer>();

            line.SetPosition(0, new Vector3(i * cellSize, 0) + transform.position);
            line.SetPosition(1, new Vector3(i * cellSize, size * cellSize) + transform.position);
            line.material = lineMat;
            line.startWidth = width;
            line.endWidth = width;
        }
    }

    bool IsTileOccupied(int x, int y)
    {
        return tiles[x][y].occupied;
    }

    Vector3 GetTileCenterWorldPos(int x, int y)
    {
        return grid.GetCellCenterWorld(new Vector3Int(x, y));
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (generateGrid)
            DrawGrid();
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(GetTileCenterWorldPos(0, 0), 1f);
    }
}
