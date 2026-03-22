using UnityEngine;
using UnityEditor;

public class TransformBaker
{
    [MenuItem("Tools/Bake Transform Into Mesh")]
    static void BakeSelected()
    {
        GameObject go = Selection.activeGameObject;
        if (go == null)
        {
            Debug.LogError("Select a GameObject.");
            return;
        }

        MeshFilter mf = go.GetComponent<MeshFilter>();
        if (mf == null || mf.sharedMesh == null)
        {
            Debug.LogError("No MeshFilter with a mesh found.");
            return;
        }

        Mesh original = mf.sharedMesh;
        Mesh baked = Object.Instantiate(original);

        Vector3[] vertices = baked.vertices;
        Matrix4x4 matrix = go.transform.localToWorldMatrix;

        for (int i = 0; i < vertices.Length; i++)
        {
            vertices[i] = matrix.MultiplyPoint3x4(vertices[i]);
        }

        baked.vertices = vertices;
        baked.RecalculateBounds();
        baked.RecalculateNormals();

        // Save as new asset
        string path = "Assets/Baked_" + original.name + ".asset";
        AssetDatabase.CreateAsset(baked, path);
        AssetDatabase.SaveAssets();

        // Assign baked mesh
        mf.sharedMesh = baked;

        // Reset transform
        go.transform.position = Vector3.zero;
        go.transform.rotation = Quaternion.identity;
        go.transform.localScale = Vector3.one;

        Debug.Log("Transform baked into mesh.");
    }
}