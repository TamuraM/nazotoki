using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ReturnKey : ButtonBase
{
    [SerializeField] NumberKeyController _numberKeyController;
    [SerializeField, Header("数字入力画面")] GameObject _inputNumber;

    public override void Click()
    {
        //画像の透明度を戻して、背景を消す
        _numberKeyController.InputNumber = "";
        Image.color = ImageColor;
        _inputNumber.SetActive(false);
        GameManager.Instance._isFocused = false;
    }
}
