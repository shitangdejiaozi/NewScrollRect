using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SDGame.UITools;

public class LoopItemTest : LoopItem {

    #region 控件绑定变量声明，自动生成请勿手改
    [ControlBinding]
    private Text m_text;

    #endregion

    public override void InitChildNodes()
    {
        base.InitChildNodes();
        UIControlData controlData = gameObject.GetComponent<UIControlData>();
        controlData.BindDataTo(this);
    }

    public override void UpdateItem(int index)
    {
        base.UpdateItem(index);
        Debug.LogError("index " + index);
        m_text.text = index.ToString();
    }
}
