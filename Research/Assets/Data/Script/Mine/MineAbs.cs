using UnityEditor;
using UnityEngine;

public abstract class MineAbs : MonoBehaviour
{
    [SerializeField] private Texture2D _cursorSprite;
    [SerializeField] private string _nameResources;
    [SerializeField] private float _spawnRadius;

    private ItemPr _item; 
    private ItemScriptableObject _tempResource;

    private void Start()
    {
        _tempResource = Resources.Load<ItemScriptableObject>("ItemSc/" + _nameResources);
    }
    
    public Texture2D GetCursoreSprite()
    {
        return _cursorSprite;
    }
    
    public void SpawnResource()
    {
        GameObject res = new GameObject();
        res.name = _tempResource.name;
        SpriteRenderer sr = res.AddComponent<SpriteRenderer>();
        sr.sprite = _tempResource.Icon;
        sr.sortingOrder = 1;
        Rigidbody2D rb = res.AddComponent<Rigidbody2D>();
        rb.gravityScale = 0;
        CircleCollider2D col = res.AddComponent<CircleCollider2D>();
        col.radius = 0.2f;
        Res resource = res.AddComponent<Res>();
        
        res.transform.position = (Vector2)transform.position + Random.insideUnitCircle * _spawnRadius;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, _spawnRadius);
    }
}
