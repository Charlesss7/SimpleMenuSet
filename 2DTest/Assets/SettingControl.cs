using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SettingControl : MonoBehaviour
{
    [SerializeField] private TMP_Dropdown resolutionDropdown;

    private Resolution[] resolutions;
    private List<Resolution> filteredResolutions;

    private float currentRefreshRate;
    private int currentResolutionIndex =0;
    void Start()
    {
        resolutions = Screen.resolutions;
        filteredResolutions = new List<Resolution>();

        resolutionDropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRate;

        //incase build in unity doesnt show dropdown (due to bug/smth)
        //Debug.Log("RefreshRate : "+currentRefreshRate);
        //try build game if this happen

        for(int i=0; i<resolutions.Length;i++)
        {
            Debug.Log("Resolution : "+resolutions[i]);
            if(resolutions[i].refreshRate==currentRefreshRate)
            {
                filteredResolutions.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();
        for(int i=0;i<filteredResolutions.Count;i++)
        {
            string resolutionOption = filteredResolutions[i].width +
                "x" + filteredResolutions[i].height + " " +
                filteredResolutions[i].refreshRate +" Hz";
            options.Add(resolutionOption);
            if(filteredResolutions[i].width == Screen.width && 
                filteredResolutions[i].height==Screen.height)
            {
                currentResolutionIndex=i;
            }
        }

        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = filteredResolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height,true);
    }

    public void SetFullScreen(bool isFullScreen)
    {
        Screen.fullScreen=isFullScreen;
        Debug.Log("Full Screen: "+Screen.fullScreen);
    }

    public void DebugMessage(string SendMessage)
    {
        Debug.Log(SendMessage);
    }
}
