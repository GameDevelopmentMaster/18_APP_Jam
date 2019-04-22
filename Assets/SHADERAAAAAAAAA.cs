using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SHADERAAAAAAAAA : MonoBehaviour
{
    public static int intensity = 500;
    private Material material;

    // Start is called before the first frame update
    void Awake()
    {
        material = new Material(Shader.Find("Unlit/mosaic"));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        material.SetFloat("_intensity", (int)intensity);
        Graphics.Blit(source, destination, material);
    }
}
