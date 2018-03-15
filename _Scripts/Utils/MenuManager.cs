using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuManager : MonoBehaviour
{
    public static MenuManager Instance;
    public bool DontCallInterface;
    private InterfaceAnimManager current;
    private int indexInterface = 0;
    public InterfaceAnimManager[] holoInterfaceList;
    public string searchTarget = "HoloInterfaces";
    public AudioSource audioSource;

    void Start()
    {
        Instance = this;
        if (holoInterfaceList[indexInterface] != null)
        {
            if (DontCallInterface)
                return;
            CallInterface(holoInterfaceList[indexInterface]);
        }
    }
    private void playSound()
    {
        if (audioSource && audioSource.enabled)
            audioSource.Play();
    }

    public void DoAppear()
    {
        Handler.Instance.BezierOrStraight(true);
        if (current)
        {
            current.startAppear();
            current.gameObject.SetActive(true);
        }
        playSound();
    }
    public void DoDisappear()
    {
        Handler.Instance.BezierOrStraight(false);
        if (current)
        {
            current.startDisappear();
        }
        playSound();
    }
    public void DoNext()
    {
        Handler.Instance.BezierOrStraight(true);
        indexInterface++;
        if (indexInterface >= holoInterfaceList.Length)
        {
            indexInterface = 0;
        }
        playSound();
        CallInterface(holoInterfaceList[indexInterface]);
    }
    public void DoPrevious()
    {
        indexInterface--;
        if (indexInterface < 0)
        {
            indexInterface = holoInterfaceList.Length - 1;
        }
        playSound();
        CallInterface(holoInterfaceList[indexInterface]);
    }
    public void CallInterface(InterfaceAnimManager _interface)
    {
        if (current)
        {
            current.startDisappear(true);
        }
        current = _interface;
        if (_interface)
        {
            current.gameObject.SetActive(true);
            current.startAppear();
        }
    }
}