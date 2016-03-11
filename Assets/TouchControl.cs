using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchControl : MonoBehaviour {

    public GameObject controlPoint;
    public GameObject controlBg;

    Image controlImg;
    RectTransform controlBgRect;

    // 鼠标状态
    bool isDown = false;

    // 遥控杆最初坐标
    Vector3 initPos;

    // 控制的对象
    public GameObject player;
    MuQiuBehaviour playerBehaviour;

	// Use this for initialization
	void Start () {
        controlImg = controlPoint.GetComponent<Image>();
        controlBgRect = controlBg.GetComponent<RectTransform>();

        initPos = controlPoint.transform.position;

        playerBehaviour = player.GetComponent<MuQiuBehaviour>();
    }
	
	// Update is called once per frame
	void Update () {

        if (Input.GetMouseButtonDown(0) && IsValidTouchArea(Input.mousePosition))
        {
            isDown = true;
        }

        if (Input.GetMouseButtonUp(0))
        {
            isDown = false;
        }

        transform.Rotate(Vector3.up * Time.deltaTime * 100, Space.World);

        // 鼠标按下记录位置
        if (isDown)
        {
            // 控制腰杆的移动

            if (IsValidTouchArea(Input.mousePosition))
            {
                Debug.Log(IsValidTouchArea(Input.mousePosition));
                controlPoint.transform.position = Input.mousePosition;
            }
            else
            {
                // 设置成最边缘
                //float angle = GetAngle(Input.mousePosition);
                float r = controlBgRect.rect.width / 2;
                //float x = controlBg.transform.position.x + r * Mathf.Cos(angle);
                //float y = controlBg.transform.position.y + r * Mathf.Sin(angle);

                float dis = Vector3.Distance(Input.mousePosition, controlBg.transform.position);
                controlPoint.transform.position = controlBg.transform.position + (Input.mousePosition - controlBg.transform.position) / dis * r;
            }

            playerDo(Input.mousePosition);
        }
        else
        {
            controlPoint.transform.position = initPos;
        }
	}        

    // 满足点击区域
    bool IsValidTouchArea(Vector3 touch_pos)
    {
        float touch_x = touch_pos.x - controlBg.transform.position.x;
        float touch_y = touch_pos.y - controlBg.transform.position.y;
        float r = controlBgRect.rect.width / 2;

        if (Mathf.Pow(touch_x, 2) + Mathf.Pow(touch_y,2) < Mathf.Pow(r, 2))
        {
            return true;
        }

        return false;
    }

    // 计算夹角
    float GetAngle(Vector3 touch_pos)
    {
        float touch_x = touch_pos.x - controlBg.transform.position.x;
        float touch_y = touch_pos.y - controlBg.transform.position.y;

        return Mathf.Atan(touch_y / touch_x);
    }

    // 执行对象行为
    void playerDo(Vector3 touch_pos) 
    {
        Vector3 move_norm = (touch_pos - controlBg.transform.position).normalized;
        move_norm = new Vector3(move_norm.x, 0, move_norm.y);

        playerBehaviour.AddForce(move_norm * Time.deltaTime);

        //playerBehaviour.SetPos(move_norm * Time.deltaTime);
    }
}
