


#pragma warning disable 1591 
using System;
using SubSonic.Schema;
using System.Collections.Generic;
using SubSonic.DataProviders;
using System.Data;

namespace LoggingService.DAL {
	
        /// <summary>
        /// Table: TextLog
        /// Primary Key: TextLogID
        /// </summary>

        public class TextLogTable: DatabaseTable {
            
            public TextLogTable(IDataProvider provider):base("TextLog",provider){
                ClassName = "TextLog";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("TextLogID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("FromUserID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ToPhone", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 15
                });

                Columns.Add(new DatabaseColumn("TextMessage", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 140
                });

                Columns.Add(new DatabaseColumn("CreateDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn TextLogID{
                get{
                    return this.GetColumn("TextLogID");
                }
            }
				
   			public static string TextLogIDColumn{
			      get{
        			return "TextLogID";
      			}
		    }
            
            public IColumn FromUserID{
                get{
                    return this.GetColumn("FromUserID");
                }
            }
				
   			public static string FromUserIDColumn{
			      get{
        			return "FromUserID";
      			}
		    }
            
            public IColumn ToPhone{
                get{
                    return this.GetColumn("ToPhone");
                }
            }
				
   			public static string ToPhoneColumn{
			      get{
        			return "ToPhone";
      			}
		    }
            
            public IColumn TextMessage{
                get{
                    return this.GetColumn("TextMessage");
                }
            }
				
   			public static string TextMessageColumn{
			      get{
        			return "TextMessage";
      			}
		    }
            
            public IColumn CreateDate{
                get{
                    return this.GetColumn("CreateDate");
                }
            }
				
   			public static string CreateDateColumn{
			      get{
        			return "CreateDate";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: PushLog
        /// Primary Key: PushLogID
        /// </summary>

        public class PushLogTable: DatabaseTable {
            
            public PushLogTable(IDataProvider provider):base("PushLog",provider){
                ClassName = "PushLog";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("PushLogID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("FromUserID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ToUserID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("PushMessage", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 300
                });

                Columns.Add(new DatabaseColumn("CreateDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn PushLogID{
                get{
                    return this.GetColumn("PushLogID");
                }
            }
				
   			public static string PushLogIDColumn{
			      get{
        			return "PushLogID";
      			}
		    }
            
            public IColumn FromUserID{
                get{
                    return this.GetColumn("FromUserID");
                }
            }
				
   			public static string FromUserIDColumn{
			      get{
        			return "FromUserID";
      			}
		    }
            
            public IColumn ToUserID{
                get{
                    return this.GetColumn("ToUserID");
                }
            }
				
   			public static string ToUserIDColumn{
			      get{
        			return "ToUserID";
      			}
		    }
            
            public IColumn PushMessage{
                get{
                    return this.GetColumn("PushMessage");
                }
            }
				
   			public static string PushMessageColumn{
			      get{
        			return "PushMessage";
      			}
		    }
            
            public IColumn CreateDate{
                get{
                    return this.GetColumn("CreateDate");
                }
            }
				
   			public static string CreateDateColumn{
			      get{
        			return "CreateDate";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: EmailBody
        /// Primary Key: EmailBodyID
        /// </summary>

        public class EmailBodyTable: DatabaseTable {
            
            public EmailBodyTable(IDataProvider provider):base("EmailBody",provider){
                ClassName = "EmailBody";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("EmailBodyID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Version", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("StatusID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Subject", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 200
                });

                Columns.Add(new DatabaseColumn("Body", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("SimpleBody", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("CreateDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn EmailBodyID{
                get{
                    return this.GetColumn("EmailBodyID");
                }
            }
				
   			public static string EmailBodyIDColumn{
			      get{
        			return "EmailBodyID";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn Version{
                get{
                    return this.GetColumn("Version");
                }
            }
				
   			public static string VersionColumn{
			      get{
        			return "Version";
      			}
		    }
            
            public IColumn StatusID{
                get{
                    return this.GetColumn("StatusID");
                }
            }
				
   			public static string StatusIDColumn{
			      get{
        			return "StatusID";
      			}
		    }
            
            public IColumn Subject{
                get{
                    return this.GetColumn("Subject");
                }
            }
				
   			public static string SubjectColumn{
			      get{
        			return "Subject";
      			}
		    }
            
            public IColumn Body{
                get{
                    return this.GetColumn("Body");
                }
            }
				
   			public static string BodyColumn{
			      get{
        			return "Body";
      			}
		    }
            
            public IColumn SimpleBody{
                get{
                    return this.GetColumn("SimpleBody");
                }
            }
				
   			public static string SimpleBodyColumn{
			      get{
        			return "SimpleBody";
      			}
		    }
            
            public IColumn CreateDate{
                get{
                    return this.GetColumn("CreateDate");
                }
            }
				
   			public static string CreateDateColumn{
			      get{
        			return "CreateDate";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: TextBody
        /// Primary Key: TextBodyID
        /// </summary>

        public class TextBodyTable: DatabaseTable {
            
            public TextBodyTable(IDataProvider provider):base("TextBody",provider){
                ClassName = "TextBody";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("TextBodyID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Version", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("StatusID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Body", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 140
                });

                Columns.Add(new DatabaseColumn("CreateDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn TextBodyID{
                get{
                    return this.GetColumn("TextBodyID");
                }
            }
				
   			public static string TextBodyIDColumn{
			      get{
        			return "TextBodyID";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn Version{
                get{
                    return this.GetColumn("Version");
                }
            }
				
   			public static string VersionColumn{
			      get{
        			return "Version";
      			}
		    }
            
            public IColumn StatusID{
                get{
                    return this.GetColumn("StatusID");
                }
            }
				
   			public static string StatusIDColumn{
			      get{
        			return "StatusID";
      			}
		    }
            
            public IColumn Body{
                get{
                    return this.GetColumn("Body");
                }
            }
				
   			public static string BodyColumn{
			      get{
        			return "Body";
      			}
		    }
            
            public IColumn CreateDate{
                get{
                    return this.GetColumn("CreateDate");
                }
            }
				
   			public static string CreateDateColumn{
			      get{
        			return "CreateDate";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: PushBody
        /// Primary Key: PushBodyID
        /// </summary>

        public class PushBodyTable: DatabaseTable {
            
            public PushBodyTable(IDataProvider provider):base("PushBody",provider){
                ClassName = "PushBody";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("PushBodyID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("Version", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("StatusID", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Int32,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Body", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 140
                });

                Columns.Add(new DatabaseColumn("CreateDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn PushBodyID{
                get{
                    return this.GetColumn("PushBodyID");
                }
            }
				
   			public static string PushBodyIDColumn{
			      get{
        			return "PushBodyID";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn Version{
                get{
                    return this.GetColumn("Version");
                }
            }
				
   			public static string VersionColumn{
			      get{
        			return "Version";
      			}
		    }
            
            public IColumn StatusID{
                get{
                    return this.GetColumn("StatusID");
                }
            }
				
   			public static string StatusIDColumn{
			      get{
        			return "StatusID";
      			}
		    }
            
            public IColumn Body{
                get{
                    return this.GetColumn("Body");
                }
            }
				
   			public static string BodyColumn{
			      get{
        			return "Body";
      			}
		    }
            
            public IColumn CreateDate{
                get{
                    return this.GetColumn("CreateDate");
                }
            }
				
   			public static string CreateDateColumn{
			      get{
        			return "CreateDate";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: MethodLog
        /// Primary Key: MethodLogID
        /// </summary>

        public class MethodLogTable: DatabaseTable {
            
            public MethodLogTable(IDataProvider provider):base("MethodLog",provider){
                ClassName = "MethodLog";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("MethodLogID", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Name", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("Parameters", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("CallDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Successful", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("SessionGuid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ExceptionGuid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("MBExceptionGuid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("Duration", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Double,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("TestBool", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Boolean,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("API", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 10
                });

                Columns.Add(new DatabaseColumn("RetVal", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1000
                });
                    
                
                
            }

            public IColumn MethodLogID{
                get{
                    return this.GetColumn("MethodLogID");
                }
            }
				
   			public static string MethodLogIDColumn{
			      get{
        			return "MethodLogID";
      			}
		    }
            
            public IColumn Name{
                get{
                    return this.GetColumn("Name");
                }
            }
				
   			public static string NameColumn{
			      get{
        			return "Name";
      			}
		    }
            
            public IColumn Parameters{
                get{
                    return this.GetColumn("Parameters");
                }
            }
				
   			public static string ParametersColumn{
			      get{
        			return "Parameters";
      			}
		    }
            
            public IColumn CallDate{
                get{
                    return this.GetColumn("CallDate");
                }
            }
				
   			public static string CallDateColumn{
			      get{
        			return "CallDate";
      			}
		    }
            
            public IColumn Successful{
                get{
                    return this.GetColumn("Successful");
                }
            }
				
   			public static string SuccessfulColumn{
			      get{
        			return "Successful";
      			}
		    }
            
            public IColumn SessionGuid{
                get{
                    return this.GetColumn("SessionGuid");
                }
            }
				
   			public static string SessionGuidColumn{
			      get{
        			return "SessionGuid";
      			}
		    }
            
            public IColumn ExceptionGuid{
                get{
                    return this.GetColumn("ExceptionGuid");
                }
            }
				
   			public static string ExceptionGuidColumn{
			      get{
        			return "ExceptionGuid";
      			}
		    }
            
            public IColumn MBExceptionGuid{
                get{
                    return this.GetColumn("MBExceptionGuid");
                }
            }
				
   			public static string MBExceptionGuidColumn{
			      get{
        			return "MBExceptionGuid";
      			}
		    }
            
            public IColumn Duration{
                get{
                    return this.GetColumn("Duration");
                }
            }
				
   			public static string DurationColumn{
			      get{
        			return "Duration";
      			}
		    }
            
            public IColumn TestBool{
                get{
                    return this.GetColumn("TestBool");
                }
            }
				
   			public static string TestBoolColumn{
			      get{
        			return "TestBool";
      			}
		    }
            
            public IColumn API{
                get{
                    return this.GetColumn("API");
                }
            }
				
   			public static string APIColumn{
			      get{
        			return "API";
      			}
		    }
            
            public IColumn RetVal{
                get{
                    return this.GetColumn("RetVal");
                }
            }
				
   			public static string RetValColumn{
			      get{
        			return "RetVal";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: MethodLogException
        /// Primary Key: MethodLogExceptionId
        /// </summary>

        public class MethodLogExceptionTable: DatabaseTable {
            
            public MethodLogExceptionTable(IDataProvider provider):base("MethodLogException",provider){
                ClassName = "MethodLogException";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("MethodLogExceptionId", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ExceptionGuid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("ExceptionCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("ExceptionSource", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 100
                });

                Columns.Add(new DatabaseColumn("ExceptionMessage", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("ExceptionStackTrace", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = -1
                });

                Columns.Add(new DatabaseColumn("ExceptionTargetSite", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 500
                });

                Columns.Add(new DatabaseColumn("ExceptionDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn MethodLogExceptionId{
                get{
                    return this.GetColumn("MethodLogExceptionId");
                }
            }
				
   			public static string MethodLogExceptionIdColumn{
			      get{
        			return "MethodLogExceptionId";
      			}
		    }
            
            public IColumn ExceptionGuid{
                get{
                    return this.GetColumn("ExceptionGuid");
                }
            }
				
   			public static string ExceptionGuidColumn{
			      get{
        			return "ExceptionGuid";
      			}
		    }
            
            public IColumn ExceptionCode{
                get{
                    return this.GetColumn("ExceptionCode");
                }
            }
				
   			public static string ExceptionCodeColumn{
			      get{
        			return "ExceptionCode";
      			}
		    }
            
            public IColumn ExceptionSource{
                get{
                    return this.GetColumn("ExceptionSource");
                }
            }
				
   			public static string ExceptionSourceColumn{
			      get{
        			return "ExceptionSource";
      			}
		    }
            
            public IColumn ExceptionMessage{
                get{
                    return this.GetColumn("ExceptionMessage");
                }
            }
				
   			public static string ExceptionMessageColumn{
			      get{
        			return "ExceptionMessage";
      			}
		    }
            
            public IColumn ExceptionStackTrace{
                get{
                    return this.GetColumn("ExceptionStackTrace");
                }
            }
				
   			public static string ExceptionStackTraceColumn{
			      get{
        			return "ExceptionStackTrace";
      			}
		    }
            
            public IColumn ExceptionTargetSite{
                get{
                    return this.GetColumn("ExceptionTargetSite");
                }
            }
				
   			public static string ExceptionTargetSiteColumn{
			      get{
        			return "ExceptionTargetSite";
      			}
		    }
            
            public IColumn ExceptionDate{
                get{
                    return this.GetColumn("ExceptionDate");
                }
            }
				
   			public static string ExceptionDateColumn{
			      get{
        			return "ExceptionDate";
      			}
		    }
            
                    
        }
        
        /// <summary>
        /// Table: MethodLogError
        /// Primary Key: MethodLogErrorId
        /// </summary>

        public class MethodLogErrorTable: DatabaseTable {
            
            public MethodLogErrorTable(IDataProvider provider):base("MethodLogError",provider){
                ClassName = "MethodLogError";
                SchemaName = "dbo";
                

                Columns.Add(new DatabaseColumn("MethodLogErrorId", this)
                {
	                IsPrimaryKey = true,
	                DataType = DbType.Int32,
	                IsNullable = false,
	                AutoIncrement = true,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("MBExceptionGuid", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.Guid,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });

                Columns.Add(new DatabaseColumn("MBExceptionCode", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 50
                });

                Columns.Add(new DatabaseColumn("FriendlyMessage", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1000
                });

                Columns.Add(new DatabaseColumn("DeveloperMessage", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.AnsiString,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 1000
                });

                Columns.Add(new DatabaseColumn("ErrorDate", this)
                {
	                IsPrimaryKey = false,
	                DataType = DbType.DateTime,
	                IsNullable = true,
	                AutoIncrement = false,
	                IsForeignKey = false,
	                MaxLength = 0
                });
                    
                
                
            }

            public IColumn MethodLogErrorId{
                get{
                    return this.GetColumn("MethodLogErrorId");
                }
            }
				
   			public static string MethodLogErrorIdColumn{
			      get{
        			return "MethodLogErrorId";
      			}
		    }
            
            public IColumn MBExceptionGuid{
                get{
                    return this.GetColumn("MBExceptionGuid");
                }
            }
				
   			public static string MBExceptionGuidColumn{
			      get{
        			return "MBExceptionGuid";
      			}
		    }
            
            public IColumn MBExceptionCode{
                get{
                    return this.GetColumn("MBExceptionCode");
                }
            }
				
   			public static string MBExceptionCodeColumn{
			      get{
        			return "MBExceptionCode";
      			}
		    }
            
            public IColumn FriendlyMessage{
                get{
                    return this.GetColumn("FriendlyMessage");
                }
            }
				
   			public static string FriendlyMessageColumn{
			      get{
        			return "FriendlyMessage";
      			}
		    }
            
            public IColumn DeveloperMessage{
                get{
                    return this.GetColumn("DeveloperMessage");
                }
            }
				
   			public static string DeveloperMessageColumn{
			      get{
        			return "DeveloperMessage";
      			}
		    }
            
            public IColumn ErrorDate{
                get{
                    return this.GetColumn("ErrorDate");
                }
            }
				
   			public static string ErrorDateColumn{
			      get{
        			return "ErrorDate";
      			}
		    }
            
                    
        }
        
}
#pragma warning restore 1591 