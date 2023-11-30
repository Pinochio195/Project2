// Tạo Interface state
public interface IBotState
{
    void Enter(BotController bot);
    void Update(BotController bot);
    void Exit(BotController bot);
}