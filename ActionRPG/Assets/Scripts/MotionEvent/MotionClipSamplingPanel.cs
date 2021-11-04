using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MotionClipSamplingPanel : MonoBehaviour
{
    [SerializeField] private Text currentClipName = null;

    [SerializeField] private Text clipTotalLength = null;

    [SerializeField] private Text curretFrame = null;

    [SerializeField] private Slider samplingTimeline = null;

    private AnimationClip currentClip = null;

    private Action<float> onSamplingValueChange = null;

    public void SetSamplingValueChange(Action<float> callback)
    {
        onSamplingValueChange = callback;

        samplingTimeline.onValueChanged.AddListener((val) => {

            curretFrame.text = samplingTimeline.value.ToString();
            onSamplingValueChange?.Invoke(samplingTimeline.value );
        });
    }

    public void SetSamplingClip(AnimationClip clip)
    {
        currentClip = clip;
        currentClipName.text = clip.name;
        clipTotalLength.text = clip.length.ToString();
        curretFrame.text = "0";

        samplingTimeline.minValue = 0f;
        samplingTimeline.maxValue = clip.length;
    }
}
