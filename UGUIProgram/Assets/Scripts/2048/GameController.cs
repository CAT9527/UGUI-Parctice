using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Console2048;
using MoveDirection = Console2048.MoveDirection;  //表示这个文件MoveDirection是Console2048的
public class GameController : MonoBehaviour,IPointerDownHandler,IDragHandler {

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

    private void Update()
    {
        UpdateMap();
        //如果地图有更新
        if (core.IsChange)
        {
            //更新界面
            //产生新数字
            GenerateNewNumber();

            //移动效果
            //合并效果

            //判断游戏是否结束
            core.IsChange = false;
        }
    }
    private void Init()
    {
        //游戏初始化，创建16个方格Sprite
        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 4; j++)
            {
                CreateSprite(i, j);
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
        spriteActionArray[loc.RIndex, loc.CIndex].CreateEffect();
    }

    public void UpdateMap()
    {
        for (int r = 0; r < 4; r++)
        {
            for (int c = 0; c < 4; c++)
            {
                spriteActionArray[r, c].SetImage(core.Map[r, c]);
            }
        }
    }

    private Vector2 startPoint;
    private bool isDown = false;
    public void OnDrag(PointerEventData eventData)
    {
        if (!isDown) return;
        Vector3 offest = eventData.position - startPoint;
        float x = Mathf.Abs(offest.x);
        float y = Mathf.Abs(offest.y);

        MoveDirection? dir = null;
        if (x > y && x >= 50)
        {
            dir = offest.x > 0 ? MoveDirection.Right : MoveDirection.Left;
        }
        if (x < y && y >= 50)
        {
            dir = offest.y > 0 ? MoveDirection.Up : MoveDirection.Down;
        }
        if (dir != null)
        {
            core.Move(dir.Value);
            isDown = false;
        }
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startPoint = eventData.position;
        isDown = true;
    }
}
