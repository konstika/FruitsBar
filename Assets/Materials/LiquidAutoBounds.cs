using UnityEngine;

public class LiquidAutoBounds : MonoBehaviour
{
    void Start()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Bounds bounds = mesh.bounds;

        // ƒл€ повЄрнутых объектов используем ось Z как вертикаль
        // bounds.min.z и bounds.max.z Ч это нижн€€ и верхн€€ точка по вертикали
        float minZ = bounds.min.z;
        float maxZ = bounds.max.z;

        Material mat = GetComponent<Renderer>().material;
        mat.SetFloat("_MinY", minZ);
        mat.SetFloat("_MaxY", maxZ);
    }
}
