using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>視点を左に回転させるスクリプト</summary>
public class LeftButton : ButtonBase
{
    [Tooltip("メインカメラオブジェクト")] GameObject _mainCamera;
    [SerializeField] ThinkingButton _thinkingButton;

    private void Start()
    {
        _mainCamera = GameObject.Find("Main Camera");
    }

    public override void Click()
    {
        _thinkingButton.AngleChange = true;
        _mainCamera.transform.Rotate(0, -90, 0);
    }
}
