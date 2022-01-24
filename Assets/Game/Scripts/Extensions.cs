public static class Extensions
{
    public static bool IsTriggered(this Joystick joystick)
    {
        const float joystickTrashold = 0.2f;
        if (joystick.Direction.magnitude > joystickTrashold) return true;
        return false;
    }
}
