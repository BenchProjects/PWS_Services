using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using HelloWorldService.Models;
using Microsoft.AspNetCore.Mvc;
using Services;

namespace HelloWorldService.Controllers
{
    [Route("api/[controller]")]
    public class LoansController : Controller
    {
        private ILoanService _loanService;

        public LoansController(ILoanService loanService)
        {
            _loanService = loanService;
        }

        // GET api/values
        [HttpGet]
        public IActionResult Get()
        {
            var loans = _loanService.GetLoans();
            var viewModel = loans.Select(x => new LoanViewModel(x));

            return Ok(viewModel);
        }

        // GET api/loans/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            var loan = _loanService.GetLoan(id);
            var viewModel = new LoanViewModel(loan);

            return Ok(viewModel);
        }

        // POST api/loans
        [HttpPost]
        public void Post([FromBody]LoanViewMode2 model)
        {
            using (var reader = new StreamReader(Request.Body))
            {
                var body = reader.ReadToEnd();

                // Do something
            }


            if (ModelState.IsValid)
            {

            }

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
    
}