using UnityEngine;
using UnityEngine.Rendering;
using UnityEditor;

[InitializeOnLoad]
class TransparentSorting
{
    static TransparentSorting()
    {
        Initialize();
    }
    [RuntimeInitializeOnLoadMethod]
    static void Initialize()
    {
        GraphicsSettings.transparencySortMode = TransparencySortMode.CustomAxis;
        GraphicsSettings.transparencySortAxis = new Vector3(0.0f, 1.0f, 1.0f);
    }
}