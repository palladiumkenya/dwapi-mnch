using System;
using System.IO;
using System.IO.Compression;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Dwapi.Mnch;
using Dwapi.Mnch.Core.Command;
using Dwapi.Mnch.Core.Domain.Dto;
using Dwapi.Mnch.Core.Interfaces.Repository;
using Dwapi.Mnch.Core.Interfaces.Service;
using Hangfire;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Serilog;
namespace Dwapi.Crs.Controllers
{
    [ApiController]
    [Route("file")]
    public class BoardRoomController : Controller
    {
        private readonly IMediator _mediator;
        private readonly IManifestService _manifestService;
        private readonly IMnchService _mnchService;
        public HttpClient Client { get; set; }
        private IWebHostEnvironment _appEnvironment;

        public BoardRoomController(IMediator mediator, IManifestRepository manifestRepository, IWebHostEnvironment appEnvironment,
        IManifestService manifestService,  IMnchService mnchService)
        {
            _mediator = mediator;
            _manifestService = manifestService;
            _mnchService = mnchService;
            _appEnvironment = appEnvironment;
        }
        [HttpPost]
        public async Task<IActionResult> UploadAsync([FromForm] IFormFile file)
        {
            string text;
            var client = Client ?? new HttpClient();
            int count = 0;
            int sendCound = 0;
            //var responses = new List<SendManifestResponse>();
            using (var stream = file.OpenReadStream())
            {
                var archive = new ZipArchive(stream);
                foreach (var item in archive.Entries)
                {
                    count++;
                    if (item.FullName.EndsWith(".json", StringComparison.OrdinalIgnoreCase))
                    {
                        using (StreamReader sr = new StreamReader(item.Open()))
                        {
                            try
                            {
                                text = await sr.ReadToEndAsync(); // OK                         

                                byte[] base64EncodedBytes = Convert.FromBase64String(text);
                                var Extract = Encoding.UTF8.GetString(base64EncodedBytes);

                                if (count == 1)
                                {
                                    try
                                    {
                                        ManifestExtractDto messageManifest = JsonConvert.DeserializeObject<ManifestExtractDto>(Extract);
                                        var manifest = new SaveManifest(messageManifest.Manifest);
                                        manifest.AllowSnapshot = Startup.AllowSnapshot;
                                        var faciliyKey = await _mediator.Send(manifest, HttpContext.RequestAborted);
                                        BackgroundJob.Enqueue(() => _manifestService.Process(manifest.Manifest.SiteCode));
                                        //return Ok(new
                                        //{
                                        //    FacilityKey = faciliyKey
                                        //});                                      
                                    }
                                    catch (Exception e)
                                    {
                                        Log.Error(e, "manifest error");
                                        return StatusCode(500, e.Message);
                                    }
                                }
                                else
                                {
                                    MnchExtractsDto extract = JsonConvert.DeserializeObject<MnchExtractsDto>(Extract);
                                    if (extract != null && extract.AncVisitExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.AncVisitExtracts));

                                            // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                    else if (extract != null && extract.CwcEnrolmentExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.CwcEnrolmentExtracts));

                                            // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                    else if (extract != null && extract.CwcVisitExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.CwcVisitExtracts));

                                            // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }

                                    else if (extract != null && extract.HeiExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.HeiExtracts));

                                            // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                    else if (extract != null && extract.MatVisitExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.MatVisitExtracts));

                                            //return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                    else if (extract != null && extract.MnchArtExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.MnchArtExtracts));

                                            //return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                    else if (extract != null && extract.MnchEnrolmentExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.MnchEnrolmentExtracts));

                                            // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                    else if (extract != null && extract.MnchLabExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.MnchLabExtracts));

                                            // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                    else if (extract != null && extract.MotherBabyPairExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.MotherBabyPairExtracts));

                                            // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                                    else if (extract != null && extract.PatientMnchExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.PatientMnchExtracts));

                                            //return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            // return StatusCode(500, ex.Message);

                                        }
                                    }
                         
                                    else if (extract != null && extract.PncVisitExtracts.Count > 0)
                                    {
                                        try
                                        {
                                            var id = BackgroundJob.Enqueue(() => _mnchService.Process(extract.PncVisitExtracts));

                                            // return Ok(new { BatchKey = id });

                                        }

                                        catch (Exception ex)
                                        {
                                            return StatusCode(500, ex.Message);

                                        }
                                    }
                              
                              
                               
                               
                                }
                            }
                            catch (Exception e)
                            {
                                Log.Error(e, $"Send Manifest Error");
                                throw;
                            }
                        }
                    }
                }

            }

            return Ok();
        }


    }
}
