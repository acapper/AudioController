using System;
using System.Collections.Generic;
using System.Diagnostics;
using Chromely.Core.Configuration;
using Chromely.Core.Network;
using NAudio.CoreAudioApi;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;

namespace AudioController.Controllers
{
  public class AudioDevicesController : ChromelyController
  {
    private readonly IChromelyConfiguration _config;

    public AudioDevicesController(IChromelyConfiguration config)
    {
      _config = config;
      RegisterGetRequest("/audiodevices", GetAudioDevices);
    }

    [HttpGet(Route = "/audiodevices")]
    private ChromelyResponse GetAudioDevices(ChromelyRequest request)
    {
      List<Object> devices = new List<Object>();

      var enumerator = new MMDeviceEnumerator();

      var outputDevices = enumerator.EnumerateAudioEndPoints(DataFlow.Render, DeviceState.Active);

      foreach (MMDevice e in outputDevices)
      {
        //Console.WriteLine($"{e.DataFlow} {e.FriendlyName} {e.DeviceFriendlyName} {e.State}");
        devices.Add(new { ID = e.ID, Flow = e.DataFlow.ToString(), FriendlyName = e.FriendlyName, DeviceFriendlyName = e.DeviceFriendlyName, State = e.State.ToString() });
      }

      var current = enumerator.GetDefaultAudioEndpoint(DataFlow.Render, Role.Console);
      //Console.WriteLine($"{current.DataFlow} {current.FriendlyName} {current.DeviceFriendlyName} {current.State}");

      var sessions = current.AudioSessionManager.Sessions;


      /* for (int i = 0; i < sessions.Count; i++)
      {
        Console.WriteLine($"Info -> DN: {sessions[i].DisplayName} ID: {sessions[i].GetSessionIdentifier} VOL: {sessions[i].SimpleAudioVolume.Volume}");
        var process = FindLivingProcess(sessions[i].GetProcessID);
        Console.WriteLine(process.ProcessName);
      } */

      return new ChromelyResponse(request.Id)
      {
        Data = devices
      };
    }

    public Process FindLivingProcess(uint id)
    {
      Process process = null;
      try
      {
        process = Process.GetProcessById((int)id);
        return process;
      }
      catch (ArgumentException e)
      {
        Console.WriteLine($@"Failed to find process {id}");
      }
      return process;
    }
  }
}