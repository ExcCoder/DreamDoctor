using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 存储单个UI的信息
/// </summary>
public class UIType
{
    /// <summary>
    ///  存储单个UI的名字
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// 存储单个UI路径
    /// </summary>
    public string Path { get; private set; }
        /// <summary>
        /// 初始化UIType
        /// </summary>
        /// <param name="path">UI的路径</param>
    public UIType(string path)
    {
        Path = path;
        Name = Path.Substring(path.LastIndexOf('/') + 1);
    }
}
