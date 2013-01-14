#region Acerca de...
///////////////////////////////////////////////////////////////////////////
// Cliente:  Instituto Tecnológico de Costa Rica
// Proyecto: Sistema de Gestión del Área del Gimnasio
// Descripción: Clase de acceso a datos para tabla 'SGPRDANOPORDEVOLUCION'
// Generado por ITCR Gen v2010.0.0.0 
// Fecha: domingo, 13 de enero de 2013, 10:54:23 p.m.
// Dado que esta clase implementa IDispose, las clases derivadas no deben hacerlo.
///////////////////////////////////////////////////////////////////////////
#endregion


using System;
using System.Data;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using ITCR.SGAG.Base;

namespace ITCR.SGAG.Datos
{
	/// <summary>
	/// Propósito: Clase de acceso a datos derivada para tabla 'SGPRDANOPORDEVOLUCION'.
	/// </summary>
	public class cSGPRDANOPORDEVOLUCIONDatos : cSGPRDANOPORDEVOLUCIONBase
	{


		/// <summary>
		/// Propósito: Constructor de la clase.
		/// </summary>
		public cSGPRDANOPORDEVOLUCIONDatos() : base()
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
		///		 <LI>FK_IDDEVOLUCION</LI>
		///		 <LI>FK_IDDANO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override bool Insertar()
		{
			return base.Insertar();
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
			return base.SeleccionarTodos();
		}


		/// <summary>
		/// Propósito: Método Buscar. Este método va a Hacer un SELECT de tabla.
		/// </summary>
		/// <returns>DataTable object si tuvo éxito, sino genera una Exception. </returns>
		/// <remarks>
		/// Propiedades necesarias para este método: 
		/// <UL>
		///		 <LI>FK_IDDEVOLUCION</LI>
		///		 <LI>FK_IDDANO</LI>
		/// </UL>
		/// Propiedades actualizadas luego de una llamada exitosa a este método: 
		/// <UL>
		///		 <LI>CodError</LI>
		/// </UL>
		/// </remarks>
		public override DataTable Buscar()
		{
			//TODO: agregar % para busqueda de campos string (varchar, etc.) con LIKE (el procedimiento ya lo hace), así:
			//if (!base.DescripcionCF.IsNull) {
				//    base.DescripcionCF = "{0}" + base.DescripcionCF + "{0}"; }
			return base.Buscar();
		}
	} //class
} //namespace
