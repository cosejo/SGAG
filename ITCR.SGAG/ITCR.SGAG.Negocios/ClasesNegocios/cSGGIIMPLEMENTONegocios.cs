#region Acerca de...
///////////////////////////////////////////////////////////////////////////
// Cliente:  Instituto Tecnológico de Costa Rica
// Proyecto: Sistema de Gestión del Área del Gimnasio
// Descripción: Clase de LOGICA DE NEGOCIOS para tabla 'SGGIIMPLEMENTO'
// Generado por ITCR Gen v2010.0.0.0 
// Fecha: domingo, 13 de enero de 2013, 10:54:23 p.m.
///////////////////////////////////////////////////////////////////////////
#endregion


using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using ITCR.SGAG.Base;
using ITCR.SGAG.Datos;
using ITCR.SGAG.Negocios.wsSeguridad;

namespace ITCR.SGAG.Negocios
{
	/// <summary>
	/// Propósito: Clase de lógica de negocios para tabla 'SGGIIMPLEMENTO'.
	/// </summary>
	public class cSGGIIMPLEMENTONegocios : cSGGIIMPLEMENTODatos
	{
		#region Declaraciones de miembros de la clase
		private int				_COD_APLICACIONBitacora, _COD_FUNCIONALIDADBitacora;
		private string			_ID_USUARIOBitacora, _COD_SEDEBitacora;
		#endregion


		/// <summary>
		/// Propósito: Constructor de la clase.
		/// </summary>
		public cSGGIIMPLEMENTONegocios(int COD_APLICACIONBitacora, string COD_SEDEBitacora, int COD_FUNCIONALIDADBitacora, string ID_USUARIOBitacora) : base()
		{
			//asignacion de las propiedades privadas para manejo de bitacoras
			_COD_APLICACIONBitacora = COD_APLICACIONBitacora;
			_COD_SEDEBitacora = COD_SEDEBitacora;
			_COD_FUNCIONALIDADBitacora = COD_FUNCIONALIDADBitacora;
			_ID_USUARIOBitacora = ID_USUARIOBitacora;
		}


		/// <summary>
		/// Propósito: Método Insertar de la clase de negocios. Este método inserta una fila nueva en la base de datos.
		/// </summary>
		/// <returns>True si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>FK_IDTIPOIMPLEMENTO</LI>
		///		 <LI>DSC_IMPLEMENTO</LI>
		///		 <LI>FK_IDDEPORTE. May be SqlInt32.Null</LI>
		///		 <LI>CAN_ENINVENTARIO. May be SqlInt32.Null</LI>
		///		 <LI>CAN_DISPONIBLE. May be SqlInt32.Null</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>ID_IMPLEMENTO</LI>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override bool Insertar()
		{
			string operacion;
			SeguridadSoapClient wsseg = new SeguridadSoapClient();
			try
			{
				//Construir aqui el string a guardar en la bitacora.
				operacion = "Insertar cSGGIIMPLEMENTO;"
					+"FK_IDTIPOIMPLEMENTO:"+FK_IDTIPOIMPLEMENTO.ToString()+";"
					+"DSC_IMPLEMENTO:"+DSC_IMPLEMENTO.ToString()+";"
					+"FK_IDDEPORTE:"+FK_IDDEPORTE.ToString()+";"
					+"CAN_ENINVENTARIO:"+CAN_ENINVENTARIO.ToString()+";"
					+"CAN_DISPONIBLE:"+CAN_DISPONIBLE.ToString()+";";
				//wsseg.BitacoraRegistrarUso(_COD_APLICACIONBitacora, _COD_FUNCIONALIDADBitacora, _COD_SEDEBitacora, eTipoEventoBitacora.UsoFuncionalidad, _ID_USUARIOBitacora,operacion);
				return base.Insertar();
			}
			catch (Exception ex)
			{
				//Construir el string a guardar en la bitácora en caso de error.
				operacion = "Error Insertar cSGGIIMPLEMENTO;"+ex.Message;
				//wsseg.BitacoraRegistrarUso(_COD_APLICACIONBitacora, _COD_FUNCIONALIDADBitacora, _COD_SEDEBitacora, eTipoEventoBitacora.Error, _ID_USUARIOBitacora,operacion);
				throw ex;
			}
		}


