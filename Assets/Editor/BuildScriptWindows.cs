using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;

public class BuildScriptWindows : MonoBehaviour
{
    [MenuItem("Build/Build Android")]
    public static void MyBuildAndroid()
    {
        BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions();
        buildPlayerOptions.scenes = new[] { "Assets/AnantarupaTest.unity" };
        buildPlayerOptions.locationPathName = "build/android/AnantarupaTest.apk";
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
