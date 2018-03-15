using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public sealed class BindObjEvent
{
    /// <summary>
    /// onPointerEnter
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onPointerEnter">指针进入</param>
    public static void BindObjPointerEnterEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.PointerEventDelegate _onPointerEnter)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onPointerEnter += _onPointerEnter;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onPointerExit
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onPointerExit">指针退出</param>
    public static void BindObjPointerExitEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.PointerEventDelegate _onPointerExit)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onPointerExit += _onPointerExit;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onPointerDown
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onPointerDown">指针按下</param>
    public static void BindObjPointerDownEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.PointerEventDelegate _onPointerDown)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onPointerDown += _onPointerDown;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onPointerUp
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onPointerUp">指针释放(可能按下时的指针位置跟释放时的指针位置不同，这里指的是按下时指针指着的物体)</param>
    public static void BindObjPointerUpEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.PointerEventDelegate _onPointerUp)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onPointerUp += _onPointerUp;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onPointerUp
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onPointerClick">在同一物体上按下并释放</param>
    public static void BindObjPointerClickEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.PointerEventDelegate _onPointerClick)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onPointerClick += _onPointerClick;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onInitializePotentialDrag
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onInitializePotentialDrag">拖拽时的初始化，跟IPointerDownHandler差不多，在按下时调用 </param>
    public static void BindObjInitializePotentialDragEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.PointerEventDelegate _onInitializePotentialDrag)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onInitializePotentialDrag += _onInitializePotentialDrag;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onBeginDrag
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onBeginDrag">开始拖拽</param>
    public static void BindObjBeginDragEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.PointerEventDelegate _onBeginDrag)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onBeginDrag += _onBeginDrag;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onDrag
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onDrag">拖拽中</param>
    public static void BindObjDragEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.PointerEventDelegate _onDrag)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onDrag += _onDrag;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onEndDrag
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onEndDrag">拖拽结束(被拖拽的物体调用)</param>
    public static void BindObjEndDragEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.PointerEventDelegate _onEndDrag)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onEndDrag += _onEndDrag;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onDrop
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onDrop">拖拽结束(拖拽结束后的位置(即鼠标位置)如果有物体，则那个物体调用)</param>
    public static void BindObjDropEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.PointerEventDelegate _onDrop)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onDrop += _onDrop;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onScroll
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onScroll">滚轮滚动</param>
    public static void BindObjScrollEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.PointerEventDelegate _onScroll)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onScroll += _onScroll;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onUpdateSelected
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onUpdateSelected">被选中的物体每帧调用</param>
    public static void BindObjUpdateSelectedEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.BaseEventDelegate _onUpdateSelected)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onUpdateSelected += _onUpdateSelected;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onSelect
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onSelect">物体被选中时(EventSystem.current.SetSelectedGameObject(gameObject))</param>
    public static void BindObjSelectEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.BaseEventDelegate _onSelect)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onSelect += _onSelect;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onDeselect
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onDeselect">物体从选中到取消选中时</param>
    public static void BindObjDeselectEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.BaseEventDelegate _onDeselect)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onDeselect += _onDeselect;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onSubmit
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onSubmit">提交按钮被按下时(与InputManager里的Submit按键相对应，PC上默认的是Enter键)，前提条件是物体被选中</param>
    public static void BindObjSubmitEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.BaseEventDelegate _onSubmit)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onSubmit += _onSubmit;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onCancel
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onCancel">取消按钮被按下时(与InputManager里的Cancel按键相对应，PC上默认的是Esc键)，前提条件是物体被选中</param>
    public static void BindObjCancelEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.BaseEventDelegate _onCancel)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onCancel += _onCancel;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }

    /// <summary>
    /// onMove
    /// </summary>
    /// <param name="_btnName">按钮名称</param>
    /// <param name="_onMove">物体移动时(与InputManager里的Horizontal和Vertica按键相对应)，前提条件是物体被选中</param>
    public static void BindObjMoveEvent(Transform _objParentTransform, string _btnName, EventTriggerListener.AxisEventDelegate _onMove)
    {
        GameObject objFind = _objParentTransform.Find(_btnName).gameObject;
        if (objFind != null)
            EventTriggerListener.GetListener(objFind).onMove += _onMove;
        else
            Debug.Log("【绑定UGUI事件】没有查找到按钮对象，按钮名称：" + _btnName);
    }
}
