using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshot : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F1))
            TakeScreenshot();
    }

    void TakeScreenshot()
    {
        DateTime dt = DateTime.Now;
        ScreenCapture.CaptureScreenshot(@"Screenshots/screenshot_" +
            dt.Date.Year + dt.Month + dt.Day + "_" + dt.Hour + dt.Minute +
            dt.Second + dt.Millisecond + ".png");
    }
}
