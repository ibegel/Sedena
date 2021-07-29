﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión de runtime:4.0.30319.42000
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SedenaServices.Models
{
	using System.Data.Linq;
	using System.Data.Linq.Mapping;
	using System.Data;
	using System.Collections.Generic;
	using System.Reflection;
	using System.Linq;
	using System.Linq.Expressions;
	using System.ComponentModel;
	using System;
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="Sedena")]
	public partial class DBSedenaDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Definiciones de métodos de extensibilidad
    partial void OnCreated();
    partial void InsertArma(Arma instance);
    partial void UpdateArma(Arma instance);
    partial void DeleteArma(Arma instance);
    partial void InsertEncargado(Encargado instance);
    partial void UpdateEncargado(Encargado instance);
    partial void DeleteEncargado(Encargado instance);
    partial void InsertFuncion(Funcion instance);
    partial void UpdateFuncion(Funcion instance);
    partial void DeleteFuncion(Funcion instance);
    partial void InsertSesion(Sesion instance);
    partial void UpdateSesion(Sesion instance);
    partial void DeleteSesion(Sesion instance);
    partial void InsertVehiculo(Vehiculo instance);
    partial void UpdateVehiculo(Vehiculo instance);
    partial void DeleteVehiculo(Vehiculo instance);
    partial void InsertUsuario(Usuario instance);
    partial void UpdateUsuario(Usuario instance);
    partial void DeleteUsuario(Usuario instance);
		#endregion
		public DBSedenaDataContext() :
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["SedenaConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		public DBSedenaDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBSedenaDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBSedenaDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public DBSedenaDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<Arma> Arma
		{
			get
			{
				return this.GetTable<Arma>();
			}
		}
		
		public System.Data.Linq.Table<Conductor> Conductor
		{
			get
			{
				return this.GetTable<Conductor>();
			}
		}
		
		public System.Data.Linq.Table<Configuracion> Configuracion
		{
			get
			{
				return this.GetTable<Configuracion>();
			}
		}
		
		public System.Data.Linq.Table<Disparo> Disparo
		{
			get
			{
				return this.GetTable<Disparo>();
			}
		}
		
		public System.Data.Linq.Table<Encargado> Encargado
		{
			get
			{
				return this.GetTable<Encargado>();
			}
		}
		
		public System.Data.Linq.Table<Funcion> Funcion
		{
			get
			{
				return this.GetTable<Funcion>();
			}
		}
		
		public System.Data.Linq.Table<Sesion> Sesion
		{
			get
			{
				return this.GetTable<Sesion>();
			}
		}
		
		public System.Data.Linq.Table<Vehiculo> Vehiculo
		{
			get
			{
				return this.GetTable<Vehiculo>();
			}
		}
		
		public System.Data.Linq.Table<Usuario> Usuario
		{
			get
			{
				return this.GetTable<Usuario>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Arma")]
	public partial class Arma : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id_Arma;
		
		private string _Caracteristicas;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId_ArmaChanging(int value);
    partial void OnId_ArmaChanged();
    partial void OnCaracteristicasChanging(string value);
    partial void OnCaracteristicasChanged();
    #endregion
		
		public Arma()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Arma", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id_Arma
		{
			get
			{
				return this._Id_Arma;
			}
			set
			{
				if ((this._Id_Arma != value))
				{
					this.OnId_ArmaChanging(value);
					this.SendPropertyChanging();
					this._Id_Arma = value;
					this.SendPropertyChanged("Id_Arma");
					this.OnId_ArmaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Caracteristicas", DbType="VarChar(MAX)")]
		public string Caracteristicas
		{
			get
			{
				return this._Caracteristicas;
			}
			set
			{
				if ((this._Caracteristicas != value))
				{
					this.OnCaracteristicasChanging(value);
					this.SendPropertyChanging();
					this._Caracteristicas = value;
					this.SendPropertyChanged("Caracteristicas");
					this.OnCaracteristicasChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Conductor")]
	public partial class Conductor
	{
		
		private System.Nullable<int> _Id_Funcion;
		
		private System.Nullable<int> _Id_Vehiculo;
		
		private string _Observaciones;
		
		public Conductor()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Funcion", DbType="Int")]
		public System.Nullable<int> Id_Funcion
		{
			get
			{
				return this._Id_Funcion;
			}
			set
			{
				if ((this._Id_Funcion != value))
				{
					this._Id_Funcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Vehiculo", DbType="Int")]
		public System.Nullable<int> Id_Vehiculo
		{
			get
			{
				return this._Id_Vehiculo;
			}
			set
			{
				if ((this._Id_Vehiculo != value))
				{
					this._Id_Vehiculo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Observaciones", DbType="VarChar(MAX)")]
		public string Observaciones
		{
			get
			{
				return this._Observaciones;
			}
			set
			{
				if ((this._Observaciones != value))
				{
					this._Observaciones = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Configuracion")]
	public partial class Configuracion
	{
		
		private System.Nullable<int> _Id_Configuracion;
		
		private string _Dispositivo;
		
		private string _Fecha;
		
		private string _Caracteristicas;
		
		public Configuracion()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Configuracion", DbType="Int")]
		public System.Nullable<int> Id_Configuracion
		{
			get
			{
				return this._Id_Configuracion;
			}
			set
			{
				if ((this._Id_Configuracion != value))
				{
					this._Id_Configuracion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Dispositivo", DbType="VarChar(30)")]
		public string Dispositivo
		{
			get
			{
				return this._Dispositivo;
			}
			set
			{
				if ((this._Dispositivo != value))
				{
					this._Dispositivo = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="VarChar(30)")]
		public string Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this._Fecha = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Caracteristicas", DbType="VarChar(MAX)")]
		public string Caracteristicas
		{
			get
			{
				return this._Caracteristicas;
			}
			set
			{
				if ((this._Caracteristicas != value))
				{
					this._Caracteristicas = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Disparo")]
	public partial class Disparo
	{
		
		private System.Nullable<int> _Id_Funcion;
		
		private System.Nullable<int> _Id_Arma;
		
		private string _Puntuacion;
		
		private string _Anomalias;
		
		public Disparo()
		{
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Funcion", DbType="Int")]
		public System.Nullable<int> Id_Funcion
		{
			get
			{
				return this._Id_Funcion;
			}
			set
			{
				if ((this._Id_Funcion != value))
				{
					this._Id_Funcion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Arma", DbType="Int")]
		public System.Nullable<int> Id_Arma
		{
			get
			{
				return this._Id_Arma;
			}
			set
			{
				if ((this._Id_Arma != value))
				{
					this._Id_Arma = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Puntuacion", DbType="VarChar(30)")]
		public string Puntuacion
		{
			get
			{
				return this._Puntuacion;
			}
			set
			{
				if ((this._Puntuacion != value))
				{
					this._Puntuacion = value;
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Anomalias", DbType="VarChar(MAX)")]
		public string Anomalias
		{
			get
			{
				return this._Anomalias;
			}
			set
			{
				if ((this._Anomalias != value))
				{
					this._Anomalias = value;
				}
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Encargado")]
	public partial class Encargado : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id_Encargado;
		
		private string _Tipo_Encargado;
		
		private string _Pass;
		
		private System.Nullable<int> _Id_Usuario;
		
		private EntitySet<Sesion> _Sesion;
		
		private EntityRef<Usuario> _Usuario;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId_EncargadoChanging(int value);
    partial void OnId_EncargadoChanged();
    partial void OnTipo_EncargadoChanging(string value);
    partial void OnTipo_EncargadoChanged();
    partial void OnPassChanging(string value);
    partial void OnPassChanged();
    partial void OnId_UsuarioChanging(System.Nullable<int> value);
    partial void OnId_UsuarioChanged();
    #endregion
		
		public Encargado()
		{
			this._Sesion = new EntitySet<Sesion>(new Action<Sesion>(this.attach_Sesion), new Action<Sesion>(this.detach_Sesion));
			this._Usuario = default(EntityRef<Usuario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Encargado", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id_Encargado
		{
			get
			{
				return this._Id_Encargado;
			}
			set
			{
				if ((this._Id_Encargado != value))
				{
					this.OnId_EncargadoChanging(value);
					this.SendPropertyChanging();
					this._Id_Encargado = value;
					this.SendPropertyChanged("Id_Encargado");
					this.OnId_EncargadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tipo_Encargado", DbType="VarChar(20)")]
		public string Tipo_Encargado
		{
			get
			{
				return this._Tipo_Encargado;
			}
			set
			{
				if ((this._Tipo_Encargado != value))
				{
					this.OnTipo_EncargadoChanging(value);
					this.SendPropertyChanging();
					this._Tipo_Encargado = value;
					this.SendPropertyChanged("Tipo_Encargado");
					this.OnTipo_EncargadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pass", DbType="VarChar(30)")]
		public string Pass
		{
			get
			{
				return this._Pass;
			}
			set
			{
				if ((this._Pass != value))
				{
					this.OnPassChanging(value);
					this.SendPropertyChanging();
					this._Pass = value;
					this.SendPropertyChanged("Pass");
					this.OnPassChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Usuario", DbType="Int")]
		public System.Nullable<int> Id_Usuario
		{
			get
			{
				return this._Id_Usuario;
			}
			set
			{
				if ((this._Id_Usuario != value))
				{
					if (this._Usuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnId_UsuarioChanging(value);
					this.SendPropertyChanging();
					this._Id_Usuario = value;
					this.SendPropertyChanged("Id_Usuario");
					this.OnId_UsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Encargado_Sesion", Storage="_Sesion", ThisKey="Id_Encargado", OtherKey="Id_Encargado")]
		public EntitySet<Sesion> Sesion
		{
			get
			{
				return this._Sesion;
			}
			set
			{
				this._Sesion.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Encargado", Storage="_Usuario", ThisKey="Id_Usuario", OtherKey="Id_Usuario", IsForeignKey=true, DeleteRule="CASCADE")]
		public Usuario Usuario
		{
			get
			{
				return this._Usuario.Entity;
			}
			set
			{
				Usuario previousValue = this._Usuario.Entity;
				if (((previousValue != value) 
							|| (this._Usuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Usuario.Entity = null;
						previousValue.Encargado.Remove(this);
					}
					this._Usuario.Entity = value;
					if ((value != null))
					{
						value.Encargado.Add(this);
						this._Id_Usuario = value.Id_Usuario;
					}
					else
					{
						this._Id_Usuario = default(Nullable<int>);
					}
					this.SendPropertyChanged("Usuario");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Sesion(Sesion entity)
		{
			this.SendPropertyChanging();
			entity.Encargado = this;
		}
		
		private void detach_Sesion(Sesion entity)
		{
			this.SendPropertyChanging();
			entity.Encargado = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Funcion")]
	public partial class Funcion : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id_Funcion;
		
		private System.Nullable<int> _Id_Usuario;
		
		private System.Nullable<int> _Id_Sesion;
		
		private string _Funcion1;
		
		private EntityRef<Sesion> _Sesion;
		
		private EntityRef<Usuario> _Usuario;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId_FuncionChanging(int value);
    partial void OnId_FuncionChanged();
    partial void OnId_UsuarioChanging(System.Nullable<int> value);
    partial void OnId_UsuarioChanged();
    partial void OnId_SesionChanging(System.Nullable<int> value);
    partial void OnId_SesionChanged();
    partial void OnFuncion1Changing(string value);
    partial void OnFuncion1Changed();
    #endregion
		
		public Funcion()
		{
			this._Sesion = default(EntityRef<Sesion>);
			this._Usuario = default(EntityRef<Usuario>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Funcion", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id_Funcion
		{
			get
			{
				return this._Id_Funcion;
			}
			set
			{
				if ((this._Id_Funcion != value))
				{
					this.OnId_FuncionChanging(value);
					this.SendPropertyChanging();
					this._Id_Funcion = value;
					this.SendPropertyChanged("Id_Funcion");
					this.OnId_FuncionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Usuario", DbType="Int")]
		public System.Nullable<int> Id_Usuario
		{
			get
			{
				return this._Id_Usuario;
			}
			set
			{
				if ((this._Id_Usuario != value))
				{
					if (this._Usuario.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnId_UsuarioChanging(value);
					this.SendPropertyChanging();
					this._Id_Usuario = value;
					this.SendPropertyChanged("Id_Usuario");
					this.OnId_UsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Sesion", DbType="Int")]
		public System.Nullable<int> Id_Sesion
		{
			get
			{
				return this._Id_Sesion;
			}
			set
			{
				if ((this._Id_Sesion != value))
				{
					if (this._Sesion.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnId_SesionChanging(value);
					this.SendPropertyChanging();
					this._Id_Sesion = value;
					this.SendPropertyChanged("Id_Sesion");
					this.OnId_SesionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="Funcion", Storage="_Funcion1", DbType="VarChar(30)")]
		public string Funcion1
		{
			get
			{
				return this._Funcion1;
			}
			set
			{
				if ((this._Funcion1 != value))
				{
					this.OnFuncion1Changing(value);
					this.SendPropertyChanging();
					this._Funcion1 = value;
					this.SendPropertyChanged("Funcion1");
					this.OnFuncion1Changed();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Sesion_Funcion", Storage="_Sesion", ThisKey="Id_Sesion", OtherKey="Id_Sesion", IsForeignKey=true)]
		public Sesion Sesion
		{
			get
			{
				return this._Sesion.Entity;
			}
			set
			{
				Sesion previousValue = this._Sesion.Entity;
				if (((previousValue != value) 
							|| (this._Sesion.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Sesion.Entity = null;
						previousValue.Funcion.Remove(this);
					}
					this._Sesion.Entity = value;
					if ((value != null))
					{
						value.Funcion.Add(this);
						this._Id_Sesion = value.Id_Sesion;
					}
					else
					{
						this._Id_Sesion = default(Nullable<int>);
					}
					this.SendPropertyChanged("Sesion");
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Funcion", Storage="_Usuario", ThisKey="Id_Usuario", OtherKey="Id_Usuario", IsForeignKey=true)]
		public Usuario Usuario
		{
			get
			{
				return this._Usuario.Entity;
			}
			set
			{
				Usuario previousValue = this._Usuario.Entity;
				if (((previousValue != value) 
							|| (this._Usuario.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Usuario.Entity = null;
						previousValue.Funcion.Remove(this);
					}
					this._Usuario.Entity = value;
					if ((value != null))
					{
						value.Funcion.Add(this);
						this._Id_Usuario = value.Id_Usuario;
					}
					else
					{
						this._Id_Usuario = default(Nullable<int>);
					}
					this.SendPropertyChanged("Usuario");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Sesion")]
	public partial class Sesion : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id_Sesion;
		
		private string _Tipo_Sesion;
		
		private string _Entorno;
		
		private string _Fecha;
		
		private System.Nullable<int> _Id_Encargado;
		
		private EntitySet<Funcion> _Funcion;
		
		private EntityRef<Encargado> _Encargado;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId_SesionChanging(int value);
    partial void OnId_SesionChanged();
    partial void OnTipo_SesionChanging(string value);
    partial void OnTipo_SesionChanged();
    partial void OnEntornoChanging(string value);
    partial void OnEntornoChanged();
    partial void OnFechaChanging(string value);
    partial void OnFechaChanged();
    partial void OnId_EncargadoChanging(System.Nullable<int> value);
    partial void OnId_EncargadoChanged();
    #endregion
		
		public Sesion()
		{
			this._Funcion = new EntitySet<Funcion>(new Action<Funcion>(this.attach_Funcion), new Action<Funcion>(this.detach_Funcion));
			this._Encargado = default(EntityRef<Encargado>);
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Sesion", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id_Sesion
		{
			get
			{
				return this._Id_Sesion;
			}
			set
			{
				if ((this._Id_Sesion != value))
				{
					this.OnId_SesionChanging(value);
					this.SendPropertyChanging();
					this._Id_Sesion = value;
					this.SendPropertyChanged("Id_Sesion");
					this.OnId_SesionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Tipo_Sesion", DbType="VarChar(30)")]
		public string Tipo_Sesion
		{
			get
			{
				return this._Tipo_Sesion;
			}
			set
			{
				if ((this._Tipo_Sesion != value))
				{
					this.OnTipo_SesionChanging(value);
					this.SendPropertyChanging();
					this._Tipo_Sesion = value;
					this.SendPropertyChanged("Tipo_Sesion");
					this.OnTipo_SesionChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Entorno", DbType="VarChar(MAX)")]
		public string Entorno
		{
			get
			{
				return this._Entorno;
			}
			set
			{
				if ((this._Entorno != value))
				{
					this.OnEntornoChanging(value);
					this.SendPropertyChanging();
					this._Entorno = value;
					this.SendPropertyChanged("Entorno");
					this.OnEntornoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Fecha", DbType="VarChar(MAX)")]
		public string Fecha
		{
			get
			{
				return this._Fecha;
			}
			set
			{
				if ((this._Fecha != value))
				{
					this.OnFechaChanging(value);
					this.SendPropertyChanging();
					this._Fecha = value;
					this.SendPropertyChanged("Fecha");
					this.OnFechaChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Encargado", DbType="Int")]
		public System.Nullable<int> Id_Encargado
		{
			get
			{
				return this._Id_Encargado;
			}
			set
			{
				if ((this._Id_Encargado != value))
				{
					if (this._Encargado.HasLoadedOrAssignedValue)
					{
						throw new System.Data.Linq.ForeignKeyReferenceAlreadyHasValueException();
					}
					this.OnId_EncargadoChanging(value);
					this.SendPropertyChanging();
					this._Id_Encargado = value;
					this.SendPropertyChanged("Id_Encargado");
					this.OnId_EncargadoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Sesion_Funcion", Storage="_Funcion", ThisKey="Id_Sesion", OtherKey="Id_Sesion")]
		public EntitySet<Funcion> Funcion
		{
			get
			{
				return this._Funcion;
			}
			set
			{
				this._Funcion.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Encargado_Sesion", Storage="_Encargado", ThisKey="Id_Encargado", OtherKey="Id_Encargado", IsForeignKey=true, DeleteRule="CASCADE")]
		public Encargado Encargado
		{
			get
			{
				return this._Encargado.Entity;
			}
			set
			{
				Encargado previousValue = this._Encargado.Entity;
				if (((previousValue != value) 
							|| (this._Encargado.HasLoadedOrAssignedValue == false)))
				{
					this.SendPropertyChanging();
					if ((previousValue != null))
					{
						this._Encargado.Entity = null;
						previousValue.Sesion.Remove(this);
					}
					this._Encargado.Entity = value;
					if ((value != null))
					{
						value.Sesion.Add(this);
						this._Id_Encargado = value.Id_Encargado;
					}
					else
					{
						this._Id_Encargado = default(Nullable<int>);
					}
					this.SendPropertyChanged("Encargado");
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Funcion(Funcion entity)
		{
			this.SendPropertyChanging();
			entity.Sesion = this;
		}
		
		private void detach_Funcion(Funcion entity)
		{
			this.SendPropertyChanging();
			entity.Sesion = null;
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Vehiculo")]
	public partial class Vehiculo : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id_Vehiculo;
		
		private string _Caracteristicas;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId_VehiculoChanging(int value);
    partial void OnId_VehiculoChanged();
    partial void OnCaracteristicasChanging(string value);
    partial void OnCaracteristicasChanged();
    #endregion
		
		public Vehiculo()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Vehiculo", DbType="Int NOT NULL", IsPrimaryKey=true)]
		public int Id_Vehiculo
		{
			get
			{
				return this._Id_Vehiculo;
			}
			set
			{
				if ((this._Id_Vehiculo != value))
				{
					this.OnId_VehiculoChanging(value);
					this.SendPropertyChanging();
					this._Id_Vehiculo = value;
					this.SendPropertyChanged("Id_Vehiculo");
					this.OnId_VehiculoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Caracteristicas", DbType="VarChar(MAX)")]
		public string Caracteristicas
		{
			get
			{
				return this._Caracteristicas;
			}
			set
			{
				if ((this._Caracteristicas != value))
				{
					this.OnCaracteristicasChanging(value);
					this.SendPropertyChanging();
					this._Caracteristicas = value;
					this.SendPropertyChanged("Caracteristicas");
					this.OnCaracteristicasChanged();
				}
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.Usuario")]
	public partial class Usuario : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private int _Id_Usuario;
		
		private string _Clave;
		
		private string _Rango;
		
		private string _Nombre;
		
		private string _Url;
		
		private EntitySet<Encargado> _Encargado;
		
		private EntitySet<Funcion> _Funcion;
		
    #region Definiciones de métodos de extensibilidad
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnId_UsuarioChanging(int value);
    partial void OnId_UsuarioChanged();
    partial void OnClaveChanging(string value);
    partial void OnClaveChanged();
    partial void OnRangoChanging(string value);
    partial void OnRangoChanged();
    partial void OnNombreChanging(string value);
    partial void OnNombreChanged();
    partial void OnUrlChanging(string value);
    partial void OnUrlChanged();
    #endregion
		
		public Usuario()
		{
			this._Encargado = new EntitySet<Encargado>(new Action<Encargado>(this.attach_Encargado), new Action<Encargado>(this.detach_Encargado));
			this._Funcion = new EntitySet<Funcion>(new Action<Funcion>(this.attach_Funcion), new Action<Funcion>(this.detach_Funcion));
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Id_Usuario", AutoSync=AutoSync.OnInsert, DbType="Int NOT NULL IDENTITY", IsPrimaryKey=true, IsDbGenerated=true)]
		public int Id_Usuario
		{
			get
			{
				return this._Id_Usuario;
			}
			set
			{
				if ((this._Id_Usuario != value))
				{
					this.OnId_UsuarioChanging(value);
					this.SendPropertyChanging();
					this._Id_Usuario = value;
					this.SendPropertyChanged("Id_Usuario");
					this.OnId_UsuarioChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Clave", DbType="VarChar(30)")]
		public string Clave
		{
			get
			{
				return this._Clave;
			}
			set
			{
				if ((this._Clave != value))
				{
					this.OnClaveChanging(value);
					this.SendPropertyChanging();
					this._Clave = value;
					this.SendPropertyChanged("Clave");
					this.OnClaveChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Rango", DbType="VarChar(30)")]
		public string Rango
		{
			get
			{
				return this._Rango;
			}
			set
			{
				if ((this._Rango != value))
				{
					this.OnRangoChanging(value);
					this.SendPropertyChanging();
					this._Rango = value;
					this.SendPropertyChanged("Rango");
					this.OnRangoChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Nombre", DbType="VarChar(MAX)")]
		public string Nombre
		{
			get
			{
				return this._Nombre;
			}
			set
			{
				if ((this._Nombre != value))
				{
					this.OnNombreChanging(value);
					this.SendPropertyChanging();
					this._Nombre = value;
					this.SendPropertyChanged("Nombre");
					this.OnNombreChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Url", DbType="VarChar(30)")]
		public string Url
		{
			get
			{
				return this._Url;
			}
			set
			{
				if ((this._Url != value))
				{
					this.OnUrlChanging(value);
					this.SendPropertyChanging();
					this._Url = value;
					this.SendPropertyChanged("Url");
					this.OnUrlChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Encargado", Storage="_Encargado", ThisKey="Id_Usuario", OtherKey="Id_Usuario")]
		public EntitySet<Encargado> Encargado
		{
			get
			{
				return this._Encargado;
			}
			set
			{
				this._Encargado.Assign(value);
			}
		}
		
		[global::System.Data.Linq.Mapping.AssociationAttribute(Name="Usuario_Funcion", Storage="_Funcion", ThisKey="Id_Usuario", OtherKey="Id_Usuario")]
		public EntitySet<Funcion> Funcion
		{
			get
			{
				return this._Funcion;
			}
			set
			{
				this._Funcion.Assign(value);
			}
		}
		
		public event PropertyChangingEventHandler PropertyChanging;
		
		public event PropertyChangedEventHandler PropertyChanged;
		
		protected virtual void SendPropertyChanging()
		{
			if ((this.PropertyChanging != null))
			{
				this.PropertyChanging(this, emptyChangingEventArgs);
			}
		}
		
		protected virtual void SendPropertyChanged(String propertyName)
		{
			if ((this.PropertyChanged != null))
			{
				this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
			}
		}
		
		private void attach_Encargado(Encargado entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = this;
		}
		
		private void detach_Encargado(Encargado entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = null;
		}
		
		private void attach_Funcion(Funcion entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = this;
		}
		
		private void detach_Funcion(Funcion entity)
		{
			this.SendPropertyChanging();
			entity.Usuario = null;
		}
	}
}
#pragma warning restore 1591
