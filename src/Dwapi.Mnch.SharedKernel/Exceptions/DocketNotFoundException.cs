﻿using System;

namespace Dwapi.Mnch.SharedKernel.Exceptions
{
    public class DocketNotFoundException : Exception
    {
        public DocketNotFoundException(string docketId) : base($"Docket {docketId} does not exist")
        {

        }
    }
}