using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SDGame.UITools;
using System;

public class ChatItem : LoopItem {

    #region 控件绑定变量声明，自动生成请勿手改
    [ControlBinding]
    private GameObject m_SelfChatContent;
    [ControlBinding]
    private GameObject m_otherChatContent;
    [ControlBinding]
    private LayoutElement m_element;

    #endregion



    private ChatItemView m_selfChatView;
    private ChatItemView m_otherChatView;
    private ChatItemView m_curChatView;
    public override void InitChildNodes()
    {
        base.InitChildNodes();
        UIControlData controlData = gameObject.GetComponent<UIControlData>();
        controlData.BindDataTo(this);


        m_selfChatView = TryAddOrGetComponnet<ChatItemView>(m_SelfChatContent);
        m_otherChatView = TryAddOrGetComponnet<ChatItemView>(m_otherChatContent);

        m_selfChatView.InitChildNodes();
        m_otherChatView.InitChildNodes();
    }

    public override void UpdateItem(int index)
    {
        base.UpdateItem(index);

        
        m_otherChatContent.SetActive(index % 2 == 0);
        m_SelfChatContent.SetActive(index % 2 == 1);
        if(index % 2 == 0)
        {

            m_curChatView = m_otherChatView;
            m_otherChatView.UpdateItemView(index);
        }
        else
        {
            m_curChatView = m_selfChatView;
            m_selfChatView.UpdateItemView(index);
        }

        m_element.preferredHeight = m_curChatView.GetItemHight();
    }

    public T TryAddOrGetComponnet<T>(GameObject go) where T : MonoBehaviour
    {
        Type type = typeof(T);
        if(go.GetComponent(type) == null)
        {
            return go.AddComponent(type) as T;
        }
        return go.GetComponent(type) as T;
    }
   
    

    
}
