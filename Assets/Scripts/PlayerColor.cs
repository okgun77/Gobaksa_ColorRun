using UnityEngine;

public class PlayerColor : MonoBehaviour
{
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private TrailRenderer  trailRenderer;

    public void SetColor(Color _color)
    {
        spriteRenderer.color     = _color;
        trailRenderer.startColor = _color;
        trailRenderer.endColor   = _color;
    }

}
