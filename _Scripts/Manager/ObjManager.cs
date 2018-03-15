using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class ObjManager : MonoBehaviour
{
    public static ObjManager Instance;
    /// <summary>
    /// 主角
    /// </summary>
    public GameObject Camerarig;
    /// <summary>
    /// 眼睛
    /// </summary>
    public GameObject CameraEye;
    /// <summary>
    /// 左右手模型
    /// </summary>
    public GameObject HandModelLeft, HandModelRight;
    /// <summary>
    /// 左右手柄模型
    /// </summary>
    public GameObject ModelLeft, ModelRight;
    /// <summary>
    /// UI交互界面
    /// </summary>
    public GameObject HoloInterfaces;

    public VRTK_BodyPhysics bodyphysics;

    // Use this for initialization
    void Start()
    {
        Instance = this;
    }

    public void SwitchHandModel(bool isHand)
    {
        if (isHand)
        {
            HandModelLeft.SetActive(true);
            HandModelRight.SetActive(true);
            ModelLeft.SetActive(false);
            ModelRight.SetActive(false);
        }
        else
        {
            HandModelLeft.SetActive(false);
            HandModelRight.SetActive(false);
            ModelLeft.SetActive(true);
            ModelRight.SetActive(true);
        }
    }

    /// <summary>
    /// 设置面板位置
    /// </summary>
    public void SetPanelPosition()
    {
        Vector3 targetv3 = CameraEye.transform.forward;
        Vector3 newposition = new Vector3(targetv3.x, 0f, targetv3.z);
        HoloInterfaces.transform.position = CameraEye.transform.position + newposition.normalized * 2f;
        HoloInterfaces.transform.eulerAngles = new Vector3(0, CameraEye.transform.eulerAngles.y, 0);
    }
}
