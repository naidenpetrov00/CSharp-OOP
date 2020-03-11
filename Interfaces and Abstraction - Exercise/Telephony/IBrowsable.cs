namespace Telephony
{
    public interface IBrowsable
    {
        string Site{ get; }

        string Brows(string site);
    }
}