		/// <summary>
		/// Propósito: Método Update. Actualiza una fila existente en la base de datos.
		/// </summary>
		/// <returns>True si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>ID_IMPLEMENTO</LI>
		///		 <LI>FK_IDTIPOIMPLEMENTO</LI>
		///		 <LI>DSC_IMPLEMENTO</LI>
		///		 <LI>FK_IDDEPORTE. May be SqlInt32.Null</LI>
		///		 <LI>CAN_ENINVENTARIO. May be SqlInt32.Null</LI>
		///		 <LI>CAN_DISPONIBLE. May be SqlInt32.Null</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override bool Actualizar()
		{
			string operacion;
			SeguridadSoapClient wsseg = new SeguridadSoapClient();
			try
			{
				//Construir aqui el string a guardar en la bitacora.
				operacion = "Actualizar cSGGIIMPLEMENTO;"
					+"ID_IMPLEMENTO:"+ID_IMPLEMENTO.ToString()+";"
					+"FK_IDTIPOIMPLEMENTO:"+FK_IDTIPOIMPLEMENTO.ToString()+";"
					+"DSC_IMPLEMENTO:"+DSC_IMPLEMENTO.ToString()+";"
					+"FK_IDDEPORTE:"+FK_IDDEPORTE.ToString()+";"
					+"CAN_ENINVENTARIO:"+CAN_ENINVENTARIO.ToString()+";"
					+"CAN_DISPONIBLE:"+CAN_DISPONIBLE.ToString()+";";
				//wsseg.BitacoraRegistrarUso(_COD_APLICACIONBitacora, _COD_FUNCIONALIDADBitacora, _COD_SEDEBitacora, eTipoEventoBitacora.UsoFuncionalidad, _ID_USUARIOBitacora,operacion);
				return base.Actualizar();
			}
			catch (Exception ex)
			{
				//Construir el string a guardar en la bitácora en caso de error.
				operacion = "Error Actualizar cSGGIIMPLEMENTO;"+ex.Message;
				//wsseg.BitacoraRegistrarUso(_COD_APLICACIONBitacora, _COD_FUNCIONALIDADBitacora, _COD_SEDEBitacora, eTipoEventoBitacora.Error, _ID_USUARIOBitacora,operacion);
				throw ex;
			}
		}


		/// <summary>
		/// Propósito: Método Eliminar de lógica de negocios. Borra una fila en la base de datos, basado en la llave primaria.
		/// </summary>
		/// <returns>True si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>ID_IMPLEMENTO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override bool Eliminar()
		{
			string operacion;
			SeguridadSoapClient wsseg = new SeguridadSoapClient();
			try
			{
				//Construir aqui el string a guardar en la bitacora.
				operacion = "Eliminar cSGGIIMPLEMENTO;"
					+"ID_IMPLEMENTO:"+ID_IMPLEMENTO.ToString()+";";
				//wsseg.BitacoraRegistrarUso(_COD_APLICACIONBitacora, _COD_FUNCIONALIDADBitacora, _COD_SEDEBitacora, eTipoEventoBitacora.UsoFuncionalidad, _ID_USUARIOBitacora,operacion);
				return base.Eliminar();
			}
			catch (Exception ex)
			{
				//Construir el string a guardar en la bitácora en caso de error.
				operacion = "Error Eliminar cSGGIIMPLEMENTO;"+ex.Message;
				//wsseg.BitacoraRegistrarUso(_COD_APLICACIONBitacora, _COD_FUNCIONALIDADBitacora, _COD_SEDEBitacora, eTipoEventoBitacora.Error, _ID_USUARIOBitacora,operacion);
				throw ex;
			}
		}


		/// <summary>
		/// Propósito: Método SELECT. Este método hace Select de una fila existente en la base de datos, basado en la llave primaria.
		/// </summary>
		/// <returns>DataTable object si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>ID_IMPLEMENTO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		///		 <LI>ID_IMPLEMENTO</LI>
		///		 <LI>FK_IDTIPOIMPLEMENTO</LI>
		///		 <LI>DSC_IMPLEMENTO</LI>
		///		 <LI>FK_IDDEPORTE</LI>
		///		 <LI>CAN_ENINVENTARIO</LI>
		///		 <LI>CAN_DISPONIBLE</LI>
		/// </UL>
		/// Llena todas las propiedades que corresponden al campo en tabla con el valor de la fila seleccionada.
		/// </remarks>
		public override DataTable SeleccionarUno()
		{
			try
			{
				return base.SeleccionarUno();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		/// <summary>
		/// Propósito: Método SeleccionarTodos. Este método va a Hacer un SELECT All de tabla.
		/// </summary>
		/// <returns>DataTable object si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override DataTable SeleccionarTodos()
		{
			try
			{
				return base.SeleccionarTodos();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}


		/// <summary>
		/// Propósito: Método Buscar. Este método va a Hacer un SELECT LIKE de tabla.
		/// </summary>
		/// <returns>DataTable object si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>ID_IMPLEMENTO</LI>
		///		 <LI>FK_IDTIPOIMPLEMENTO</LI>
		///		 <LI>DSC_IMPLEMENTO</LI>
		///		 <LI>FK_IDDEPORTE. May be SqlInt32.Null</LI>
		///		 <LI>CAN_ENINVENTARIO. May be SqlInt32.Null</LI>
		///		 <LI>CAN_DISPONIBLE. May be SqlInt32.Null</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override DataTable Buscar()
		{
			try
			{
				return base.Buscar();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}

        // ========================================

        public override DataTable ConocerProxDevolucion()
        {
            try
            {
                return base.ConocerProxDevolucion();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
         
	} //class
} //namespace
