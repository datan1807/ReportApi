#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api.Data;
using Api.Models;
using Api.Services.IService;
using Api.Dtos;
using Api.Global;

namespace Api.Controllers
{
    [Route("api/reports")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly IReportService _service;

        public ReportController(IReportService service)
        {
            _service = service;
        }

        // GET: api/Reports
        [HttpGet]
        public async Task<ResponseObject> GetReports()
        {
            var enties = await _service.GetAll();
            return new ResponseObject
            {
                status = "success",
                data = enties
            };
        }

        // GET: api/Reports/5
        [HttpGet("{id}")]
        public async Task<ResponseObject> GetReport(int id)
        {
            var report = await _service.GetById(id);

            if (report == null)
            {
                return new ResponseObject { status = "failed",
                message = "Report is not found"};
            }

            return new ResponseObject { status="success",
            data = report};
        }

        // PUT: api/Reports/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ResponseObject> PutReport(int id, ReportDto report)
        {
            if (id != report.Id)
            {
                return new ResponseObject
                {
                    status = "failed",
                    message = "report id is not found"
                };
            }



            try
            {
                await _service.Update(report);
                return new ResponseObject { status = "success" };
            }
            catch (DbUpdateConcurrencyException)
            {
                return new ResponseObject { status = "failed" };
            }

            return new ResponseObject { status = "failed" };
        }

        // POST: api/Reports
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ResponseObject> Insert(ReportDto report)
        {

            try
            {
                await _service.Insert(report);
                return new ResponseObject
                {
                    status = "success"
                };
            }
            catch (DbUpdateException)
            {
                return new ResponseObject
                {
                    status = "failed"
                };
            }

        }

        [HttpPut("delete/{reportId}")]
        public async Task<ResponseObject> DeleteReport(int reportId)
        {
            if(reportId > 0)
            {
                try
                {
                    await _service.DeleteReport(reportId);
                    return new ResponseObject {status = "success" };
                }
                catch (DbUpdateConcurrencyException)
                {
                    return new ResponseObject { status = "failed" };
                }
            }
            else
            {
                return new ResponseObject { status = "failed" };
            }
           

        }

        [HttpGet("get")]
        public async Task<ResponseObject> GetReport()
        {
            var entities = await _service.GetReport("Active");
            return new ResponseObject
            {
                data = entities,
                status = "success"
            };
        }
    }
}
