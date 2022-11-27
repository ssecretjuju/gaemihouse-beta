using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.Linq;
using System.Reflection;
using System;


/* Created by PEROT Nicolas: https://nicolas-perot.go.yj.fr/ the 14/10/2022 with Unity 2020.3.17f1
 * 
 * Help with this forum for search the field of Playmode Tint in the Assembly: https://answers.unity.com/questions/759634/unity-editor-playmode-tint-change-by-script.html
 * 
 */

#if UNITY_EDITOR
public class RainbowPlaymodeTint : MonoBehaviour
{
    public static RainbowPlaymodeTint instance { get; private set; }

    public Color startColor = new Color(1f, 0.5f, 0.5f, 1f);
    public float speedColor = 0.05f;
    public Color actualColorDebug;

    private float H, S, V;
    private static FieldInfo m_PrefsField = null;
    private static FieldInfo m_PrefColorField = null;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    void Start()
    {
        //Setup first color RGB to HSV
        Color.RGBToHSV(startColor, out H, out S, out V);

        Type settingsType = GetEditorType("PrefSettings");
        Type prefColorType = GetEditorType("PrefColor");
        if (settingsType == null || prefColorType == null)
            Debug.Log("settingsType or prefColorType have changed types cause to different Unity version");
        m_PrefsField = settingsType.GetField("m_Prefs", BindingFlags.Static | BindingFlags.NonPublic);
        m_PrefColorField = prefColorType.GetField("m_Color", BindingFlags.Instance | BindingFlags.NonPublic);
    }

    // Update is called once per frame
    void Update()
    { 
        //Rainbow fade
        H += Time.deltaTime * speedColor;
        H = Mathf.Min(1f, H);
        if (H >= 1) H = 0; //Loop Rainbow

        //Convert HSV to RGB
        Color rgb = Color.HSVToRGB(H, S, V);
        actualColorDebug = rgb;

        object p = GetPref("Playmode tint");

        //Change the field Playmode Tint in "Edit/Preferences/Colors/Playmode tint"
        m_PrefColorField.SetValue(p, rgb);

        //Change the regedix line (Synchronisation between windows. Tool bars only on highlight)
        EditorPrefs.SetString("Playmode tint", "Playmode tint;" + rgb.r.ToString()+ ";" + rgb.g.ToString() + ";" + rgb.b.ToString() + ";" + rgb.a.ToString());
    }

    static object GetPref(string aName)
    {
        return ((SortedList<string, object>)m_PrefsField.GetValue(null))[aName];
    }

    static System.Type GetEditorType(string aName)
    {
        return typeof(Editor).Assembly.GetTypes().Where((a) => a.Name == aName).FirstOrDefault();
    }
}

public class PlaymodeTintWindow : EditorWindow
{
    private float speedColor = 0.05f;
    private Color startColor = new Color(1f, 0.5f, 0.5f, 1f);

    private bool scriptCreated = false;

    // Add menu named "My Window" to the Window menu
    [MenuItem("Window/==== Rainbow Playmode Tint Window ====")]
    static void Init()
    {
        // Get existing open window or if none, make a new one:
        PlaymodeTintWindow window = (PlaymodeTintWindow)EditorWindow.GetWindow(typeof(PlaymodeTintWindow));
        window.Show();
    }

    void Awake()
    {
        RainbowPlaymodeTint script = FindObjectOfType<RainbowPlaymodeTint>();
        if (script != null) scriptCreated = true;
        else scriptCreated = false;
    }

    void OnGUI()
    {
        GUILayout.Label("Rainbow Settings", EditorStyles.boldLabel);
        GUILayout.Space(10);
        speedColor = EditorGUILayout.FloatField("Speed Color", speedColor);
        startColor = EditorGUILayout.ColorField("Start Color", startColor);
        GUILayout.Space(20);
        if (!scriptCreated)
        {
            if (GUILayout.Button("Create the Rainbow Component"))
            {
                if (FindObjectOfType<RainbowPlaymodeTint>() == null)
                {
                    GameObject go = new GameObject();
                    go.name = "Rainbow Playmode Tint";
                    go.AddComponent<RainbowPlaymodeTint>().speedColor = speedColor;
                    go.GetComponent<RainbowPlaymodeTint>().startColor = startColor;
                    scriptCreated = true;
                }
            }
        }
        else
        {
            if (GUILayout.Button("Delete the Rainbow Component"))
            {
                RainbowPlaymodeTint script = FindObjectOfType<RainbowPlaymodeTint>();
                if (script != null)
                {
                    DestroyImmediate(script.gameObject);
                }
                scriptCreated = false;
            }
        }
    }
}
#endif