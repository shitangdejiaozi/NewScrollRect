using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class ScrollTest : MonoBehaviour
{
    public GameObject itemTemp;
    public int totalCount;
    public Button m_button;
    public InputField m_input;
    private LoopScrollRect m_scrollRect;

    // Use this for initialization
    void Start()
    {
        m_button.onClick.AddListener(ClickButton);
        m_scrollRect = GetComponent<LoopScrollRect>();
        SetScrollView(30);
    }


    private void SetScrollView(int totalCount)
    {
        UpdateScrollView<LoopItemTest>(20, itemTemp.name);
    }


    private void UpdateScrollView<T>(int totalCount, string itemPrefab) where T : LoopItem
    {
        m_scrollRect.SetScrollRect(totalCount, typeof(T), itemPrefab);
    }

    private void ClickButton()
    {
        ScrollToIndex(int.Parse(m_input.text), 1000);
    }

    public void ScrollToIndex(int index, float speed)
    {
        m_scrollRect.SrollToCell(index, speed);
    }
}


