using System;
using System.Reflection;
using System.Threading.Tasks;
using Dwapi.Mnch.Core.Command;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.Core.Interfaces.Service;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Dwapi.Mnch.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MnchController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IManifestService _manifestService;
        private readonly IMnchService _htsService;

        public MnchController(IMediator mediator, IManifestRepository manifestRepository,
            IManifestService manifestService, IMnchService htsService)
        {
            _mediator = mediator;
            _manifestService = manifestService;
            _htsService = htsService;
        }

        // POST api/Mnch/verify
        [HttpPost("Verify")]
        public async Task<IActionResult> Verify([FromBody] VerifySubscriber subscriber)
        {
            if (null == subscriber)
                return BadRequest();

            try
            {
                var dockect = await _mediator.Send(subscriber, HttpContext.RequestAborted);
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
        public async Task<IActionResult> ProcessManifest([FromBody] SaveManifest manifest)
        {
            if (null == manifest)
                return BadRequest();

            try
            {
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
        public IActionResult ProcessPatientMnch([FromBody] SavePatientMnch client)
        {
            if (null == client) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _htsService.Process(client.ClientPatientMnch));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PatientMnch error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("MnchEnrolment")]
        public IActionResult ProcessMnchEnrolment([FromBody] SaveMnchEnrolment extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _htsService.Process(extract.ClientMnchEnrolment));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "MnchEnrolment error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("MnchArt")]
        public IActionResult ProcessMnchArt([FromBody] SaveMnchArt extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _htsService.Process(extract.ClientMnchArt));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "MnchArt error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("AncVisit")]
        public IActionResult ProcessAncVisit([FromBody] SaveAncVisit extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _htsService.Process(extract.ClientAncVisit));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "AncVisit error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("MatVisit")]
        public IActionResult ProcessMatVisit([FromBody] SaveMatVisit extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _htsService.Process(extract.ClientMatVisit));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "MatVisit error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("PncVisit")]
        public IActionResult ProcessPncVisit([FromBody] SavePncVisit extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _htsService.Process(extract.ClientPncVisit));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "PncVisit error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("MotherBabyPair")]
        public IActionResult ProcessMotherBabyPair([FromBody] SaveMotherBabyPair extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _htsService.Process(extract.ClientMotherBabyPair));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "MotherBabyPair error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("CwcEnrolment")]
        public IActionResult ProcessCwcEnrolment([FromBody] SaveCwcEnrolment extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _htsService.Process(extract.ClientCwcEnrolment));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "CwcEnrolment error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("CwcVisit")]
        public IActionResult ProcessCwcVisit([FromBody] SaveCwcVisit extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _htsService.Process(extract.ClientCwcVisit));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "CwcVisit error");
                return StatusCode(500, e.Message);
            }
        }

        [HttpPost("Hei")]
        public IActionResult ProcessHei([FromBody] SaveHei extract)
        {
            if (null == extract) return BadRequest();
            try
            {
                var id = BackgroundJob.Enqueue(() => _htsService.Process(extract.ClientHei));
                return Ok(new {BatchKey = id});
            }
            catch (Exception e)
            {
                Log.Error(e, "Hei error");
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
                    build = "13MAY21211"
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
