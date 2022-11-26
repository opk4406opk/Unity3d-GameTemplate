using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ���� Scene ���� ���۵Ǵ� ���� ����. ( Entry ) // main() �Լ��� ���� ����.
/// </summary>
public class SceneEntryBase : MonoBehaviour
{
#if UNITY_EDITOR || DEVELOPMENT_BUILD
    #region DEBUG
    [Range(1, 100)]
    public int DebugFontSize = 80;
    [Range(1, 100)]
    public float DebugPositionY = 100;
    private float DebugDeltaTime = 0.0f;

    protected int DebugScreenWidth = Screen.width;
    protected int DebugScreenHeight = Screen.height;
    protected GUIStyle DebugGuiStyle = new GUIStyle();

    #endregion
#endif

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR || DEVELOPMENT_BUILD
        DebugDeltaTime += (Time.unscaledDeltaTime - DebugDeltaTime) * 0.1f;
#endif
    }

#if UNITY_EDITOR || DEVELOPMENT_BUILD
    /// <summary>
    /// ���� ����׿�.
    /// </summary>
    protected virtual void OnGUI()
    {
        Rect rect = new Rect(0, 0, DebugScreenWidth, DebugScreenHeight * 2 / DebugPositionY);
        DebugGuiStyle.alignment = TextAnchor.UpperLeft;
        DebugGuiStyle.fontSize = DebugScreenHeight * 2 / DebugFontSize;
        DebugGuiStyle.normal.textColor = Color.green;
        float msec = DebugDeltaTime * 1000.0f;
        float fps = 1.0f / DebugDeltaTime;
        string text = string.Format("{0:0.0} ms ({1:0.} fps)", msec, fps);
        GUI.Label(rect, text, DebugGuiStyle);

        Rect textRect = new Rect(0, 30, DebugScreenWidth, DebugScreenHeight * 2 / DebugPositionY);
        GUI.Label(textRect, "DEV Build", DebugGuiStyle);
    }
#endif
}
