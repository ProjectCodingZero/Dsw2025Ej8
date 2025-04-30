namespace Dsw2025Ej8.Domain;

public class SaldoInsuficiente : Exception
{
    public SaldoInsuficiente(){}
    public SaldoInsuficiente(string message) : base(message){}

}