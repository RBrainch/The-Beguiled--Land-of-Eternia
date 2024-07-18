using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip[] musicClips; // 数组来存放不同的音乐曲目

    private int currentTrackIndex = 0;

    void Awake()
    {
        DontDestroyOnLoad(gameObject); // 保持音乐播放器在不同场景间不被销毁

        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // 确保有 AudioSource 组件
        }

        audioSource.loop = true; // 确保音乐循环播放
    }

    void Start()
    {
        // 可选：在开始时播放第一首音乐
        if (musicClips.Length > 0)
        {
            PlayTrack(currentTrackIndex);
        }
    }

    public void PlayMusic()
    {
        if (audioSource != null && !audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void PauseMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Pause();
        }
    }

    public void StopMusic()
    {
        if (audioSource != null && audioSource.isPlaying)
        {
            audioSource.Stop();
        }
    }

    public void ChangeMusic(int trackIndex)
    {
        if (audioSource != null && trackIndex >= 0 && trackIndex < musicClips.Length)
        {
            currentTrackIndex = trackIndex;
            PlayTrack(currentTrackIndex);
        }
    }

    public void NextTrack()
    {
        currentTrackIndex = (currentTrackIndex + 1) % musicClips.Length;
        PlayTrack(currentTrackIndex);
    }

    public void PreviousTrack()
    {
        currentTrackIndex = (currentTrackIndex - 1 + musicClips.Length) % musicClips.Length;
        PlayTrack(currentTrackIndex);
    }

    private void PlayTrack(int trackIndex)
    {
        if (musicClips.Length > 0 && trackIndex >= 0 && trackIndex < musicClips.Length)
        {
            audioSource.clip = musicClips[trackIndex];
            audioSource.Play();
        }
    }
}