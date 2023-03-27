using System;
using System.Collections.Generic;
using System.Linq;
using Dwapi.ExtractsManagement.Core.Model.Destination.Mnch;
using Dwapi.Mnch.Core.Domain;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.Core.Interfaces.Service;
using Dwapi.Mnch.SharedKernel.Exceptions;
using Dwapi.Mnch.SharedKernel.Model;
using Serilog;

namespace Dwapi.Mnch.Core.Service
{
    public class MnchService : IMnchService
    {
        private readonly IPatientMnchRepository _patientMnchRepository;
        private readonly IAncVisitRepository _ancVisitRepository;
        private readonly IFacilityRepository _facilityRepository;

        private readonly ILiveSyncService _syncService;

        private List<SiteProfile> _siteProfiles = new List<SiteProfile>();

        private readonly IMnchEnrolmentRepository _mnchEnrolmentRepository;
        private readonly IMnchArtRepository _mnchArtRepository;
        private readonly IMatVisitRepository _matVisitRepository;
        private readonly IPncVisitRepository _pncVisitRepository;
        private readonly IMotherBabyPairRepository _motherBabyPairRepository;
        private readonly ICwcEnrolmentRepository _cwcEnrolmentRepository;
        private readonly ICwcVisitRepository _cwcVisitRepository;
        private readonly IHeiRepository _heiRepository;
        private readonly IMnchLabRepository _mnchLabRepository;
        private readonly IMnchImmunizationRepository _mnchImmunizationRepository;


        public MnchService(IPatientMnchRepository patientMnchRepository, IAncVisitRepository ancVisitRepository, IFacilityRepository facilityRepository, ILiveSyncService syncService, IMnchEnrolmentRepository mnchEnrolmentRepository, IMnchArtRepository mnchArtRepository, IMatVisitRepository matVisitRepository, IPncVisitRepository pncVisitRepository, IMotherBabyPairRepository motherBabyPairRepository, ICwcEnrolmentRepository cwcEnrolmentRepository, ICwcVisitRepository cwcVisitRepository, IHeiRepository heiRepository, IMnchLabRepository mnchLabRepository,IMnchImmunizationRepository mnchImmunizationRepository)
        {
            _patientMnchRepository = patientMnchRepository;
            _ancVisitRepository = ancVisitRepository;
            _facilityRepository = facilityRepository;
            _syncService = syncService;
            _mnchEnrolmentRepository = mnchEnrolmentRepository;
            _mnchArtRepository = mnchArtRepository;
            _matVisitRepository = matVisitRepository;
            _pncVisitRepository = pncVisitRepository;
            _motherBabyPairRepository = motherBabyPairRepository;
            _cwcEnrolmentRepository = cwcEnrolmentRepository;
            _cwcVisitRepository = cwcVisitRepository;
            _heiRepository = heiRepository;
            _mnchLabRepository = mnchLabRepository;
            _mnchImmunizationRepository = mnchImmunizationRepository;
        }

        public void Process(IEnumerable<PatientMnch> patients)
        {
            List<Guid> facilityIds=new List<Guid>();

            if(null==patients)
                return;
            if(!patients.Any())
                return;

            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();

            var batch = new List<PatientMnch>();
            int count = 0;

            foreach (var patient in patients)
            {
                count++;
                try
                {
                    patient.FacilityId = GetFacilityId(patient.SiteCode);
                    patient.UpdateRefId();
                    batch.Add(patient);

                    facilityIds.Add(patient.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {patient.SiteCode}");
                }


                if (count == 1000)
                {
                    _patientMnchRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<PatientMnch>();
                }

            }

            if (batch.Any())
                _patientMnchRepository.CreateBulk(batch);

            SyncClients(facilityIds);

        }

        public void Process(IEnumerable<AncVisit> extracts)
        {
            List<Guid> facilityIds=new List<Guid>();
            if(null==extracts)
                return;
            if(!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<AncVisit>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _ancVisitRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<AncVisit>();
                }
            }
            if (batch.Any())
                _ancVisitRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }


