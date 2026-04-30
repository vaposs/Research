using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item/New Item")]
public class ItemScriptableObject : ScriptableObject
{
    [SerializeField] private string _name;
    [SerializeField] private string _discritption;
    [SerializeField] private Sprite _icon;
    [SerializeField] private TypeItem _typeItem;

    public string Name => this._name;
    public string Discritption => this._discritption;
    public Sprite Icon => this._icon;
    public TypeItem Type => this._typeItem;
}
