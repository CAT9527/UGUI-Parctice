using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class EventDemo : MonoBehaviour,IPointerClickHandler,IDragHandler {

	public void Fun1()
    {
        print("Click");
    }

    public void Fun2(string str)
    {
        print("Click:" + str);
    }

    //当光标拖拽时执行
    public void OnDrag(PointerEventData eventData)
    {
        //eventData.Position:光标位置（屏幕坐标）
        //就仅仅适用于overlay模式
        //this.transform.position = eventData.position;

        //通用的拖拽overlay ,camera
        //将屏幕坐标转换成物体的世界坐标
        RectTransform parentRTF = this.transform.parent as RectTransform;
        Vector3 worldPos;
        //(父物体的变换组件，屏幕坐标，摄像机，out 世界坐标)
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF,eventData.position,eventData.pressEventCamera,out worldPos);
        this.transform.position = worldPos;

    }

    //当光标单击时执行，点击次数clickCount
    public void OnPointerClick(PointerEventData eventData)
    {
        //eventData时间参数类：提供了引发时间时的一些信息
        if (eventData.clickCount == 2)
            print("OnPointClick(双击)" + eventData.clickCount);
    }

    private void Start()
    {
        //Button btn = this.transform.Find("Button").GetComponent<Button>();
        //btn.onClick.AddListener(Fun1);
       
        //InputField input = this.transform.Find("InputField").GetComponent<InputField>();
        //public delegate void UnityAction<T0>(T0 arg0);
        //input.onEndEdit.AddListener(Fun2);

        
    }
}
