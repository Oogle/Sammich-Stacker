using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToolTip : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textObj;
    [SerializeField] Image ToolTipObj;
    [SerializeField] HorizontalLayoutGroup BgLayout;
    RectTransform toolTipRectangle;

    //Don't worry the tooltip's horizontal scale component should auto-resize the background.
    private void setText(string r_text)
    {
        textObj.text = r_text;
        if (r_text == "")
        {

            ToolTipObj.enabled = false;
            return;
        }
        ToolTipObj.enabled = true;
        textObj.ForceMeshUpdate();

        //LMAO the horizontal scale component doesn't update except when it is disabled and enabled. I guess that forces an update
        Canvas.ForceUpdateCanvases();
        BgLayout.enabled = false;
        BgLayout.enabled = true;
    }

    private void OnEnable()
    {
        ToolTipupdater.updateToolTip += setText;
    }

    private void OnDisable()
    {
        ToolTipupdater.updateToolTip -= setText;
    }

    // Start is called before the first frame update
    void Start()
    {
        toolTipRectangle = this.GetComponent<RectTransform>();
        setText("");
    }

    // Update is called once per frame
    void Update()
    {
        toolTipRectangle.anchoredPosition = Input.mousePosition;
    }
}
