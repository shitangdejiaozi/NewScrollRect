using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollIndexCallBack : MonoBehaviour {

    public Image image;
    public Text text;

    void ScrollCellIndex(int idx)
    {
        string name = "Cell " + idx.ToString();
        if (text != null)
        {
            text.text = name;
        }
        
        gameObject.name = name;
    }
   
}
