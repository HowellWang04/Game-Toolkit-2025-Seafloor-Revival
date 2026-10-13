using UnityEngine;
using UnityEngine.Video;

public class VideoOverlay : MonoBehaviour
{
    public string videoFileName = "intro.mp4"; // 放在 StreamingAssets 文件夹里

    void Start()
    {
        PlayVideoOnTop();
    }

    void PlayVideoOnTop()
    {
        VideoPlayer videoPlayer = gameObject.AddComponent<VideoPlayer>();

        videoPlayer.source = VideoSource.Url;
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);

        videoPlayer.renderMode = VideoRenderMode.CameraNearPlane;
        videoPlayer.targetCameraAlpha = 1f;

        videoPlayer.isLooping = false;

        videoPlayer.loopPointReached += OnVideoEnd;

        videoPlayer.Play();
    }

    void OnVideoEnd(VideoPlayer vp)
    {
        GlobalData.videoEnd = true;
    }
}
