﻿using System;

namespace Dwapi.Mnch.SharedKernel.Exceptions
{
    public class FacilityNotFoundException:Exception
    {
        public FacilityNotFoundException(int siteCode):base($"Facility not found with MFL Code {siteCode}")
        {
            
        }

        public FacilityNotFoundException(Guid id) : base($"Facility not found with Id {id}")
        {

        }

    }
}