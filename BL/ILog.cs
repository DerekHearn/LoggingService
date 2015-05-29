using ResultWrappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoggingService.BL
{
	public interface ILog
	{
		BLError save(); 
	}
}