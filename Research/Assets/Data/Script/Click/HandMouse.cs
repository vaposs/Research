using System.Collections.Generic;
using UnityEngine;

public class HandMouse : MonoBehaviour
{
    [SerializeField] private Canvas _canvas;
    [SerializeField] private MiningControl _miningControl;
    [SerializeField] private Cell _prefabCell;
    [SerializeField] private Vector3 _offSet;

    private Queue<Res> _hand = new Queue<Res>();
    private List<Cell> _cell = new List<Cell>();

    private void Update()
    {
        if(_hand.Count > 0 && _canvas.enabled == true)
        {
            _canvas.transform.position = _miningControl.TakeMousePosition() + _offSet;
        }
    }

    public void TakeInHand(Res res)
    {
        res.gameObject.SetActive(false);
        _hand.Enqueue(res);

        Cell tempCell = Instantiate(_prefabCell);
        _cell.Add(tempCell);
        tempCell.transform.SetParent(_canvas.transform);
        tempCell.SetIcon(res);
    }

    public Res GetInHand(Vector3 position)
    {
        Res res = _hand.Dequeue();
        res.gameObject.SetActive(true);
        res.transform.position = position;
        
        Destroy(_cell[_cell.Count-1].gameObject);
        _cell.RemoveAt(_cell.Count-1);
        return res;
    }

    public int TakeCountRes()
    {
        return _hand.Count;
    }
}
