// Базовая версия перемещения сделанная на коленке, чтобы Кирилл меньше бухтел. Антон перепиши потом во что-то нормальное
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))] // Автоматически требуем Rigidbody2D для игрока
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private MoveStats moveStats;

    [Header("Точка проверки земли (под ногами)")]
    [SerializeField] private Transform groundCheckPoint;

    private Rigidbody2D rb;
    private float horizontalInput;
    private bool isFacingRight = true;
    private bool jumpRequested;
    private bool isGrounded;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        // Определяем куда идет игрок: -1 = лево, 1 = право, 0 = встал и думает
        horizontalInput = Input.GetAxisRaw("Horizontal"); //кнопки взял из Input menager-а в юньке 

        // Проверяем, стоит ли игрок на земле через круг под ногами
        if (groundCheckPoint != null && moveStats != null)
        {
            isGrounded = Physics2D.OverlapCircle(
                groundCheckPoint.position,
                moveStats.GroundCheckRadius,
                moveStats.GroundLayer
            );
        }

        // Заставляем пробел тыкаться
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jumpRequested = true;
        }

        CheckDirectionToFace(horizontalInput > 0);
    }

    private void FixedUpdate()
    {
        Move();

        // прыгаем
        if (jumpRequested)
        {
            Jump();
            jumpRequested = false;
        }
    }

    private void Move()
    {
        if (moveStats == null) return;

        float MaxSpeed = horizontalInput * moveStats.MoveSpeed;
        // Коэффициент для разгона или тормоза
        float accelerate = Mathf.Abs(horizontalInput) > 0f ? moveStats.Acceleration : moveStats.Deceleration;
        float speedplus = MaxSpeed - rb.velocity.x; // Разница между максимальной и нынешней скоростью 
        float movement = speedplus * accelerate * Time.fixedDeltaTime; // Сколько нужно прибавить за физический шаг

        // Переносим математику на физ. модель
        rb.velocity = new Vector2(rb.velocity.x + movement, rb.velocity.y);
    }

    private void Jump() // Прыжок нахуячил через импульс. Не судите строго мне в падлу думать было
    {
        // Импульсный пинок строго вверх
        rb.AddForce(Vector2.up * moveStats.JumpForce, ForceMode2D.Impulse);
    }

    private void CheckDirectionToFace(bool movingRight)
    {
        if (movingRight != isFacingRight && horizontalInput != 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    // Красный кружок в окне Scene для настройки радиуса под ногами
    private void OnDrawGizmosSelected()
    {
        if (groundCheckPoint != null && moveStats != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundCheckPoint.position, moveStats.GroundCheckRadius);
        }
    }
}
