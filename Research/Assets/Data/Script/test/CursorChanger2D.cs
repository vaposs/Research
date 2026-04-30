using UnityEngine;

public class CursorChanger2D : MonoBehaviour
{
    [SerializeField] private Texture2D defaultCursor;

    private CursorMode cursorMode = CursorMode.Auto;
    private Camera mainCamera;
    
    void Start()
    {
        mainCamera = Camera.main;
    }
    
    void Update()
    {
        Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);
    
        if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out Wood wood))
        {
            Cursor.SetCursor(wood.GetCursoreSprite(), Vector2.zero, cursorMode);
            wood.SpawnResource();
        }
        else if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out Stone stone))
        {
            Cursor.SetCursor(stone.GetCursoreSprite(), Vector2.zero, cursorMode);
            stone.SpawnResource();
        }
        else if (hit.collider != null && hit.collider.gameObject.TryGetComponent(out Water water))
        {
            Cursor.SetCursor(water.GetCursoreSprite(), Vector2.zero, cursorMode);
            water.SpawnResource();
        }
        else
        {
            Cursor.SetCursor(defaultCursor, Vector2.zero, cursorMode);
        }
    }
}