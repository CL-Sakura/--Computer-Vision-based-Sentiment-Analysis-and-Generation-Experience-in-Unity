using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MediaPlayerController : MonoBehaviour
{
    [Header("TrackList")]
    [SerializeField] private Track[] trackSources;

    [Header("Text UI")]
    [SerializeField] private Text trackTextUI;

    private int trackIndex;
    private AudioSource MediaAudioSource;


    

    private void Start()
    {
        MediaAudioSource = GetComponent<AudioSource>();

        trackIndex = 0;
        MediaAudioSource.clip = trackSources[trackIndex].trackAudioClip;
        trackTextUI.text = trackSources[trackIndex].name;

    }

    /*

    public void ChangeAudioTime()
    {
        MediaAudioSource.time = MediaAudioSource.clip.length * MediaAudioSource.value;
    }

        public void Update()
        {
            slider.value = audioSource.time / audioSource.clip.length;
        }

     */
    public void updateTrack(int index)
    {
        MediaAudioSource.clip = trackSources[trackIndex].trackAudioClip;
        trackTextUI.text = trackSources[trackIndex].name;
    }

    public void PlayAudio()
    {
        MediaAudioSource.Play();
    }
    public void PauseAudio()
    {
        MediaAudioSource.Pause();
        

    }
    public void StopAudio()
    {
        MediaAudioSource.Stop();
    }

    public void ForwardButton()
    {
        if(trackIndex < trackSources.Length - 1)
        {
            trackIndex++;
            updateTrack(trackIndex);
            PlayAudio();
        }
        
    }

    public void BackForwardButton()
    {
        if(trackIndex >=1)
        {
            trackIndex--;
            updateTrack(trackIndex);
            PlayAudio();
        }
        
        
    }


}
