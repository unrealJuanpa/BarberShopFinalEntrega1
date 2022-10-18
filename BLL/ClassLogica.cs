using DAL.DataSetBSTableAdapters;
using System.Data;

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

        public void InsertCliente(string nombre, string apellido, int tel)
        {
            _cliente.Insert(nombre, apellido, tel, 1);
        }


        public byte[] ReadFile(string sPath)
        {
            //Initialize byte array with a null value initially.
            byte[] data = null;

            //Use FileInfo object to get file size.
            FileInfo fInfo = new FileInfo(sPath);
            long numBytes = fInfo.Length;

            //Open FileStream to read file
            FileStream fStream = new FileStream(sPath, FileMode.Open, FileAccess.Read);

            //Use BinaryReader to read file stream into byte array.
            BinaryReader br = new BinaryReader(fStream);

            //When you use BinaryReader, you need to supply number of bytes to read from file.
            //In this case we want to read entire file. So supplying total number of bytes.
            data = br.ReadBytes((int)numBytes);
            return data;
        }

        public void InsertTratamiento(string nombre, int duracion, double costo, string imgpath)
        {
            byte[] img = ReadFile(imgpath);
            _tipoTratamiento.Insert(nombre, duracion, costo, img, 1);
        }

        public DataTable ListarTratamientos()
        {
            return _tipoTratamiento.GetDataByActivo();
        }
    }
}