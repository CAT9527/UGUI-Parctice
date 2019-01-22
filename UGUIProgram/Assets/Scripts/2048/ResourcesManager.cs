using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 资源管理类，负责管理加载资源
/// </summary>
public class ResourcesManager : MonoBehaviour {

    //1. private static Sprite[] spriteDic;       //数组类似于一个一个找
    private static Dictionary<int,Sprite> spriteDic;  //创建字典集合 ,字典集合则是类似于用偏旁部首找资源，效率更高

    //类被加载时调用和
    static ResourcesManager()
    {
        //1. spriteArray = Resources.LoadAll<Sprite>("2048Atlas");
        spriteDic = new Dictionary<int, Sprite>();                   //初始化
        var spriteArray = Resources.LoadAll<Sprite>("2048Atlas");    //匿名使用Resources.LoadAll查找图集
        foreach (var item in spriteArray)                            //遍历spriteArray,然后加在字典上
        {
            int intSpriteName = int.Parse(item.name);
            spriteDic.Add(intSpriteName, item);
        }
    }

    /// <summary>
    /// 读取数字精灵
    /// </summary>
    /// <param name="number">精灵表示的数字</param>
    /// <returns>精灵</returns>
	public static Sprite LoadSprite(int number)
    {
        //1.
        //foreach (var item in spriteArray)
        //{
        //    if (item.name == number.ToString())
        //        return item;
        //}
        //return null;
        return spriteDic[number];      //读取精灵
    }
}
