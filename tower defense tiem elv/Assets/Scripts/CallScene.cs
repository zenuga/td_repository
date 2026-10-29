using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using System.Runtime.InteropServices;

public class CallScene : MonoBehaviour
{
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
    [DllImport("user32.dll", CharSet = CharSet.Unicode)]
    private static extern int MessageBox(IntPtr window, string text, string caption, uint type);
#endif

// public int gamescene = 1;
    public void OpenScene(int scene)
    {
        SceneManager.LoadScene(scene);
    }

    public void Death()
    {
#if UNITY_STANDALONE_WIN || UNITY_EDITOR_WIN
        MessageBox(IntPtr.Zero, "OopsieWoopsie the Siwwies have takwen ovew!        hawe fun with twis cwash :3             Ps, I'm deleting system32 jsyk", "oopsie woopsie UwU", 0x00000010);
#else
        Debug.LogError("A severe case of the sillies was detected. The game will now close.");
#endif
        Environment.FailFast("A severe case of the sillies was detected. The game will now close.");
    }
}
