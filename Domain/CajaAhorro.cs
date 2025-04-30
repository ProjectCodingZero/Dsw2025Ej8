namespace Dsw2025Ej8.Domain;
public class CajaAhorro : CuentaBancaria
{
    private decimal _tasaDeInteres;

    #region GETTERS/SETTERS
    public decimal TasaDeInteres
    {
        get => _tasaDeInteres;
        set => _tasaDeInteres = value;
    }
    #endregion

    public CajaAhorro(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
    {
        _tasaDeInteres = 0.01m;
    }
    public override void Depositar(decimal monto)
    {
        if (monto <= 0)
            throw new MontoNoValido();
        if (Estado != Estado.Activa)
            throw new CuentaNoActiva();
        
        Saldo += monto;
    }
    public override void Retirar(decimal monto)
    {
        if (monto <= 0)
            throw new MontoNoValido();
        if (Estado != Estado.Activa)
            throw new CuentaNoActiva();
        if (Saldo < monto)
        {
            Estado = Estado.Suspendida;
            throw new SaldoInsuficiente();
        }

        Saldo -= monto;
    }

    public void AplicarInteres()
    {
        Saldo += Saldo * _tasaDeInteres;
    }
}