using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using System.Text;


public class ListAssets : EditorWindow
{
        
    public static void ShowExample()
    {
        ListAssets wnd = GetWindow<ListAssets>();
        wnd.titleContent = new GUIContent("ListAssets");
        wnd.minSize = new Vector2(800, 600);
    }

    public void OnEnable()
    {
        VisualTreeAsset original = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Editor/ListAssets.uxml");
        TemplateContainer treeAsset = original.CloneTree();
        rootVisualElement.Add(treeAsset);

        StyleSheet styleSheet = AssetDatabase.LoadAssetAtPath<StyleSheet>("Assets/Editor/ListAssets.uss");
        rootVisualElement.styleSheets.Add(styleSheet);
    }

    public void FindAssets()
    {
    }
}
