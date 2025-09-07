namespace OrderApiSOLID.Services.Notifications
{
    public interface INotification
    {
        void Send(string to, string message);
    }
}
