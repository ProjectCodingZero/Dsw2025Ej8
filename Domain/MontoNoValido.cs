namespace Dsw2025Ej8.Domain;

public class MontoNoValido : Exception  
{
    private decimal _monto;
    
    public MontoNoValido(){}
    public MontoNoValido(string message) : base(message){}

    public MontoNoValido(string message, decimal monto) : base(message)
    {
        _monto = monto;
    }
    public decimal Monto { get => _monto; }
}