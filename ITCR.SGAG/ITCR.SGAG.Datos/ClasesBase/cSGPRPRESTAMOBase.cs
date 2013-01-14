#region Acerca de...
///////////////////////////////////////////////////////////////////////////
// Empresa:  Instituto Tecnológico de Costa Rica
// Proyecto: Sistema de Gestión del Área del Gimnasio
// Descripción: Clase de acceso a datos para tabla 'SGPRPRESTAMO'
// Generado por ITCR Gen v2010.0.0.0 
// Fecha: domingo, 13 de enero de 2013, 10:54:23 p.m.
// Dado que esta clase implementa IDispose, las clases derivadas no deben hacerlo.
///////////////////////////////////////////////////////////////////////////
#endregion


using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
//using Microsoft.SqlServer.Types;  //usarlo cuando hay tipos Geometry, Geography, HierarchiId. Está en C:\Program Files\Microsoft SQL Server\100\SDK\Assemblies\Microsoft.SqlServer.Types.dll

namespace ITCR.SGAG.Base
{
	/// <summary>
	/// Propósito: Clase de acceso a datos para tabla 'SGPRPRESTAMO'.
	/// </summary>
	public class cSGPRPRESTAMOBase : cBDInteraccionBase
	{
		#region Declaraciones de miembros de la clase
			private SqlBoolean		_eSTADO;
			private SqlDateTime		_fEC_INGRESADO, _fEC_PRESTAMO;
			private SqlInt32		_iD_PRESTAMO, _fK_IDTIPOPRESTAMO, _fK_IDTIPOPRESTAMOOld;
			private SqlString		_dSC_PRESTAMO, _cAR_USUARIOGIMNASIO;
		#endregion


		/// <summary>
		/// Propósito: Constructor de la clase.
		/// </summary>
		public cSGPRPRESTAMOBase()
		{
			// Agregar código aquí.
		}


		/// <summary>
		/// Propósito: Método Insertar. Este método inserta una fila nueva en la base de datos.
		/// </summary>
		/// <returns>True si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>FEC_PRESTAMO</LI>
		///		 <LI>FEC_INGRESADO</LI>
		///		 <LI>FK_IDTIPOPRESTAMO</LI>
		///		 <LI>DSC_PRESTAMO</LI>
		///		 <LI>CAR_USUARIOGIMNASIO</LI>
		///		 <LI>ESTADO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>ID_PRESTAMO</LI>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override bool Insertar()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRPRESTAMO_Insertar]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_PRESTAMO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_PRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_INGRESADO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_INGRESADO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iFK_IDTIPOPRESTAMO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _fK_IDTIPOPRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@sDSC_PRESTAMO", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dSC_PRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@sCAR_USUARIOGIMNASIO", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cAR_USUARIOGIMNASIO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@bESTADO", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _eSTADO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iID_PRESTAMO", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _iD_PRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iCodError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _codError));

				if(_conexionBDEsCreadaLocal)
				{
					// Abre una conexión.
					_conexionBD.Open();
				}
				else
				{
					if(_conexionBDProvider.IsTransactionPending)
					{
						cmdAEjecutar.Transaction = _conexionBDProvider.CurrentTransaction;
					}
				}

				// Ejecuta la consulta.
				_filasAfectadas = cmdAEjecutar.ExecuteNonQuery();
				_iD_PRESTAMO = Int32.Parse(cmdAEjecutar.Parameters["@iID_PRESTAMO"].Value.ToString());
				_codError = Int32.Parse(cmdAEjecutar.Parameters["@iCodError"].Value.ToString());

				if(_codError != (int)ITCRError.AllOk)
				{
					// Genera un error.
					throw new Exception("Procedimiento Almacenado 'pr_SGPRPRESTAMO_Insertar' reportó el error Codigo: " + _codError);
				}

