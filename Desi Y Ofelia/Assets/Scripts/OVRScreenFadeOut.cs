using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System.Collections;

public class OVRScreenFadeOut : MonoBehaviour {

    public float fadeTime = 2.0f;

    /// <summary>
    /// The initial screen color.
    /// </summary>
    public Color fadeColor = new Color(0.01f, 0.01f, 0.01f, 1.0f);

    private Material fadeMaterial = null;
    private bool isFading = false;
    private YieldInstruction fadeInstruction = new WaitForEndOfFrame();

    /// <summary>
    /// Initialize.
    /// </summary>
    void Awake()
    {
        // create the fade material
        fadeMaterial = new Material(Shader.Find("Oculus/Unlit Transparent Color"));
    }

    void Start()
    {

    }

    /// <summary>
    /// Fade
    public void Fade(string level)
    {
        StartCoroutine(FadeOut(level));
    }

    /// <summary>
    /// Cleans up the fade material
    /// </summary>
	void OnDestroy()
	{
		if (fadeMaterial != null)
		{
			Destroy(fadeMaterial);
		}
	}

    /// <summary>
    /// Fades alpha from 1.0 to 0.0
    /// </summary>
    public IEnumerator FadeOut(string level)
    {
        float elapsedTime = 0.0f;
        Color color = fadeColor;
        color.a = 0f;
        fadeMaterial.color = color;
        isFading = true;
        while (elapsedTime < fadeTime)
      {
            yield return fadeInstruction;
            elapsedTime += Time.deltaTime;
            color.a = Mathf.Clamp01(elapsedTime / fadeTime);
            fadeMaterial.color = color;
        }
        isFading = false;
		GameObject.FindGameObjectWithTag ("DesiPlayer").transform.Translate (Vector3.down * 100);
        NetworkManager.singleton.ServerChangeScene(level);
    }

    /// <summary>
    /// Renders the fade overlay when attached to a camera object
    /// </summary>
    void OnPostRender()
    {
        if (isFading)
        {
            fadeMaterial.SetPass(0);
            GL.PushMatrix();
            GL.LoadOrtho();
            GL.Color(fadeMaterial.color);
            GL.Begin(GL.QUADS);
            GL.Vertex3(0f, 0f, -12f);
            GL.Vertex3(0f, 1f, -12f);
            GL.Vertex3(1f, 1f, -12f);
            GL.Vertex3(1f, 0f, -12f);
            GL.End();
            GL.PopMatrix();
        }
    }
}
