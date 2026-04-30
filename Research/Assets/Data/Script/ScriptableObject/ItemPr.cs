using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPr : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private string _discritption;
    [SerializeField] private Sprite _icon;
    [SerializeField] private TypeItem _typeItem;

    public string Name => this._name;
    public string Discritption => this._discritption;
    public Sprite Icon => this._icon;
    public TypeItem Type => this._typeItem;

    public void SetData(ItemScriptableObject data)
    {
        _name = data.Name;
        _discritption = data.Discritption;
        _icon = data.Icon;
        _typeItem = data.Type;
    }
}