				return true;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRPRESTAMOBase::Insertar::Ocurrió un error." + ex.Message, ex);
			}
			finally
			{
				if(_conexionBDEsCreadaLocal)
				{
					// Cierra la conexión.
					_conexionBD.Close();
				}
				cmdAEjecutar.Dispose();
			}
		}


		/// <summary>
		/// Propósito: Método Update. Actualiza una fila existente en la base de datos.
		/// </summary>
		/// <returns>True si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>ID_PRESTAMO</LI>
		///		 <LI>FEC_PRESTAMO</LI>
		///		 <LI>FEC_INGRESADO</LI>
		///		 <LI>FK_IDTIPOPRESTAMO</LI>
		///		 <LI>DSC_PRESTAMO</LI>
		///		 <LI>CAR_USUARIOGIMNASIO</LI>
		///		 <LI>ESTADO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override bool Actualizar()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRPRESTAMO_Actualizar]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iID_PRESTAMO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _iD_PRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_PRESTAMO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_PRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_INGRESADO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_INGRESADO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iFK_IDTIPOPRESTAMO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _fK_IDTIPOPRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@sDSC_PRESTAMO", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dSC_PRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@sCAR_USUARIOGIMNASIO", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cAR_USUARIOGIMNASIO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@bESTADO", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _eSTADO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iCodError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _codError));

				if(_conexionBDEsCreadaLocal)
				{
					// Abre una conexión.
					_conexionBD.Open();
				}
				else
				{
					if(_conexionBDProvider.IsTransactionPending)
					{
						cmdAEjecutar.Transaction = _conexionBDProvider.CurrentTransaction;
					}
				}

				// Ejecuta la consulta.
				_filasAfectadas = cmdAEjecutar.ExecuteNonQuery();
				_codError = Int32.Parse(cmdAEjecutar.Parameters["@iCodError"].Value.ToString());

				if(_codError != (int)ITCRError.AllOk)
				{
					// Genera un error.
					throw new Exception("Procedimiento Almacenado 'pr_SGPRPRESTAMO_Actualizar' reportó el error Codigo: " + _codError);
				}

				return true;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRPRESTAMOBase::Actualizar::Ocurrió un error." + ex.Message, ex);
			}
			finally
			{
				if(_conexionBDEsCreadaLocal)
				{
					// Cierra la conexión.
					_conexionBD.Close();
				}
				cmdAEjecutar.Dispose();
			}
		}


		/// <summary>
		/// Propósito: Método Update para actualizar una o más filas utilizando la llave foránea 'FK_IDTIPOPRESTAMO.
		/// Este método actualiza una o más filas existentes en la base de datos, actualiza el campo 'FK_IDTIPOPRESTAMO' en
		/// todas las filas que tienen ese valor para este campo con el valor 'FK_IDTIPOPRESTAMOanterior 
		/// con el valor colocado en la propiedad 'FK_IDTIPOPRESTAMO'.
		/// </summary>
		/// <returns>True si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>FK_IDTIPOPRESTAMO</LI>
		///		 <LI>FK_IDTIPOPRESTAMOOld</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public bool ActualizarTodos_Con_FK_IDTIPOPRESTAMO_FK()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRPRESTAMO_ActualizarTodos_Con_FK_IDTIPOPRESTAMO_FK]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iFK_IDTIPOPRESTAMO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _fK_IDTIPOPRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iFK_IDTIPOPRESTAMOOld", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _fK_IDTIPOPRESTAMOOld));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iCodError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _codError));

				if(_conexionBDEsCreadaLocal)
				{
					// Abre una conexión.
					_conexionBD.Open();
				}
				else
				{
					if(_conexionBDProvider.IsTransactionPending)
					{
						cmdAEjecutar.Transaction = _conexionBDProvider.CurrentTransaction;
					}
				}

				// Ejecuta la consulta.
				_filasAfectadas = cmdAEjecutar.ExecuteNonQuery();
				_codError = Int32.Parse(cmdAEjecutar.Parameters["@iCodError"].Value.ToString());

				if(_codError != (int)ITCRError.AllOk)
				{
					// Genera un error.
					throw new Exception("Procedimiento almacenado 'pr_SGPRPRESTAMO_ActualizarTodos_Con_FK_IDTIPOPRESTAMO_FK' reportó el error Código: " + _codError);
				}

				return true;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRPRESTAMOBase::ActualizarTodos_Con_FK_IDTIPOPRESTAMO_FK::Ocurrió un error." + ex.Message, ex);
			}
			finally
			{
				if(_conexionBDEsCreadaLocal)
				{
					// Cierra la conexión.
					_conexionBD.Close();
				}
				cmdAEjecutar.Dispose();
			}
		}


		/// <summary>
		/// Propósito: Método Eliminar. Borra una fila en la base de datos, basado en la llave primaria.
		/// </summary>
		/// <returns>True si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>ID_PRESTAMO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override bool Eliminar()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRPRESTAMO_Eliminar]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iID_PRESTAMO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _iD_PRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iCodError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _codError));

				if(_conexionBDEsCreadaLocal)
				{
					// Abre una conexión.
					_conexionBD.Open();
				}
				else
				{
					if(_conexionBDProvider.IsTransactionPending)
					{
						cmdAEjecutar.Transaction = _conexionBDProvider.CurrentTransaction;
					}
				}

				// Ejecuta la consulta.
				_filasAfectadas = cmdAEjecutar.ExecuteNonQuery();
				_codError = Int32.Parse(cmdAEjecutar.Parameters["@iCodError"].Value.ToString());

				if(_codError != (int)ITCRError.AllOk)
				{
					// Genera un error.
					throw new Exception("Procedimiento Almacenado 'pr_SGPRPRESTAMO_Eliminar' reportó el error Codigo: " + _codError);
				}

				return true;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRPRESTAMOBase::Eliminar::Ocurrió un error." + ex.Message, ex);
			}
			finally
			{
				if(_conexionBDEsCreadaLocal)
				{
					// Cierra la conexión.
					_conexionBD.Close();
				}
				cmdAEjecutar.Dispose();
			}
		}


		/// <summary>
		/// Propósito: Método Eliminar para una llave primaria. Este método va a borrar una o más filas en la base de datos, basado en la llave primaria 'FK_IDTIPOPRESTAMO'
		/// </summary>
		/// <returns>True si tuvo éxito, false otherwise. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>FK_IDTIPOPRESTAMO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public bool EliminarTodo_Con_FK_IDTIPOPRESTAMO_FK()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRPRESTAMO_EliminarTodo_Con_FK_IDTIPOPRESTAMO_FK]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iFK_IDTIPOPRESTAMO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _fK_IDTIPOPRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iCodError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _codError));

				if(_conexionBDEsCreadaLocal)
				{
					// Abre una conexión.
					_conexionBD.Open();
				}
				else
				{
					if(_conexionBDProvider.IsTransactionPending)
					{
						cmdAEjecutar.Transaction = _conexionBDProvider.CurrentTransaction;
					}
				}

				// Ejecuta la consulta.
				_filasAfectadas = cmdAEjecutar.ExecuteNonQuery();
				_codError = Int32.Parse(cmdAEjecutar.Parameters["@iCodError"].Value.ToString());

				if(_codError != (int)ITCRError.AllOk)
				{
					// Genera un error.
					throw new Exception("Procedimiento almacenado 'pr_SGPRPRESTAMO_EliminarTodo_Con_FK_IDTIPOPRESTAMO_FK' reportó el error Código: " + _codError);
				}

				return true;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRPRESTAMOBase::EliminarTodo_Con_FK_IDTIPOPRESTAMO_FK::Ocurrió un error." + ex.Message, ex);
			}
			finally
			{
				if(_conexionBDEsCreadaLocal)
				{
					// Cierra la conexión.
					_conexionBD.Close();
				}
				cmdAEjecutar.Dispose();
			}
		}


		/// <summary>
		/// Propósito: Método SELECT. Este método hace Select de una fila existente en la base de datos, basado en la llave primaria.
		/// </summary>
		/// <returns>DataTable object si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>ID_PRESTAMO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		///		 <LI>ID_PRESTAMO</LI>
		///		 <LI>FEC_PRESTAMO</LI>
		///		 <LI>FEC_INGRESADO</LI>
		///		 <LI>FK_IDTIPOPRESTAMO</LI>
		///		 <LI>DSC_PRESTAMO</LI>
		///		 <LI>CAR_USUARIOGIMNASIO</LI>
		///		 <LI>ESTADO</LI>
		/// </UL>
		/// Llena todas las propiedades que corresponden al campo en tabla con el valor de la fila seleccionada.
		/// </remarks>
		public override DataTable SeleccionarUno()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRPRESTAMO_SeleccionarUno]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("SGPRPRESTAMO");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdAEjecutar);

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iID_PRESTAMO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _iD_PRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iCodError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _codError));

				if(_conexionBDEsCreadaLocal)
				{
					// Abre una conexión.
					_conexionBD.Open();
				}
				else
				{
					if(_conexionBDProvider.IsTransactionPending)
					{
						cmdAEjecutar.Transaction = _conexionBDProvider.CurrentTransaction;
					}
				}

				// Ejecuta la consulta.
				adapter.Fill(toReturn);
				_codError = Int32.Parse(cmdAEjecutar.Parameters["@iCodError"].Value.ToString());

				if(_codError != (int)ITCRError.AllOk)
				{
					// Genera un error.
					throw new Exception("Procedimiento Almacenado 'pr_SGPRPRESTAMO_SeleccionarUno' reportó el error Código: " + _codError);
				}

				if(toReturn.Rows.Count > 0)
				{
					_iD_PRESTAMO = (Int32)toReturn.Rows[0]["ID_PRESTAMO"];
					_fEC_PRESTAMO = (DateTime)toReturn.Rows[0]["FEC_PRESTAMO"];
					_fEC_INGRESADO = (DateTime)toReturn.Rows[0]["FEC_INGRESADO"];
					_fK_IDTIPOPRESTAMO = (Int32)toReturn.Rows[0]["FK_IDTIPOPRESTAMO"];
					_dSC_PRESTAMO = (string)toReturn.Rows[0]["DSC_PRESTAMO"];
					_cAR_USUARIOGIMNASIO = (string)toReturn.Rows[0]["CAR_USUARIOGIMNASIO"];
					_eSTADO = (bool)toReturn.Rows[0]["ESTADO"];
				}
				return toReturn;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRPRESTAMOBase::SeleccionarUno::Ocurrió un error." + ex.Message, ex);
			}
			finally
			{
				if(_conexionBDEsCreadaLocal)
				{
					// Cierra la conexión.
					_conexionBD.Close();
				}
				cmdAEjecutar.Dispose();
				adapter.Dispose();
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
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRPRESTAMO_SeleccionarTodos]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("SGPRPRESTAMO");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdAEjecutar);

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iCodError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _codError));

				if(_conexionBDEsCreadaLocal)
				{
					// Abre una conexión.
					_conexionBD.Open();
				}
				else
				{
					if(_conexionBDProvider.IsTransactionPending)
					{
						cmdAEjecutar.Transaction = _conexionBDProvider.CurrentTransaction;
					}
				}

				// Ejecuta la consulta.
				adapter.Fill(toReturn);
				_codError = Int32.Parse(cmdAEjecutar.Parameters["@iCodError"].Value.ToString());

				if(_codError != (int)ITCRError.AllOk)
				{
					// Genera un error.
					throw new Exception("Procedimiento Almacenado 'pr_SGPRPRESTAMO_SeleccionarTodos' reportó el error Código: " + _codError);
				}

				return toReturn;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRPRESTAMOBase::SeleccionarTodos::Ocurrió un error." + ex.Message, ex);
			}
			finally
			{
				if(_conexionBDEsCreadaLocal)
				{
					// Cierra la conexión.
					_conexionBD.Close();
				}
				cmdAEjecutar.Dispose();
				adapter.Dispose();
			}
		}


		/// <summary>
		/// Propósito: Método SELECT para una llave primaria. Este método hace Select de una o más filas de la base de datos, basado en la llave primaria 'FK_IDTIPOPRESTAMO'
		/// </summary>
		/// <returns>DataTable object si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>FK_IDTIPOPRESTAMO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public DataTable SeleccionarTodos_Con_FK_IDTIPOPRESTAMO_FK()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRPRESTAMO_SeleccionarTodos_Con_FK_IDTIPOPRESTAMO_FK]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("SGPRPRESTAMO");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdAEjecutar);

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iFK_IDTIPOPRESTAMO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _fK_IDTIPOPRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iCodError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _codError));

				if(_conexionBDEsCreadaLocal)
				{
					// Abre una conexión.
					_conexionBD.Open();
				}
				else
				{
					if(_conexionBDProvider.IsTransactionPending)
					{
						cmdAEjecutar.Transaction = _conexionBDProvider.CurrentTransaction;
					}
				}

				// Ejecuta la consulta.
				adapter.Fill(toReturn);
				_codError = Int32.Parse(cmdAEjecutar.Parameters["@iCodError"].Value.ToString());

				if(_codError != (int)ITCRError.AllOk)
				{
					// Genera un error.
					throw new Exception("Procedimiento Almacenado 'pr_SGPRPRESTAMO_SeleccionarTodos_Con_FK_IDTIPOPRESTAMO_FK' reportó el error Código: " + _codError);
				}

				return toReturn;
			}
			catch(Exception ex)
			{
				// Ocurrió un error. Le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRPRESTAMOBase::SeleccionarTodos_Con_FK_IDTIPOPRESTAMO_FK::Ocurrió un error." + ex.Message, ex);
			}
			finally
			{
				if(_conexionBDEsCreadaLocal)
				{
					// Cierra la conexión.
					_conexionBD.Close();
				}
				cmdAEjecutar.Dispose();
				adapter.Dispose();
			}
		}


		/// <summary>
		/// Propósito: Método Buscar. Este método hace una busqueda de acuerdo con todos los campos de la tabla.
		/// </summary>
		/// <returns>DataTable si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>ID_PRESTAMO</LI>
		///		 <LI>FEC_PRESTAMO</LI>
		///		 <LI>FEC_INGRESADO</LI>
		///		 <LI>FK_IDTIPOPRESTAMO</LI>
		///		 <LI>DSC_PRESTAMO</LI>
		///		 <LI>CAR_USUARIOGIMNASIO</LI>
		///		 <LI>ESTADO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override DataTable Buscar()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRPRESTAMO_Buscar]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("SGPRPRESTAMO");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdAEjecutar);

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iID_PRESTAMO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _iD_PRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_PRESTAMO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_PRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_INGRESADO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_INGRESADO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iFK_IDTIPOPRESTAMO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _fK_IDTIPOPRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@sDSC_PRESTAMO", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _dSC_PRESTAMO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@sCAR_USUARIOGIMNASIO", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cAR_USUARIOGIMNASIO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@bESTADO", SqlDbType.Bit, 1, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _eSTADO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iCodError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _codError));

				if(_conexionBDEsCreadaLocal)
				{
					// Abre una conexión.
					_conexionBD.Open();
				}
				else
				{
					if(_conexionBDProvider.IsTransactionPending)
					{
						cmdAEjecutar.Transaction = _conexionBDProvider.CurrentTransaction;
					}
				}

				// Ejecuta la consulta.
				adapter.Fill(toReturn);
				_codError = Int32.Parse(cmdAEjecutar.Parameters["@iCodError"].Value.ToString());

				if(_codError != (int)ITCRError.AllOk)
				{
					// Genera un error.
					throw new Exception("Procedimiento Almacenado 'pr_SGPRPRESTAMO_Buscar' reportó el error Código: " + _codError);
				}

				return toReturn;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRPRESTAMOBase::Buscar::Ocurrió un error." + ex.Message, ex);
			}
			finally
			{
				if(_conexionBDEsCreadaLocal)
				{
					// Cierra la conexión.
					_conexionBD.Close();
				}
				cmdAEjecutar.Dispose();
				adapter.Dispose();
			}
		}


		#region Declaraciones de propiedades de la clase
		public SqlInt32 ID_PRESTAMO
		{
			get
			{
				return _iD_PRESTAMO;
			}
			set
			{
				SqlInt32 iD_PRESTAMOTmp = (SqlInt32)value;
				if(iD_PRESTAMOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_PRESTAMO", "ID_PRESTAMO can't be NULL");
				}
				_iD_PRESTAMO = value;
			}
		}


		public SqlDateTime FEC_PRESTAMO
		{
			get
			{
				return _fEC_PRESTAMO;
			}
			set
			{
				SqlDateTime fEC_PRESTAMOTmp = (SqlDateTime)value;
				if(fEC_PRESTAMOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("FEC_PRESTAMO", "FEC_PRESTAMO can't be NULL");
				}
				_fEC_PRESTAMO = value;
			}
		}


		public SqlDateTime FEC_INGRESADO
		{
			get
			{
				return _fEC_INGRESADO;
			}
			set
			{
				SqlDateTime fEC_INGRESADOTmp = (SqlDateTime)value;
				if(fEC_INGRESADOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("FEC_INGRESADO", "FEC_INGRESADO can't be NULL");
				}
				_fEC_INGRESADO = value;
			}
		}


		public SqlInt32 FK_IDTIPOPRESTAMO
		{
			get
			{
				return _fK_IDTIPOPRESTAMO;
			}
			set
			{
				SqlInt32 fK_IDTIPOPRESTAMOTmp = (SqlInt32)value;
				if(fK_IDTIPOPRESTAMOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("FK_IDTIPOPRESTAMO", "FK_IDTIPOPRESTAMO can't be NULL");
				}
				_fK_IDTIPOPRESTAMO = value;
			}
		}
		public SqlInt32 FK_IDTIPOPRESTAMOOld
		{
			get
			{
				return _fK_IDTIPOPRESTAMOOld;
			}
			set
			{
				SqlInt32 fK_IDTIPOPRESTAMOOldTmp = (SqlInt32)value;
				if(fK_IDTIPOPRESTAMOOldTmp.IsNull )
				{
					throw new ArgumentOutOfRangeException("FK_IDTIPOPRESTAMOOld", "FK_IDTIPOPRESTAMOOld can't be NULL");
				}
				_fK_IDTIPOPRESTAMOOld = value;
			}
		}


		public SqlString DSC_PRESTAMO
		{
			get
			{
				return _dSC_PRESTAMO;
			}
			set
			{
				SqlString dSC_PRESTAMOTmp = (SqlString)value;
				if(dSC_PRESTAMOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("DSC_PRESTAMO", "DSC_PRESTAMO can't be NULL");
				}
				_dSC_PRESTAMO = value;
			}
		}


		public SqlString CAR_USUARIOGIMNASIO
		{
			get
			{
				return _cAR_USUARIOGIMNASIO;
			}
			set
			{
				SqlString cAR_USUARIOGIMNASIOTmp = (SqlString)value;
				if(cAR_USUARIOGIMNASIOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("CAR_USUARIOGIMNASIO", "CAR_USUARIOGIMNASIO can't be NULL");
				}
				_cAR_USUARIOGIMNASIO = value;
			}
		}


		public SqlBoolean ESTADO
		{
			get
			{
				return _eSTADO;
			}
			set
			{
				SqlBoolean eSTADOTmp = (SqlBoolean)value;
				if(eSTADOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ESTADO", "ESTADO can't be NULL");
				}
				_eSTADO = value;
			}
		}
		#endregion
	}
}
