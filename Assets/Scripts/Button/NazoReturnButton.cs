using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>�Ȃ����N���b�N�����Ƃ��ɂłĂ���w�i�������X�N���v�g
public class NazoReturnButton : ButtonBase
{
    [Tooltip("��̌��ɂ���p�l��")] GameObject _nazoBackground;
    [Tooltip("�h�A�̓�̌��ɂ���p�l��")] GameObject _lastNazoBackground;

    void Start()
    {
        _nazoBackground = GameObject.Find("NazoBackground");
        _lastNazoBackground = GameObject.Find("LastNazoBackground");
    }

    public override void Click()
    {

        if(this.gameObject.name == "NazoReturnButton")
        {
            //�摜�̓����x��߂��āA�w�i������
            Image.color = ImageColor;
            _nazoBackground.SetActive(false);
            GameManager.instance._isFocused = false;
        }
        else if(this.gameObject.name == "LastNazoReturnButton")
        {
            Image.color = ImageColor;
            _lastNazoBackground.SetActive(false);
            GameManager.instance._isFocused = false;
        }

    }
}