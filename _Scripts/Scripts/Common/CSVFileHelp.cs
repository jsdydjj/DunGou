using System.Collections.Generic;
using System.IO;
using Unity;
using UnityEngine;


/// <summary>
/// 读取csv配置文件列表
/// </summary>
public class CSVFileHelp
{
    private static string csv_ModelClip = Application.dataPath + "/_Lesson/ModelClip.csv";



    /// <summary>
    /// 获取工程动画分段信息列表
    /// </summary>
    public static List<ModelClip> GetCsv2ModelClipList()
    {
        string strline = string.Empty;
        string[] aryline;
        int line = 0;
        List<ModelClip> list = new List<ModelClip>();
        //开始解析
        FileStream fs;
        StreamReader sr;
        FileHelp.Instance.GetFileStream(csv_ModelClip, out fs, out sr);
        while ((strline = sr.ReadLine()) != null)
        {
            //首行，添加为table列
            if (line > 0)
            {
                aryline = strline.Split(new char[] { ',' });
                ModelClip m = new ModelClip();
                m.ModelName = aryline[0];
                m.ClipID = aryline[1];
                m.TimeBigin = int.Parse(aryline[2]);
                m.TimeEnd = int.Parse(aryline[3]);
                list.Add(m);
            }
            line++;
        }
        sr.Dispose(); sr.Close();
        fs.Dispose(); fs.Close();
        return list;
    }



}
