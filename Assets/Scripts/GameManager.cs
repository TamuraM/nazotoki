using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Linq;

/// <summary>ゲームマネージャー！！！！！！！！！</summary>
public class GameManager : MonoBehaviour
{

    public static GameManager instance; 

    Clear _clearState;

    [SerializeField, Header("ライト1のMeshRenderer"), Tooltip("1つ目のライトのメッシュレンダラー")] MeshRenderer _light1;
    [SerializeField, Header("ライト2のMeshRenderer"), Tooltip("2つ目のライトのメッシュレンダラー")] MeshRenderer _light2;
    [SerializeField, Header("ライト3のMeshRenderer"), Tooltip("3つ目のライトのメッシュレンダラー")] MeshRenderer _light3;
    [SerializeField, Header("光ってないマテリアル"), Tooltip("ライトがひかってないときのマテリアル")] Material _lightMaterial;
    [SerializeField, Header("光るMaterial"), Tooltip("ライトが光ってるマテリアル")] Material _lightEmission;

    [SerializeField, Header("謎解きのImage"), Tooltip("謎解きがかいてある画像")] GameObject _nazo;
    [SerializeField, Header("入力するテキストGameObject"), Tooltip("タイプライターをクリックしたときに出てくる入力画面パネル")] GameObject _inputText;
    [SerializeField, Header("ボタン"), Tooltip("ボタンのゲームオブジェクト")] GameObject _button;

    [Tooltip("背面にある色付きボタンのリスト")] List<string> _buttons = new();
    [Tooltip("ボタンの配列 押す順番に名前が入ってる")] //黄、白、青、赤、緑
    string[] _colorButton = { "YellowButton", "WhiteButton", "BlueButton", "RedButton", "GreenButton" };
    [SerializeField, Tooltip("ボタンを正しく押せた時に光るライトのリスト")] List<MeshRenderer> _lights = new(5);
    [Tooltip("ライトのやつカウントする数字")] int _lighting = 0;

    [Tooltip("オブジェクトに触れる時かどうか")] bool _inGame;

    /// <summary>謎解きの進行度</summary>
    enum Clear
    {
        ClearSitenaiMan = 0,
        /// <summary>最初の謎解けた</summary>
        FirstStageClear = 1 << 0,
        /// <summary>二番目の謎解けた</summary>
        SecondStageClear = 1 << 1,
        /// <summary>三番目の謎解けた</summary>
        ThirdStageClear = 1 << 2,
        /// <summary>すべての謎解けた</summary>
        AllStageClear = 1 << 3, 
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        _clearState = Clear.ClearSitenaiMan;
        _button.SetActive(false);
        _nazo.SetActive(false);
        _inputText.SetActive(false);
        _buttons = _colorButton.ToList();
    }

    
    void Update()
    {
        //右クリックで現在のクリア状況を確認
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            Debug.Log(_clearState);
        }

        //全部の謎解いたら、ステータスが「すべての謎を解いた」になる
        if((_clearState & Clear.FirstStageClear) == Clear.FirstStageClear && (_clearState & Clear.SecondStageClear) == Clear.SecondStageClear && (_clearState & Clear.ThirdStageClear) == Clear.ThirdStageClear)
        {
            _clearState = Clear.AllStageClear;
        }

        
        Ray _ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit _hit;

        if(_inGame)
        {
            if (Physics.Raycast(_ray, out _hit, 10.0f, 3) && Input.GetMouseButtonDown(0))
            {
                //Debug.Log(_hit.collider.gameObject.name);

                //左側にある謎解き　机の上の紙クリックして謎解いてなんかしたらレバー現れる
                if (_hit.collider.gameObject.name == "Nazo")
                {
                    Debug.Log("なぞだ");
                    _nazo.SetActive(true);
                }

                //タイプライタークリックしたら、入力画面でてくる
                if (_hit.collider.gameObject.name == "Typewriter")
                {
                    Debug.Log("タイプライターだ");
                    _inputText.SetActive(true);
                }

                if (_hit.collider.gameObject == _button)
                {
                    _clearState |= Clear.FirstStageClear;
                }

                //背面にある謎解き　クリックした順番があってたらクリア
                //メインカメラからRayを飛ばして、オブジェクトを探す
                //左クリックしたオブジェクトが_buttonリストの0番目と同じならリストから消える
                //全部消えたらクリア
                if (_hit.collider.gameObject.name == _buttons[0])
                {
                    //正解のボタンを押したら、上にあるライトが順番に点く
                    _buttons.RemoveAt(0);
                    Debug.Log(_buttons.Count);
                    _lights[_lighting].material = _lightEmission;
                    _lighting = _lighting < 5 ? _lighting++ : _lighting;
                }
                else if (_hit.collider.gameObject.name != _buttons[0] && _hit.collider.gameObject.tag == "ColorButton")
                {
                    //間違ったボタンを押したら、上にあるライトが全部消える
                    _buttons = _colorButton.ToList();
                    Debug.Log(_buttons.Count);
                    _lighting = 0;
                    _lights.ForEach(light => light.material = _lightMaterial);

                    //foreach (MeshRenderer light in _lights)
                    //{
                    //    light.material = _lightMaterial;
                    //}

                }

            }
        }
        
        //リストの中身がなくなったら、2個目のライトを光らせる
        if (_buttons.Count == 0)
        {
            _buttons.Add("a");
            _light2.material = _lightEmission;
            _clearState |= Clear.SecondStageClear;
        }

    }

}
