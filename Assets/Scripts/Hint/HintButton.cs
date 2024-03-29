using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class HintButton : HintButtonBase
{
    public override void Click()
    {
        StartCoroutine(ShowHint());
    }

    public override IEnumerator ShowHint()
    {
        //ヒントを1文字0.1秒かけて表示させる
        yield return HintText.DOText(Hint.text, 0.1f * Hint.text.Length).SetEase(Ease.Linear).SetAutoKill().WaitForCompletion();
        yield return new WaitForSeconds(0.1f);
        _endReadHint = true;
    }

}
