using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;
using HighlightingSystem;
using UnityStandardAssets.ImageEffects;
using System.IO;

public class Handler : MonoBehaviour
{

    public static Handler Instance;

    private GameObject RightController, LeftController;
    private VRTK_StraightPointerRenderer Right_StraightPointerRenderer;
    private VRTK_BezierPointerRenderer Right_BeizierPointerRender;
    private VRTK_BezierPointerRenderer Left_BeizierPointerRender;
    private VRTK_ControllerEvents Right_ControllerEvents;

    string path;


    // Use this for initialization
    void Start()
    {
        Instance = this;
        ExcelMakerManager.CreateExcelMakerManager();
        RightController = GameObject.Find("RightController");
        LeftController = GameObject.Find("LeftController");
        Right_StraightPointerRenderer = RightController.GetComponent<VRTK_StraightPointerRenderer>();
        Right_BeizierPointerRender = RightController.GetComponent<VRTK_BezierPointerRenderer>();
        Left_BeizierPointerRender = LeftController.GetComponent<VRTK_BezierPointerRenderer>();
        BezierOrStraight(true);
    }

    public void AddCell(string m, string ron)
    {
        TestInfo testinfo = new TestInfo();
        testinfo.Module = m;
        testinfo.RightOrNot = ron;
        testinfo.Time = System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        CommonVariables.ListInfos.Add(testinfo);
    }

    public void PrintExcel()
    {
        if (!Directory.Exists(Directory.GetParent(Application.dataPath) + "/考核记录"))
        {
            Directory.CreateDirectory(Directory.GetParent(Application.dataPath) + "/考核记录");
        }
        path = Directory.GetParent(Application.dataPath) + "/考核记录/安全培训" + System.DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss") + ".xls";
        ExcelMakerManager.eInstance.ExcelMaker(path, CommonVariables.ListInfos);
    }

    public void BezierOrStraight(bool awake)
    {
        Right_StraightPointerRenderer.enabled = awake;
        Right_BeizierPointerRender.enabled = !awake;
        Left_BeizierPointerRender.enabled = !awake;
    }

    //高亮颜色
    public static Color highLightColor = new Color(0, 0.7f, 1.0f);
    public static Color highLightColorRed = Color.red;

    /// <summary>
    /// 给物体添加Collider
    /// </summary>
    /// <param name="t"></param>
    /// <param name="path"></param>
    /// <param name="layerName"></param>
    public static void AddColliderToObj(Transform t, string path, string layerName)
    {
        GameObject Obj = t.FindChild(path).gameObject;
        Obj.SetActive(true);
        Obj.GetComponent<MeshRenderer>().enabled = false;
        Obj.AddComponent<MeshCollider>();
        Obj.layer = LayerMask.NameToLayer(layerName);
    }
    public static void AddColliderToObj(GameObject go, string layerName)
    {
        if (go == null) return;
        go.SetActive(true);
        go.GetComponent<MeshRenderer>().enabled = false;
        go.AddComponent<MeshCollider>();
        go.layer = LayerMask.NameToLayer(layerName);
    }

    /// <summary>
    /// 添加模糊
    /// </summary>
    /// <param name="c"></param>
    /// <param name="isAdd"></param>
    public static void AddCameraBlur(GameObject obj, bool isAdd)
    {
        if (obj == null) return;
        obj.GetComponentInChildren<BlurOptimized>().enabled = isAdd;
    }

    /// <summary>
    /// 开始震动
    /// </summary>
    /// <param name="obj"></param>
    /// <param name="duration">持续时间 单位- 秒</param>
    /// <param name="strenth">振幅 2000</param>
    public static void StartHapticRumb(GameObject obj)
    {
        if (obj == null) return;
        VRTK_ControllerActions controllerActions = obj.GetComponent<VRTK_ControllerActions>();
        if (controllerActions == null)
        {
            Debug.Log(obj.name + "上未找到 SteamVR_ControllerActions 脚本");
            return;
        }
        controllerActions.TriggerHapticPulse(CommonVariables.rumbStrenth, CommonVariables.rumbDuration, 0.01f);
    }

    /// <summary>
    /// 添加物体高亮
    /// </summary>
    /// <param name="go">高亮的物体</param>
    /// <param name="isAdd">是否高亮</param>
    public static void AddGameObjectHighLight(GameObject go, bool isAdd, Color color)
    {
        if (go == null)
        {
            //Debug.Log("物体为空！");
            return;
        }
        if (isAdd)
        {
            Highlighter hl = go.AddComponent<Highlighter>();
            hl.ConstantOn(color);
        }
        else
        {
            Highlighter hl = go.GetComponent<Highlighter>();
            if (hl != null) Object.Destroy(hl);
        }
    }
}
