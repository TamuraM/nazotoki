using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorHint1Button : HintButtonBase
{

    public override void Click()
    {
        _hintText.DOText(_hint[6], 1.5f).SetEase(Ease.Linear).OnComplete(() => _endReadHint = true).SetAutoKill();
    }

}
