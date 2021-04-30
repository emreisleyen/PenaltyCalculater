using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PenaltyCalculator.Infrastructure.Service.Abstract;
using PenaltyCalculator.MVC.Models;

namespace PenaltyCalculator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICountryService _countryService;
        private readonly IPenaltyCalculatorService _penaltyCalculatorService;
        private readonly IMapper _mapper;

        public HomeController(ILogger<HomeController> logger, IPenaltyCalculatorService penaltyCalculatorService,
            ICountryService countryService, IMapper mapper)
        {
            _logger = logger;
            _penaltyCalculatorService = penaltyCalculatorService;
            _countryService = countryService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewBag.Countries = GetCountryModels().ToArray();
            return View();
        }


        [HttpPost]
        public IActionResult Index(BookDateCheckRequestModel requestModel)
        {
            ViewBag.Countries = GetCountryModels().ToArray();
            if (ModelState.IsValid)
            {
                var penaltyResult = _penaltyCalculatorService.Calculate(requestModel.CheckoutDate,
                    requestModel.ReturnDate,
                    requestModel.Country.CountryId);
                var country = _countryService.GetCountry(requestModel.Country.CountryId);
                var model = new PenaltyResultViewModel
                {
                    PenaltyAmount = penaltyResult.PenaltyAmount,
                    PenaltyDayCount = penaltyResult.PenaltyDayCount,
                    Currency = country.Currency.Name
                };
                ViewBag.Result = model;
                return View();
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        private IEnumerable<CountryViewModel> GetCountryModels()
        {
            var countries = _countryService.GetCountries();
            var countryModels = _mapper.Map<IEnumerable<CountryViewModel>>(countries);
            // countries.Select(x => new CountryViewModel
            // {
            //     Name = x.Name,
            //     CountryId = x.Id
            // })
            return countryModels;
        }
    }
}