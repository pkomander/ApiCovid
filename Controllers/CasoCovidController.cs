using ApiCovid.Data;
using ApiCovid.Dtos;
using ApiCovid.Model;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiCovid.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CasoCovidController : ControllerBase
    {
        private CovidContext _context;
        private IMapper _mapper;

        public CasoCovidController(CovidContext covidContext, IMapper mapper)
        {
            _context = covidContext;
            _mapper = mapper;
        }

        [HttpPost]
        public IActionResult AdicionaCasoCovid([FromBody] List<CreateCasoCovidDto> casoCovidDto)
        {
            List<CasoCovid> casoCovid = _mapper.Map<List<CasoCovid>>(casoCovidDto);
            foreach(var item in casoCovid)
            {
                _context.CasoCovids.Add(item);
                _context.SaveChanges();
            }
            return Ok();

            //CreateCasoCovidDto casoCovidDto
            //CasoCovid casoCovid = _mapper.Map<CasoCovid>(casoCovidDto);
            //_context.CasoCovids.Add(casoCovid);
            //_context.SaveChanges();
            //return CreatedAtAction(nameof(RecuperarCasoCovidPorId), new { Id = casoCovid.Id }, casoCovid);
        }

        [HttpGet]
        public IActionResult RecuperaCasoCovid()
        {
            List<CasoCovid> casoCovid = _context.CasoCovids.ToList();
            return Ok(casoCovid);
            //return Ok(_context.CasoCovids);
        }

        [HttpGet("{id}")]
        public IActionResult RecuperarCasoCovidPorId(int id)
        {
            CasoCovid casoCovid = _context.CasoCovids.FirstOrDefault(x => x.Id == id);
            if(casoCovid != null)
            {
                ReadCasoCovidDto readCasoCovidDto = _mapper.Map<ReadCasoCovidDto>(casoCovid);
                return Ok(readCasoCovidDto);
            }
            return NotFound();
        }

        [Route(@"daterange/{date}")]
        [HttpGet("{date}")]
        //http://localhost:5000/CasoCovid/daterange/2020-07-06
        public IActionResult RecuperarCasoCovidPorData(DateTime date)
        {
            List<CasoCovid> casoCovid = _context.CasoCovids.Where(x => x.Date == date)
                .OrderBy(x => x.Location).OrderBy(x => x.Variant).ToList();
            if (casoCovid != null)
            {
                List<ReadCasoCovidDto> readCasoCovidDto = _mapper.Map<List<ReadCasoCovidDto>>(casoCovid);
                return Ok(readCasoCovidDto);
            }
            return NotFound();
        }

        [Route(@"daterangeTotal/{date}")]
        [HttpGet("{date}")]
        //http://localhost:5000/CasoCovid/daterangeTotal/2020-07-06
        public IActionResult RecuperarCasoCovidPorDataTotal(DateTime date)
        {
            var casoCovid = _context.CasoCovids.Where(x => x.Date == date).ToList();
            List<TotalCasoCovidDto> TotalCasoCovidDto = new List<TotalCasoCovidDto>();
            var locationAnterior = "";
            var variantAnterior = "";
            foreach (var item in casoCovid)
            {
                if (locationAnterior != item.Location && variantAnterior != item.Variant)
                {
                    var busca = casoCovid.Where(x => x.Location == item.Location && x.Variant == item.Variant).ToList();
                    TotalCasoCovidDto total = new TotalCasoCovidDto();
                    foreach (var item2 in busca)
                    {
                        total.Date = item.Date;
                        total.Location = item2.Location;
                        total.Variant = item2.Variant;
                        total.TotalCasos = busca.Sum(x => x.Num_Sequesces_total);
                        TotalCasoCovidDto.Add(total);
                        break;
                    }
                    locationAnterior = item.Location;
                    variantAnterior = item.Variant;
                }
            }

            if(TotalCasoCovidDto != null)
            {
                return Ok(TotalCasoCovidDto.OrderBy(x => x.Location).OrderBy(x => x.Variant).ToList());
            }
            return NotFound();
        }

        [Route(@"dates/")]
        [HttpGet]
        //http://localhost:5000/CasoCovid/dates/
        public IActionResult RecuperaCasoCovidDatas()
        {
            List<string> data = new List<string>();
            var casoCovid = _context.CasoCovids.ToList();
            foreach(var item in casoCovid)
            {
                if(data.Contains(item.Date.ToString("d")) == false)
                {
                    data.Add(item.Date.ToString("d"));
                }
            }

            return Ok(data);
        }

        [HttpPut("{id}")]
        public IActionResult AtualizaCasoCovid(int id, [FromBody] UpdateCasoCovidDto casoDto)
        {
            CasoCovid casoCovid = _context.CasoCovids.FirstOrDefault(x => x.Id == id);
            if(casoCovid == null)
            {
                return NotFound();
            }

            _mapper.Map(casoDto, casoCovid);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult DeletaCasoCovid(int id)
        {
            CasoCovid casoCovid = _context.CasoCovids.FirstOrDefault(x => x.Id == id);
            if (casoCovid == null)
            {
                return NotFound();
            }
            _context.Remove(casoCovid);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
