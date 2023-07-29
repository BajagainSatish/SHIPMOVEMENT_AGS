using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OceanManager : MonoBehaviour
{
    [SerializeField] private float wavesHeight = 0.07f;
    [SerializeField] private float wavesFrequency = 0.01f;
    [SerializeField] private float wavesSpeed = 0.04f;
    public Transform ocean;
    Material oceanMat;
    Texture2D wavesDisplacement;

    private void Start()
    {
        SetVariables();
    }

    private void SetVariables()
    {
        oceanMat = ocean.GetComponent<Renderer>().sharedMaterial;
        wavesDisplacement = (Texture2D)oceanMat.GetTexture("Displacement");
    }


    public float WaterHeightAtPosition(Vector3 position)
    {
        return ocean.position.y + wavesDisplacement.GetPixelBilinear(position.x * wavesFrequency, position.z * wavesFrequency + Time.time * wavesSpeed).g * wavesHeight * ocean.localScale.x;
    }

    private void OnValidate()
    {
        if (!oceanMat)
            SetVariables();
        UpdateMaterial();
    }

    private void UpdateMaterial()
    {
        oceanMat.SetFloat("_WavesFrequency",wavesFrequency);
        oceanMat.SetFloat("_WavesSpeed",wavesSpeed);
        oceanMat.SetFloat("_WavesHeight",wavesHeight);
    }
}
