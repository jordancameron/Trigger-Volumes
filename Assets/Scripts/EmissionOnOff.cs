using UnityEngine;

public class EmissionButton : MonoBehaviour
{
    public Renderer targetRenderer; // Assign the renderer of the 3D model here.
    public Color onColor = Color.white; // Color when the button is pressed.
    public Color offColor = Color.black; // Color when the button is not pressed.

    private bool isOnButton = false;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnButton = true;
            ToggleEmission(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isOnButton = false;
            ToggleEmission(false);
        }
    }

    void ToggleEmission(bool on)
    {
        if (targetRenderer != null)
        {
            Material material = targetRenderer.material;
            Color targetColor = on ? onColor : offColor;
            material.SetColor("_EmissionColor", targetColor);

            // Enable or disable the emission texture based on the color.
            if (on)
            {
                material.EnableKeyword("_EMISSION");
            }
            else
            {
                material.DisableKeyword("_EMISSION");
            }
        }
    }
}
