using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Timeline.TimelinePlaybackControls;

public interface ISubscribeToInputs
{
    PlayerControls PlayerControls { get; set; }
    void SubscribeInputs();
    void UnsubscribeInputs();
}
