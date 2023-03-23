﻿#pragma warning disable 1591
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Source.Models
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
	
	
	[global::System.Data.Linq.Mapping.DatabaseAttribute(Name="KTPM")]
	public partial class dataDataContext : System.Data.Linq.DataContext
	{
		
		private static System.Data.Linq.Mapping.MappingSource mappingSource = new AttributeMappingSource();
		
    #region Extensibility Method Definitions
    partial void OnCreated();
    partial void InsertTK(TK instance);
    partial void UpdateTK(TK instance);
    partial void DeleteTK(TK instance);
    #endregion
		
		public dataDataContext() : 
				base(global::System.Configuration.ConfigurationManager.ConnectionStrings["KTPMConnectionString"].ConnectionString, mappingSource)
		{
			OnCreated();
		}
		
		public dataDataContext(string connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dataDataContext(System.Data.IDbConnection connection) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dataDataContext(string connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public dataDataContext(System.Data.IDbConnection connection, System.Data.Linq.Mapping.MappingSource mappingSource) : 
				base(connection, mappingSource)
		{
			OnCreated();
		}
		
		public System.Data.Linq.Table<TK> TKs
		{
			get
			{
				return this.GetTable<TK>();
			}
		}
	}
	
	[global::System.Data.Linq.Mapping.TableAttribute(Name="dbo.TK")]
	public partial class TK : INotifyPropertyChanging, INotifyPropertyChanged
	{
		
		private static PropertyChangingEventArgs emptyChangingEventArgs = new PropertyChangingEventArgs(String.Empty);
		
		private string _User;
		
		private string _Pass;
		
		private System.Nullable<int> _IsAllow;
		
		private string _PhoneNumber;
		
		private string _ConfirmText;
		
    #region Extensibility Method Definitions
    partial void OnLoaded();
    partial void OnValidate(System.Data.Linq.ChangeAction action);
    partial void OnCreated();
    partial void OnUserChanging(string value);
    partial void OnUserChanged();
    partial void OnPassChanging(string value);
    partial void OnPassChanged();
    partial void OnIsAllowChanging(System.Nullable<int> value);
    partial void OnIsAllowChanged();
    partial void OnPhoneNumberChanging(string value);
    partial void OnPhoneNumberChanged();
    partial void OnConfirmTextChanging(string value);
    partial void OnConfirmTextChanged();
    #endregion
		
		public TK()
		{
			OnCreated();
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Name="[User]", Storage="_User", DbType="VarChar(100) NOT NULL", CanBeNull=false, IsPrimaryKey=true)]
		public string User
		{
			get
			{
				return this._User;
			}
			set
			{
				if ((this._User != value))
				{
					this.OnUserChanging(value);
					this.SendPropertyChanging();
					this._User = value;
					this.SendPropertyChanged("User");
					this.OnUserChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_Pass", DbType="VarChar(100)")]
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
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_IsAllow", DbType="Int")]
		public System.Nullable<int> IsAllow
		{
			get
			{
				return this._IsAllow;
			}
			set
			{
				if ((this._IsAllow != value))
				{
					this.OnIsAllowChanging(value);
					this.SendPropertyChanging();
					this._IsAllow = value;
					this.SendPropertyChanged("IsAllow");
					this.OnIsAllowChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_PhoneNumber", DbType="VarChar(100)")]
		public string PhoneNumber
		{
			get
			{
				return this._PhoneNumber;
			}
			set
			{
				if ((this._PhoneNumber != value))
				{
					this.OnPhoneNumberChanging(value);
					this.SendPropertyChanging();
					this._PhoneNumber = value;
					this.SendPropertyChanged("PhoneNumber");
					this.OnPhoneNumberChanged();
				}
			}
		}
		
		[global::System.Data.Linq.Mapping.ColumnAttribute(Storage="_ConfirmText", DbType="VarChar(100)")]
		public string ConfirmText
		{
			get
			{
				return this._ConfirmText;
			}
			set
			{
				if ((this._ConfirmText != value))
				{
					this.OnConfirmTextChanging(value);
					this.SendPropertyChanging();
					this._ConfirmText = value;
					this.SendPropertyChanged("ConfirmText");
					this.OnConfirmTextChanged();
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
}
#pragma warning restore 1591
