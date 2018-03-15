using UnityEditor;
using Unity;
using System;
using System.Collections.Generic;
using UnityEngine;

public class MyAnimationClip : AssetPostprocessor
{
    /// <summary>
    /// 当前正在导入的模型
    /// </summary>
    public void OnPreprocessModel()
    {
        ModelImporter modelImporter = (ModelImporter)assetImporter;
        try
        {
            string modelName = assetPath.Substring(assetPath.LastIndexOf("/") + 1).Split('.')[0];
            this.AutoClipAnima(modelImporter, modelName);
        }
        catch (Exception ex)
        {
            LogHelp.Write(ex.ToString());
        }
    }




    /// <summary>
    /// 切割动画模型
    /// </summary>
    /// <param name="_fbx"></param>
    /// <param name="_modelName"></param>
    private void AutoClipAnima(ModelImporter _fbx, string _modelName)
    {
        List<ModelClip> listClip = CSVFileHelp.GetCsv2ModelClipList();
        listClip = listClip.FindAll(delegate(ModelClip m) { return m.ModelName.Equals(_modelName); });
        if (listClip.Count <= 0) return;

        _fbx.animationType = ModelImporterAnimationType.Generic;
        _fbx.generateAnimations = ModelImporterGenerateAnimations.GenerateAnimations;
        ModelImporterClipAnimation[] animations = new ModelImporterClipAnimation[listClip.Count];
        for (int i = 0; i < listClip.Count; i++)
        {
            animations[i] = SetClipAnimation(string.Format("{0}-{1}", listClip[i].ModelName, listClip[i].ClipID),
                    listClip[i].TimeBigin,
                    listClip[i].TimeEnd,
                    false);
        }
        _fbx.clipAnimations = animations;
        LogHelp.Write("动画{0}自动分段已完成！", _modelName);
    }
    private ModelImporterClipAnimation SetClipAnimation(string _name, int _first, int _last, bool _isLoop)
    {
        ModelImporterClipAnimation tempClip = new ModelImporterClipAnimation();
        tempClip.name = _name;
        tempClip.firstFrame = _first;
        tempClip.lastFrame = _last;
        tempClip.loop = _isLoop;
        if (_isLoop)
            tempClip.wrapMode = WrapMode.Loop;
        else
            tempClip.wrapMode = WrapMode.Default;

        return tempClip;
    }
}