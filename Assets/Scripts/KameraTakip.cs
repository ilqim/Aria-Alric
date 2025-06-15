using UnityEngine;

public class KameraTakip : MonoBehaviour
{
    public Transform oyuncu1;
    public Transform oyuncu2;

    public float takipHizi = 5f;
    public Vector2 minKameraPozisyonu;
    public Vector2 maxKameraPozisyonu;
    public float offsetY = 2f;

    void LateUpdate()
    {
        if (oyuncu1 != null && oyuncu2 != null)
        {
            float ortalamaX = (oyuncu1.position.x + oyuncu2.position.x) / 2f;
            float ortalamaY = (oyuncu1.position.y + oyuncu2.position.y) / 2f;

            ortalamaY += offsetY;

            Vector3 kameraPozisyonu = new Vector3(ortalamaX, ortalamaY, transform.position.z);

            kameraPozisyonu.x = Mathf.Clamp(kameraPozisyonu.x, minKameraPozisyonu.x, maxKameraPozisyonu.x);
            kameraPozisyonu.y = Mathf.Clamp(kameraPozisyonu.y, minKameraPozisyonu.y, maxKameraPozisyonu.y);

            transform.position = Vector3.Lerp(transform.position, kameraPozisyonu, takipHizi * Time.deltaTime);
        }
    }
}
