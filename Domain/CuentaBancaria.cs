namespace Dsw2025Ej8.Domain;

public abstract class CuentaBancaria
{
    private Estado _estado;
    private readonly string _numero;
    private decimal _saldo;
    private string[] _titulares;

    public CuentaBancaria(string numero, decimal saldo, string[] titulares)
    {
        _numero = numero;
        _saldo = saldo;
        _estado = Estado.Activa;
        _titulares = titulares;
    }
    #region Getters/Setters

    public string  Numero => _numero;

    public decimal Saldo
    {
        get => _saldo;
        protected set => _saldo = value;
    }

    public Estado Estado
    {
        get => _estado; 
        set => _estado = value;
    }

    public string[] Titulares
    {
        get => _titulares; 
        set => _titulares = value;
    }
    #endregion
    public abstract void Depositar(decimal monto);

    public abstract void Retirar(decimal monto);
    

}
