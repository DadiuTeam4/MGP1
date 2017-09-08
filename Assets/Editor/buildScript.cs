using UnityEngine;
using System.Collections;
using UnityEditor;
using System;
using System.Collections.Generic;
 
public class BuildScript : MonoBehaviour {
 
static void PerformBuild ()
{

BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
buildPlayerOptions.scenes = new[] {"Assets/Scenes/ProtoScene1.unity", "Assets/Scenes/ProtoScene2.unity"};
buildPlayerOptions.locationPathName = "Android";
buildPlayerOptions.target = BuildTarget.Android;
buildPlayerOptions.APP_NAME = "Drengen der talte alting";
buildPlayerOptions.TARGET_DIR = "Builds/";
buildPlayerOptions.options = BuildOptions.None;

BuildPipeline.BuildPlayer(buildPlayerOptions);

}