using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Cell : MonoBehaviour
{
    [SerializeField] private Image _icon;
    private Text _countText;
    private int _count = 0;

    public int TakeCount()
    {
        return _count;
    }
    public void SetIcon(Res res)
    {
        _icon.sprite = res.GetComponent<SpriteRenderer>().sprite;
    }

    public void DeleteIcon()
    {
        _icon = null;
    }
    public void AddCount()
    {
        _count++;

        OffOnTextVisible();
    }

    public void MinusCount()
    {
        _count--;

        OffOnTextVisible();
    }

    private void OffOnTextVisible()
    {
        if(_count > 1)
        {
            _countText.gameObject.SetActive(true);
        }
        else
        {
            _countText.gameObject.SetActive(false);
        }
    }
}
