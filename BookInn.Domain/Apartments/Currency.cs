namespace BookInn.Domain.Apartments;

public record Currency
{
    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");
    public string Code { get; set; }

    public Currency(string code)
    {
        Code = code;
    }

    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(x => x.Code == code) ??
               throw new ApplicationException($"Unknown currency code: {code}");
    }

    public static readonly IReadOnlyCollection<Currency> All = [Usd, Eur];
}