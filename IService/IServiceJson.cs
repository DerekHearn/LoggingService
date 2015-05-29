using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace LoggingService.IService
{
	[ServiceContract]
	public interface IServiceJson : ILoggingService
	{

	}
}