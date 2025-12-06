using UnityEngine;

public enum SwipeDecision { None, Jogada, Mão }

public class CardMov : MonoBehaviour
{
    public bool keepOffset = true;
    public Camera cam;
    public int activeFingerId = -1;
    public float screenZ;
    public Vector3 dragOffset;
    [SerializeField] bool has2D;
    public int cardIndex;

    public System.Action<CardMov, SwipeDecision> OnSwipeReleased;
    public System.Action OnDragStart;
    public System.Action OnDragEnd;

    void Awake()
    {
        cam = Camera.main;
        has2D = GetComponent<Collider2D>() != null;
    }

    void OnEnable()
    {
        screenZ = cam.WorldToScreenPoint(transform.position).z;
    }

    void Update()
    {
        
        if (!Application.isMobilePlatform)
        {
            // Início
            if (Input.GetMouseButtonDown(0) && activeFingerId == -1 && MouseHitsThis())
            {
                activeFingerId = 0;

                Vector3 worldAtMouse = ScreenToWorld(Input.mousePosition);
                dragOffset = keepOffset ? (transform.position - worldAtMouse) : Vector3.zero;

                OnDragStart?.Invoke();
            }

            // Arraste
            if (Input.GetMouseButton(0) && activeFingerId == 0)
            {
                Vector3 worldAtMouse = ScreenToWorld(Input.mousePosition);
                transform.position = worldAtMouse + dragOffset;
            }

            // Fim
            if (Input.GetMouseButtonUp(0) && activeFingerId == 0)
            {
                SwipeDecision decision =
                      transform.position.y > 0f ? SwipeDecision.Jogada
                    : transform.position.y < 0f ? SwipeDecision.Mão
                    : SwipeDecision.None;

                OnSwipeReleased?.Invoke(this, decision);
                OnDragEnd?.Invoke();

                activeFingerId = -1;
            }

            return;
        }

        
        if (Input.touchCount == 0) return;

        for (int i = 0; i < Input.touchCount; i++)
        {
            Touch toutch = Input.GetTouch(i);

            if (toutch.phase == TouchPhase.Began && activeFingerId == -1 && TouchHitsThis(toutch.position))
            {
                activeFingerId = toutch.fingerId;

                Vector3 worldAtFinger = ScreenToWorld(toutch.position);
                dragOffset = keepOffset ? (transform.position - worldAtFinger) : Vector3.zero;

                OnDragStart?.Invoke();
            }

            if (toutch.fingerId == activeFingerId &&
                (toutch.phase == TouchPhase.Moved || toutch.phase == TouchPhase.Stationary))
            {
                Vector3 worldAtFinger = ScreenToWorld(toutch.position);
                transform.position = worldAtFinger + dragOffset;
            }

            if (toutch.fingerId == activeFingerId &&
                (toutch.phase == TouchPhase.Ended || toutch.phase == TouchPhase.Canceled))
            {
                SwipeDecision decision =
                      transform.position.y > 0f ? SwipeDecision.Jogada
                    : transform.position.y < 0f ? SwipeDecision.Mão
                    : SwipeDecision.None;

                OnSwipeReleased?.Invoke(this, decision);
                OnDragEnd?.Invoke();

                activeFingerId = -1;
            }
        }
    }

    Vector3 ScreenToWorld(Vector2 screenPos)
    {
        var screenPosition = new Vector3(screenPos.x, screenPos.y, screenZ);
        return cam.ScreenToWorldPoint(screenPosition);
    }

    bool TouchHitsThis(Vector2 screenPos)
    {
        if (has2D)
        {
            Vector3 world = ScreenToWorld(screenPos);
            return Physics2D.OverlapPoint(world) == GetComponent<Collider2D>();
        }
        return true;
    }

    bool MouseHitsThis()
    {
        if (has2D)
        {
            Vector3 world = ScreenToWorld(Input.mousePosition);
            return Physics2D.OverlapPoint(world) == GetComponent<Collider2D>();
        }
        return true;
    }
}
