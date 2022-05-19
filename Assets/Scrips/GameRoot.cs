using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// ����ȫ�ֵ�һЩ����
/// </summary>
public class GameRoot : MonoBehaviour
{
    public static GameRoot Instance { get; private set; }
    /// <summary>
    /// ����������
    /// </summary>
    public SceneSystem SceneSystem { get; private set; }
    public StoryManager StoryManager { get; private set; }
    public PanelManager PanelManager { get; private set; }
    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
        
        
        SceneSystem = new SceneSystem();
        StoryManager = new StoryManager();
        DontDestroyOnLoad(gameObject);
    }
    private void Start()
    {
        Debug.Log("001");
        SceneSystem.SetScene(new StartScene());
    }
}
