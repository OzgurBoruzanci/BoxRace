using System;
using System.Collections.Generic;
using UnityEngine;

public static class EventManager
{
    public static Action<BoxController> Boxcollided;
    public static Action<GameObject> BoxcollidedToObstacle;
    public static Action SpeedRegulation;
    public static Action GameOverControl;
    public static Action NextLevelControl;
}