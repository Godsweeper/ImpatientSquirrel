using UnityEngine;
using System.Collections;

public class Utility : MonoSingleton<Utility>
{
    #region Public variables
    public Timer enlargeTimer;      //Timer for UI enlargement
    #endregion

    #region Private variables
    private bool timeCheck;
    private Vector2 originalScale,
                    originalPos,
                    scaleDifference;
    #endregion

    void Start()
    {
        enlargeTimer = new Timer();
        enlargeTimer.setTimer(0.2f);
    }

    void Update()
    {
        enlargeTimer.UpdateTimer();
        //Debug.Log("updated enlarge timer");
        timeCheck = enlargeTimer.checkTimer();
    }

    public void ResetEnlargeTimer()
    {
        enlargeTimer.resetTimer(0.2f);
    }

    public void StartEnlargeTimer()
    {
        enlargeTimer.startTimer();
    }

    public bool CheckEnlargeTimer()
    {
        return timeCheck;
    }

    // Convert from screen-space coordinates to world-space coordinates on the Z = 0 plane
    public Vector3 GetWorldPos(Vector2 screenPos)
    {
        Ray ray = Camera.main.ScreenPointToRay(screenPos);

        // we solve for intersection with z = 0 plane
        float t = -ray.origin.z / ray.direction.z;

        return ray.GetPoint(t);
    }

    public Vector2 EnlargeButtonScale(Vector2 originalButtonScale)
    {
        originalScale = originalButtonScale;
        originalButtonScale.x = originalButtonScale.x * 1.2f;
        originalButtonScale.y = originalButtonScale.y * 1.2f;
        scaleDifference.x = originalButtonScale.x - originalScale.x;
        scaleDifference.y = originalButtonScale.y - originalScale.y;
        return originalButtonScale;
    }

    public Vector2 EnlargeButtonPosition(Vector2 originalButtonPos)
    {
        originalPos = originalButtonPos;
        originalButtonPos.x = originalPos.x - (scaleDifference.x / 2.0f);
        originalButtonPos.y = originalPos.y - (scaleDifference.y / 2.0f);
        return originalButtonPos;
    }

    public Vector2 ResetButtonScale()
    {
        return originalScale;
    }

    public Vector2 ResetButtonPosition()
    {
        return originalPos;
    }
}
