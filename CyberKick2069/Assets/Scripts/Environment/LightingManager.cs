using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightingManager : MonoBehaviour
{
    [SerializeField] private Light directionalLight;
    [SerializeField] private LightingPreset Preset;
    [SerializeField, Range(0, 24)] private float timeOfDay;


    private void Update(){
        if (Preset == null){
            return;
        }

        if (Application.isPlaying){
            timeOfDay += Time.deltaTime;
            timeOfDay %= 24;
            UpdateLighting(timeOfDay/24f);
        }
    }
    private void UpdateLighting(float timePercent){
        RenderSettings.ambientLight = Preset.ambientColor.Evaluate(timePercent);
        RenderSettings.fogColor = Preset.fogColor.Evaluate(timePercent);

        if (directionalLight != null){
            directionalLight.color = Preset.directionalColor.Evaluate(timePercent);
            directionalLight.transform.localRotation = Quaternion.Euler(new Vector3((timePercent * 360f) - 90f, 170, 0));
        }
    }
    private void OnValidate(){
        if (directionalLight != null){
            return;
        }

        if (RenderSettings.sun != null){
            directionalLight = RenderSettings.sun;
        }
        else{
            Light[] lights = GameObject.FindObjectsOfType<Light>();
            foreach(Light light in lights){
                if (light.type == LightType.Directional){
                    directionalLight = light;
                    return;
                }
            }
        }
    }
}
