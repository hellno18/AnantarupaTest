using UnityEditor;
using UnityEngine;
using UnityEditor.Build.Reporting;


namespace teamcity
{

    public class PerformBuild : MonoBehaviour
    {
        private const string PROJECT_NAME = "AnantarupaTest";
        
        [MenuItem("Build/ Build To Android")]
        public static void BuildToAndroid()
        {
           
                var bundleVersionSplit = UnityEditor.PlayerSettings.bundleVersion.Split('.');
                int major = 0;
                int minor = 0;
                int subVersion = 0;
                if (bundleVersionSplit.Length >= 1)
                    int.TryParse(bundleVersionSplit[0], out major);
                if (bundleVersionSplit.Length >= 2)
                    int.TryParse(bundleVersionSplit[1], out minor);
                if (bundleVersionSplit.Length >= 3)
                    int.TryParse(bundleVersionSplit[2], out subVersion);
                ++subVersion;
                string version = string.Format("{0}.{1}.{2}", major, minor, subVersion);
                var bundleVersionCode = (major * 100000) + (minor * 1000) + subVersion;

                UnityEditor.PlayerSettings.bundleVersion = version;
                UnityEditor.PlayerSettings.Android.bundleVersionCode = bundleVersionCode;
                UnityEditor.PlayerSettings.macOS.buildNumber = bundleVersionCode.ToString();

            Build(".apk", BuildTarget.Android);

            Debug.Log(version);
        }

        public static void BuildToiOS()
        {
            Build(".app", BuildTarget.iOS);
        }

        public static void BuildToWindows64()
        {
            Build(".exe", BuildTarget.StandaloneWindows64);
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
