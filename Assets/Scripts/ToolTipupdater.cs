using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class ToolTipupdater : MonoBehaviour
{

    [TextArea] [SerializeField] string newToolTiptext;
    public delegate void ToolTipUpdate(string text);
    public static event ToolTipUpdate updateToolTip;
    bool shouldDisplay = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseEnter()
    {
        if (shouldDisplay)
            updateToolTip?.Invoke(newToolTiptext);
    }

    private void OnMouseDown()
    {
        shouldDisplay = false;
    }

    private void OnMouseUp()
    {
        shouldDisplay = true;
    }

    void OnMouseExit()
    {
        updateToolTip?.Invoke("");
    }
}
