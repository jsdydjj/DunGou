using UnityEditor;
using UnityEngine;
using System.IO;
using Unity;
using System.Collections.Generic;
using UnityEditor.Animations;

public class BuildAnimation : EditorWindow
{
    private static string path_Models = Application.dataPath + "/_DongHuaModel/";
    //private static string path_ModelPrefabs = Application.dataPath + "/ModelPrefabs/";


    [MenuItem("MengYuan/动画-更新动画控制和预设")]
    public static void UpdateFbxAnimation()
    {
        DoUpdateFbxAnimation();
        AssetDatabase.Refresh();
        LogHelp.Write("End-更新动画控制和预设");
    }



    /// <summary>
    /// 判断文件夹是否存在，不存在创建
    /// </summary>
    /// <param name="_path"></param>
    private static void DirectoryExists(string _path)
    {
        if (Directory.Exists(_path) == false)
            Directory.CreateDirectory(_path);
    }
    /// <summary>
    /// 获取文件夹下的所有类型文件
    /// </summary>
    /// <param name="dirPath">文件夹路径</param>
    /// <param name="fileType">文件类型</param>
    /// <param name="dirs">返回文件路径集合</param>
    private static void GetFolderAllFile(string _dirPath, string _fileType, ref IList<string> _dirs)
    {
        foreach (string path in Directory.GetFiles(_dirPath))
        {
            if (System.IO.Path.GetExtension(path) == _fileType)
                _dirs.Add(path.Substring(path.IndexOf("Assets/")));
        }
        if (Directory.GetDirectories(_dirPath).Length > 0)
        {
            foreach (string path in Directory.GetDirectories(_dirPath))
                GetFolderAllFile(path, _fileType, ref _dirs);
        }
    }
    private static void DoUpdateFbxAnimation()
    {
        //获取工程下的所有预设模型
        IList<string> dirs = new List<string>();
        GetFolderAllFile(path_Models, ".FBX", ref dirs);
        foreach (string p in dirs)
        {
            LogHelp.Write("生成模型 " + p);//生成模型 Assets/Models/GongGuan\0\chengmo\tj-0-chengmo-ct4.FBX
            string temp = p.Replace("/_DongHuaModel/", "/_DongHuaModelPrefab/");
            Debug.Log(temp);
            string tempPath = Unity.ApplicationHelp.Instance.dataPath + "/" + temp.Substring(0, temp.LastIndexOf('/'));
            DirectoryExists(tempPath);//创建预设文件夹

            GameObject obj = (GameObject)AssetDatabase.LoadAssetAtPath(p, typeof(GameObject));
            Animator animator = obj.GetComponent<Animator>();
            if (animator != null)
            {
                //创建动画控制器
                AnimatorController controller = AnimatorController.CreateAnimatorControllerAtPath(string.Format("{0}/{1}.controller", p.Substring(0, p.LastIndexOf('/')), obj.name));
                //把动画文件保存在我们创建的AnimationController中
                AddStateTransition(p, obj.name, controller.layers[0]);
                animator.applyRootMotion = false;
                animator.runtimeAnimatorController = controller;
            }
            PrefabUtility.CreatePrefab(string.Format("{0}/{1}.prefab", temp.Substring(0, temp.LastIndexOf('/')), obj.name), obj);
            AssetDatabase.SaveAssets();
            System.Threading.Thread.Sleep(200);
        }
    }
    private static void AddStateTransition(string path, string modelName, AnimatorControllerLayer layer)
    {
        Object[] objects = AssetDatabase.LoadAllAssetsAtPath(path);
        AnimatorStateMachine sm = layer.stateMachine;
        AnimatorState state = sm.AddState(modelName, new Vector3(250, -50, 0));
        sm.AddAnyStateTransition(state);
        int count = 10;
        foreach (Object o in objects)
        {
            if (o.name.Contains(modelName + "-"))
            {
                int c = count % 10;
                state = sm.AddState(o.name, new Vector3(count / 10 * 250, c * 50, 0));
                state.mirrorParameter = o.name;
                state.motion = o as AnimationClip;
                AnimatorStateTransition tran = sm.AddAnyStateTransition(state);
                tran.duration = 0;
                tran.hasExitTime = false;

                count += 1;
            }
        }
    }

}
