using dotnow;
using dotnow.Runtime;
using UnityEngine;

internal static partial class DirectCallBindings
{
    [Preserve]
    [CLRMethodDirectCallBinding(typeof(MeshFilter), "get_mesh")]
    public static void unityEngine_MeshFilter_GetMesh(StackData[] stack, int offset)
    {
        stack[offset].refValue = ((MeshFilter)stack[offset].refValue).mesh;
        stack[offset].type = StackData.ObjectType.Ref;
    }
}