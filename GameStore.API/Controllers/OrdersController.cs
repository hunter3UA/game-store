﻿using GameStore.API.Helpers;
using GameStore.API.Static;
using GameStore.BLL.DTO.Order;
using GameStore.BLL.Services.Abstract;
using GameStore.BLL.Services.Implementation;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using System.Threading.Tasks;

namespace GameStore.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService _orderService;
        private readonly ICustomerGenerator _customerGenerator;
        private readonly IPaymentContext _paymentContext;

        public OrdersController(IOrderService orderService,ICustomerGenerator customerGenerator,IPaymentContext paymentContext)
        {
            _orderService = orderService;
            _customerGenerator = customerGenerator;
            _paymentContext = paymentContext;

        }

        [HttpPost]
        [Route("/pay")]
        public async Task<IActionResult> PayAsync([FromBody] OrderPaymentDTO orderPayment)
        {       
            switch (orderPayment.PaymentType)
            {
                case 1:
                    _paymentContext.SetStrategy(new BankPayment());
                    object filePath = await _paymentContext.ExecutePay(orderPayment.OrderId);
                    return PhysicalFile(filePath.ToString(), Constants.TEXT_PLAIN_CONTENT_TYPE, Path.GetFileName(filePath.ToString()));
                case 2:
                    _paymentContext.SetStrategy(new IBoxPayment());
                    break;
                case 3:
                    _paymentContext.SetStrategy(new VisaPayment());
                    break;
            }
            return Ok();
        }

        [HttpGet]
        [Route("/order/{orderId}")]
        public async Task<IActionResult> MakeOrderAsync([FromRoute] int orderId)
        {
            var createdOrder = await _orderService.MakeOrderAsync(orderId);

            if (createdOrder == null)
            {
                return BadRequest();
            }

            return Ok(createdOrder);
        }

        [HttpDelete]
        [Route("/order/{orderId}")]
        public async Task<IActionResult> CancelOrderAsync([FromRoute] int orderId)
        {
            var canceledOrder = await _orderService.CancelOrderAsync(orderId);

            if (canceledOrder == false)
            {
                return BadRequest();
            }

            return Ok();
        }


        [HttpGet]
        [Route("/order")]
        public async Task<IActionResult> GetOrderAsync()
        {
            var customerId = _customerGenerator.GetCookies(HttpContext);
            var orderByCustomer = await _orderService.GetOrderAsync(customerId);

            if (orderByCustomer == null)
            {
                return NotFound();
            }

            return new JsonResult(orderByCustomer);
        }

    }
}
