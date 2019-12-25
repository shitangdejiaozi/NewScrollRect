using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIScrollView : MonoBehaviour {

    public LoopScrollRect scrollRect;
    // Use this for initialization
    void Start () {
		
	}

    public void UpdateScrollView<T>(int totalCount, string itemPrefab) where T : LoopItem
    {
        scrollRect.SetScrollRect(totalCount, typeof(T), itemPrefab);
    }


}
