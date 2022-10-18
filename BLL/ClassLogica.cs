using DAL.DataSetBSTableAdapters;

namespace BLL
{
    public class ClassLogica
    {
        TipoTratamientoTableAdapter _tipoTratamiento;
        ClienteTableAdapter _cliente;
        RegistroAplicacionTableAdapter _registroAplicacion;
        PromocionTableAdapter _promocion;
        RolEmpleadoTableAdapter _rolEmpleado;
        EmpleadoTableAdapter _empleado;
        ProveedorTableAdapter _proveedor;
        RegistroCompraTableAdapter _registroCompra;
        ArticuloTableAdapter _articulo;
        RetiroBodegaTableAdapter _retiroBodega;

        public ClassLogica()
        {
            _tipoTratamiento = new TipoTratamientoTableAdapter();
            _cliente = new ClienteTableAdapter();
            _registroAplicacion = new RegistroAplicacionTableAdapter();
            _promocion = new PromocionTableAdapter();
            _rolEmpleado = new RolEmpleadoTableAdapter();
            _empleado = new EmpleadoTableAdapter();
            _proveedor = new ProveedorTableAdapter();
            _registroCompra = new RegistroCompraTableAdapter();
            _articulo = new ArticuloTableAdapter();
            _retiroBodega = new RetiroBodegaTableAdapter();
        }

        public int VerifyLogin(string cui)
        {
            return (int)_empleado.ScalarQueryVerifyLogin(cui);
        }
    }
}