using DAL.DataSetBSTableAdapters;
using System.Data;

namespace BLL
{
    public class ClassLogica
    {
        TipoTratamientoTableAdapter _tipoTratamiento;
        ClienteTableAdapter _cliente;
        PromocionTableAdapter _promocion;
        RolEmpleadoTableAdapter _rolEmpleado;
        EmpleadoTableAdapter _empleado;
        ProveedorTableAdapter _proveedor;
        ArticuloTableAdapter _articulo;
        RegistroAplicacionTableAdapter _registroAplicacion;
        RegistroCompraTableAdapter _registroCompra;

        RetiroBodegaTableAdapter _retiroBodega;

        public ClassLogica()
        {
            _tipoTratamiento = new TipoTratamientoTableAdapter();
            _cliente = new ClienteTableAdapter();
            _promocion = new PromocionTableAdapter();
            _rolEmpleado = new RolEmpleadoTableAdapter();
            _empleado = new EmpleadoTableAdapter();
            _proveedor = new ProveedorTableAdapter();
            _articulo = new ArticuloTableAdapter();

            _registroAplicacion = new RegistroAplicacionTableAdapter();
            _registroCompra = new RegistroCompraTableAdapter();
            _retiroBodega = new RetiroBodegaTableAdapter();

            _tipoTratamiento.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "DB\\DatabaseBS.mdf; Integrated Security = True";
            _cliente.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "DB\\DatabaseBS.mdf; Integrated Security = True";
            _registroAplicacion.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "DB\\DatabaseBS.mdf; Integrated Security = True";
            _promocion.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "DB\\DatabaseBS.mdf; Integrated Security = True";
            _rolEmpleado.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "DB\\DatabaseBS.mdf; Integrated Security = True";
            _empleado.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "DB\\DatabaseBS.mdf; Integrated Security = True";
            _proveedor.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "DB\\DatabaseBS.mdf; Integrated Security = True";
            _registroCompra.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "DB\\DatabaseBS.mdf; Integrated Security = True";
            _articulo.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "DB\\DatabaseBS.mdf; Integrated Security = True";
            _retiroBodega.Connection.ConnectionString = "Data Source = (LocalDB)\\MSSQLLocalDB; AttachDbFilename = " + Environment.CurrentDirectory.Split("WinUI")[0] + "DB\\DatabaseBS.mdf; Integrated Security = True";
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

        public void UpdateTratamiento(string nombre, int duracion, double costo, byte[] img, int id)
        {
            _tipoTratamiento.UpdateQuery(nombre, duracion, costo, img, 1, id);
        }

        public void EliminarTratamiento(int id)
        {
            _tipoTratamiento.UpdateDeleteQuery(id);
        }

        public DataTable ListarClientes()
        {
            return _cliente.GetDataByActivo();
        }

        public void ActualizarCliente(string nombre, string apellido, int tel, int id)
        {
            _cliente.UpdateQueryCliente(nombre, apellido, tel, 1, id);
        }

        public void EliminarCliente(int id)
        {
            _cliente.UpdateDeleteQuery(id);
        }

        public void InsertPromocion(string nombre, int porcentaje, string desc, DateTime fi, DateTime ff, int tratamiento)
        {
            _promocion.Insert(nombre, porcentaje, desc, fi, ff, 1, tratamiento);
        }

        public DataTable listarPromociones()
        {
            return _promocion.GetDataByActivo();
        }

        public void actualizarPromocion(string nombre, int porcentaje, string desc, DateTime fi, DateTime ff, int tratamiento, int id)
        {
            _promocion.UpdateQuery(nombre, porcentaje, desc, fi, ff, 1, tratamiento, id);
        }

        public void eliminarPromocion(int id)
        {
            _promocion.UpdateDeleteQuery(id);
        }

        public DataTable listarEmpleados()
        {
            return _empleado.GetDataByActivo();
        }

        public DataTable listarRoles()
        {
            return _rolEmpleado.GetDataByActivo();
        }

        public void InsertEmpleado(string cui, string nombre, string apellido, string direccion, int tel, int rol)
        {
            _empleado.Insert(cui, nombre, apellido, direccion, tel, 1, rol);
        }

        public void actualizarEmpleado(string cui, string nombre, string apellido, string direccion, int tel, int rol, string original_cui)
        {
            _empleado.UpdateQuery(cui, nombre, apellido, direccion, tel, 1, rol, original_cui);
        }

        public void eliminarEmpleado(string cui)
        {
            _empleado.UpdateDeleteQuery(cui);
        }

        // -----------------
        public DataTable listarProveedores()
        {
            return _proveedor.GetDataByActivo();
        }

        public void InsertProveedor(string nombre, int telefono)
        {
            _proveedor.Insert(nombre, telefono, 1);
        }

        public void ActualizarProveedor(string nombre, int telefono, int id)
        {
            _proveedor.UpdateQuery(nombre, telefono, 1, id);
        }

        public void EliminarProveedor(int id)
        {
            _proveedor.UpdateDeleteQuery(id);
        }

        //--------------------------------------

        public void InsertRegistroAplicacion(DateTime fechah, double costofinal, int tratamiento, int cliente, string cui)
        {
            _registroAplicacion.Insert(fechah, costofinal, 1, tratamiento, cliente, cui);
        }

        public DataTable ListarRegistroAplicacion()
        {
            return _registroAplicacion.GetData();
        }

        // ------------------------------------ 

        public DataTable ListarArticulos()
        {
            return _articulo.GetDataByActivo();
        }

        public void InsertArticulo(string Nombre, string Descripcion)
        {
            _articulo.Insert(Nombre, Descripcion, 1);
        }

        public void UpdateArticulo(string Nombre, string Descripcion, int id)
        {
           _articulo.UpdateQuery(Nombre, Descripcion, 1, id);
        }

        public void EliminarArticulo(int id)
        {
            _articulo.UpdateDeleteQuery(id);
        }

        //---------------------------------
        public DataTable ListarRegistroCompra()
        {
            return _registroCompra.GetDataByActivo();
        }

        public void InsertarRegistroCompra(DateTime FechaHora, int Unidades, double CostoTotal, int Articulo, int Proveedor)
        {
            _registroCompra.Insert(FechaHora, Unidades, CostoTotal, 1, Articulo, Proveedor);
        }

        public void ActualizarRegistroCompra(DateTime FechaHora, int Unidades, double CostoTotal, int Articulo, int Proveedor, int id)
        {
            _registroCompra.UpdateQuery(FechaHora, Unidades, CostoTotal, 1, Articulo, Proveedor, id);
        }

        public void EliminarRegistroCompra(int id)
        {
            _registroCompra.UpdateDeleteQuery(id);
        }

        //-------------------------------------------------

        public DataTable ListarRetiroBodega()
        {
            return _retiroBodega.GetDataByActivo();
        }

        public void InsertarRetiroBodega(int Cantidad, DateTime FechaHora, string cui, int IdArticulo)
        {
            _retiroBodega.Insert(Cantidad, FechaHora, 1, cui, IdArticulo);
        }

        public void ActualizarRetiroBodega(int Cantidad, DateTime FechaHora, string cui, int IdArticulo, int id)
        {
            _retiroBodega.UpdateQuery(Cantidad, FechaHora, 1, cui, IdArticulo, id);
        }

        public void EliminarRetiroBodega(int id)
        {
            _retiroBodega.UpdateDeleteQuery(id);
        }
    }
}