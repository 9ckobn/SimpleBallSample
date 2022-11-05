using UnityEngine;
public abstract class InputModule : IInputService
{
    protected const string _verticalAxis = "Vertical";
    protected const string _horizontalAxis = "Horizontal";

    public abstract Vector2 Axis { get; }

    protected static Vector2 DesktopAxis() => new Vector2(UnityEngine.Input.GetAxis(_horizontalAxis), UnityEngine.Input.GetAxis(_verticalAxis));

}
