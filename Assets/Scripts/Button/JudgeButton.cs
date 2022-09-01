using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>���͂��ꂽ�e�L�X�g���������ǂ������肷��X�N���v�g</summary>
public class JudgeButton : ButtonBase
{
    [Tooltip("���͂��ꂽ�e�L�X�g")] Text _inputText;
    [Tooltip("��̓���")] string seikai = "answer";
    [SerializeField, Header("�{�^��"), Tooltip("�{�^���̃Q�[���I�u�W�F�N�g")] GameObject _button;
    [Tooltip("�������͂̌��ɂ���p�l��")] GameObject _inputTextBackground;

    void Start()
    {
        _inputTextBackground = GameObject.Find("InputTextBackground");
        _inputText = GameObject.Find("InputText").GetComponent<Text>();
        _button.SetActive(false);
    }

    public override void Click()
    {
        //���͂��ꂽ�e�L�X�g���������ǂ������肷��
        if(_inputText.text == seikai)
        {
            //�����������烌�o�[�������
            _button.SetActive(true);
            _inputTextBackground.SetActive(false);
            GameManager.instance._isFocused = false;
        }
        else
        {
            _inputText.text = "";
        }
    }
}