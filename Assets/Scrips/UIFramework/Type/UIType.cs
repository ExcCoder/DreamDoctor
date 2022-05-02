using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// �洢����UI����Ϣ
/// </summary>
public class UIType
{
    /// <summary>
    ///  �洢����UI������
    /// </summary>
    public string Name { get; private set; }
    /// <summary>
    /// �洢����UI·��
    /// </summary>
    public string Path { get; private set; }
        /// <summary>
        /// ��ʼ��UIType
        /// </summary>
        /// <param name="path">UI��·��</param>
    public UIType(string path)
    {
        Path = path;
        Name = Path.Substring(path.LastIndexOf('/') + 1);
    }
}
