using System;
using System.Linq;
using System.Threading.Tasks;
using Dwapi.Mnch.Core.Command;
using Dwapi.Mnch.Core.Domain.Dto;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.Core.Interfaces.Service;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using Serilog;

namespace Dwapi.Mnch.Controllers
{
    [Route("api/[controller]")]
    public class MnchController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IManifestService _manifestService;
        private readonly IMnchService _mnchService;

        public MnchController(IMediator mediator, IManifestRepository manifestRepository,
            IManifestService manifestService, IMnchService mnchService)
        {
            _mediator = mediator;
            _manifestService = manifestService;
            _mnchService = mnchService;
        }

        // POST api/Mnch/verify
        [HttpPost("Verify")]
        public async Task<IActionResult> Verify([FromBody] SubscriberDto subscriber)
        {
            if (null == subscriber)
                return BadRequest();

            try
            {
                var dockect = await _mediator.Send(new VerifySubscriber(subscriber.SubscriberId,subscriber.AuthToken), HttpContext.RequestAborted);
                return Ok(dockect);
            }
            catch (Exception e)
            {
                Log.Error(e, "verify error");
                return StatusCode(500, e.Message);
            }
        }

        // POST api/Mnch/Manifest
        [HttpPost("Manifest")]
        public async Task<IActionResult> ProcessManifest([FromBody] ManifestExtractDto manifestDto)
        {
            if (null == manifestDto)
                return BadRequest();
            
            // check if version allowed to send
            var version = manifestDto.Manifest.Cargoes.Select(x =>  x).Where(m => m.Items.Contains("MnchService")).FirstOrDefault().Items;
            var DwapiVersionSending = Int32.Parse((JObject.Parse(version)["Version"].ToString()).Replace(".", string.Empty));
            
            var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
            var DwapiVersionCuttoff = Int32.Parse(config["DwapiVersionCuttoff"]);
            
            var currentLatestVersion = config["currentLatestVersion"];
            
            if (DwapiVersionSending < DwapiVersionCuttoff)
            {
                return StatusCode(500, $" ====> You're using DWAPI Version [{DwapiVersionSending}]. Older Versions of DWAPI are " +
                                       $"not allowed to send to NDWH. UPGRADE to the latest version {currentLatestVersion} and RELOAD and SEND");
            }

            try
            {
                var manifest = new SaveManifest(manifestDto.Manifest);
                manifest.AllowSnapshot = Startup.AllowSnapshot;
                var faciliyKey = await _mediator.Send(manifest, HttpContext.RequestAborted);
                BackgroundJob.Enqueue(() => _manifestService.Process(manifest.Manifest.SiteCode));
                return Ok(new
                {
                    FacilityKey = faciliyKey
                });
            }
            catch (Exception e)
            {
                Log.Error(e, "manifest error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("PatientMnch")]
        public IActionResult ProcessPatientMnch([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.PatientMnchExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PatientMnch error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("MnchEnrolment")]
        public IActionResult ProcessMnchEnrolment([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.MnchEnrolmentExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "MnchEnrolment error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("MnchArt")]
        public IActionResult ProcessMnchArt([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.MnchArtExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "MnchArt error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("AncVisit")]
        public IActionResult ProcessAncVisit([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.AncVisitExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "AncVisit error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("MatVisit")]
        public IActionResult ProcessMatVisit([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.MatVisitExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "MatVisit error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("PncVisit")]
        public IActionResult ProcessPncVisit([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.PncVisitExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PncVisit error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("MotherBabyPair")]
        public IActionResult ProcessMotherBabyPair([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.MotherBabyPairExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "MotherBabyPair error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("CwcEnrolment")]
        public IActionResult ProcessCwcEnrolment([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.CwcEnrolmentExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "CwcEnrolment error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("CwcVisit")]
        public IActionResult ProcessCwcVisit([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.CwcVisitExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "CwcVisit error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Hei")]
        public IActionResult ProcessHei([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.HeiExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "Hei error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("MnchLab")]
        public IActionResult ProcessMnchLab([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.MnchLabExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "MnchArt error");
                return StatusCode(500, e.Message);
            }
        }
        
        [HttpPost("MnchImmunization")]
        public IActionResult ProcessMnchImmunization([FromBody] MnchExtractsDto extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.MnchImmunizationExtracts));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "MnchImmunization error");
                return StatusCode(500, e.Message);
            }
        }



        // POST api/Mnch/Status
        [HttpGet("Status")]
        public IActionResult GetStatus()
        {
            try
            {
                var ver = GetType().Assembly.GetName().Version;
                return Ok(new
                {
                    name = "Dwapi Central - API (MNCH)",
                    status = "running",
                    version = "v1.0.0.1",
                    build = "05JUL221246"
                });
            }
            catch (Exception e)
            {
                Log.Error(e, "status error");
                return StatusCode(500, e.Message);
            }
        }
    }
}
