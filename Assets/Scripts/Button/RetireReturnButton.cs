using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RetireReturnButton : ButtonBase
{
    [SerializeField, Header("リタイア画面の背景")] GameObject _retirePanel;

    public override void Click()
    {
        Image.color = ImageColor;
        _retirePanel.SetActive(false);
    }

}
