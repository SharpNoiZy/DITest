﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MFT.Core.Data.Models.Enums
{
	public enum ServiceCommandType
	{
		RefreshServiceInfo,
		RefreshWatchInfos,
		StartWatchingForJobs,
		StopWatchingForJobs,
		SetMaxThreadCount		
	}
}