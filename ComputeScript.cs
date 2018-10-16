using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputeScript : MonoBehaviour
{

    public ComputeShader shader;
    private int _Kernel;
    string kernel = "CSMain";
    public Renderer rend;

    // Use this for initialization
    void Awake()
    {
        rend = GetComponent<Renderer>();
        _Kernel = shader.FindKernel(kernel);
        if (_Kernel < 0)
            Debug.Log("Unable to find Kernel");
        RunShader();
    }

    public void RunShader()
    {
        RenderTexture tex = new RenderTexture(256, 256, 24);
        tex.enableRandomWrite = true;
        tex.Create();

        shader.SetTexture(_Kernel, "Result", tex);
        shader.Dispatch(_Kernel, 256 / 8, 256 / 8, 1);

        rend.material.mainTexture = tex;

    }

    private void OnDestroy()
    {
    }

}