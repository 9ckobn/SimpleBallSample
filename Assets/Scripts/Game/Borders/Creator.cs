using UnityEngine;

public class Creator : MonoBehaviour
{
    public static Vector3 WorldCorners(int x, int y) => Camera.main.ViewportToWorldPoint(new Vector3(x, y, Camera.main.nearClipPlane));
    public Vector3 WorldCorners(int x, int y, Vector3 offset) => Camera.main.ViewportToWorldPoint(new Vector3(x, y, Camera.main.nearClipPlane)) + offset;
}
