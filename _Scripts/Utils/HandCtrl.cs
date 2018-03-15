using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class HandCtrl : MonoBehaviour
{
    /// <summary>
    /// 手柄控制器
    /// </summary>
    public GameObject controller;
    /// <summary>
    /// 动画控制器
    /// </summary>
    public Animator ani;

    // Use this for initialization
    void Start()
    {
        //controller.GetComponent<VRTK_ControllerEvents>().TriggerPressed += Hand_UseButtonPressed;
        //controller.GetComponent<VRTK_ControllerEvents>().TriggerReleased += Hand_UseButtonReleased;
        controller.GetComponent<VRTK_ControllerEvents>().TriggerAxisChanged += Hand_TriggerAxisChanged;
    }

    void Hand_TriggerAxisChanged(object sender, ControllerInteractionEventArgs e)
    {
        ani.Play("Grab", 0, e.buttonPressure);
        ani.speed = 0;
    }

    /// <summary>
    /// trigger键松开处理函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Hand_UseButtonPressed(object sender, ControllerInteractionEventArgs e)
    {
        ani.SetTrigger("Release");
    }


    /// <summary>
    /// trigger键按下处理函数
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    void Hand_UseButtonReleased(object sender, ControllerInteractionEventArgs e)
    {
        ani.SetTrigger("Grab");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
