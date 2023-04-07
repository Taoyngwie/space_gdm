using UnityEngine;

public class HexagonPattern : MonoBehaviour
{
    public Sprite hexagonSprite;
    public float hexagonSize;
    public float hexagonWidth = 0.75f;

    public int width = 10;
    public int height = 10;

    void Start()
    {
        HexagonPattern hexPattern = GetComponent<HexagonPattern>();

        for (int x = -20; x < width; x++)
        {
            for (int y = -20; y < height; y++)
            {
                Vector2 position = new Vector2(x, y);
                hexPattern.GetHexagon(position);
            }
        }
    }


    public GameObject GetHexagon(Vector2 position)
    {
        float x = position.x;
        float y = position.y;

        float xPos = x * hexagonWidth * hexagonSize;
        float yPos = y * hexagonSize * Mathf.Sqrt(3) + ((x % 2 == 0) ? 0 : hexagonSize * Mathf.Sqrt(3) / 2);

        Vector2 hexagonPos = new Vector2(xPos, yPos);

        GameObject hexagon = new GameObject("Hexagon");
        hexagon.transform.parent = transform;
        hexagon.transform.position = hexagonPos;

        SpriteRenderer hexagonRenderer = hexagon.AddComponent<SpriteRenderer>();
        hexagonRenderer.sprite = hexagonSprite;

        return hexagon;
    }
}