        public void Process(IEnumerable<MnchEnrolment> extracts)
        {
            List<Guid> facilityIds=new List<Guid>();
            if(null==extracts)
                return;
            if(!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<MnchEnrolment>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _mnchEnrolmentRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<MnchEnrolment>();
                }
            }
            if (batch.Any())
                _mnchEnrolmentRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<MnchArt> extracts)
        {
            List<Guid> facilityIds=new List<Guid>();
            if(null==extracts)
                return;
            if(!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<MnchArt>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _mnchArtRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<MnchArt>();
                }
            }
            if (batch.Any())
                _mnchArtRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<MatVisit> extracts)
        {
            List<Guid> facilityIds=new List<Guid>();
            if(null==extracts)
                return;
            if(!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<MatVisit>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _matVisitRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<MatVisit>();
                }
            }
            if (batch.Any())
                _matVisitRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<PncVisit> extracts)
        {
            List<Guid> facilityIds=new List<Guid>();
            if(null==extracts)
                return;
            if(!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<PncVisit>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _pncVisitRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<PncVisit>();
                }
            }
            if (batch.Any())
                _pncVisitRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<MotherBabyPair> extracts)
        {
            List<Guid> facilityIds=new List<Guid>();
            if(null==extracts)
                return;
            if(!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<MotherBabyPair>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _motherBabyPairRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<MotherBabyPair>();
                }
            }
            if (batch.Any())
                _motherBabyPairRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<CwcEnrolment> extracts)
        {
            List<Guid> facilityIds=new List<Guid>();
            if(null==extracts)
                return;
            if(!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<CwcEnrolment>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _cwcEnrolmentRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<CwcEnrolment>();
                }
            }
            if (batch.Any())
                _cwcEnrolmentRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<CwcVisit> extracts)
        {
            List<Guid> facilityIds=new List<Guid>();
            if(null==extracts)
                return;
            if(!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<CwcVisit>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _cwcVisitRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<CwcVisit>();
                }
            }
            if (batch.Any())
                _cwcVisitRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<Hei> extracts)
        {
            List<Guid> facilityIds=new List<Guid>();
            if(null==extracts)
                return;
            if(!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<Hei>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Console.WriteLine("error for hei extract ===============> ");
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _heiRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<Hei>();
                }
            }
            if (batch.Any())
                _heiRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }

        public void Process(IEnumerable<MnchLab> extracts)
        {
            Console.WriteLine("mnch lab process===============> ");
            List<Guid> facilityIds=new List<Guid>();
            if(null==extracts)
                return;
            if(!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<MnchLab>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _mnchLabRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<MnchLab>();
                }
            }
            if (batch.Any())
                _mnchLabRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }


        public void Process(IEnumerable<MnchImmunization> extracts)
        {
            Console.WriteLine("mnch Immunizationprocess===============> ");
            List<Guid> facilityIds=new List<Guid>();
            if(null==extracts)
                return;
            if(!extracts.Any())
                return;
            _siteProfiles = _facilityRepository.GetSiteProfiles().ToList();
            var batch = new List<MnchImmunization>();
            int count = 0;
            foreach (var extract in extracts)
            {
                count++;
                try
                {
                    extract.FacilityId = GetFacilityId(extract.SiteCode);
                    extract.UpdateRefId();
                    batch.Add(extract);
                    facilityIds.Add(extract.FacilityId);
                }
                catch (Exception e)
                {
                    Log.Error(e, $"Facility Id missing {extract.SiteCode}");
                }


                if (count == 1000)
                {
                    _mnchImmunizationRepository.CreateBulk(batch);
                    count = 0;
                    batch = new List<MnchImmunization>();
                }
            }
            if (batch.Any())
                _mnchImmunizationRepository.CreateBulk(batch);
            SyncClients(facilityIds);
        }


        public Guid GetFacilityId(int siteCode)
        {
            var profile = _siteProfiles.FirstOrDefault(x => x.SiteCode == siteCode);
            if (null == profile)
                throw new FacilityNotFoundException(siteCode);

            return profile.FacilityId;
        }

        private void SyncClients(List<Guid> facIlds)
        {
            if (facIlds.Any())
            {
                _syncService.SyncStats(facIlds.Distinct().ToList());
            }
        }
    }
}
