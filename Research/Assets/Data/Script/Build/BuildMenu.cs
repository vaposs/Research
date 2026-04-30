using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenu : MonoBehaviour
{
    [SerializeField] private MiningControl _miningControl;

    private Build _tempBuild = null;
    private void Update()
    {
        if(_tempBuild != null)
        {
            _tempBuild.transform.position = _miningControl.TakeMousePosition();
        }

        if(Input.GetMouseButtonDown(0))
        {
            _tempBuild = null;
        }
    }
    public void Building(Build build)
    {
        _tempBuild = Instantiate(build);
    }
}
