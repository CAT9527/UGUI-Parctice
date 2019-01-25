using UnityEngine;
using UnityEngine.EventSystems;
public class DialogDrag : MonoBehaviour,IPointerDownHandler,IDragHandler {

    private RectTransform parentRTF;

    private void Start()
    {
        parentRTF = this.transform.parent as RectTransform;
    }

    private Vector3 offest;  //光标偏移量

    //当按下当前物体时执行
    public void OnPointerDown(PointerEventData eventData)
    {
        //记录从按下点到中心点偏移量（坐标）

        Vector3 worldPos;
        //屏幕坐标  -->世界坐标
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF, eventData.position, eventData.pressEventCamera, out worldPos);
        offest = this.transform.position - worldPos;
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector3 worldPos;
        //屏幕坐标  -->世界坐标
        RectTransformUtility.ScreenPointToWorldPointInRectangle(parentRTF, eventData.position, eventData.pressEventCamera, out worldPos);
        //根据偏移量移动当前UI
        this.transform.position = worldPos + offest;
    }
}
