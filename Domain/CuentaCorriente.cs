namespace Dsw2025Ej8.Domain;
/// <summary>
/// Summary description for Class1
/// </summary>
public class CuentaCorriente : CuentaBancaria
{
    private decimal _comision;
    private decimal _limiteDeDescubierto;
    
    #region GETTERS/SETTERS
    public decimal Comision
    {
        get => _comision;
        set => _comision = value;
    }

    public decimal LimiteDeDescubierto
    {
        get => _limiteDeDescubierto;
        set => _limiteDeDescubierto = value;
    }
    #endregion

    public CuentaCorriente(string numero, decimal saldo, string[] titulares) : base(numero, saldo, titulares)
    {
        _comision = 0.01m;
        _limiteDeDescubierto = 1000;
    }
    
    public override void Depositar(decimal monto)
    {
        if (monto <= 0)
            throw new MontoNoValido("El monto ingresado no es válido para la operación solicitada");
        if (Estado != Estado.Activa)
            throw new CuentaNoActiva("No se puede operar con la cuenta", Estado);
        monto -= monto * _comision;
        Saldo += monto;
    }

    public override void Retirar(decimal monto)
    {
        if (monto <= 0)
            throw new MontoNoValido("El monto ingresado no es válido para la operación solicitada.");
        if (Estado != Estado.Activa)
            throw new CuentaNoActiva($"No se puede operar con la cuenta {Estado}.");
        if (Saldo - monto < -_limiteDeDescubierto)
        {
            Estado = Estado.Suspendida;
            throw new SaldoInsuficiente("La cuenta no cuenta con saldo para la operación solicitada. Fue suspendida.");
        }
        Saldo -= monto;
    }
}
