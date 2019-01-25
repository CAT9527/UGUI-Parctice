using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Console2048;
public class GameController : MonoBehaviour {

    /// <summary>
    /// 2048游戏控制器
    /// </summary>

    private GameCore core;
    private NumberSprite[,] spriteActionArray;  //精灵行为的二维数组
    private void Start()
    {
        core = new GameCore();
        spriteActionArray = new NumberSprite[4,4];

        Init();

        GenerateNewNumber();
        GenerateNewNumber();
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
    private void CreateSprite(int r,int c)
    {
        //Instantiate();
        GameObject go = new GameObject(r.ToString()+c.ToString());
        //设置图片
        go.AddComponent<Image>();
        NumberSprite action = go.AddComponent<NumberSprite>();
        //将引用存储到二维数组里spriteActionArray
        spriteActionArray[r, c] = action;
        action.SetImage(0);
        //创建游戏对象，Scale默认为1，设置为false表示相对父物体的坐标
        go.transform.SetParent(this.transform,false);  

    }

    //生成新数字
    private void GenerateNewNumber()
    {
        Location loc;
        int number;
        core.GenerateNumber(out loc, out number);

        //根据位置，获取精灵行为脚本对象引用
        spriteActionArray[loc.RIndex, loc.CIndex].SetImage(number);
    }
}
