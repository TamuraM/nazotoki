using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>�^�C�v���C�^�[���N���b�N�����Ƃ��ɏo�Ă���w�i�������X�N���v�g</summary>
public class InputTextReturnButton : ButtonBase
{
    [Tooltip("�������͂̌��ɂ���p�l��")] GameObject _inputTextBackground;
    [Tooltip("���͂��ꂽ�e�L�X�g")] Text _inputText;

    void Start()
    {
        _inputTextBackground = GameObject.Find("InputTextBackground");
        _inputText = GameObject.Find("InputText").GetComponent<Text>();
    }

    public override void Click()
    {
        _inputText.text = "";
        Image.color = ImageColor;
        _inputTextBackground.SetActive(false);
        GameManager.instance._isFocused = false;
    }
}