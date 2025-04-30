namespace Dsw2025Ej8.Domain;

public class CuentaNoActiva : Exception
{
    private Estado _estado;
    
    public CuentaNoActiva(){}
    public CuentaNoActiva(string message) : base(message){}

    public CuentaNoActiva(string message, Estado estado) : base(message)
    {
        _estado = estado;
    }
    public Estado Estado { get => _estado; }
}