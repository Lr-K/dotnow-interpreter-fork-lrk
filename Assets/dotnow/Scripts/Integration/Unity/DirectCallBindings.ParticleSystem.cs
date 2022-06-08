using dotnow;
using dotnow.Runtime;
using UnityEngine;

internal static partial class DirectCallBindings
{
    [Preserve]
    [CLRMethodDirectCallBinding(typeof(ParticleSystem), "get_isPlaying")]
    public static void unityEngine_ParticleSystem_IsPlaying(StackData[] stack, int offset)
    {
        stack[offset].refValue = ((ParticleSystem)stack[offset].refValue).isPlaying;
        stack[offset].type = StackData.ObjectType.Ref;
    }

    [Preserve]
    [CLRMethodDirectCallBinding(typeof(ParticleSystem), "set_emissionRate", typeof(float))]
    public static void unityEngine_ParticleSystem_SetEmissionRate(StackData[] stack, int offset)
    {
        ((ParticleSystem)stack[offset].refValue).emissionRate = stack[offset + 1].value.Single;
    }

    [Preserve]
    [CLRMethodDirectCallBinding(typeof(ParticleSystem), "get_emissionRate")]
    public static void unityEngine_ParticleSystem_GetEmissionRate(StackData[] stack, int offset)
    {
        stack[offset].refValue = ((ParticleSystem)stack[offset].refValue).emissionRate;
        stack[offset].type = StackData.ObjectType.Ref;
    }
}