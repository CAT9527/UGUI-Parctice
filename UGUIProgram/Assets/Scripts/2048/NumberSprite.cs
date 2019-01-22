using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
/// <summary>
/// 附加到每个方格中，用于定义方格行为
/// </summary>
public class NumberSprite : MonoBehaviour {

    private Image img;
    private void Awake()   //不应该使用start
    {
        img = GetComponent<Image>();
    }
    public void SetImage(int number)
    {
        //2 ==>精灵 ==>设置到image中
        //备注：读取单个精灵使用Load,读取图集使用LoadAll
        img.sprite = ResourcesManager.LoadSprite(number);
    }

    //移动 合并 生成效果
}
