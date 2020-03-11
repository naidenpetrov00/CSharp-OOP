namespace Telephony
{
    public interface ICallable
    {
        string PhoneNumber { get; }

        string Call(string number);
    }
}
