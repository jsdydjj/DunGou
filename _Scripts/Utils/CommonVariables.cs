using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CommonVariables : MonoBehaviour
{


    //手柄震动幅度
    public static float rumbDuration = 1.5f;
    public static ushort rumbStrenth = 30000;


    //软件是否启动过一次
    public static bool isBegin = true;

    public static List<TestInfo> ListInfos = new List<TestInfo>();

}
