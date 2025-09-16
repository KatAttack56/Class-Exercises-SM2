using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    public Material alternateMat;
    private Renderer rend;
    private Material originalMat;
    private bool usingAlternateMat;

    private void Awake()
    {
        rend = GetComponent<Renderer>();
        if (rend != null)
        {
            originalMat = rend.material;
            usingAlternateMat = false;
        }

    }

    public void SwitchMaterial()
    {
        if (rend == null || alternateMat == null)
        {
            Debug.LogWarning("Renderer or alternate material is not set.");
            return;
        }

        if (!usingAlternateMat) {
            rend.material = alternateMat;
            usingAlternateMat = true;
        }
        else
        {
            rend.material = originalMat;
            usingAlternateMat = false;
        }
    }
}
