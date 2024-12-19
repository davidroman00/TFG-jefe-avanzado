
using UnityEngine;

public class MouseCursorManager : MonoBehaviour
{
    public void HideMouse()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    public void ShowMouse()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }
}
