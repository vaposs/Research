using System.Collections;
using System.Data.Common;
using UnityEngine;

public class MiningControl : MonoBehaviour
{
    private HandMouse _handMouse;
    private Coroutine _passiveMining = null;

    private void Awake()
    {
        _handMouse = FindAnyObjectByType<HandMouse>();
    }
    private void Update()
    {
        OneLeftClick();
        OnRightClick();

        if(_passiveMining == null)
        {
            PressButtonMouse();
        }
    }

    private void OnRightClick()
    {
        if(Input.GetMouseButtonDown(1))
        {
            if(_handMouse.TakeCountRes() > 0)
            {
                _handMouse.GetInHand(TakeMousePosition());
            }
        }
    }

    private void OneLeftClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Reaction();
        }
    }

    private void PressButtonMouse()
    {
        if(Input.GetMouseButton(0))
        {
            Reaction();
        }
    }

    private void Reaction()
    {
        RaycastHit2D hit2D = Physics2D.Raycast(TakeMousePosition(), Vector2.zero);

        if(hit2D.collider != null)
        {
            if(hit2D.collider.TryGetComponent<MineAbs>(out MineAbs mine))
            {
                mine.SpawnResource();
                _passiveMining = StartCoroutine(Sleep());
            }
            else if(hit2D.collider.TryGetComponent<Res>(out Res resource))
            {
                if(_handMouse.TakeCountRes() < SettingPlayer.TakeMaxItem())
                {
                    _handMouse.TakeInHand(resource);
                }
            }
        }

        Debug.DrawLine(transform.position, TakeMousePosition());
    }

    public Vector3 TakeMousePosition()
    {
        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorldPosition.z = 0;

        return mouseWorldPosition;
    }

    private IEnumerator Sleep()
    {
        yield return SettingPlayer.TakeTimeMining();
        _passiveMining = null;
    }
}