using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    /// <summary>
    /// 2048游戏控制器
    /// </summary>

    private void Start()
    {
        Init();
    }

    private void Init()
    {
        //游戏初始化，创建16个方格Sprite
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                CreateSprite(i,j);
            }
        }
    }

    //创建一个方格Sprite
    private void CreateSprite(int i,int j)
    {
        //Instantiate();
        GameObject go = new GameObject(i.ToString()+j.ToString());
        //设置图片
        go.AddComponent<Image>();
        NumberSprite action = go.AddComponent<NumberSprite>();
        action.SetImage(0);
        //创建游戏对象，Scale默认为1，设置为false表示相对父物体的坐标
        go.transform.SetParent(this.transform,false);  

    }
}
