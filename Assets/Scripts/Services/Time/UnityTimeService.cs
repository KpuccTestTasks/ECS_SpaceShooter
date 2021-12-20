using UnityEngine;

public class UnityTimeService : ITimeService
{
    public float GetFrameTime()
    {
        return Time.deltaTime;
    }
}
