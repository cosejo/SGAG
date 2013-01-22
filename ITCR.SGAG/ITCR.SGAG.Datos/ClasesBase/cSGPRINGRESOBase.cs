#region Acerca de...
///////////////////////////////////////////////////////////////////////////
// Empresa:  Instituto Tecnológico de Costa Rica
// Proyecto: Sistema de Gestión del Área del Gimnasio
// Descripción: Clase de acceso a datos para tabla 'SGPRINGRESO'
// Generado por ITCR Gen v2010.0.0.0 
// Fecha: domingo, 20 de enero de 2013, 09:00:09 p.m.
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
	/// Propósito: Clase de acceso a datos para tabla 'SGPRINGRESO'.
	/// </summary>
	public class cSGPRINGRESOBase : cBDInteraccionBase
	{
		#region Declaraciones de miembros de la clase
			private SqlDateTime		_fEC_SISTEMA, _fEC_INGRESO;
			private SqlInt32		_iD_INGRESO;
			private SqlString		_cAR_USUARIOGIMNASIO;
		#endregion


		/// <summary>
		/// Propósito: Constructor de la clase.
		/// </summary>
		public cSGPRINGRESOBase()
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
		///		 <LI>FEC_INGRESO</LI>
		///		 <LI>FEC_SISTEMA</LI>
		///		 <LI>CAR_USUARIOGIMNASIO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>ID_INGRESO</LI>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override bool Insertar()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRINGRESO_Insertar]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_INGRESO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_INGRESO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_SISTEMA", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_SISTEMA));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@sCAR_USUARIOGIMNASIO", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cAR_USUARIOGIMNASIO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iID_INGRESO", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _iD_INGRESO));
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
				_iD_INGRESO = Int32.Parse(cmdAEjecutar.Parameters["@iID_INGRESO"].Value.ToString());
				_codError = Int32.Parse(cmdAEjecutar.Parameters["@iCodError"].Value.ToString());

				if(_codError != (int)ITCRError.AllOk)
				{
					// Genera un error.
					throw new Exception("Procedimiento Almacenado 'pr_SGPRINGRESO_Insertar' reportó el error Codigo: " + _codError);
				}

				return true;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRINGRESOBase::Insertar::Ocurrió un error." + ex.Message, ex);
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
		///		 <LI>ID_INGRESO</LI>
		///		 <LI>FEC_INGRESO</LI>
		///		 <LI>FEC_SISTEMA</LI>
		///		 <LI>CAR_USUARIOGIMNASIO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override bool Actualizar()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRINGRESO_Actualizar]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iID_INGRESO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _iD_INGRESO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_INGRESO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_INGRESO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_SISTEMA", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_SISTEMA));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@sCAR_USUARIOGIMNASIO", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cAR_USUARIOGIMNASIO));
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
					throw new Exception("Procedimiento Almacenado 'pr_SGPRINGRESO_Actualizar' reportó el error Codigo: " + _codError);
				}

				return true;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRINGRESOBase::Actualizar::Ocurrió un error." + ex.Message, ex);
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
		///		 <LI>ID_INGRESO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override bool Eliminar()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRINGRESO_Eliminar]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iID_INGRESO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _iD_INGRESO));
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
					throw new Exception("Procedimiento Almacenado 'pr_SGPRINGRESO_Eliminar' reportó el error Codigo: " + _codError);
				}

				return true;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRINGRESOBase::Eliminar::Ocurrió un error." + ex.Message, ex);
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
		///		 <LI>ID_INGRESO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		///		 <LI>ID_INGRESO</LI>
		///		 <LI>FEC_INGRESO</LI>
		///		 <LI>FEC_SISTEMA</LI>
		///		 <LI>CAR_USUARIOGIMNASIO</LI>
		/// </UL>
		/// Llena todas las propiedades que corresponden al campo en tabla con el valor de la fila seleccionada.
		/// </remarks>
		public override DataTable SeleccionarUno()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRINGRESO_SeleccionarUno]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("SGPRINGRESO");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdAEjecutar);

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iID_INGRESO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _iD_INGRESO));
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
					throw new Exception("Procedimiento Almacenado 'pr_SGPRINGRESO_SeleccionarUno' reportó el error Código: " + _codError);
				}

				if(toReturn.Rows.Count > 0)
				{
					_iD_INGRESO = (Int32)toReturn.Rows[0]["ID_INGRESO"];
					_fEC_INGRESO = (DateTime)toReturn.Rows[0]["FEC_INGRESO"];
					_fEC_SISTEMA = (DateTime)toReturn.Rows[0]["FEC_SISTEMA"];
					_cAR_USUARIOGIMNASIO = (string)toReturn.Rows[0]["CAR_USUARIOGIMNASIO"];
				}
				return toReturn;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRINGRESOBase::SeleccionarUno::Ocurrió un error." + ex.Message, ex);
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
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRINGRESO_SeleccionarTodos]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("SGPRINGRESO");
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
					throw new Exception("Procedimiento Almacenado 'pr_SGPRINGRESO_SeleccionarTodos' reportó el error Código: " + _codError);
				}

				return toReturn;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRINGRESOBase::SeleccionarTodos::Ocurrió un error." + ex.Message, ex);
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
		///		 <LI>ID_INGRESO</LI>
		///		 <LI>FEC_INGRESO</LI>
		///		 <LI>FEC_SISTEMA</LI>
		///		 <LI>CAR_USUARIOGIMNASIO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override DataTable Buscar()
		{
			SqlCommand	cmdAEjecutar = new SqlCommand();
			cmdAEjecutar.CommandText = "dbo.[pr_SGPRINGRESO_Buscar]";
			cmdAEjecutar.CommandType = CommandType.StoredProcedure;
			DataTable toReturn = new DataTable("SGPRINGRESO");
			SqlDataAdapter adapter = new SqlDataAdapter(cmdAEjecutar);

			// Usar el objeto conexión de la clase base
			cmdAEjecutar.Connection = _conexionBD;

			try
			{
				cmdAEjecutar.Parameters.Add(new SqlParameter("@iID_INGRESO", SqlDbType.Int, 4, ParameterDirection.Input, false, 10, 0, "", DataRowVersion.Proposed, _iD_INGRESO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_INGRESO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_INGRESO));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@daFEC_SISTEMA", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _fEC_SISTEMA));
				cmdAEjecutar.Parameters.Add(new SqlParameter("@sCAR_USUARIOGIMNASIO", SqlDbType.VarChar, 20, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, _cAR_USUARIOGIMNASIO));
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
					throw new Exception("Procedimiento Almacenado 'pr_SGPRINGRESO_Buscar' reportó el error Código: " + _codError);
				}

				return toReturn;
			}
			catch (Exception ex)
			{
				// Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
				throw new Exception("cSGPRINGRESOBase::Buscar::Ocurrió un error." + ex.Message, ex);
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
        /// Propósito: Método Seleccionar datos entre dos fechas. Este método va a Hacer un SELECT LIKE de tabla.
        /// </summary>
        /// <returns>DataTable object si tuvo éxito, sino genera una Exception. </returns>
        /// <remarks>
        /// Propiedades necesarias para este método: 
        /// <UL>
        /// </UL>
        /// Propiedades actualizadas luego de una llamada exitosa a este método: 
        /// <UL>
        ///		 <LI>CodError</LI>
        /// </UL>
        /// </remarks>
        public DataTable SeleccionarPorFecha(DateTime Inicio, DateTime Final)
        {
            SqlCommand cmdAEjecutar = new SqlCommand();
            cmdAEjecutar.CommandText = "dbo.[pr_SGPRINGRESO_SeleccionarTodos_Por_Fechas]";
            cmdAEjecutar.CommandType = CommandType.StoredProcedure;
            DataTable toReturn = new DataTable("SGPRINGRESO");
            SqlDataAdapter adapter = new SqlDataAdapter(cmdAEjecutar);

            // Usar el objeto conexión de la clase base
            cmdAEjecutar.Connection = _conexionBD;

            try
            {
                cmdAEjecutar.Parameters.Add(new SqlParameter("@dFEC_INICIO", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Inicio));
                cmdAEjecutar.Parameters.Add(new SqlParameter("@dFEC_FINAL", SqlDbType.DateTime, 8, ParameterDirection.Input, false, 0, 0, "", DataRowVersion.Proposed, Final));
                cmdAEjecutar.Parameters.Add(new SqlParameter("@iCodError", SqlDbType.Int, 4, ParameterDirection.Output, true, 10, 0, "", DataRowVersion.Proposed, _codError));

                if (_conexionBDEsCreadaLocal)
                {
                    // Abre una conexión.
                    _conexionBD.Open();
                }
                else
                {
                    if (_conexionBDProvider.IsTransactionPending)
                    {
                        cmdAEjecutar.Transaction = _conexionBDProvider.CurrentTransaction;
                    }
                }

                // Ejecuta la consulta.
                adapter.Fill(toReturn);
                _codError = Int32.Parse(cmdAEjecutar.Parameters["@iCodError"].Value.ToString());

                if (_codError != (int)ITCRError.AllOk)
                {
                    // Genera un error.
                    throw new Exception("Procedimiento Almacenado 'pr_SGPRINGRESO_SeleccionarTodos_Por_Fechas' reportó el error Código: " + _codError);
                }

                return toReturn;
            }
            catch (Exception ex)
            {
                // Ocurrió un error. le hace Bubble a quien llama y encapsula el objeto Exception
                throw new Exception("cSGPRINGRESOBase::Buscar::Ocurrió un error." + ex.Message, ex);
            }
            finally
            {
                if (_conexionBDEsCreadaLocal)
                {
                    // Cierra la conexión.
                    _conexionBD.Close();
                }
                cmdAEjecutar.Dispose();
                adapter.Dispose();
            }
        }

		#region Declaraciones de propiedades de la clase
		public SqlInt32 ID_INGRESO
		{
			get
			{
				return _iD_INGRESO;
			}
			set
			{
				SqlInt32 iD_INGRESOTmp = (SqlInt32)value;
				if(iD_INGRESOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("ID_INGRESO", "ID_INGRESO can't be NULL");
				}
				_iD_INGRESO = value;
			}
		}


		public SqlDateTime FEC_INGRESO
		{
			get
			{
				return _fEC_INGRESO;
			}
			set
			{
				SqlDateTime fEC_INGRESOTmp = (SqlDateTime)value;
				if(fEC_INGRESOTmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("FEC_INGRESO", "FEC_INGRESO can't be NULL");
				}
				_fEC_INGRESO = value;
			}
		}


		public SqlDateTime FEC_SISTEMA
		{
			get
			{
				return _fEC_SISTEMA;
			}
			set
			{
				SqlDateTime fEC_SISTEMATmp = (SqlDateTime)value;
				if(fEC_SISTEMATmp.IsNull)
				{
					throw new ArgumentOutOfRangeException("FEC_SISTEMA", "FEC_SISTEMA can't be NULL");
				}
				_fEC_SISTEMA = value;
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
		#endregion


    }
}
