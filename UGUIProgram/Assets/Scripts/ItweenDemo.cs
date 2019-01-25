using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ItweenDemo : MonoBehaviour
{

    public Transform imgTF, btnTF;
    public float moveSpeed;
    public iTween.EaseType type;
    public void Movement()
    {
        //iTween.MoveTo(imgTF.gameObject, btnTF.position, 2.0f);
        //UI缓动 ITween  DoTween
        iTween.MoveTo(imgTF.gameObject, iTween.Hash(
         "position", btnTF.position,
        "speed", moveSpeed,
        "easetype", type
        ));
    }

    private void Start()
    {
        Button btn = this.transform.Find("Button").GetComponent<Button>();
        btn.onClick.AddListener(Movement);
    }
}
