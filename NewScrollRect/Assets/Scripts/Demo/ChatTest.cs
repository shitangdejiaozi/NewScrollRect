using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatTest : MonoBehaviour {

    public InputField m_inputfiled;
    public Button m_button;
    public UIScrollView ScrollView;
    private static List<string> m_msgLists = new List<string>();
    public string ItemName;
	// Use this for initialization
	void Start () {
        m_button.onClick.AddListener(SendMessage);
	}
	
	private void SendMessage()
    {
        string msg = m_inputfiled.text;
        m_msgLists.Add(msg);
        ScrollView.UpdateScrollView<ChatItem>(m_msgLists.Count, ItemName);
    }


    public static List<string> GetMsgList()
    {
        return m_msgLists;
    }
}
