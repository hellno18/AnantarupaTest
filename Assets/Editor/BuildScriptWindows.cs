using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;


namespace teamcity
{
    public class BuildScriptWindows : MonoBehaviour
    {
        public static void MyBuildAndroid()
        {
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
            buildPlayerOptions.scenes = new[] { "Assets/Scenes/AnantarupaTest.unity" };
            buildPlayerOptions.locationPathName = "Builds/Android/Game.apk";
            buildPlayerOptions.target = BuildTarget.Android;
            buildPlayerOptions.options = BuildOptions.None;

            BuildReport report = BuildPipeline.BuildPlayer(buildPlayerOptions);
            BuildSummary summary = report.summary;

            if (summary.result == BuildResult.Succeeded)
            {
                Debug.Log("Build succeeded: " + summary.totalSize + " bytes");
            }

            if (summary.result == BuildResult.Failed)
            {
                Debug.Log("Build failed");
            }
        }
    }

}
