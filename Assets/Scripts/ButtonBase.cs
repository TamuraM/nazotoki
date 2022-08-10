using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

/// <summary>�{�^���̊��N���X</summary>
public class ButtonBase : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    [Tooltip("���ꂪ���Ă�I�u�W�F�N�g�̃C���[�W�R���|�[�l���g")] Image _image;
    [Tooltip("���̃C���[�W�̐F")] Color _imageColor;

    public Image Image
    {
        get
        {
            return _image;
        }

        set
        {
            _image = value;
        }
    }

    public Color ImageColor
    {
        get
        {
            return _imageColor;
        }

        set
        {
            _imageColor = value;
        }
    }

    private void Awake()
    {
        _image = this.gameObject.GetComponent<Image>();
        _imageColor = _image.color;
    }

    /// <summary>�{�^�����������Ƃ��̏���</summary>
    public virtual void Click()
    {
        Debug.LogError("�p����̔h���N���X�Ŋ֐����`���Ă��������B");
    }

    public void OnPointerClick(PointerEventData eventData) // �{�^����������A���̌�h���b�O���삪���邱�ƂȂ��{�^�����������
    {
        Click();
    }

    /// <summary>�{�^���̏�ɃJ�[�\����������瓧���x��������</summary>
    /// <param name="eventData"></param>
    public void OnPointerEnter(PointerEventData eventData) //�{�^���͈̔͂Ƀ}�E�X�J�[�\��������
    {
        _image.color = _imageColor +  new Color(0, 0, 0, 105);
    }

    /// <summary>�{�^���̏ォ��J�[�\�����Ȃ��Ȃ����瓧���x���グ��</summary>
    /// <param name="eventData"></param>
    public void OnPointerExit(PointerEventData eventData) //�{�^���͈̔͂���}�E�X�J�[�\�����o��
    {
        _image.color = _imageColor;
    }
}