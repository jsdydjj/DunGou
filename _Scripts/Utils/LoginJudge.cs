using UnityEngine;
using System.Collections;

public class LoginJudge : MonoBehaviour
{
    void Awake()
    {
        if (CommonVariables.isBegin)
        {
            //GetData();
            GetDog();
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    void GetDog()
    {
        int result = 0;
        UserDLL.UserOperationDLL UserOperation = new UserDLL.UserOperationDLL();
        result = UserOperation.GetSoftDog(5); //演示5，正式6
        if (result != 1)
        {
            Debug.Log("【加密锁错误！】" + "   " + result);
            Application.Quit();
        }
        else
        {
            Debug.Log("【登陆成功！】");
        }
        CommonVariables.isBegin = false;
    }

    //void GetData()
    //{
    //    UserDLL.Tools.FileHelper fh = new UserDLL.Tools.FileHelper();
    //    if (fh.isHasTempFile())
    //    {
    //        UserDLL.Models.UserInfo user = fh.getTempFileInfos();
    //        Debug.Log("user.ModuleId" + user.ModuleId);
    //        if (int.Parse(user.ModuleId) != -1)
    //        {
    //            Application.Quit();
    //        }
    //    }
    //    else
    //    {
    //        Application.Quit();
    //    }
    //    fh.deleteTempFile();
    //    CommonVariables.isBegin = false;
    //}
}
