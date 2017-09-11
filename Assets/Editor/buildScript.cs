using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.Collections.Generic;

public class BuildScript : MonoBehaviour
{
    [MenuItem("MyTools/Jenkins build test")]
    public static void PerformBuild()
    {
        Debug.Log("run the menu item");
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/Scenes/ProtoScene1.unity" };
        buildPlayerOptions.locationPathName = "Builds/gameTest.apk";
        buildPlayerOptions.target = BuildTarget.Android;
        buildPlayerOptions.options = BuildOptions.None;
        BuildPipeline.BuildPlayer(buildPlayerOptions);
    }
}