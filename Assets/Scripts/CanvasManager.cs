using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum CanvasType
{
    MainMenu,
    GameUI,
    GameOver,
}

public class CanvasManager : Singleton<CanvasManager>
{
    List<CanvasController> canvasControllers;
    CanvasController lastActiveCanvas;

    protected override void Awake()
    {
        base.Awake();
        canvasControllers = GetComponentsInChildren<CanvasController>()
                            .ToList();
        canvasControllers.ForEach(c => c.gameObject.SetActive(false));
        SwitchCanvas(CanvasType.MainMenu);
    }

    public void SwitchCanvas(CanvasType type)
    {
        CanvasController desiredCanvas = canvasControllers.Find(c => c.canvasType == type);
        if (desiredCanvas != null)
        {
            if (lastActiveCanvas != null)
            {
                lastActiveCanvas.gameObject.SetActive(false);
            }

            desiredCanvas.gameObject.SetActive(true);
            lastActiveCanvas = desiredCanvas;
        }
        else { Debug.LogWarning("The desired canvas was not found!"); }
    }
}
