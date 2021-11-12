using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Player : MonoBehaviour
{
    // Поля:
    // соблюдаем инкапсуляцию, публичные поля только при необходимости, именуются по обычно exampleField
    // если нужно, чтобы публичное поле было скрыто в инспекторе Unity, то дописываем атрибут HideInInspector
    // приватные поля именуется с _ (нижним подчеркиванием) _exampleField
    // если нужно, чтобы приватное поле было видно в инспекторе Unity, то дописываем атрибут SerializeField
    //
    // Методы:
    // Awake - Начинается до старта сцены, вся инициализация объектов, всё здесь делать
    // Start - Срабатывает при старте сцены, выполнять операции с объектами, необходимые в начале
    // Update - Срабатывает каждый кадр
    // FixedUpdate - Использовать только при работе с физикой

    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _movementSpeed;
    [SerializeField] private float _jumpForce;
    private Rigidbody2D _rigidbody;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float velocityX = 0;
        float velocityY = 0;

        if (_joystick.Horizontal != 0)
            velocityX = _movementSpeed * (_joystick.Horizontal > 0 ? 1 : -1);

        if (_joystick.Vertical >= 0.4f)
            velocityY = _jumpForce;

        _rigidbody.velocity = new Vector2(velocityX, velocityY);
    }
}
