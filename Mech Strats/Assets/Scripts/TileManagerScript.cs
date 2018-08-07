using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManagerScript : MonoBehaviour {
    GameObject[,] map;
    Vector2Int size;

    bool somethingSelected;
    Vector2Int selected;

    public Tilemap tilemap;

    public GameObject wolf;

    GameObject CreateWolf(Vector2Int position)
    {
        Vector2Int i = position + new Vector2Int(size.x / 2, size.y / 2);

        map[i.x, i.y] = Instantiate(wolf, new Vector3(position.x + 0.5f, position.y + 0.5f, 0), Quaternion.identity);
        map[i.x, i.y].transform.parent = gameObject.transform;

        return map[i.x, i.y];
    }

    Vector3 GetHoveredTile()
    {
        float distance = -Camera.main.transform.position.z;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Vector3 pos = tilemap.WorldToCell(ray.GetPoint(-ray.origin.z / ray.direction.z));
        return pos;
    }

    void Move(int xi, int yi, int xf, int yf) {
        map[xi, yi].GetComponent<MovementScript>().Move(xf, yf);
        map[xf + size.x / 2, yf + size.y / 2] = map[xi, yi];
        map[xi, yi] = null;

        somethingSelected = false;
    }

    // Use this for initialization
    void Start () {
        size = new Vector2Int(20, 10);
        map = new GameObject[size.x, size.y];

        GameObject wolf1 = CreateWolf(new Vector2Int(-8, 1));
        //CreateWolf(new Vector2Int(-8, -2));
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Vector3Int hoveredTile = Vector3Int.FloorToInt(GetHoveredTile());
            int x = hoveredTile.x + size.x / 2;
            int y = hoveredTile.y + size.y / 2;

            if (map[x, y] == null && somethingSelected) {
                Move(selected.x, selected.y, hoveredTile.x, hoveredTile.y);
            } else if (map[x, y] != null) {
                somethingSelected = true;
                selected = new Vector2Int(x, y);
            }
        }
    }
}
