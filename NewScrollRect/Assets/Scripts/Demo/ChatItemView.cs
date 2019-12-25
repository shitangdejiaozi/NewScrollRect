using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SDGame.UITools;

public class ChatItemView : MonoBehaviour,IBindableUI{

    #region 控件绑定变量声明，自动生成请勿手改
    [ControlBinding]
    private RectTransform m_ChatContent;
    [ControlBinding]
    private Image m_ChatBg;
    [ControlBinding]
    private Text m_MsgText;
    [ControlBinding]
    private Image m_RoleIcon;
    [ControlBinding]
    private Text m_RoleName;

    #endregion


    private List<string> m_msgLists;
    private float m_totalHight = 0;
    public void InitChildNodes()
    {
        UIControlData controlData = gameObject.GetComponent<UIControlData>();
        controlData.BindDataTo(this);
    }

    public void UpdateItemView(int index)
    {
        m_msgLists = ChatTest.GetMsgList();
        string msg = m_msgLists[index];
        m_MsgText.text = msg;
        RefreshSizeByText();
    }

    public void RefreshSizeByText()
    {
        m_ChatBg.rectTransform.sizeDelta = new Vector2(m_ChatBg.rectTransform.sizeDelta.x, m_MsgText.preferredHeight + 20);

        float hight = 0f;
        for (int i = 0; i < m_ChatContent.childCount; i++) //在排列上有将就，头像的父节点和高度+ 聊天的父节点的高度= 总高度
        {
            Transform child = m_ChatContent.GetChild(i);
            if (child.gameObject.activeSelf)
            {
                hight += (child as RectTransform).sizeDelta.y;
            }
        }
        m_totalHight = hight;
    }

    public float GetItemHight()
    {
        return m_totalHight;
    }
}
