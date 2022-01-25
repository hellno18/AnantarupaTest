using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;


namespace teamcity
{
    public class PerformBuild : MonoBehaviour
    {
        private const string PROJECT_NAME = "AnantarupaTest";

        public static void ToAndroid()
        {
            Build(".apk", BuildTarget.Android);
        }

        public static void ToiOS()
        {
            Build(".app", BuildTarget.iOS);
        }

        private static void Build(string nameDotExtentions, BuildTarget buildTarget)
        {
            BuildPlayerOptions buildPlayerOptions = new BuildPlayerOptions
            {
                scenes = GetScenesPath(),
                locationPathName = $"Build/{PROJECT_NAME}{nameDotExtentions}",
                target = buildTarget,
                options = BuildOptions.None
            };

            DebugResult(buildPlayerOptions);
        }

        private static string[] GetScenesPath()
        {
            //TEMPORARY
            return new string[] {
                "Assets/Scenes/AnantarupaTest.unity",
            };
        }

        private static void DebugResult(BuildPlayerOptions buildPlayerOptions)
        {
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
