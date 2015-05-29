using PostSharp.Aspects;
using ResultWrappers;
using System;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;

namespace LoggingService
{

	/// <summary>
	/// LoggedMethodAttribute class
	/// </summary>
	[Serializable]
	public sealed class LoggedMethodAttribute : OnMethodBoundaryAspect
	{
		#region Variables

		/* START Added for PS 3.0 */
		// This field is initialized and serialized at build time, then deserialized at runtime.
		private readonly string category;
		// These fields are initialized at runtime. They do not need to be serialized.
		[NonSerialized]
		private string enteringMessage;
		[NonSerialized]
		private string exitingMessage;
		/* END Added for PS 3.0 */
		private string methodName;
		private ParameterInfo[] parameters;
		private DateTime startTime;

		#endregion

		/* START Added for PS 3.0 */
		public LoggedMethodAttribute()
		{

		}
		// Constructor specifying the tracing category, invoked at build time.
		public LoggedMethodAttribute(string category)
		{
			this.category = category;
		}
		// Invoked only once at runtime from the static constructor of type declaring the target method.
		public override void RuntimeInitialize(MethodBase method)
		{
			string methodName = method.DeclaringType.FullName + method.Name;
			this.enteringMessage = "Entering " + methodName;
			this.exitingMessage = "Exiting " + methodName;
		}
		// Invoked at runtime before that target method is invoked.
		public override void OnEntry(MethodExecutionArgs args)
		{
			startTime = DateTime.UtcNow;
			//Trace.WriteLine(this.enteringMessage, this.category);
		}
		// Invoked at runtime after the target method is invoked (in a finally block).
		public override void OnExit(MethodExecutionArgs args)
		{
			//Trace.WriteLine(this.exitingMessage, this.category);
		}
		/* END Added for PS 3.0 */

		/// <summary>
		/// Method invoked at build time to initialize the instance fields of the current aspect. This method is invoked before any other build-time method.
		/// </summary>
		/// <param name="method">Method to which the current aspect is applied</param>
		/// <param name="aspectInfo">Reserved for future usage.</param>
		public override void CompileTimeInitialize(System.Reflection.MethodBase method, AspectInfo aspectInfo)
		{
			this.methodName = method.Name;
			this.parameters = method.GetParameters();
		}

		/// <summary>
		/// Method executed after the body of methods to which this aspect is applied, but only when the method successfully returns (i.updateEmail. when no exception flies out the method.).
		/// </summary>
		/// <param name="args">Event arguments specifying which method is being executed and which are its arguments.</param>
		public override void OnSuccess(MethodExecutionArgs args)
		{
			LogMethod(args, true);
		}

		/// <summary>
		/// Method executed after the body of methods to which this aspect is applied, in case that the method resulted with an exception (i.updateEmail., in a catch block).
		/// </summary>
		/// <param name="args">Advice arguments.</param>
		public override void OnException(MethodExecutionArgs args)
		{
			LogMethod(args, false);
		}

		/// <summary>
		/// Log the Methods execution results details.
		/// </summary>
		/// <param name="args">Advice arguments.</param>
		/// <param name="success">Result of the method operation.</param>
		private void LogMethod(MethodExecutionArgs args, bool success)
		{
			var endTime = DateTime.UtcNow;
			Guid errorGuid = Guid.Empty;
			Guid exceptionGuid = Guid.Empty;
			string sessionId = null;
			ServiceError error = null;

			string returnValues;

			extractReturnValue(args, out returnValues);

			// Save the MB error if returning one to the caller
			Object returnValue = args.ReturnValue;
			if (returnValue is IServiceResult)
			{
				error = ((IServiceResult)returnValue).error;
				if (error.hadException)
				{
					var m = new BL.MethodLogException(error.exception, DateTime.UtcNow);
					exceptionGuid = m.guid;
					m.save();
				}

				if (!error.success)
				{
					var mle = new BL.MethodErrorMessage(Guid.NewGuid(), "2",
						error.friendlyErrorMsg, error.developerErrorMsg, DateTime.UtcNow);
					errorGuid = mle.guid;
					mle.save();
				}
			}

			StringBuilder stringBuilder = new StringBuilder();
			var jsonSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
			int i;

			// Get the list of all arguments.
			for (i = 0; i < args.Arguments.Count; i++)
			{
				if (parameters[i].Name.Equals("sessionid", StringComparison.InvariantCultureIgnoreCase))
				{
					object sessionValue = args.Arguments.GetArgument(i);
					if (sessionValue != null)
					{
						sessionId = sessionValue.ToString();
					}
				}
				else
				{
					if (i > 0)
						stringBuilder.Append(", ");
					stringBuilder.Append(parameters[i].Name).Append("=");
					if (parameters[i].Name.ToLower().Contains("password"))
					{
						stringBuilder.Append("[redacted]");
					}
					else
					{
						object arg = args.Arguments.GetArgument(i);
						stringBuilder.Append(arg ?? "null");
						if (arg != null)
						{
							Type argType = args.Arguments.GetArgument(i).GetType();
							if (!argType.IsPrimitive && !argType.Equals(typeof(string)) && argType.IsSerializable)
							{
								stringBuilder.Append(":").Append(jsonSerializer.Serialize(args.Arguments.GetArgument(i)));
							}
						}
					}
				}
			}

			var ml = new BL.MethodLog(this.methodName, stringBuilder.ToString(), startTime,
				errorGuid.Equals(Guid.Empty), Guid.Empty, exceptionGuid, errorGuid,
				(endTime - startTime).TotalMilliseconds, false, "LogServ", returnValues);

			ml.save();
		}

		private static void LogException(Exception ex, DateTime callDate)
		{
			var mle = new BL.MethodLogException(ex, callDate);

			mle.save();
		}

		private void extractReturnValue(MethodExecutionArgs args, out string returnVal)
		{
			returnVal = "";

			var rv = args.ReturnValue;


			var jss = new JavaScriptSerializer();
			string jrv = "";
			string jmbr = "";
			try
			{
				jrv = jss.Serialize(args.ReturnValue);
			}
			catch (Exception e)
			{
				var x = 0;
			}

			if (!(rv is IServiceResult))
			{
				returnVal = rv.ToString();
				return;
			}

			var mbResult = ((IServiceResult)rv).error;

			if (rv is BasicServiceResult)
			{
				returnVal = "Success: " + mbResult.success.ToString();
				return;
			}

			try
			{
				jmbr = jss.Serialize(mbResult);
				jmbr = "\"MBResult\":" + jmbr;
				var contains = jrv.Contains(jmbr);
				if(contains)
					jrv = jrv.Replace(jmbr, "");
			}
			catch (Exception e)
			{
				var x = 0;
			}

			if (jrv.Length > 1000)
			{
				returnVal = jrv.Substring(0, 1000);
			}
			else
				returnVal = jrv;
		}
	}
}
