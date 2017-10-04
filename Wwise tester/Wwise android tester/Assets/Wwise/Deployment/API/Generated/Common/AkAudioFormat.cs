#if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.
/* ----------------------------------------------------------------------------
 * This file was automatically generated by SWIG (http://www.swig.org).
 * Version 2.0.11
 *
 * Do not make changes to this file unless you know what you are doing--modify
 * the SWIG interface file instead.
 * ----------------------------------------------------------------------------- */


using System;
using System.Runtime.InteropServices;

public class AkAudioFormat : IDisposable {
  private IntPtr swigCPtr;
  protected bool swigCMemOwn;

  internal AkAudioFormat(IntPtr cPtr, bool cMemoryOwn) {
    swigCMemOwn = cMemoryOwn;
    swigCPtr = cPtr;
  }

  internal static IntPtr getCPtr(AkAudioFormat obj) {
    return (obj == null) ? IntPtr.Zero : obj.swigCPtr;
  }

  ~AkAudioFormat() {
    Dispose();
  }

  public virtual void Dispose() {
    lock(this) {
      if (swigCPtr != IntPtr.Zero) {
        if (swigCMemOwn) {
          swigCMemOwn = false;
          AkSoundEnginePINVOKE.CSharp_delete_AkAudioFormat(swigCPtr);
        }
        swigCPtr = IntPtr.Zero;
      }
      GC.SuppressFinalize(this);
    }
  }

  public uint uSampleRate {
    set {
      AkSoundEnginePINVOKE.CSharp_AkAudioFormat_uSampleRate_set(swigCPtr, value);
    } 
    get {
      uint ret = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_uSampleRate_get(swigCPtr);
      return ret;
    } 
  }

  public AkChannelConfig channelConfig {
    set {
      AkSoundEnginePINVOKE.CSharp_AkAudioFormat_channelConfig_set(swigCPtr, AkChannelConfig.getCPtr(value));
    } 
    get {
      IntPtr cPtr = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_channelConfig_get(swigCPtr);
      AkChannelConfig ret = (cPtr == IntPtr.Zero) ? null : new AkChannelConfig(cPtr, false);
      return ret;
    } 
  }

  public uint uBitsPerSample {
    set {
      AkSoundEnginePINVOKE.CSharp_AkAudioFormat_uBitsPerSample_set(swigCPtr, value);
    } 
    get {
      uint ret = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_uBitsPerSample_get(swigCPtr);
      return ret;
    } 
  }

  public uint uBlockAlign {
    set {
      AkSoundEnginePINVOKE.CSharp_AkAudioFormat_uBlockAlign_set(swigCPtr, value);
    } 
    get {
      uint ret = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_uBlockAlign_get(swigCPtr);
      return ret;
    } 
  }

  public uint uTypeID {
    set {
      AkSoundEnginePINVOKE.CSharp_AkAudioFormat_uTypeID_set(swigCPtr, value);
    } 
    get {
      uint ret = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_uTypeID_get(swigCPtr);
      return ret;
    } 
  }

  public uint uInterleaveID {
    set {
      AkSoundEnginePINVOKE.CSharp_AkAudioFormat_uInterleaveID_set(swigCPtr, value);
    } 
    get {
      uint ret = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_uInterleaveID_get(swigCPtr);
      return ret;
    } 
  }

  public uint GetNumChannels() {
    uint ret = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_GetNumChannels(swigCPtr);
    return ret;
  }

  public uint GetBitsPerSample() {
    uint ret = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_GetBitsPerSample(swigCPtr);
    return ret;
  }

  public uint GetBlockAlign() {
    uint ret = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_GetBlockAlign(swigCPtr);
    return ret;
  }

  public uint GetTypeID() {
    uint ret = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_GetTypeID(swigCPtr);
    return ret;
  }

  public uint GetInterleaveID() {
    uint ret = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_GetInterleaveID(swigCPtr);
    return ret;
  }

  public void SetAll(uint in_uSampleRate, AkChannelConfig in_channelConfig, uint in_uBitsPerSample, uint in_uBlockAlign, uint in_uTypeID, uint in_uInterleaveID) {
    AkSoundEnginePINVOKE.CSharp_AkAudioFormat_SetAll(swigCPtr, in_uSampleRate, AkChannelConfig.getCPtr(in_channelConfig), in_uBitsPerSample, in_uBlockAlign, in_uTypeID, in_uInterleaveID);

  }

  public bool IsChannelConfigSupported() {
    bool ret = AkSoundEnginePINVOKE.CSharp_AkAudioFormat_IsChannelConfigSupported(swigCPtr);
    return ret;
  }

  public AkAudioFormat() : this(AkSoundEnginePINVOKE.CSharp_new_AkAudioFormat(), true) {

  }

}
#endif // #if ! (UNITY_DASHBOARD_WIDGET || UNITY_WEBPLAYER || UNITY_WII || UNITY_WIIU || UNITY_NACL || UNITY_FLASH || UNITY_BLACKBERRY) // Disable under unsupported platforms.