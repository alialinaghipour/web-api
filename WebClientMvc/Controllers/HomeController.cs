using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebClientMvc.Models;

namespace WebClientMvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICustomerRepository _customerRepository;

        public HomeController(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public IActionResult Index()
        {
            return View(_customerRepository.GetAllCustomer());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            _customerRepository.AddCustomer(customer);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var customer = _customerRepository.GetCustomerById(id);
            return View(customer);
        }

        [HttpPost]
        public IActionResult Edit(Customer customer)
        {
            _customerRepository.UpdateCustomer(customer);
            return RedirectToAction("Index");
        }


        public IActionResult Delete(int id)
        {
            _customerRepository.DeleteCustomer(id);
            return RedirectToAction("Index");
        }
    }
}