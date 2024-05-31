using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppController : MonoBehaviour
{
    [SerializeField] AudioSource playAudioSource;
    [SerializeField] AudioClip[] clips;
    [SerializeField] GameObject waveObject;
    [SerializeField] GameObject playButton;
    [SerializeField] GameObject pauseButton;
    [SerializeField] Animator windowAnimation;

    int currentSLide;

    void Start()
    {
        currentSLide = 1;
        playAudioSource.GetComponent<Animator>().SetBool("stopAnimation", true);
    }

    void Update()
    {
        
    }

    public void OnButtonClickPlayAudio(){
        if(playButton.activeSelf){
            playAudioSource.GetComponent<Animator>().SetBool("stopAnimation", false);
            playAudioSource.clip = clips[currentSLide - 1];
            playAudioSource.Play();
            pauseButton.SetActive(true);
            playButton.SetActive(false);
        }else if(pauseButton.activeSelf){
            playAudioSource.GetComponent<Animator>().SetBool("stopAnimation", true);
            playAudioSource.Stop();
            pauseButton.SetActive(false);
            playButton.SetActive(true);
        }
    }

    public void OnButtonClickChangesSlide(int slideId){
        if(currentSLide == slideId) return;
        if(slideId == 1){
            Debug.Log($"Came to IF statement");
            windowAnimation.Play("window_change_animation_back");
        }else{
            Debug.Log($"Came to ELSE statement");
            windowAnimation.Play("window_change_animation");
        }
        currentSLide = slideId;
    }
}
