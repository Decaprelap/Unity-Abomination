using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorGrid : MonoBehaviour
{
    [Range(0.5f,100f)]
    public float size = 1f;

    public Vector3 GetNearestPointOnGrid(Vector3 position, bool cubeplace)
    {
        position -= transform.position;

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        Vector3 result = new Vector3((float)xCount* size, (float)yCount * size, (float)zCount * size);
        result += transform.position;
        return result;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        for (float x = -25; x < 25; x += size)
        {
            for (float z = -25; z < 25; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z),false);
                Gizmos.DrawSphere(point, 0.2f);
            }
        }
    }
}

/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorGrid : MonoBehaviour
{
    private float size = 1f;
    [Range(0, 60)]
    public int scale = 1;
    [HideInInspector]
    public Vector3 scaleVec3;

    public Vector3 GetNearestPointOnGrid(Vector3 position, bool cubeplace)
    {
        position -= transform.position;
        if (!cubeplace) { scaleVec3 = new Vector3(scale, scale, scale); }
        //if (cubeplace) { scaleVec3 = new Vector3(scale, scale, scale); }
        if (cubeplace) { scaleVec3 = new Vector3(2 / scale, 2 / scale, 2 / scale); }

        int xCount = Mathf.RoundToInt(position.x / size);
        int yCount = Mathf.RoundToInt(position.y / size);
        int zCount = Mathf.RoundToInt(position.z / size);

        if (zCount % 2 == 2 % 1)
        {
            Vector3 result = new Vector3(((float)xCount + 0.5f) * size, (float)yCount * size, (float)zCount * size);
            result = Vector3.Scale(result, scaleVec3);
            result += transform.position;
            if (cubeplace) { Debug.Log("indent result" + result); }
            return result;
        }
        if (zCount % 2 != 2 % 1)
        {
            Vector3 result = new Vector3((float)xCount * size, (float)yCount * size, (float)zCount * size);
            result = Vector3.Scale(result, scaleVec3);
            result += transform.position;
            if (cubeplace) { Debug.Log("regular result" + result); }
            return result;
        }
        else { return Vector3.zero; }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        for (float x = -20; x < 20; x += size)
        {
            for (float z = -20; z < 20; z += size)
            {
                var point = GetNearestPointOnGrid(new Vector3(x, 0f, z), false);
                Gizmos.DrawSphere(point, 0.1f);
            }
        }
    }
}
*/